INSTRUCTION MANUAL FOR PAAS (POSTGRADUATE APPLICATION APPROVAL SYSTEM):


1) Software Requirements:

Download and install the following:

-Google Chrome OR Mozilla Firefox web browser: This is a web application and so a web browser is required. Both are free and choosing one is a matter of personal preference. Google Chrome can be downloaded from the webpage: https://www.google.com/chrome/browser/desktop/index.html
Mozilla Firefox can be downloaded from the webpage: https://www.mozilla.org/en-US/firefox/new/

-Microsoft Visual Studio: Preferably MVS 2017. A free copy can be downloaded from the webpage: https://www.visualstudio.com/downloads/

-Microsoft SQL Server 2014: A copy can be downloaded from the webpage: https://www.microsoft.com/en-za/download/details.aspx?id=42299

2) Instructions on application use:
-Run visual studio as administrator. 

-In visual studio, go to file->open->project/solution. Find the desired solution file (paas.sln) located in the PAAS folder.

-Next, go to Build->Build Solution and wait for the solution to complete its build process. 

-After the solution has finished building, you can run the application by pressing "ctrl-F5". This runs the web app without executing the debug process. The application should start up in your default browser window.

3) Possible Issues:

Once the solution is opened in visual studio, if you cannot connect to the server, do the following:

-On the left hand side in the dock menu, go to "Server Explorer". To check whether the server is connected, expand the "Data Connections" tab. The object "PAASContext(PAAS)" should have a small green icon if connected. If not, a red cross is displayed.

-To connect, go to Tools->NuGet Package Manager->Package Manager Console. The console is started in the bottom window. In the console type the following instructions in succession:
1) Install-Package Dapper -Version 1.50.2
2) Install-Package EntityFramework

-Go back to the server explorer and right click on PAASContext(PAAS) and go to modify connection. The data source should be "Microsoft SQL Server (SqlClient)". The server name should be "(LocalDb)\MSSQLLocalDB". The database name should be "PAAS". Test the connection and it should be successful. Click OK. You are now connected to the server.

The following is required for making model changes and may be necessary to access and view the data:
Go to Tools->NuGet Package Manager->Package Manager Console. The console is started in the bottom window. In the console type the following instructions in succession:
1) Enable-Migrations
2) Add-Migration Initial -Force
3) Update-Database
