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
    
    public Laptop(string name, bool isAvailable, string cpu, int ramGb, int batteryLifeHours) : base(name, isAvailable)
    {
        Cpu = cpu;
        RamGb = ramGb;
        BatteryLifeHours = batteryLifeHours;
    }
}