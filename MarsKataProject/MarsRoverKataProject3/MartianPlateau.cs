using MarsRoverKataProject3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKataProject3
{
    public abstract class MartianPlateau : IMartianPlateau
    {
        private string _shapeOfPlateau;
        private int[] _dimensionsOfPlateau;
        private char[,] _occupationmap;
        
        protected MartianPlateau(string shapeOfPlateau, int[] dimensionsOfPlateau, char [,] occupationmap)
        {
            _shapeOfPlateau = shapeOfPlateau;
            _dimensionsOfPlateau = dimensionsOfPlateau;
            _occupationmap = occupationmap;
        }

        public string ShapeOfPlateau { get { return _shapeOfPlateau; } private set { _shapeOfPlateau = value; } }
        public int[] DimensionsOfPlateau { get { return _dimensionsOfPlateau; } private set { _dimensionsOfPlateau = value; } }
        public char[,] OccupationMap { get { return _occupationmap; } private set { _occupationmap = value; } }


        public int[] RetrieveDimensionsOfPlateau()
        {
            return _dimensionsOfPlateau;
        }

        public int[] UpdateDimensionsOfPlateau(int[] platdims)
        {
            _dimensionsOfPlateau = platdims;
            return _dimensionsOfPlateau;
        }

        public string UpdateShapeOfPlateau(string platshape)
        {
            _shapeOfPlateau = platshape;
            return _shapeOfPlateau;
        }

        public string RetrieveShapeOfPlateau()
        {
            return _shapeOfPlateau;
        }

        public char[,] UpdateOccupationMap(char[,] occupationmap)
        {
            _occupationmap = occupationmap;
            return _occupationmap = occupationmap;
        }

        public bool UpdateStatusOfCoordInOccupationMap(int[] oldpos, int[] newpos)
        {
            if (_occupationmap[newpos[0], newpos[1]] == 'X')
            {
                return false;
            }
            else
            {
                _occupationmap[oldpos[0], oldpos[1]] = '-';
                _occupationmap[newpos[0], newpos[1]] = 'X';
            }

            return true;
        }

        public char[,] RetrieveOccupationMap()
        {
            return _occupationmap;
        }

        public bool ConstructOccupationMap(int[] dimensionsOfPlateau)
        {
            return false; 
        }
    }

    public class SquareMartianPlateauArea : MartianPlateau
    {
        static private string _mapshape = "SQUARE";

        static private int[] _dimensionsOfPlateau = { 0, 0 };

        static private char[,] occupationmap = new char[0, 0];

        public SquareMartianPlateauArea() : base(_mapshape, _dimensionsOfPlateau, occupationmap) { }

        public new char[,] ConstructOccupationMap(int[] _dimensionsOfPlateau)
        {
            _dimensionsOfPlateau = UpdateDimensionsOfPlateau(_dimensionsOfPlateau);
            _dimensionsOfPlateau = RetrieveDimensionsOfPlateau();
            occupationmap = new char[_dimensionsOfPlateau[0], _dimensionsOfPlateau[1]];

            UpdateOccupationMap(occupationmap);

            // Initialise the martion plateau occupation map ...
            for (int j = _dimensionsOfPlateau[1] - 1; j >= 0; j--)
            {
                for (int i = 0; i < _dimensionsOfPlateau[0]; i++)
                {
                    occupationmap[i, j] = '-';                         // '-' == 'unoccupied' 
                }
            }

            return occupationmap;
        }
    }
}
