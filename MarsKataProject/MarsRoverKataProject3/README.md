# MarsRoverKataProject3


This code implements the NUnit test function.

To activate it:

* The reference to Microsoft.NET.Test.Sdk in MarsRoverKataProject3.csproj is commented out. Uncomment it OR
* Install Microsoft.NET.Test.Sdk with VS Package Manager THEN
* In Programs.cs comment out Main() method
* Rebuild


1.  Create a UML class diagram:

            MarsRoverKataUML.drawio

            There are two abstract interface classes:

            ExtraPlanetaryVehicle - which implements the common features of any extra-planetary exploration vehicle. 
            The class contains all the methods to control the movements of the vehicle

            MartianPlateau - which implements the common features of any rectangular Martian plateau.
            This class also implements an occupation map which records the location of multiple concurrently active vehicles.
            This map is commonly accessible by these vehicles.

            Using these two classes, objects can be created and further customised to reflect
            the different characteristics of individual extra planetary exploration vehicles and different 
            Martian exploration areas.

            
2.  Implement classes and objects to test:

            Test1:
           
                Development environment works ! 

            Test2:
           
                Two MarsRover objects correctly instantiated, constructed
                Each MarsRover position and orientation correctly initialised, retrieved, updated 

            Test3:

                MartianPlateauArea object correctly instantiated, constructed
                MartianPlateauArea object correctly initialises, updates, retrieves shape and dimensions of plateau
                MartianPlateauArea object correctly creates, initialises occupation map, and updates and retrieves from it

            Test4:
           
                Two marsrover obejcts correctly update shared occupation map ...

            Test5:

                MarsRover method MoveVehicle()correctly moves two marsrover objects


Limitations:

As the software stands, any number of vehicles can be operated in an area of user configurable size.
However, additional Forms GUIs must be created.

Alternating moves have not been enforced.

Vehicles cannot move to an occupied location. However, they can move through an occupied location.

