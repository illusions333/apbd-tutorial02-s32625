namespace tutorial03;

public class UserService
{
    private UserRepository _userRepository;

    public UserService(UserRepository users)
    {
        _userRepository = users;
    }
    
    public void AddUser(string firstName, string lastName, string userType)
    {
        User user = new User(firstName, lastName, userType);
        _userRepository.AddUser(user);
    }
    
    public void RemoveUser(long userId)
    {
        _userRepository.RemoveUser(userId);
    }

    public User GetUser(long userId)
    {
        return _userRepository.GetUser(userId);
    }

    public IReadOnlyList<User> GetUsers()
    {
        return _userRepository.GetAllUsers();
    }
}