namespace tutorial03;

public abstract class Equipment
{
    private static long _lastId = 0;
    public long Id { get; private set; }
    public string Name { get; private set; }
    public bool IsAvailable { get; private set; }

    protected Equipment()
    {
        _lastId++;
        Id = _lastId;
        Name = "Unknown name";
        IsAvailable = true;
    }

    protected Equipment(string name, bool isAvailable)
    {
        _lastId++;
        Id = _lastId;
        Name = name;
        IsAvailable = isAvailable;
    }
    
    public string MakeAvailable()
    {
        if (IsAvailable)
        {
            return "Equipment " + Name + " with id #" + Id +  " is already available.";
        }
        IsAvailable = true;
        return "Equipment " + Name + " with id #" + Id + " is made available.";
    }
    
    public string MakeUnavailable(string reason)
    {
        if (string.IsNullOrEmpty(reason))
        {
            return "Reason for making equipment " + Name + " with id #" + Id + " unavailable cannot be empty.";
        }
        if (!IsAvailable)
        {
            return "Equipment " + Name + " with id #" + Id +  " is already unavailable.";
        }
        IsAvailable = false;
        return "Equipment " + Name + " with id #" + Id + " is made unavailable due to " + reason + ".";
    }
}