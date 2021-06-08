using UnityEngine;

public class ChangeQuality : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string[] names = QualitySettings.names;
        string s = "";
        foreach (var n in names)
        {
            s += n + ", ";
        }

        Debug.Log("Hepsi:" + s + " - Current:" + QualitySettings.GetQualityLevel());
    }

    // Update is called once per frame
    void Update()
    {
    }
}