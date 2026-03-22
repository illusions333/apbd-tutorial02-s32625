namespace tutorial03;

public class ReportService
{
    private RentalService _rentalService;
    private EquipmentService _equipmentService;
    private UserService _userService;

    public ReportService(RentalService rentalService, EquipmentService equipmentService, UserService userService)
    {
        _rentalService = rentalService;
        _equipmentService = equipmentService;
        _userService = userService;
    }
    
    public string GenerateSummary()
    {
        string report = "------ Rental Summary Report ------\n";
        report += "Total Users: " + _userService.GetUsers().Count + "\n\n";
        report += "Total Equipments: " + _equipmentService.GetEquipments().Count + "\n";
        report += "Available Equipments: " + _equipmentService.GetAvailableEquipments().Count + "\n\n";
        report += "Total Rentals: " + _rentalService.GetAllRentals().Count + "\n";
        report += "Active Rentals: " + _rentalService.GetAllRentals().Count(r => r.ReturnDate == null) + "\n";
        report += "Overdue Rentals: " + _rentalService.GetOverdueRentals().Count + "\n";
        return report;
    }
}