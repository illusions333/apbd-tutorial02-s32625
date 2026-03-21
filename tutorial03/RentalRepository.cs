namespace tutorial03;

public class RentalRepository
{
    private List<Rental> _rentals;
    
    public RentalRepository()
    {
        _rentals = new List<Rental>();
    }
    
    public void AddRental(Rental rental)
    {
        _rentals.Add(rental);
    }
    
    public Rental GetRental(long userId, long equipmentId, DateTime rentalDate)
    {
        foreach (var rental in _rentals)
        {
            if (rental.UserId == userId && rental.EquipmentId == equipmentId &&
                rental.RentalDate == rentalDate) return rental;
        }
        throw new KeyNotFoundException("Rental was not found.");
    }
    public List<Rental> GetAllRentals()
    {
        return _rentals;
    }
    public void RemoveRental(long userId, long equipmentId, DateTime rentalDate)
    {
        Rental? rentalToRemove = null;
        foreach (var rental in _rentals)
        {
            if (rental.UserId == userId && rental.EquipmentId == equipmentId &&
                rental.RentalDate == rentalDate)
            {
                rentalToRemove = rental;
                break;
            }
        }
        if (rentalToRemove != null)
        {
            _rentals.Remove(rentalToRemove);
        }
        else
        {
            throw new KeyNotFoundException("Rental was not found.");
        }
    }
    public List<Rental> GetActiveRentalsByUserId(long userId)
    {
        List<Rental> result = new List<Rental>();
        foreach (var rental in _rentals)
        {
            if (rental.UserId == userId && rental.ReturnDate == null)
            {
                result.Add(rental);
            }
        }
        return result;
    }
}