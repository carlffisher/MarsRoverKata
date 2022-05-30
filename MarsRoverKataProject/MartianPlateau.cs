using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKataProject
{
    public abstract class MartianPlateau : IMartianPlateau
    {
        private string _shapeOfPlateau;
        private int[] _dimensionsOfPlateau;
        private char[,] _occupationmap;
        
        // = new char[_dimensionsOfPlateau[0], _dimensionsOfPlateau[1]];


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


        public char[,] RetrieveOccupationMap()
        {
            return _occupationmap;
        }


        public bool ConstructOccupationMap(int[] dimensionsOfPlateau)
        {

            return false; // dummy ...
        }
    }

    public class SquareMartianPlateauArea : MartianPlateau
    {
        static private string mapshape = "SQUARE";

        static private int[] dimensionsOfPlateau = { 0, 0 };

        //static private int[] dimensionsOfPlateau = { 5, 5 };
        //   static private char[,] _occupationmap = new char[_dimensionsOfPlateau[0], _dimensionsOfPlateau[1]];
        static private char[,] occupationmap = new char[0, 0];



        public SquareMartianPlateauArea() : base(mapshape, dimensionsOfPlateau, occupationmap) { }



        public new char[,] ConstructOccupationMap(int[] dimensionsOfPlateau)
        {
            /*

             int[] tempdimensionsOfPlateau;

             tempdimensionsOfPlateau = RetrieveDimensionsOfPlateau();

             Console.WriteLine("OCCMAP Dimensions Pre = {0} {1}  \n", tempdimensionsOfPlateau[0], tempdimensionsOfPlateau[1]);

             tempdimensionsOfPlateau = UpdateDimensionsOfPlateau(dimensionsOfPlateau);

             Console.WriteLine("OCCMAP Dimensions Post = {0} {1}  \n", tempdimensionsOfPlateau[0], tempdimensionsOfPlateau[1]);

             occupationmap = new char[dimensionsOfPlateau[0], dimensionsOfPlateau[1]];

             */

            dimensionsOfPlateau = UpdateDimensionsOfPlateau(dimensionsOfPlateau);
            dimensionsOfPlateau = RetrieveDimensionsOfPlateau();
            occupationmap = new char[dimensionsOfPlateau[0], dimensionsOfPlateau[1]];



            // update the base occupation map

            UpdateOccupationMap(occupationmap);


            for (int i = 0; i < dimensionsOfPlateau[0]; i++)           // Initialise the martion plateau occupation map ...
            {
                for (int j = 0; j < dimensionsOfPlateau[1]; j++)
                {
                    occupationmap[i, j] = '-';                         // '-' == 'unoccupied' 
                }
            }

            return occupationmap;
        }
        
    }
}
