# RestfulAPI_Data_Processing
## Caner Celik (4594738)

### How it works

First of all, this is a very complex project i created, therefore, I will try to explain the logic. The database.sql file is the data that will be in the database, which is utilized through the project RestfulAPI, this project acts as a remote desktop, which in hindsight is a creation of my own API. When RestfulAPI is running, the data that is in the database gets used through an Entity Framework in HDIDataAccess, this data is then validated in JsonValidator and JsonXmlValidator. Once the data is validated it gets called onto the ClientApplication, thus, in this case is onto 3 html pages, HDIPage.html, SuicideRatesPage.html, and YouthRatesPage.html. Each page has different data according to the data in the database, in addition, each page also has its own individual charts as requested for visualization. 

#### Note: For the data to work and be displayed on the pages, your desktop or laptop need to be configured to the right specifications, these specifications will be explained in Setup.

### Requirements

* Microsoft SQL Server Management Studio 18 (MSSQL)
* C# IDE (In this project I used Jetbrains Rider)
* SQL Server 2019 Configuration Manager
* Preferred Windows 10 (Tested on)

### Setup

Here i will explain how to set up your environment correctly, so that the data is displayed on your computer, and that my assignment works.

#### Import Database

To import the database, execute my database.sql file in Microsoft SQL Management Studio. Click on New Query and paste the contents inside, then replace the **FILENAME** to your server name and press execute. Or double click the database.sql file and it should already make the query, replace the **FILENAME** to your server name, and then just press execute. When it shows success, the API is ready to utlize the database data.

#### Connection String

In my project, under HDIDataAccess, there is a file called App.config, please replace the data source to your server and instance name, replace the catalog which is the database name, replace the user id to your user role in mssql, and password as well. To test if it works, start the API and if you get a connection error, it means it is incorrect. If the problem persists, it means your computer can not be used as its own remote server, therefore, open your SQL Server 2019 configuration manager and check if Shared Memory, Named Pipes, and TCP/IP are all enabled under the server name you are using for the connection string.

![ConfigManager](https://i.imgur.com/bZniVs4.png)

Also check under SQL Server services that everything is running and not stopped.

If the problem is still there with the issue of the connection string, follow this guide.

https://docs.microsoft.com/en-us/sql/sql-server/install/configure-the-windows-firewall-to-allow-sql-server-access?view=sql-server-ver16

#### Starting the API

To start the API, in my case, I pick RestfulAPI and run it. Below in the image is what it should look like to run it.

![RestfulAPI Execution](https://i.imgur.com/kBsSY9T.png)

It will open a Home Page, when the home page is open on the top left it has a tab called API Structure, if you click this it will show every API call that can be made using my created API. Some even have sample structures for testing purposes. If for any reason there are errors see below.

If you get some API structure errors check the bottom right icon called ISS Express, it creates two TCP/IP ports, this can be found on the bottom right as an icon when you right click it. When you see both ports, it means everything should be working.

![RestfulAPI 2 Ports](https://i.imgur.com/C7UfXap.png)

On each page you will first see working charts provided by Chart.js, then if you scroll to the bottom you will see the data in the tables of each page. All three front end pages has CRUD operations, all data should load. All endpoints were tested through Postman. Json was validated through https://www.jsonschemavalidator.net/ and XML was validated through https://www.xmlvalidation.com/, 

#### Postman

![Postman1](https://i.imgur.com/BS3kZNw.png)

![Postman2](https://i.imgur.com/Fc5g18w.png)

![Postman3](https://i.imgur.com/6wdtJze.png)

![Post](https://i.imgur.com/0Eevkfu.png)


***PS: If you get an error popup when opening the webpage in relation to entity framework connection, then please follow the Connection String guide above and fix it.***

Caner Celik (4594738)



