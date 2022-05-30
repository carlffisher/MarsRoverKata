using MarsRoverKataProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MarsRoverKataProject
{
    public abstract class ExtraPlanetaryVehicle : IExtraPlanetaryVehicle
    {
        private int[] _positionOfVehicle;
        private char _orientationOfVehicle;

        protected ExtraPlanetaryVehicle(int[] positionofvehicle, char orientationofvehicle)
        {
            _positionOfVehicle = positionofvehicle;
            _orientationOfVehicle = orientationofvehicle;
        }

        public int[] PositionOfVehicle { get { return _positionOfVehicle; } private set { _positionOfVehicle = value; } }
        public char OrientationOfVehicle { get { return _orientationOfVehicle; } private set { _orientationOfVehicle = value; } }


        
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

        // // //

        public bool MoveVehicle(char[] movevehicleinstructions)
        {
            // dummy return value ...

            return false;
        }
    }

    public class MarsRover : ExtraPlanetaryVehicle
    {
        static private int[] _initposofrover = { 0, 0 };
        public MarsRover() : base(_initposofrover, 'N') { }

        public new bool MoveVehicle(char[] movevehicleinstructions)
        {
            /*
              RetrievePositionOfVehicle
              RetrieveOrientationOfVehicle
            
              do the move ...

              UpdatePositionOfVehicle
              UpdateOrientationOfVehicle
            */
            
            // dummy return value ...


            return true;
        }
    }
}