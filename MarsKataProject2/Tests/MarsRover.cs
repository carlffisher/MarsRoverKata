using MarsKataProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsKataProject
{
    public abstract class ExtraPlanetaryVehicle : IExtraPlanetaryVehicle
    {
        private int[] _positionOfVehicle;
        private char _orientationOfVehicle;
        public string _name;
        protected ExtraPlanetaryVehicle(int[] positionofvehicle, char orientationofvehicle, string nameofvehicle)
        {
            _positionOfVehicle = positionofvehicle;
            _orientationOfVehicle = orientationofvehicle;
            _name = nameofvehicle;
        }

        public int[] PositionOfVehicle { get { return _positionOfVehicle; } private set { _positionOfVehicle = value; } }
        public char OrientationOfVehicle { get { return _orientationOfVehicle; } private set { _orientationOfVehicle = value; } }
        public string Name { get { return _name; }  private set { _name = value; } }

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
        static private int[] _initposofrover = { 0, 0 };
        static private string nameofvehicle = "placeholder";

        public MarsRover() : base(_initposofrover, 'N', nameofvehicle) { }

        // public new bool MoveVehicle(char[] movevehicleinstructions)
        public new string MoveVehicle(SquareMartianPlateauArea plateau, IExtraPlanetaryVehicle marsrover, char[] movevehicleinstructions)
        {
            string VehicleName;
            int[]  NewPosVehicle = { 0, 0 };
            int[]  OldPosVehicle = { 0, 0 };
            int[]  TempOldPosVehicle = { 0, 0 };
            
            char   OldOrientVehicle;
            char   NewOrientVehicle;
            int[]  DimsPlateau;
          
            VehicleName       = RetrieveNameOfVehicle();
            TempOldPosVehicle = RetrievePositionOfVehicle();

            OldPosVehicle[0]  = TempOldPosVehicle[0]; // Get the value insteadof reference, so it is unchanged by increments to NewPosVehicle coords
            OldPosVehicle[1]  = TempOldPosVehicle[1];

            NewPosVehicle     = RetrievePositionOfVehicle();

            Console.WriteLine(" RRRRRRRR    OldPos     = {0} {1}", OldPosVehicle[0], OldPosVehicle[1]);
            Console.WriteLine(" RRRRRRRR    NewPos     = {0} {1}", NewPosVehicle[0], NewPosVehicle[1]);
            Console.WriteLine(" RRRRRRRR    OldPos     = {0} {1}", OldPosVehicle[0], OldPosVehicle[1]);
            Console.WriteLine(" RRRRRRRR    NewPos     = {0} {1}", NewPosVehicle[0], NewPosVehicle[1]);
         
            OldOrientVehicle  = RetrieveOrientationOfVehicle();
            NewOrientVehicle  = RetrieveOrientationOfVehicle();
            DimsPlateau       = plateau.RetrieveDimensionsOfPlateau();

            Console.WriteLine("movevehicleinstructions");

            for (int i = 0; i < movevehicleinstructions.Length; i++)
            {
                Console.Write(" {0} ", movevehicleinstructions[i]);
            }

            Console.WriteLine(" ");
            Console.WriteLine(" RRRRRRRR    PosVehicle = {0} {1}", OldPosVehicle[0], OldPosVehicle[1]);
            Console.WriteLine(" RRRRRRRR NewPosVehicle = {0} {1}", NewPosVehicle[0], NewPosVehicle[1]);
            Console.WriteLine(" OrientVehicle = {0} ", NewOrientVehicle);
            Console.WriteLine(" DimsPlateau = {0} {1} ", DimsPlateau[0], DimsPlateau[1]);
            
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

                                    return ($"ERROR 003: Attempted move to out of bounds location: coordinates: {NewPosVehicle[0]} {NewPosVehicle[1] + 1}/n");
                                }

                                Console.WriteLine(" RRRRRRRRW OldPosVehicle = {0} {1}", OldPosVehicle[0], OldPosVehicle[1]);
                                Console.WriteLine(" RRRRRRRRW NewPosVehicle = {0} {1}", NewPosVehicle[0], NewPosVehicle[1]); 
                                NewPosVehicle[1]++;
                                Console.WriteLine(" RRRRRRRRX OldPosVehicle = {0} {1}", OldPosVehicle[0], OldPosVehicle[1]);
                                Console.WriteLine(" RRRRRRRRX NewPosVehicle = {0} {1}", NewPosVehicle[0], NewPosVehicle[1]);

                                break;

                            case 'S':

                                if (NewPosVehicle[1] - 1 < 0)
                                {

                                    return ($"ERROR 004: Attempted move to out of bounds location: coordinates: {NewPosVehicle[0]} {NewPosVehicle[1] - 1}/n");
                                }

                                NewPosVehicle[1]--;
                                break;

                            case 'E':

                                if (NewPosVehicle[0] + 1 >= DimsPlateau[0])
                                {

                                    return ($"ERROR 005: Attempted move to out of bounds location: coordinates: {NewPosVehicle[0] + 1} {NewPosVehicle[1]}/n");
                                }

                                NewPosVehicle[0]++;
                                break;

                            case 'W':
                                if (NewPosVehicle[0] - 1 < 0)
                                {

                                    return ($"ERROR 006: Attempted move to out of bounds location: coordinates: {NewPosVehicle[0] - 1} {NewPosVehicle[1]}/n");
                                }

                                NewPosVehicle[0]--;
                                break;

                            default:
                                return ($"ERROR 007: Vehicle orientation instruction out of range: {NewOrientVehicle}/n");
                        }

                        break;

                    case 'L':

                        Console.WriteLine(" ");

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
                                return ($"ERROR 008: Vehicle orientation instruction invalid: {NewOrientVehicle}/n");
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
                                return ($"ERROR 009: Vehicle orientation instruction out of range: {NewOrientVehicle}/n");
                        }

                        break;

                     default:
                        return ($"ERROR 010: Vehicle orientation instruction out of range: {NewOrientVehicle}/n");
                }

            }
                       
            Console.WriteLine("HHHHHHHHH OldPosVehicle = {0} {1}", OldPosVehicle[0], OldPosVehicle[1]);
            Console.WriteLine("HHHHHHHHH NewPosVehicle = {0} {1}", NewPosVehicle[0], NewPosVehicle[1]);
            Console.WriteLine("SSSSSSSSS OldPosVehicle = {0} {1}", OldPosVehicle[0], OldPosVehicle[1]);

            if (!plateau.UpdateStatusOfCoordInOccupationMap(OldPosVehicle, NewPosVehicle))
            {
                return ($"{VehicleName}: Attempted to move to occupied location: coordinates: {NewPosVehicle[0]} {NewPosVehicle[1]} : Please try again!");
            }
            else
            {

                Console.WriteLine("ZZZNew Orient Vehicle = {0} ", NewOrientVehicle);

                NewPosVehicle = UpdatePositionOfVehicle(NewPosVehicle);
                NewOrientVehicle = UpdateOrientationOfVehicle(NewOrientVehicle);

                Console.WriteLine("ZZZNew Orient Vehicle = {0} ", NewOrientVehicle);
            }

            Console.WriteLine("TTTTTTTTT OldPosVehicle = {0} {1}", OldPosVehicle[0], OldPosVehicle[1]);

            return ($"{VehicleName}: successful move to location {NewPosVehicle[0]} {NewPosVehicle[1]}; vehicle now facing {NewOrientVehicle} ");
        }
    }               
 }

                
            
         
    