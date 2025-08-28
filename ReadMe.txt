Overview : 
ASP .NET Web Application showcasing a functioning online site for organizing Brazilian Jiu-Jitsu events in Europe.

Features:
- Users that have created and logged in to their accounts can pin events for later viewing , create Open Mat and Seminar events and make a profile.
- Users that are logged in and have created a profile can mark events as "attending" . There is also a separate page to view all Events marked that way.
- Users who are not logged in can still browse events and view their extended info on the Event Details page.
- Search functionality for events is included with text search and country filters.
- 3 Different Event Types : Open Mat , Seminar , Tournament.
- Sponsors page to display images and links associated with site sponsors. (Not real sponsors , only for showcasing functionality)
- The user with admin privileges can add, edit and delete Tournament events.

Prerequisites for running the project locally:
- Visual Studio with .NET version 8.0
- MS SQL Server Management Studio or an alternative program for using a SQL database

Running the app after installation :
- After pulling the project from GitHub, if you wish to create a local database instead of using the Azure database, go to the appsettings.Development.json file in the EuropeBJJ project folder and edit the SqlServer connection string to something like this "Server=DESKTOP-...;Database=EuropeBJJDb;Trusted_Connection=True;TrustServerCertificate=True;" and make sure you are connected to your local SQL instance . After that in the Program.cs file edit this line : "var connectionString = builder.Configuration.GetConnectionString("AzureConnection") ?? throw new InvalidOperationException("Connection string not found.");" to replace "AzureConnection" to "SqlServer". Open the Package Manager Console and write "add-migration Initial".
When creating migrations for connecting tables (EventsAccounts,EventsProfiles , etc.), 'onDelete: ReferentialAction.Cascade' needs to be changed to 'onDelete: ReferentialAction.NoAction' manually. After that open the Package Manager Console again and write
"update-database". After that you should have a working web app with an empty database . If you wish to fill the database with data , you can do it manually through SQL or register as yovo352@gmail.com and have admin privileges (you can change the admin e-mail by editing
this line in Program.cs :"string email = "admin@gmail.com";"). You might get an error related to user roles when launching the app for the 1st time , just launch it again and it should work.

Notes for the Azure Live Demo:
- Link : europebjj.azurewebsites.net
- If you get an error when clicking the azure link, try opening the link again in 10-15 minutes, since the database is on a serverless plan and has periodic pauses.
