Hi There,

Things to note and general assumptions

1. Application was built using Visual Studio 2019 on .NET Core 2.2 (Net Core 2.2.5 Hosting Bundle should be installed to run)
2. Use of Dependency Injection, Unit tests (NUnit), AspNetCore SignalR and Observer Design Pattern
3. Static class was used to simulate database. Will have implemented an ORM e.g Entity Framework/Dapper in a main project.
4. Code didnt fully follow SOLID procedures due to console application limitations. The Idea of solid principles was however shown.  

A brief project description below;

## OddsServerWeb

Hosts the application web service and responsible for client and admin syncronisation.

## OddsAdmin

Simulation of Admin page on a console app for Add, Edit, Delete,and Publish Methods

## OddsClient

Simulation of Client/Plunker page for viewing real time odds.


## OddsServices

Class library for reusable code

## OddsTest

Class library for implementation of unit tests

## Program Test Instructions

1. Open project in Visual Studio 2019.
2. Set the OddsServerWeb as start up and run on IIS Express. Press **Ctrl + F5**
3. Run the client and admin console applications to use operations.
