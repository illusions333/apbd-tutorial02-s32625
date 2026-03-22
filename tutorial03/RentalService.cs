namespace tutorial03;

public class RentalService
{
    private RentalRepository _rentalRepository;
    private EquipmentService _equipmentService;
    private UserService _userService;
    public RentalService(RentalRepository rentalRepository, EquipmentService equipmentService, UserService userService)
    {
        _rentalRepository = rentalRepository;
        _equipmentService = equipmentService;
        _userService = userService;
    }
    
    private void AddRental(long userId, long equipmentId, DateTime rentalDate, DateTime dueDate)
    {
        Rental rental = new Rental(userId, equipmentId, rentalDate, dueDate);
        _rentalRepository.AddRental(rental);
    }
    
    public void RemoveRental(long userId, long equipmentId, DateTime rentalDate)
    {
        _rentalRepository.RemoveRental(userId, equipmentId, rentalDate);
    }
    public List<Rental> GetActiveRentalsByUserId(long userId)
    {
        return _rentalRepository.GetActiveRentalsByUserId(userId);
    }
    
    public IReadOnlyList<Rental> GetAllRentals()
    {
        return _rentalRepository.GetAllRentals();
    }
    
    public void RentEquipment(long userId, long equipmentId, DateTime rentalDate, DateTime dueDate)
    {
        Equipment equipment = _equipmentService.GetEquipmentById(equipmentId);
        if (!equipment.IsAvailable)
        {
            Console.Error.WriteLine("Equipment " + equipment.Name + " is not available for rent.");
            return;
        }
        User user = _userService.GetUser(userId);
        List<Rental> activeRentals = GetActiveRentalsByUserId(userId);
        if (user.UserType == UserType.Student && activeRentals.Count >= 2)
        {
            Console.Error.WriteLine("User with ID " + userId + " cannot rent more than 2 equipments at the same time.");
            return;
        }

        if (user.UserType == UserType.Employee && activeRentals.Count >= 5)
        {
            Console.Error.WriteLine("User with ID " + userId + " cannot rent more than 5 equipments at the same time.");
            return;
        }

        AddRental(userId, equipmentId, rentalDate, dueDate);
        equipment.MakeUnavailable();
    }
    
    public double ReturnEquipment(long userId, long equipmentId, DateTime rentalDate, DateTime returnDate)
    {
        Rental rental = _rentalRepository.GetRental(userId, equipmentId, rentalDate);
        if (rental.ReturnDate != null)
        {
            Console.Error.WriteLine("Equipment has already been returned.");
            return -1;
        }
        if (returnDate.Date < rental.RentalDate.Date)
        {
            Console.Error.WriteLine("Return date cannot be before rental date.");
            return -1;
        }
        Equipment equipment = _equipmentService.GetEquipmentById(equipmentId);
        double rentalFee = FeeCalculator.CalculateFee(rental, returnDate);
        rental.Return(returnDate, rentalFee);
        equipment.MakeAvailable();
        return rentalFee;
    }
    
    public List<Rental> GetOverdueRentals()
    {
        return _rentalRepository.GetOverdueRentals();
    }
}