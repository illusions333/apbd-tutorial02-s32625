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

    protected Equipment(string name)
    {
        _lastId++;
        Id = _lastId;
        Name = name;
        IsAvailable = true;
    }
    
    public void MakeAvailable()
    {
        if (IsAvailable)
        {
            throw new Exception("Equipment " + Name + " with id #" + Id +  " is already available.");
        }
        IsAvailable = true;
    }
    
    public void MakeUnavailable()
    {
        if (!IsAvailable)
        {
            throw new InvalidOperationException("Equipment " + Name + " with id #" + Id +  " is already unavailable.");
        }
        IsAvailable = false;
    }
}