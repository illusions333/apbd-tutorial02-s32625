namespace tutorial03;

public class Laptop : Equipment
{
    public string Cpu { get; private set; }
    public int RamGb { get; private set; }
    public int BatteryLifeHours { get; private set; }
    
    public Laptop() : base()
    {
        Cpu = "Unknown CPU";
        RamGb = 0;
        BatteryLifeHours = 0;
    }
    
    public Laptop(string name, string cpu, int ramGb, int batteryLifeHours) : base(name)
    {
        Cpu = cpu;
        RamGb = ramGb;
        BatteryLifeHours = batteryLifeHours;
    }

    public override string ToString()
    {
        return "Laptop #" + Id + "(Name: " + Name + ", CPU: " + Cpu + ", RAM: " + RamGb + " GB, battery life: " + BatteryLifeHours + " hours, available: " + IsAvailable + ")";
    }
}