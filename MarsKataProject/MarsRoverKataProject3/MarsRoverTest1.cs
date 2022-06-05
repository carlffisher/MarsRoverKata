using NUnit.Framework;
using FluentAssertions;

namespace MarsRoverKataProject3.Tests
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
            // Development environment works !..

            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            // Two MarsRover objects correctly instantiated and constructed
            // Each MarsRover position and orientation correctly initialised, updated and retrieved ...

            int[] TestIntegerArray1 = { 0, 0 };
            int[] PosIntArray2 = { 4, 4 };
            int[] PosIntArray3 = { 2, 5 };

            MarsRover marsrover1 = new();

            marsrover1.RetrieveOrientationOfVehicle().Should().Be('N');
            marsrover1.UpdateOrientationOfVehicle('W').Should().Be('W');

            marsrover1.RetrievePositionOfVehicle().Should().BeEquivalentTo(TestIntegerArray1);

            marsrover1.UpdatePositionOfVehicle(PosIntArray2).Should().BeEquivalentTo(PosIntArray2);

            MarsRover marsrover2 = new();

            marsrover2.RetrieveOrientationOfVehicle().Should().Be('N');
            marsrover2.UpdateOrientationOfVehicle('E').Should().Be('E');

            marsrover2.RetrievePositionOfVehicle().Should().BeEquivalentTo(TestIntegerArray1);

            marsrover2.UpdatePositionOfVehicle(PosIntArray3).Should().BeEquivalentTo(PosIntArray3);
        }

        [Test]
        public void Test3()
        {
            // MartianPlateauArea object correctly instantiated and constructed
            // MartianPlateauArea object correctly updates/retrieves shape and dimensions of plateau
            // MartianPlateauArea object correctly creates occupation map, and updates/retrieves shape from it ...

            // shape ...

            SquareMartianPlateauArea martianplateauarea1 = new();

            martianplateauarea1.RetrieveShapeOfPlateau().Should().Be("SQUARE");

            // dimensions ...

            int[] TestIntegerArray0 = { 0, 0 };
            int[] TestIntegerArray1 = { 5, 5 };

            martianplateauarea1.RetrieveDimensionsOfPlateau().Should().BeEquivalentTo(TestIntegerArray0);

            martianplateauarea1.UpdateDimensionsOfPlateau(TestIntegerArray1).Should().BeEquivalentTo(TestIntegerArray1);

            martianplateauarea1.UpdateDimensionsOfPlateau(TestIntegerArray0).Should().BeEquivalentTo(TestIntegerArray0);

            // create an occupation map ...

            int[]   DimensionsOfPlateau1 = { 5, 5 };
            int[]   DimensionsOfPlateau2 = { 2, 5 };
            char[,] Occupationmap1 = new char[5, 5];

            char[,] expected_arr2D1 = new char[,] { { '-', '-', '-', '-', '-' },
                                                    { '-', '-', '-', '-', '-' },
                                                    { '-', '-', '-', '-', '-' },
                                                    { '-', '-', '-', '-', '-' },
                                                    { '-', '-', '-', '-', '-' } };

            char[,] expected_arr2D2 = new char[,] {  { 'X', '-', '-', '-', '-' },
                                                    { '-', '-', '-', '-', '-' },
                                                    { '-', '-', '-', '-', '-' },
                                                    { '-', '-', '-', '-', '-' },
                                                    { '-', '-', '-', '-', '-' } };


            martianplateauarea1.ConstructOccupationMap(DimensionsOfPlateau1).Should().BeEquivalentTo(expected_arr2D1);

            martianplateauarea1.RetrieveOccupationMap().Should().BeEquivalentTo(expected_arr2D1);


            // change the status of initial location coord in occupation map and update it ...

            Occupationmap1[0, 0] = 'X';
            
            martianplateauarea1.UpdateOccupationMap(Occupationmap1).Should().BeEquivalentTo(expected_arr2D2); // Without occupation check - it's a new map

            int[] OldPosVehicle = { 0, 0 };
            int[] NewPosVehicle = { 0, 1 };

            bool TestBool = true;

            martianplateauarea1.UpdateStatusOfCoordInOccupationMap(OldPosVehicle, NewPosVehicle).Should().Be(TestBool); // With occupation check
        }

        [Test]
        public void Test4()
        {
            // Create two MarsRoverObjects and test each of them correctly update shared occupation map ...

            char[,] Occupationmap1 = new char[5, 5];
            int[]   DimensionsOfPlateau1 = { 5, 5 };
            int[]   OldPosVehicle = { 0, 0 };
            int[]   NewPosVehicle = { 0, 0 };

            MarsRover marsrover1 = new();
            MarsRover marsrover2 = new();
            SquareMartianPlateauArea martianplateauarea1 = new();

            char[,] expected_arr2D1 = new char[,] { { '-', '-', '-', '-', '-' },
                                                    { '-', '-', '-', '-', '-' },
                                                    { '-', '-', '-', '-', '-' },
                                                    { '-', '-', '-', '-', '-' },
                                                    { '-', '-', '-', '-', '-' } };

            char[,] expected_arr2D2 = new char[,] { { 'X', 'X', '-', '-', '-' },
                                                    { '-', '-', '-', '-', '-' },
                                                    { '-', '-', '-', '-', '-' },
                                                    { '-', 'X', '-', 'X', '-' },
                                                    { '-', 'X', '-', '-', '-' } };


            char[,] expected_arr2D3 = new char[,] { { 'X', 'X', '-', '-', '-' },
                                                    { '-', '-', '-', '-', '-' },
                                                    { '-', '-', '-', 'X', '-' },
                                                    { '-', 'X', '-', 'X', '-' },
                                                    { '-', '-', '-', '-', '-' } };


            martianplateauarea1.ConstructOccupationMap(DimensionsOfPlateau1).Should().BeEquivalentTo(expected_arr2D1);
            martianplateauarea1.RetrieveOccupationMap().Should().BeEquivalentTo(expected_arr2D1);

            // Update a coordinate in occupation map in map ...

            Occupationmap1 = expected_arr2D1;

            Occupationmap1[0, 0] = 'X';
            Occupationmap1[0, 1] = 'X';
            Occupationmap1[3, 3] = 'X';
            Occupationmap1[3, 1] = 'X';
            Occupationmap1[4, 1] = 'X';

            martianplateauarea1.UpdateOccupationMap(Occupationmap1).Should().BeEquivalentTo(expected_arr2D2); // Without occupation check - it's a new map

            // Now update another coordinate in occupation map, this time checking for occupation of cood location ...

            OldPosVehicle[0] = 4;
            OldPosVehicle[1] = 1;
            NewPosVehicle[0] = 2;
            NewPosVehicle[1] = 4;

            bool TestBool = true;

            martianplateauarea1.UpdateStatusOfCoordInOccupationMap(OldPosVehicle, NewPosVehicle).Should().Be(TestBool); // With occupation check
        }

        [Test]
        public void Test5()
        {
            // MarsRover Interface Method MoveVehicle() call tested for two marsrovers...

            char[,] Occupationmap1 = new char[5, 5];
            char[,] OccupationMap2 = new char[5, 5];
            int[]   DimensionsOfPlateau1 = { 5, 5 };
            string  MoveConfirmString;

            char[,] expected_arr2D1 = new char[,] { { '-', '-', '-', '-', '-' },
                                                    { '-', '-', '-', '-', '-' },
                                                    { '-', '-', '-', '-', '-' },
                                                    { '-', '-', '-', '-', '-' },
                                                    { '-', '-', '-', '-', '-' } };


            char[,] expected_arr2D2 = new char[,] { { 'X', '-', '-', '-', '-' },
                                                    { '-', '-', '-', '-', '-' },
                                                    { '-', '-', '-', '-', '-' },
                                                    { '-', '-', '-', '-', '-' },
                                                    { '-', '-', '-', '-', '-' } };

            char[,] expected_arr2D3 = new char[,] { { '-', '-', '-', '-', '-' },
                                                    { '-', '-', 'X', '-', '-' },
                                                    { '-', '-', '-', '-', '-' },
                                                    { '-', '-', '-', '-', '-' },
                                                    { '-', '-', '-', '-', '-' } };

            char[,] expected_arr2D4 = new char[,] { { '-', 'X', '-', '-', '-' },
                                                    { '-', '-', '-', 'X', '-' },
                                                    { '-', '-', '-', '-', '-' },
                                                    { '-', '-', '-', 'X', '-' },
                                                    { '-', '-', '-', '-', '-' } };


            // Set Up the initial coordinate map and test its construction ...

            MarsRover marsrover1 = new();
            MarsRover marsrover2 = new();

            marsrover1.UpdateNameOfVehicle("marsrover1");
            marsrover2.UpdateNameOfVehicle("marsrover2");

            SquareMartianPlateauArea martianplateauarea1 = new();
            
            martianplateauarea1.ConstructOccupationMap(DimensionsOfPlateau1).Should().BeEquivalentTo(expected_arr2D1);
            martianplateauarea1.RetrieveOccupationMap().Should().BeEquivalentTo(expected_arr2D1);

            Occupationmap1 = martianplateauarea1.RetrieveOccupationMap();

            Occupationmap1[0, 0] = 'X';
            
            martianplateauarea1.UpdateOccupationMap(Occupationmap1).Should().BeEquivalentTo(expected_arr2D2); // Without occupation check - it's a new map

            // Now set up marsrover1 move from occupation map coords 1, 2 initially facing N ...
            // Set up new start postion on a occupaton map ...

            int[] OldPosVehicle = { 0, 0 };
            int[] NewPosVehicle = { 1, 2 };

            bool TestBool = true;

            martianplateauarea1.UpdateStatusOfCoordInOccupationMap(OldPosVehicle, NewPosVehicle).Should().Be(TestBool); // With occupation check
            
            marsrover1.UpdateOrientationOfVehicle('N').Should().Be('N');

            int[] TestIntegerArray1 = { 1, 2 };
            int[] PosIntArray2 = { 1, 2 };
            int[] PosIntArray3 = { 0, 0 };

            marsrover1.UpdatePositionOfVehicle(TestIntegerArray1).Should().BeEquivalentTo(PosIntArray2);

            PosIntArray3 = marsrover1.RetrievePositionOfVehicle();

            // Now move marsrover1 from the above position ...

            char[] MoveVehicleInstructions1 = { 'L', 'M', 'L', 'M', 'L', 'M', 'L', 'M', 'M' };

            MoveConfirmString = "marsrover1: successful move to location 1 3; vehicle now facing N ";

            marsrover1.MoveVehicle(martianplateauarea1, marsrover1, MoveVehicleInstructions1).Should().Be(MoveConfirmString);
;
            Occupationmap1 = martianplateauarea1.RetrieveOccupationMap();

            // Now move marsrover2   ...
            // Set up new start postion on occupation map ...

            OldPosVehicle[0] = 0;
            OldPosVehicle[1] = 0;
            NewPosVehicle[0] = 3;
            NewPosVehicle[1] = 3;

            TestBool = true;

            martianplateauarea1.UpdateStatusOfCoordInOccupationMap(OldPosVehicle, NewPosVehicle).Should().Be(TestBool); // With occupation check

            marsrover2.UpdateOrientationOfVehicle('E').Should().Be('E');

            int[] posintarray5 = { 3, 3 };

            marsrover2.UpdatePositionOfVehicle(NewPosVehicle).Should().BeEquivalentTo(posintarray5);

            TestIntegerArray1 = marsrover2.RetrievePositionOfVehicle();

            char[] MoveVehicleInstructions2 = { 'M','R', 'M', 'R', 'M', 'L' };

            MoveConfirmString = "marsrover2: successful move to location 3 2; vehicle now facing S ";

            marsrover2.MoveVehicle(martianplateauarea1, marsrover2, MoveVehicleInstructions2).Should().Be(MoveConfirmString);

            // Now move marsrover1 again, resuming from previous end position...

            int[] PosIntArray7 = { 1, 3 };

            marsrover1.RetrieveOrientationOfVehicle().Should().Be('N');

            marsrover1.RetrievePositionOfVehicle().Should().BeEquivalentTo(PosIntArray7);
            
            char[] MoveVehicleInstructions3  = { 'M', 'R','M', 'R', 'L', 'M', 'R', 'R', 'M', 'M' };

            MoveConfirmString = "marsrover1: successful move to location 1 4; vehicle now facing W ";

            marsrover1.MoveVehicle(martianplateauarea1, marsrover1, MoveVehicleInstructions3).Should().Be(MoveConfirmString);
        }
    }
}