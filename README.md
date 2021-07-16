# powerplant-challenge
The project is developped with .NET Core 3.1
The solution is composed by tree components :
  - resources files
  - controllers
  - Models
  
  The services are implemented in startup.cs and the entry of the program is program.cs
  The configuration of the port 8888 is launchSettings.json 
  
  For testing I lunch postman(after launching app to listen to 8888 port) at http:://localhost:8888/api/productionplan/payload
  
 Processing :
 
 I get the tree resources json files and for each one I convert it into named object.
 In this way, I can process easily the power calculation . Note : I dind't understand how to set the merit order and sum the produced power of all powerplant.
  
