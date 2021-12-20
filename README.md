# actor-locator-api
**Problem -**
API to locate the actors in the game, its a part of Multi-player Game
The goal is to build an API to locate the actors in the game, All actors are tagged to the Landmarks.
the purpose of the API is to provide routes between landmarks to suggest routes to the actors
In order to achieve this, the game engine should be able to calculate
  •	The distance along certain routes via landmarks
  •	The number of different routes between landmarks
  
The input to the program should consist of set of data represented by Starting Landmark, Ending Landmark and directed distance. A given route should not appear more than once. The starting and ending landmark cannot be the same for a given route. For input data you can use a formatted input so for e.g. A route from A to B landmarks with a distance of 3Km will be represented as AB3. For queries where no path exists between 2 landmarks, output should be. returned as “Path not found".
 
This Program should be able to answer following question -
 
1.	The distance between landmarks via the route A-B-C ----> Expected Output - 12
2.	The distance between landmarks via the route A-E-B-C-D ----> Expected Output - 17
3.	The distance between landmarks via the route A-E-D ----> Expected Output - Path not found
4.	The number of routes starting at A and ending at C with a maximum of 2 stops  ----> Expected Output - 2
 
Sample input to test with 
  AB3, BC9, CD3, DE6, AD4, DA5, CE2, AE4,EB1
 
Image View

![image](https://user-images.githubusercontent.com/10783656/146644318-fe3a0e60-5191-4cb6-abf9-5858d0976aa6.png)

**Technologies Used**
1. ASP.NET Core 5
2. MediatR
3. Swagger UI
4. xUnit
5. FluentAssertions
6. And Clean Architecture pattern used in solution design

**Prerequisites to build this solution locally**
1. .Net5 sdk - https://dotnet.microsoft.com/en-us/download/dotnet/5.0
2. Visual Studio 2019

Solution deployd on aws (using EBS) - http://locatorapi.ap-south-1.elasticbeanstalk.com/swagger/index.html
![image](https://user-images.githubusercontent.com/10783656/146644939-825f4b06-15d9-4aa6-9f60-1bc560fdd453.png)
![image](https://user-images.githubusercontent.com/10783656/146644957-8100d5ba-dcdd-4242-9dc9-679c24b152f3.png)


![image](https://user-images.githubusercontent.com/10783656/146644979-eeed3cd2-2d98-4244-bd2e-bf40822f7348.png)
![image](https://user-images.githubusercontent.com/10783656/146644999-21a77c19-1f46-43ca-b6aa-1538590945e7.png)
