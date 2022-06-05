# MarsRoverKata


This code implements the NUnit test function.


1.  Create a UML class diagram:

            MarsRoverKataUML.drawio

            There are two abstract interface classes:

            ExtraPlanetaryVehicle - which implements the common features of any extra-planetary exploration vehicle.

            MartianPlateau - which implements the common features of any Martian plateau.This class also implements
            an occupation map which records the location of multiple concurrently active vehicles and is commonly 
            accessible by them.

            Using these two classes, multiple objects can be created and further customised to reflect
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
           
                MarsRover MoveVehicle() method correctly works with two vehicles


Limitations:

As the software stands, any number of vehicles can be operated an an area of user configurable size.
However, due to lack of time to fully complete the work, some small issues remain outstanding:

Neither rover can move through its own start coordinates. 
Also, neither rover is individually identified on the graphical map.
Alternating moves have not been enforced.
  
