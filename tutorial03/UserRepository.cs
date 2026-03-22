namespace tutorial03;

public class UserRepository
{
    List<User> _users;

    public UserRepository()
    {
        _users = new List<User>();
    }
    
    public void AddUser(User user)
    {
        _users.Add(user);
    }
    
    public void RemoveUser(long userId)
    {
        User? userToRemove = null;
        foreach (var user in _users)
        {
            if (user.Id == userId)
            {
                userToRemove = user;
                break;
            }
        }
        if (userToRemove != null)
        {
            _users.Remove(userToRemove);
        }
        else
        {
            Console.Error.WriteLine("User with ID " + userId + " not found.");
        }
    }
    
    public IReadOnlyList<User> GetAllUsers()
    {
        return _users.AsReadOnly();
    }
    
    public User GetUser(long userId)
    {
        foreach (var user in _users)
        {
            if (user.Id == userId) return user;
        }
        throw new KeyNotFoundException("User with ID " + userId + " not found.");
    }
}