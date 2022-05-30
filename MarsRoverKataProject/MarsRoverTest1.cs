using NUnit.Framework;
using FluentAssertions;


namespace MarsRoverKataProject.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            // Development  envirinment works !..

            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            // Two MarsRover objects correctly instantiated and constructed
            // Each MarsRover position and orientation correctly initialised, retrieved, updated and retrieved ...

            int[] posintarray1 = { 0, 0 };
            int[] posintarray2 = { 4, 4 };
            int[] posintarray3 = { 2, 5 };

            MarsRover marsrover1 = new();



            Console.WriteLine("MR1 ORIENT = {0} ", marsrover1.OrientationOfVehicle);
            marsrover1.RetrieveOrientationOfVehicle().Should().Be('N');
            marsrover1.UpdateOrientationOfVehicle('W').Should().Be('W');
            Console.WriteLine("MR1 ORIENT = {0} ", marsrover1.OrientationOfVehicle);

            marsrover1.RetrievePositionOfVehicle().Should().BeEquivalentTo(posintarray1);
            Console.WriteLine("MR1 POSITION =  {0} {1}", posintarray1[0], posintarray1[1]);

            marsrover1.UpdatePositionOfVehicle(posintarray2).Should().BeEquivalentTo(posintarray2);
            Console.WriteLine("MR1 POSITION =  {0} {1}", posintarray2[0], posintarray2[1]);


            MarsRover marsrover2 = new();

            Console.WriteLine("MR2 ORIENT = {0} ", marsrover2.OrientationOfVehicle);
            marsrover2.RetrieveOrientationOfVehicle().Should().Be('N');
            marsrover2.UpdateOrientationOfVehicle('E').Should().Be('E');
            Console.WriteLine("MR2 ORIENT = {0} ", marsrover2.OrientationOfVehicle);

            marsrover2.RetrievePositionOfVehicle().Should().BeEquivalentTo(posintarray1);
            Console.WriteLine("MR2 POSITION =  {0} {1}", posintarray1[0], posintarray1[1]);

            marsrover2.UpdatePositionOfVehicle(posintarray3).Should().BeEquivalentTo(posintarray3);
            Console.WriteLine("MR2 POSITION =  {0} {1}", posintarray3[0], posintarray3[1]);

            Console.WriteLine("MR2 POSITION GET DIRECTLY  =  {0} ", marsrover2.OrientationOfVehicle);
        }

        [Test]
        public void Test3()
        {
            // MartianPlateauArea object correctly instantiated and constructed
            // MartianPlateauArea object correctly updates/retrieves shape and dimensions of plateau
            // MartianPlateauArea object correctly creates occupation map, and updates/retrieves shape from it ...

            // shape ...

            SquareMartianPlateauArea martianplateauarea1 = new();

            martianplateauarea1.RetrieveShapeOfPlateau();

            Console.WriteLine("MPA1 Shape   = {0}", martianplateauarea1.RetrieveShapeOfPlateau());

            martianplateauarea1.RetrieveShapeOfPlateau().Should().Be("SQUARE");

            Console.WriteLine("MPA1 Shape   = {0}", martianplateauarea1.RetrieveShapeOfPlateau());


            // dimensions ...

            int[] posintarray0 = { 0, 0 };
            int[] posintarray1 = { 5, 5 };
            int[] posintarray2 = { 2, 3 };

            martianplateauarea1.RetrieveDimensionsOfPlateau().Should().BeEquivalentTo(posintarray0);

            posintarray0 = martianplateauarea1.RetrieveDimensionsOfPlateau();

            Console.WriteLine("MPA1 Dimensions   = {0} {1} ", posintarray0[0], posintarray0[0]);

            
            martianplateauarea1.UpdateDimensionsOfPlateau(posintarray1).Should().BeEquivalentTo(posintarray1);

            posintarray1 = martianplateauarea1.RetrieveDimensionsOfPlateau();

            Console.WriteLine("MPA1 Dimensions   = {0} {1} ", posintarray1[0], posintarray1[1]);


            martianplateauarea1.UpdateDimensionsOfPlateau(posintarray0).Should().BeEquivalentTo(posintarray0);

            posintarray1 = martianplateauarea1.RetrieveDimensionsOfPlateau();

            Console.WriteLine("MPA1 Dimensions   = {0} {1} ", posintarray1[0], posintarray1[1]);


            // occupation map ...

            int[] dimensionsOfPlateau1 = { 5, 5 };
            int[] dimensionsOfPlateau2 = { 2, 3 };
            int[] dimensionsOfPlateau3 = { 2, 5 };


            char[,] expected_arr2D1 = new char[,] { { '-', '-', '-', '-', '-' }, 
                                                    { '-', '-', '-', '-', '-' },
                                                    { '-', '-', '-', '-', '-' }, 
                                                    { '-', '-', '-', '-', '-' }, 
                                                    { '-', '-', '-', '-', '-' } };

            char[,] expected_arr2D2 = new char[,] { { '-', '-', '-',},
                                                    { '-', '-', '-',} };

            char[,] expected_arr2D3 = new char[,] { { 'a', 'b', 'c', 'd', 'e'},
                                                    { 'f', 'g', 'h', 'i', 'j'} };



            char[,] occupationmap1 = new char[5, 5];
            char[,] occupationmap2 = new char[2, 3];
            char[,] occupationmap3 = new char[0, 0];

            char[,] occupationmap4 = new char[0,0];
            char[,] occupationmap5 = new char[0, 0];



            martianplateauarea1.ConstructOccupationMap(dimensionsOfPlateau1).Should().BeEquivalentTo(expected_arr2D1);

            occupationmap4 = martianplateauarea1.RetrieveOccupationMap();


            Console.Write("\n");
            
            for (int i = 0; i < dimensionsOfPlateau1[0]; i++)
            {
                for (int j = 0; j < dimensionsOfPlateau1[1]; j++)
                {
                    Console.Write("occmap4: {0} {1} = {2} \n", i, j, occupationmap4[i, j]);
                }
            }

            // change the status of a coord in OccupationMap and Update it ...


            occupationmap4[0, 0] = 'X';

            occupationmap5 = martianplateauarea1.UpdateOccupationMap(occupationmap4);


            for (int i = 0; i < dimensionsOfPlateau1[0]; i++)
            {
                for (int j = 0; j < dimensionsOfPlateau1[1]; j++)
                {
                    Console.Write("occmap4: {0} {1} = {2} \n", i, j, occupationmap5[i, j]);
                }
            }


            ///////////////////////////////


            Console.Write("\n");


            SquareMartianPlateauArea martianplateauarea2 = new();

            martianplateauarea2.ConstructOccupationMap(dimensionsOfPlateau2).Should().BeEquivalentTo(expected_arr2D2);

            occupationmap2 = martianplateauarea2.RetrieveOccupationMap();


            Console.Write("\n");
            
            for (int i = 0; i < dimensionsOfPlateau2[0]; i++)
            {
                for (int j = 0; j < dimensionsOfPlateau2[1]; j++)
                {
                    Console.Write("occmap2: {0} {1} = {2} \n", i, j, occupationmap2[i, j]);
                }
            }

            Console.Write("\n");
            
            for (int i = 0; i < dimensionsOfPlateau3[0]; i++)
            {
                for (int j = 0; j < dimensionsOfPlateau3[1]; j++)
                {
                    Console.Write("occmap3: {0} {1} = {2} \n", i, j, expected_arr2D3[i, j]);
                }
            }

        }

        [Test]
        public void Test4()
        {
            // MarsRover Interface Method MoveVehicle() call tested ...

            /*
            List<char> movelistchar = new List<char> { 'R', 'M', 'M', 'L', 'M' };
            List<int> poslistint1 = new() { 0, 0 };
            List <int> poslistint2 = new() { 2, 1 };

            MarsRover marsrover1 = new();

            Console.WriteLine("MR1 PreMove   = {0} {1} ", poslistint1[0], poslistint1[1]);

            marsrover1.MoveVehicle(movelistchar).Should().Equal(true);

            Console.WriteLine("MR1 PostMove  = {0} {1} ", poslistint2[0], poslistint2[1]);
            */


            Console.WriteLine("MR1 Premove MMMMMMMMMMMMMMMMM ");

            char[] movevehicleinstructions = { 'R', 'M', 'M', 'L', 'M' };
            int[] poslistint1 = { 0, 0 };
            int[] poslistint2 = { 0, 0 };


            MarsRover marsrover1 = new();
            marsrover1.MoveVehicle(movevehicleinstructions).Should().Be(true);

            Console.WriteLine("MR1 PostMove MMMMMMMMMMMMMMMMM ");





        }

    }
}