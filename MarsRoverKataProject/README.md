# MarsRoverKata

1.  Create a UML class diagram:

            MarsRoverKataUML.drawio

            There are two abstract interface classes:

            ExtraPlanetaryVehicle - which implements the common features of any extra-planetary exploration vehicle.

            MartianPlateau - which implements the common features of any Martian plateau.This class also implements
            an occupation map which records the location of multiple concurrently active vehicles and is commonly 
            accessible by them.

            Using these two classes, multiple objects can easily be created and further customised to reflect
            the differentiated characteristics of  individual extra planetary exploration vehicles and other 
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
           
                MarsRover MoveVehicle() method correctly accepts and returns dummy params


3.  Pseudocode for MoveVehicle:

            _newPosVehicle
            _posVehicle    = RetrievePositionOfVehicle
            _orientVehicle = RetrieveOrientationOfVehicle
            _dimsPlateau   = RetrieveDimensionsOfPlateau
           
            foreach (amove in movevehicleinstructions)
            {
                switch amove

                    case: 'L':
                                    switch _orientVehicle

                                        case: 'N'
                                                             _orientVehicle = 'W'
                                        case: 'S'
                                                             _orientVehicle = 'E'
                                        case: 'E'
                                                             _orientVehicle = 'N'
                                        case: 'W'
                                                             _orientVehicle = 'S'
                                        default:             
                                                             ERROR

                    case: 'R'
                                    switch _orientVehicle

                                        case: 'N'
                                                             _orientVehicle = 'E'
                                        case: 'S'
                                                             _orientVehicle = 'W'
                                        case: 'E'
                                                             _orientVehicle = 'S'
                                        case: 'W'
                                                             _orientVehicle = 'N'
                                        default:             
                                                             ERROR

                    case: 'M':
                                    switch _orientVehicle
                            
                                        case: 'N'
                                                             _newPosVehicle[1] + 1 >= _dimsPlateau[1] ? ERROR
                                                             _newPosVehicle[1]++
                                        case: 'S'
                                                             _newPosVehicle[1] - 1 < 0 ? ERROR
                                                             _newPosVehicle[1]--
                                        case: 'E'
                                                             _newPosVehicle[0] + 1 >= _dimsPlateau[0] ? ERROR
                                                             _newPosVehicle[0]++
                                        case: 'W'
                                                             _newPosVehicle[0] - 1 < 0 ? ERROR
                                                             _newPosVehicle[0]--1
                                        default:             
                                                             ERROR

                    default: ERROR  
            }

            Update relevant fields with new location, orientation, and map details.
           
4.  Implement MoveVehicle(... and  test:
  
