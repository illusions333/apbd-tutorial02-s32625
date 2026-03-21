namespace tutorial03;

public class User
{
    private static long _lastId = 0;
    public long Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public UserType UserType { get; private set; }
    public User(string firstName, string lastName, string userType)
    {
        if (string.IsNullOrEmpty(firstName))
            throw new ArgumentException("First name cannot be empty", nameof(firstName));
        if (string.IsNullOrEmpty(lastName))
            throw new ArgumentException("Last name cannot be empty", nameof(lastName));
        if (userType == null)
            throw new ArgumentNullException(nameof(userType));
        string normalized = userType.ToLower();
        if (normalized != "student" && normalized != "employee")
        {
            throw new ArgumentException("Invalid user type. User type must be either 'student' or 'employee' (in any case).");
        }
        _lastId++;
        Id = _lastId;
        FirstName = firstName;
        LastName = lastName;
        UserType = normalized == "student" ? UserType.Student : UserType.Employee;
    }
}