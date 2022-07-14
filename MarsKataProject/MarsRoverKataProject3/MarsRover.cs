using MarsRoverKataProject3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKataProject3
{
    public abstract class ExtraPlanetaryVehicle : IExtraPlanetaryVehicle
    {
        private int[] _positionOfVehicle;
        private char _orientationOfVehicle;
        private string _name;
        private char _idofvehicle;


        protected ExtraPlanetaryVehicle(int[] positionofvehicle, char orientationofvehicle, string nameofvehicle, char idofvehicle)
        {
            _positionOfVehicle = positionofvehicle;
            _orientationOfVehicle = orientationofvehicle;
            _name = nameofvehicle;
            _idofvehicle = idofvehicle;
        }

        public int[] PositionOfVehicle { get { return _positionOfVehicle; } private set { _positionOfVehicle = value; } }
        public char OrientationOfVehicle { get { return _orientationOfVehicle; } private set { _orientationOfVehicle = value; } }
        public string Name { get { return _name; }  private set { _name = value; } }
        public char ID { get { return _idofvehicle; } private set { _idofvehicle = value; } }


        public char RetrieveIdOfVehicle()
        {
            return _idofvehicle;
        }
        
        public string RetrieveNameOfVehicle()
        {
            return _name;
        }

        public string UpdateNameOfVehicle(string vehiclename)
        {
            _name = vehiclename;
            return _name;
        }

        public int[] RetrievePositionOfVehicle()
        {
            return _positionOfVehicle;
        }

        public int[] UpdatePositionOfVehicle(int[] currpos)
        {
            _positionOfVehicle = currpos;
            return _positionOfVehicle;
        }

        public char UpdateOrientationOfVehicle(char currorient)
        {
            _orientationOfVehicle = currorient;
            return _orientationOfVehicle;
        }

        public char RetrieveOrientationOfVehicle()
        {
            return _orientationOfVehicle;
        }

        public string MoveVehicle(SquareMartianPlateauArea martianplateau, IExtraPlanetaryVehicle extraplanetaryvehicle, char[] movevehicleinstructions)
        {
            return "false";
        }
    }

    public class MarsRover : ExtraPlanetaryVehicle
    {
        // public MarsRover() : base(_initposofrover, 'N', _nameofvehicle, _idOfVehicle) { }

        // public MarsRover(int[] InitPosOfRover, char InitOrientOfRover, string NameOfVehicle, char IdOfVehicle) : base(InitPosOfRover, InitOrientOfRover, NameOfVehicle, IdOfVehicle) { }

        public MarsRover(int[] InitPosOfRover, char InitOrientOfRover, string NameOfVehicle, char IdOfVehicle) : base(InitPosOfRover, InitOrientOfRover, NameOfVehicle, IdOfVehicle) { }


        public new string MoveVehicle(SquareMartianPlateauArea plateau, IExtraPlanetaryVehicle marsrover, char[] movevehicleinstructions)
        {
            string VehicleName;
            char   IdOfVehicle = '0';
            int[]  NewPosVehicle = { 0, 0 };
            int[]  OldPosVehicle = { 0, 0 };
            int[]  TempOldPosVehicle = { 0, 0 };

            char   OldOrientVehicle;
            char   NewOrientVehicle;
            int[]  DimsPlateau;
          
            VehicleName       = RetrieveNameOfVehicle();
            IdOfVehicle       = RetrieveIdOfVehicle();


            TempOldPosVehicle = RetrievePositionOfVehicle();

            OldPosVehicle[0]  = TempOldPosVehicle[0]; // Get the value into a new variable, so value of OldPosVehicle is unchanged by increments to NewPosVehicle coords.
            OldPosVehicle[1]  = TempOldPosVehicle[1]; // I guess the unwanted increment is because both OldPosVehicle and NewPosVehicle use GetPositionOfVehicle
                                                      // method so they end up pointing to the same memory location storing the value.
            NewPosVehicle     = RetrievePositionOfVehicle();

            OldOrientVehicle  = RetrieveOrientationOfVehicle();
            NewOrientVehicle  = RetrieveOrientationOfVehicle();
            DimsPlateau       = plateau.RetrieveDimensionsOfPlateau();

            /*
            Console.WriteLine("movevehicleinstructions");

            for (int i = 0; i < movevehicleinstructions.Length; i++)
            {
                Console.Write(" {0} ", movevehicleinstructions[i]);
            }
            */

            foreach (char amove in movevehicleinstructions)
            {
                switch (amove)
                {
                    case 'M':
                        switch (NewOrientVehicle)
                        {
                            case 'N':
                                if (NewPosVehicle[1] + 1 >= DimsPlateau[1])
                                {

                                    return ($"ERROR: Attempted move to out of bounds location: coordinates: {NewPosVehicle[0]} {NewPosVehicle[1] + 1}");
                                }

                                NewPosVehicle[1]++;
                                break;

                            case 'S':
                                if (NewPosVehicle[1] - 1 < 0)
                                {

                                    return ($"ERROR: Attempted move to out of bounds location: coordinates: {NewPosVehicle[0]} {NewPosVehicle[1] - 1}");
                                }

                                NewPosVehicle[1]--;
                                break;

                            case 'E':
                                if (NewPosVehicle[0] + 1 >= DimsPlateau[0])
                                {

                                    return ($"ERROR: Attempted move to out of bounds location: coordinates: {NewPosVehicle[0] + 1} {NewPosVehicle[1]}");
                                }

                                NewPosVehicle[0]++;
                                break;

                            case 'W':
                                if (NewPosVehicle[0] - 1 < 0)
                                {

                                    return ($"ERROR: Attempted move to out of bounds location: coordinates: {NewPosVehicle[0] - 1} {NewPosVehicle[1]}");
                                }

                                NewPosVehicle[0]--;
                                break;

                            default:
                                return ($"ERROR: Vehicle orientation instruction invalid: {NewOrientVehicle}");
                        }

                        break;

                    case 'L':
                        switch (NewOrientVehicle)
                        {
                            case 'N':
                                NewOrientVehicle = 'W';
                                break;
                            case 'S':
                                NewOrientVehicle = 'E';
                                break;
                            case 'E':
                                NewOrientVehicle = 'N';
                                break;
                            case 'W':
                                NewOrientVehicle = 'S';
                                break;
                            default:
                                return ($"ERROR: Vehicle orientation instruction invalid: {NewOrientVehicle}");
                        }

                        break;

                    case 'R':
                        switch (NewOrientVehicle)
                        {
                            case 'N':
                                NewOrientVehicle = 'E';
                                break;

                            case 'S':
                                NewOrientVehicle = 'W';
                                break;

                            case 'E':
                                NewOrientVehicle = 'S';
                                break;

                            case 'W':
                                NewOrientVehicle = 'N';
                                break;

                            default:
                                return ($"ERROR: Vehicle orientation instruction out of range: {NewOrientVehicle}");
                        }

                        break;

                     default:
                        return ($"ERROR: Vehicle orientation instruction invalid: {NewOrientVehicle}");
                }

            }


                       
            if (!plateau.UpdateStatusOfCoordInOccupationMap(OldPosVehicle, NewPosVehicle, IdOfVehicle))
            {
                OldPosVehicle = UpdatePositionOfVehicle(OldPosVehicle);
                OldOrientVehicle = UpdateOrientationOfVehicle(OldOrientVehicle);
                return ($"ERROR: Attempted to move to occupied location: coordinates: {NewPosVehicle[0]} {NewPosVehicle[1]}");
            }
            else
            {
                NewPosVehicle = UpdatePositionOfVehicle(NewPosVehicle);
                NewOrientVehicle = UpdateOrientationOfVehicle(NewOrientVehicle);
            }

            return ($"{VehicleName}: successful move to location {NewPosVehicle[0]} {NewPosVehicle[1]}; vehicle now facing {NewOrientVehicle} ");
        }
    }               
 }

                
            
         
    