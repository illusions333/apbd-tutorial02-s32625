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
        RentalDate = rentalDate.Date;
        if (dueDate.Date < rentalDate.Date)
            throw new ArgumentException("Due date cannot be before rental date.");
        DueDate = dueDate.Date;
        ReturnDate = null;
        RentalFee = 0.0;
    }

    public void Return(DateTime returnDate, double rentalFee)
    {
        if (ReturnDate != null)
        {
            Console.Error.WriteLine("Equipment has already been returned.");
            return;
        }

        if (returnDate.Date < RentalDate.Date)
        {
            Console.Error.WriteLine("Return date cannot be before rental date.");
            return;
        }
        ReturnDate = returnDate.Date;
        RentalFee = rentalFee;
    }

    public override string ToString()
    {
        return "Rental for user ID " + UserId + " and equipment ID " + EquipmentId + " from " + RentalDate.ToString("yyyy-MM-dd") +
               " to " + DueDate.ToString("yyyy-MM-dd") + (ReturnDate != null ? ", returned on " + ReturnDate.Value.ToString("yyyy-MM-dd") : ", not returned yet") +
               ", rental fee: " + RentalFee;
    }
}