namespace tutorial03;

public class App
{
    public static void Main(string[] args)
    {
        string command;
        bool running = true;
        UserRepository userRepository = new UserRepository();
        EquipmentRepository equipmentRepository = new EquipmentRepository();
        RentalRepository rentalRepository = new RentalRepository();
        UserService userService = new UserService(userRepository);
        EquipmentService equipmentService = new EquipmentService(equipmentRepository);
        RentalService rentalService = new RentalService(rentalRepository, equipmentService, userService);
        ReportService reportService = new ReportService(rentalService, equipmentService, userService);
        while (true)
        {
            Console.WriteLine(">>> Enter a command (type 'help' for a list of commands):");
            command = Console.ReadLine();
            switch (command)
            {
                case "help":
                    Console.WriteLine("Available commands:");
                    Console.WriteLine("* addUser - Add a new user");
                    Console.WriteLine("* addEquipment - Add a new equipment");
                    Console.WriteLine("* displayEquipment - Display all equipments together with their availability status");
                    Console.WriteLine("* displayAvailable - Display all equipments, which are currently available for rent");
                    Console.WriteLine("* rentEquipment - Rent an equipment");
                    Console.WriteLine("* returnEquipment - Return a rented equipment");
                    Console.WriteLine("* markUnavailable - Mark an equipment as unavailable");
                    Console.WriteLine("* userActive - Display all active rentals for a specific user");
                    Console.WriteLine("* overdue - Display all overdue rentals");
                    Console.WriteLine("* report - Generate a summary report of the rental system");
                    Console.WriteLine("* exit - Exit the application");
                    break;
                case "exit":
                    running = false;
                    break;
                case "addUser":
                    Console.WriteLine(">>> Enter first name:");
                    string firstName = Console.ReadLine();
                    Console.WriteLine(">>> Enter last name:");
                    string lastName = Console.ReadLine();
                    Console.WriteLine(">>> Enter user type (Student or Employee):");
                    string userType = Console.ReadLine();
                    userService.AddUser(firstName, lastName, userType);
                    break;
                case "addEquipment":
                    Console.WriteLine(">>> Enter equipment type (laptop, camera or projector):");
                    string equipmentType = Console.ReadLine();
                    Console.WriteLine(">>> Enter equipment name:");
                    string equipmentName = Console.ReadLine();
                    switch (equipmentType)
                    {
                        case "laptop":
                            Console.WriteLine("Enter the laptop's CPU model:");
                            string cpuModel = Console.ReadLine();
                            Console.WriteLine("Enter the laptop's RAM size (in GB):");
                            int ramSize = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the laptop's battery lifetime (in hours):");
                            int batteryLifetime = int.Parse(Console.ReadLine());
                            equipmentService.AddEquipment(new Laptop(equipmentName, cpuModel, ramSize, batteryLifetime));
                            break;
                        case "camera":
                            Console.WriteLine("Enter the amount of megapixels this camera has:");
                            int megapixels = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter, if this camera has a zoom lens (true/false):");
                            bool zoomLens = bool.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the type of lens this camera has:");
                            string lensType = Console.ReadLine();
                            equipmentService.AddEquipment(new Camera(equipmentName, megapixels, zoomLens, lensType));
                            break;
                        case "projector":
                            Console.WriteLine("Enter the projector's resolution:");
                            string resolution = Console.ReadLine();
                            Console.WriteLine("Enter, if the projector has the HDMI port (true/false):");
                            bool hasHdmiPort = bool.Parse(Console.ReadLine());
                            equipmentService.AddEquipment(new Projector(equipmentName, resolution, hasHdmiPort));
                            break;
                        default:
                            Console.WriteLine("Invalid type of the equipment!");
                            break;
                    }
                    break;
                case "displayEquipment":
                    Console.WriteLine("All equipments:");
                    foreach (var e in equipmentService.GetEquipments())
                    {
                        Console.WriteLine(e);    
                    }
                    break;
                case "displayAvailable":
                    Console.WriteLine("Available equipments:");
                    foreach (var e in equipmentService.GetAvailableEquipments())
                    {
                        Console.WriteLine(e);
                    }
                    break;
                case "rentEquipment":
                    Console.WriteLine("Enter the ID of the user who wants to rent an equipment:");
                    long userId = long.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the ID of the equipment to rent:");
                    long equipmentId = long.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the rental date (in format YYYY-MM-DD):");
                    DateTime rentalDate;
                    while (!DateTime.TryParse(Console.ReadLine(), out rentalDate))
                    {
                        Console.Error.WriteLine("Invalid date format. Try again (YYYY-MM-DD):");
                    }
                    DateTime dueDate;
                    Console.WriteLine("Enter the due date (in format YYYY-MM-DD):");
                    while (!DateTime.TryParse(Console.ReadLine(), out dueDate))
                    {
                        Console.Error.WriteLine("Invalid date format. Try again (YYYY-MM-DD):");
                    }
                    rentalService.RentEquipment(userId, equipmentId, rentalDate, dueDate);
                    break;
                case "markUnavailable":
                    Console.WriteLine("Enter the ID of the equipment to mark as unavailable:");
                    long equipmentIdToMark = long.Parse(Console.ReadLine());
                    equipmentService.GetEquipmentById(equipmentIdToMark).MakeUnavailable();
                    break;
                case "userActive":
                    Console.WriteLine("Enter the ID of the user:");
                    long userIdToCheck = long.Parse(Console.ReadLine());
                    List<Rental> rentals = rentalService.GetActiveRentalsByUserId(userIdToCheck);
                    foreach (Rental e in rentals)
                    {
                        Console.WriteLine(e);
                    }
                    break;
                case "overdue":
                    List<Rental> overdueRentals = rentalService.GetOverdueRentals();
                    foreach (Rental e in overdueRentals)
                    {
                        Console.WriteLine(e);
                    }
                    break;
                case "report":
                    string report = reportService.GenerateSummary();
                    Console.WriteLine(report);
                    break;
                case "returnEquipment":
                    Console.WriteLine("Enter the ID of the user who wants to return an equipment:");
                    long userIdToReturn = long.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the ID of the equipment to return:");
                    long equipmentIdToReturn = long.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the rental date (in format YYYY-MM-DD):");
                    DateTime rentalDateToReturn;
                    while (!DateTime.TryParse(Console.ReadLine(), out rentalDateToReturn))
                    {
                        Console.Error.WriteLine("Invalid date format. Try again (YYYY-MM-DD):");
                    }
                    Console.WriteLine("Enter the return date (in format YYYY-MM-DD):");
                    DateTime returnDate;
                    while (!DateTime.TryParse(Console.ReadLine(), out returnDate))
                    {
                        Console.Error.WriteLine("Invalid date format. Try again (YYYY-MM-DD):");
                    }
                    double rentalFee = rentalService.ReturnEquipment(userIdToReturn, equipmentIdToReturn, rentalDateToReturn, returnDate);
                    if (rentalFee >= 0)
                    {
                        Console.WriteLine("Equipment returned successfully. Rental fee: " + rentalFee);
                    }
                    break;
                default:
                    Console.WriteLine("Invalid command!");
                    break;
            }

            if (!running)
            {
                break;
            }
        }
    }
}