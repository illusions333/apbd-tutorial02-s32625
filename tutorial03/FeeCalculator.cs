namespace tutorial03;

public class FeeCalculator
{
    private static double _baseFee = 10.0;
    private static double _dailyPenalty = 2.0;
    public static double CalculateFee(Rental rental, DateTime returnDate)
    {
        double rentalFee = _baseFee;
        if (returnDate.Date > rental.DueDate.Date)
        {
            int lateDays = (int) Math.Ceiling((returnDate - rental.DueDate).TotalDays);
            rentalFee += lateDays * _dailyPenalty;
        }
        return rentalFee;
    }
}