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

    public Projector(string name, string resolution, bool hasHdmi) : base(name)
    {
        Resolution = resolution;
        HasHdmi = hasHdmi;
    } 
    
    public override string ToString()
    {
        return "Projector #" + Id + "(Name: " + Name + ", resolution: " + Resolution + ", has HDMI: " + HasHdmi + ", available: " + IsAvailable + ")";
    }
}