public class GroundData
{
    private float _groundStiffness;
    private GroundType _groundType;


    public GroundData(GroundType groundType)
    {
        _groundType = groundType;
        SetData();
    }

    private void SetData()
    {
        switch (_groundType)
        {
            case GroundType.Snow:
                _groundStiffness = -0.6F;
                break;
            case GroundType.Ice:
                _groundStiffness = -0.75F;
                break;
            case GroundType.Dirt:
                _groundStiffness = -0.2F;
                break;
            case GroundType.OldAsphalt:
                _groundStiffness = -0.3F;
                break;
            case GroundType.Sand:
                _groundStiffness = -0.4F;
                break;
            default:
                _groundStiffness = 0;
                break;
        }
    }

    public float GroundStiffness => _groundStiffness;
    public GroundType GroundType => _groundType;
}