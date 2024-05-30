# Hotel Booking Web Application



This project is a hotel booking web application developed as part of an assessment for a Full Stack Developer position. The primary objective of this assignment was to demonstrate proficiency in database design, backend development using .NET, and frontend development with HTML, CSS, Bootstrap, JavaScript, and jQuery. The application consists of a booking database, APIs for booking logic, and a web interface to interact with the API and display booking data.

## Features

1. **Booking Database (SQL Server)**
   - Designed to store booking information, customer details, and room details.

2. **APIs (ASP.NET Core MVC)**
   - Handle the logic of the booking process including creating new bookings, retrieving booking lists, and displaying booking details.

3. **Web Application (ASP.NET Core MVC)**
   - User interface for interacting with the booking system. It includes pages for creating new bookings, viewing booking lists, and booking details.

## Project Structure

- **Database Design**
  - Entity-Relationship Diagram (ERD) illustrating the database schema.
  - SQL scripts for creating the database and tables.

- **Backend**
  - API controllers for handling booking operations.
  - Services for business logic implementation.

- **Frontend**
  - HTML, CSS, and Bootstrap for structuring and styling the web pages.
  - JavaScript and jQuery for client-side interactivity.

## Installation

### Prerequisites

- .NET Core SDK
- SQL Server
- Visual Studio or any C# compatible IDE
- Git

### Setup

1. **Clone the Repository**
   ```bash
   git clone <repository-url>
   cd <repository-directory>

2. **Setup Database**

- Execute the provided SQL scripts to create the database and tables.
- Update the connection string in appsettings.json with your SQL Server details.


3. **Run the Application**

- Open the solution in Visual Studio.
- Restore NuGet packages.
- Build and run the application.

### Usage

1. Create Booking

- Navigate to the "Create Booking" page.
- Fill in the customer details, booking dates, and room information.
- Submit the form to create a new booking.

2. View Booking List

- Navigate to the "Booking List" page.
- View all existing bookings with basic details.

3. Booking Details

- Click on a booking from the list to view detailed information about the booking.
## Considerations

- The booking form includes fields for customer name, national ID, phone number, hotel branch, check-in date, check-out date, and number of rooms.
- Multiple rooms can be booked under one booking.
- Room details include type (single, double, suite), number of adults, and number of children.
- A discount of 5% is applied if the customer has booked previously.
Contact

For any questions or feedback, please contact:

Email: atefrehan111@gmail.com


Thank you for using the Hotel Booking Web Application! We hope it meets your needs for managing hotel bookings efficiently.