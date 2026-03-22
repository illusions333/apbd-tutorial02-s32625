# University Equipment Rental – Console App (C#)



A console application that manages a small university equipment rental service.





## Features



The application implements the next requirements:



- Add new users (e.g. Student, Employee) with identifiers, names, and user type.

- Add new equipment of different types (e.g. Laptop, Projector, Camera) with shared and type-specific fields.

- Display all equipment with current status (available / unavailable).

- Display only equipment currently available for rental.

- Rent equipment to a user with validation of:

    - User rental limits (Students: max 2 active rentals; Employees: max 5 active rentals).

    - Equipment availability and “unavailable” state (e.g. damaged, maintenance).

- Return equipment and calculate a late penalty when the due date is exceeded.

- Mark equipment as unavailable.

- Display active rentals for a selected user.

- Display list of overdue rentals.

- Generate a short summary report of the rental service state.





## Class hierarchy

- 'Equipment': base class, common id, name, availability status.

- 'Laptop', 'Projector', 'Camera': inherit from the Equipment, add at least two type-specific properties (e.g. RAM / CPU, hasHDMI / resolution, megapixels / lens type).

- 'User': id, first name, last name, user type (defined with Enum UserType). Inheritance here does not make sense, as the student and the employee have the same logic.

- 'Rental': stores all the information about rentals - all the dates, equipment, and the user of the system who rented the equipment.

- 'RentalRepository', 'UserRepository', 'EquipmentRepository': repositories for storing and working with multiple instances of the named classes.

- 'RentalService', 'UserService', 'EquipmentService', 'ReportService': classes, where the main logic is implemented. Different services working together allow us to successfully implement every feature.

- 'App': main class, which is responsible for I/O operations.

Division like this allows us to separate entity classes, data access, main logic and I/O operations, which keeps code easier to read, modify and test.


## Demonstration
You can run the console application and use the interactive menu to try all operations yourself, from adding data to performing rentals and viewing reports. 

