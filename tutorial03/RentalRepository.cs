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

    public Rental GetRental(long rentalId)
    {
        foreach (var rental in _rentals)
        {
            if (rental.UserId == rentalId) return rental;
        }
        throw new KeyNotFoundException("Rental with ID " + rentalId + " not found.");
    }
    public List<Rental> GetAllRentals()
    {
        return _rentals;
    }
    public void RemoveRental(long rentalId)
    {
        Rental? rentalToRemove = null;
        foreach (var rental in _rentals)
        {
            if (rental.UserId == rentalId)
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
            throw new KeyNotFoundException("Rental with ID " + rentalId + " not found.");
        }
    }
}