namespace tutorial03;

public class Rental
{
    public long UserId { get; private set; }
    public long EquipmentId { get; private set; }
    public DateTime RentalDate { get; private set; }
    public DateTime DueDate { get; private set; }
    public DateTime? ReturnDate { get; private set; }
    public double RentalFee { get; private set; }

    public Rental(long userId, long equipmentId, DateTime rentalDate, DateTime dueDate)
    {
        UserId = userId;
        EquipmentId = equipmentId;
        RentalDate = rentalDate;
        if (DueDate < RentalDate)
            throw new ArgumentException("Due date cannot be before rental date.");
        DueDate = dueDate;
        ReturnDate = null;
        RentalFee = 0.0;
    }
    
    public void Return(DateTime returnDate, double rentalFee)
    {
        if (ReturnDate != null)
            throw new InvalidOperationException("Equipment has already been returned.");
        if (returnDate < RentalDate)
            throw new ArgumentException("Return date cannot be before rental date.");
        ReturnDate = returnDate;
        RentalFee = rentalFee;
    }
}