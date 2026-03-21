namespace tutorial03;

public class Projector : Equipment
{
    public string Resolution { get; private set; }
    public bool HasHdmi { get; private set; }
    
    public Projector() : base()
    {
        Resolution = "Unknown resolution";
        HasHdmi = false;
    }

    public Projector(string name, bool isAvailable, string resolution, bool hasHdmi) : base(name, isAvailable)
    {
        Resolution = resolution;
        HasHdmi = hasHdmi;
    } 
}