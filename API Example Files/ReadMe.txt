Project Notes:
1. This project contains both the application and a unit test solution with associated files. These solutions each contain
   their own nuget packages and specific classes pertinent to the solution specific functionality. The original intent
   of this project was to build an interactive web application that can print labels to two thermal printers in 
   production (ZT410, GK420t) from any computer that can access the web address with a user who has permissions.
   This is accomplished by printing from the web server so that only the web server needs the thermal printer drivers
   installed. This also helps reduce maintinence and provides for easier access by employees.
   The original scope was 18 different labels and potentialy a few reports.
2. This project was reduced to just three labels by Bradley Herbst due to lack of use of other existing labels by employees.

Project Patterns:
1. Services - used to get or perform server actions and connect to data.
2. Templates - Label templates are XML files that hold the necessary information for formating, sizing and printing.
   The do not hold the label data, but do contain the SQL statements needed to pull the data.
3. Models - Classes used to contain the data from the SQL server, Template XML Files, Configurations, Selected Data from UI, Etc.
4. Factories - Classes that perform work in producing new labels, label templates, etc.
5. Exceptions - Application specific exceptions that provide more specific information on possible errors.
6. Brokers - Classes that interact with third party software and extracts out logic involved in operations
   (E.g. LoggingBroker connects to the Microsoft extensions logger).
7. Controllers - Service end point classes that are responsible for the API data architecture and resources.

Nuget Packages (AmetekLabelAPI):
1. Dapper (SQL Server Micro-ORM)
2. System.Drawing.Common (Used for printing to a print driver)

Nuget Packages (AmetekLabelAPI.Tests):
1. MOQ (Moqing framework/code impersonator)
2. Tynamix (Object filler)
3. xunit (Testing Framework)
4. bunit (Blazor Testing library)
5. FluentAssertions (Extensions for more natural reading of unit tests)

Architecture:
1. Services push/pull data from sources.
2. Brokers handle communication with third party software.
3. Models hold necessary data coming from and going to the API endpoints.
4. Configurations provide application configuration information for the proper operation of the application.
5. Factories perform specific API work necessary for the creation of new resources such as label templates.
6. Controlers connect HTTP endpoints to the resources within the API.
Note - example interaction: UI requests list of templates. This request hist the FileOperations controller's "GET" endpoint. 
                            The file operations controler accesses the FileService "GetAllTemplateFilePathsAndNames" method
                            passing in the correct directory from the configurations. This method then validates the path and
                            captures a list of all files with the ".tmplt" file extension. It then returns this list to the 
                            calling "FileOperationsController". This end point then returns the list of file names and paths
                            to the calling UI via HTML and Json.