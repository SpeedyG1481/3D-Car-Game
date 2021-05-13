using System.Collections.Generic;
using UnityEngine;

namespace VehicleBehaviour.Trails
{
    public class Trail
    {
        private float width;
        private float decay;
        private Material m;
        private int _rough;
        private int maxRough;
        private bool softSource;

        private Transform par;

        private GameObject trail;
        private MeshFilter filter;
        private MeshRenderer render;
        private Mesh mesh;


        private LinkedList<Vector3> verts = new LinkedList<Vector3>();
        private LinkedList<Vector2> uvs = new LinkedList<Vector2>();
        private LinkedList<int> tris = new LinkedList<int>();
        private LinkedList<Color> cols = new LinkedList<Color>();

        private bool _finished = false;
        private bool _dead = false;

        private Vector3 _previousPosition;
        private Vector3 currentPosition;
        public float MinimumSegmentLength = 0.1f;
        public Vector3 PositionOffset;

        public bool Dead
        {
            get => _dead;
            private set
            {
                _dead = true;
                GameObject.Destroy(trail);
            }
        }

        public Trail(Transform parent, Material material, float decayTime, int roughness, bool softSourceEdges,
            Vector3 off, float wid = 0.1f)
        {
            softSource = softSourceEdges;
            maxRough = roughness;
            _rough = 0;
            decay = decayTime;
            par = parent;
            width = wid;
            m = material;
            trail = new GameObject("Trail");
            filter = trail.AddComponent(typeof(MeshFilter)) as MeshFilter;
            render = trail.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
            mesh = new Mesh();
            render.material = m;
            filter.mesh = mesh;
            PositionOffset = off;
        }

        public void Finish()
        {
            _finished = true;
        }

        public bool Finished => _finished;

        public void Update()
        {
            if (!_finished)
            {
                if (_rough > 0)
                    _rough--;
                else
                {
                    _rough = maxRough;

                    var currentPosition = par.transform.position + PositionOffset;
                    if (Vector3.Distance(_previousPosition, currentPosition) > MinimumSegmentLength)
                    {
                        _previousPosition = currentPosition;

                        var offset = par.right * width / 2f;
                        verts.AddLast(currentPosition - offset);
                        verts.AddLast(currentPosition + offset);

                        if (softSource)
                        {
                            if (cols.Count >= 4)
                            {
                                cols.Last.Value = Color.white;
                                cols.Last.Previous.Value = Color.white;
                            }

                            cols.AddLast(Color.clear);
                            cols.AddLast(Color.clear);
                        }
                        else
                        {
                            if (cols.Count >= 2)
                            {
                                cols.AddLast(Color.white);
                                cols.AddLast(Color.white);
                            }
                            else
                            {
                                cols.AddLast(Color.clear);
                                cols.AddLast(Color.clear);
                            }
                        }

                        uvs.AddLast(new Vector2(0, 1));
                        uvs.AddLast(new Vector2(1, 1));


                        if (verts.Count < 4)
                            return;


                        var c = verts.Count;
                        tris.AddLast(c - 1);
                        tris.AddLast(c - 2);
                        tris.AddLast(c - 3);
                        tris.AddLast(c - 3);
                        tris.AddLast(c - 2);
                        tris.AddLast(c - 4);

                        var v = new Vector3[c];
                        var uv = new Vector2[c];
                        var t = new int[tris.Count];
                        verts.CopyTo(v, 0);
                        uvs.CopyTo(uv, 0);
                        tris.CopyTo(t, 0);

                        mesh.vertices = v;
                        mesh.triangles = t;
                        mesh.uv = uv;
                    }
                }
            }

            var i = cols.Count;

            if (i == 0)
                return;

            var alive = false;

            var d = cols.First;
            do
            {
                if (d.Value.a > 0)
                {
                    var t = d.Value;
                    alive = true;
                    t.a -= Mathf.Min(Time.deltaTime / decay, t.a);
                    d.Value = t;
                }

                d = d.Next;
            } while (d != null);

            if (!alive && _finished)
                Dead = true;
            else
            {
                if (i != mesh.vertices.Length)
                    return;
                var cs = new Color[i];
                cols.CopyTo(cs, 0);
                mesh.colors = cs;
            }
        }
    }
}