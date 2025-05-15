Agri-Energy COnnect Platform 
System Overview 
Agri-Energy is a farm management system that connects farmers with agricultural employees, enabling:
•	Farmers to record and manage their products.
•	Employees to monitor all farm products and manage farmer accounts.
•	Secure authentication for both user types.
•	Real-time data tracking and reporting. 
Technology Stack
•	Backend: ASP.NET Core MVC 
•	Database: SQLite (development), SQL Server (production)
•	Frontend: HTML5, CSS3, Bootstrap 5
•	Authentication: Session-based 
Development Environment Setup 
Prerequisites 
1.	Hardware Requirements
•	Windows/macOS/Linux machine 
•	Minimum 4GB RAM (8GB recommended)
2.	Software Requirements
•	.NET 6.0 SDK 
•	Visual Studio 2022 (Community Edition is free) or VS Code 
•	Git 
Installation Steps 
1.	Clone the repository 
2.	Database Setup 
The system uses SQLite by default (no installation required). For production:
•	Install SQL Server Express 
•	Update connection in ‘appsettings.json’. 
3.	Restore Dependencies 
4.	Initialize Database 
Run this command to create and seed the database: 
‘dotnet ef database update’
Building and Running the Application 
Development Mode 
1.	Using Visual Studio 
•	Open ‘AgriEnergy.sln’. 
•	Press F5 or click ‘Start Debugging’.
2.	Using command line: ‘dotnet run’.
Production Build 
1.	Create publish package: ‘dotnet publish -c Release -o ./publish’
2.	Deploy the publish folder to your hosting environment.
Default Accounts 
•	Employee:
-	Username: Admin
-	Password: admin
•	Farmer: 
-	Username: John
-	Password: 1234
System Functionalities 
Farmer: 
•	Production Management: Add, view, and manage agricultural products.
•	Dashboard: View all personal products in a centralized location.
•	Secure Login: Protected access to personal data.
Employee: 
•	Farmer Management: Register and manage farmer accounts.
•	Product Monitoring: View all products across all farms.
•	Reporting: Filter products by category, date, or farmer. 
User Roles and Permissions
Farmer Permissions:
•	Add/edit own products
•	View personal listings 
•	Update profile information 
Farmer Restrictions:
•	Cannot view other farmer’ data 
•	Cannot create new user accounts 
Employee Permissions: 
•	Create and manage farmer accounts 
•	View all system products
•	Generate system reports 
•	Filter and analyse product data
Employee Restrictions:
•	Cannot modify product information
•	Cannot delete farmer accounts
