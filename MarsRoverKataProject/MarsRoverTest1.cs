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

            Console.WriteLine("MR1 ORIENT = {0} ", marsrover1.OrientationOfVehicle);
            marsrover1.RetrieveOrientationOfVehicle().Should().Be('N');
            marsrover1.UpdateOrientationOfVehicle('W').Should().Be('W');
            Console.WriteLine("MR1 ORIENT = {0} ", marsrover1.OrientationOfVehicle);

            marsrover1.RetrievePositionOfVehicle().Should().BeEquivalentTo(TestIntegerArray1);
            Console.WriteLine("MR1 POSITION =  {0} {1}", TestIntegerArray1[0], TestIntegerArray1[1]);

            marsrover1.UpdatePositionOfVehicle(PosIntArray2).Should().BeEquivalentTo(PosIntArray2);
            Console.WriteLine("MR1 POSITION =  {0} {1}", PosIntArray2[0], PosIntArray2[1]);

            MarsRover marsrover2 = new();

            Console.WriteLine("MR2 ORIENT = {0} ", marsrover2.OrientationOfVehicle);
            marsrover2.RetrieveOrientationOfVehicle().Should().Be('N');
            marsrover2.UpdateOrientationOfVehicle('E').Should().Be('E');
            Console.WriteLine("MR2 ORIENT = {0} ", marsrover2.OrientationOfVehicle);

            marsrover2.RetrievePositionOfVehicle().Should().BeEquivalentTo(TestIntegerArray1);
            Console.WriteLine("MR2 POSITION =  {0} {1}", TestIntegerArray1[0], TestIntegerArray1[1]);

            marsrover2.UpdatePositionOfVehicle(PosIntArray3).Should().BeEquivalentTo(PosIntArray3);
            Console.WriteLine("MR2 POSITION =  {0} {1}", PosIntArray3[0], PosIntArray3[1]);

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

            martianplateauarea1.RetrieveShapeOfPlateau().Should().Be("SQUARE");

            Console.WriteLine("MPA1 Shape   = {0}", martianplateauarea1.RetrieveShapeOfPlateau());


            // dimensions ...

            int[] TestIntegerArray0 = { 0, 0 };
            int[] TestIntegerArray1 = { 5, 5 };

            martianplateauarea1.RetrieveDimensionsOfPlateau().Should().BeEquivalentTo(TestIntegerArray0);

            Console.WriteLine("MPA1 Dimensions   = {0} {1} ", TestIntegerArray0[0], TestIntegerArray0[0]);

            martianplateauarea1.UpdateDimensionsOfPlateau(TestIntegerArray1).Should().BeEquivalentTo(TestIntegerArray1);

            Console.WriteLine("MPA1 Dimensions   = {0} {1} ", TestIntegerArray1[0], TestIntegerArray1[1]);

            martianplateauarea1.UpdateDimensionsOfPlateau(TestIntegerArray0).Should().BeEquivalentTo(TestIntegerArray0);

            Console.WriteLine("MPA1 Dimensions   = {0} {1} ", TestIntegerArray0[0], TestIntegerArray0[1]);


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

            Occupationmap1 = martianplateauarea1.RetrieveOccupationMap();

            Console.Write("\n");

            for (int i = 0; i < DimensionsOfPlateau1[0]; i++)
            {
                for (int j = 0; j < DimensionsOfPlateau1[1]; j++)
                {
                    Console.Write("occmapA1: {0} {1} = {2} \n", i, j, Occupationmap1[i, j]);
                }
            }


            // change the status of initial location coord in occupation map and update it ...

            Occupationmap1[0, 0] = 'X';
            
            martianplateauarea1.UpdateOccupationMap(Occupationmap1).Should().BeEquivalentTo(expected_arr2D2); // Without occupation check - it's a new map

            int[] OldPosVehicle = { 0, 0 };
            int[] NewPosVehicle = { 0, 1 };

            Console.WriteLine("SSSSSSSSS OldPosVehicle = {0} {1}", OldPosVehicle[0], OldPosVehicle[1]);

            bool TestBool = true;
            martianplateauarea1.UpdateStatusOfCoordInOccupationMap(OldPosVehicle, NewPosVehicle).Should().Be(TestBool); // With occupation check

            if (!TestBool) // With occupation check
            {
                    Console.WriteLine( $"Attempted to initialise an occupied map location: coordinates: {NewPosVehicle[0]} {NewPosVehicle[1]} : Please try again!");
            }
            
            Occupationmap1 = martianplateauarea1.RetrieveOccupationMap();

            for (int i = 0; i < DimensionsOfPlateau1[0]; i++)
            {
                for (int j = 0; j < DimensionsOfPlateau1[1]; j++)
                {
                    Console.Write("occmapA2: {0} {1} = {2} \n", i, j, Occupationmap1[i, j]);
                }
            }
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

            Occupationmap1 = martianplateauarea1.RetrieveOccupationMap();

            Console.Write("XXXXXXXXXXXXXXXX\n");

            for (int i = 0; i < DimensionsOfPlateau1[0]; i++)
            {
                for (int j = 0; j < DimensionsOfPlateau1[1]; j++)
                {
                    Console.Write("occmapB1: {0} {1} = {2} \n", i, j, Occupationmap1[i, j]);
                }
            }

            // Now updare another coordinat in occupation map, this time checking for occupation of cood location ...

            OldPosVehicle[0] = 4;
            OldPosVehicle[1] = 1;
            NewPosVehicle[0] = 2;
            NewPosVehicle[1] = 4;

            bool TestBool = true;

            martianplateauarea1.UpdateStatusOfCoordInOccupationMap(OldPosVehicle, NewPosVehicle).Should().Be(TestBool); // With occupation check

            if (!TestBool) // With occupation check
            {
                Console.WriteLine($"Attempted to initialise an occupied map location: coordinates: {NewPosVehicle[0]} {NewPosVehicle[1]} : Please try again!");
            }

            Occupationmap1 = martianplateauarea1.RetrieveOccupationMap();

            Console.Write("XXXXXXXXXXXXXXXX\n");

            for (int i = 0; i < DimensionsOfPlateau1[0]; i++)
            {
                for (int j = 0; j < DimensionsOfPlateau1[1]; j++)
                {
                    Console.Write("occmapB2: {0} {1} = {2} \n", i, j, Occupationmap1[i, j]);
                }
            }
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

            Console.Write("VVVVVVVVVVVVVVVVVVVVV Vehicle Name: = {0} \n", marsrover1.RetrieveNameOfVehicle());

            SquareMartianPlateauArea martianplateauarea1 = new();
            
            martianplateauarea1.ConstructOccupationMap(DimensionsOfPlateau1).Should().BeEquivalentTo(expected_arr2D1);
            martianplateauarea1.RetrieveOccupationMap().Should().BeEquivalentTo(expected_arr2D1);

            Occupationmap1 = martianplateauarea1.RetrieveOccupationMap();

            Occupationmap1[0, 0] = 'X';
            
            martianplateauarea1.UpdateOccupationMap(Occupationmap1).Should().BeEquivalentTo(expected_arr2D2); // Without occupation check - it's a new map

            Occupationmap1 = martianplateauarea1.RetrieveOccupationMap();

            Console.Write("XXXXXXXXXXXXXXXX\n");

            for (int i = 0; i < DimensionsOfPlateau1[0]; i++)
            {
                for (int j = 0; j < DimensionsOfPlateau1[1]; j++)
                {
                    Console.Write("occmapB1: {0} {1} = {2} \n", i, j, Occupationmap1[i, j]);
                }
            }


            // Now set up marsrover1 move from occupation map coords 1, 2 initially facing N ...
            // Set up new start postion on a occupaton map ...

            int[] OldPosVehicle = { 0, 0 };
            int[] NewPosVehicle = { 1, 2 };

            Console.WriteLine("SSSSSSSSS OldPosVehicle = {0} {1}", OldPosVehicle[0], OldPosVehicle[1]);

            bool TestBool = true;

            martianplateauarea1.UpdateStatusOfCoordInOccupationMap(OldPosVehicle, NewPosVehicle).Should().Be(TestBool); // With occupation check
            
            if (!TestBool)
            {
                Console.WriteLine($"Attempted to initialise an occupied map location: coordinates: {NewPosVehicle[0]} {NewPosVehicle[1]} : Please try again!");
                return;
            }

            marsrover1.UpdateOrientationOfVehicle('N').Should().Be('N');

            int[] TestIntegerArray1 = { 1, 2 };
            int[] PosIntArray2 = { 1, 2 };
            int[] PosIntArray3 = { 0, 0 };

            marsrover1.UpdatePositionOfVehicle(TestIntegerArray1).Should().BeEquivalentTo(PosIntArray2);

            PosIntArray3 = marsrover1.RetrievePositionOfVehicle();

            Console.WriteLine("MR1 POSITION =  {0} {1}", PosIntArray3[0], PosIntArray3[1]);

            for (int i = 0; i < DimensionsOfPlateau1[0]; i++)
            {
                for (int j = 0; j < DimensionsOfPlateau1[1]; j++)
                {
                    Console.Write("occmapC1: {0} {1} = {2} \n", i, j, Occupationmap1[i, j]);
                }
            }

            // Now move marsrover1 from the above position ...

            char[] MoveVehicleInstructions1 = { 'L', 'M', 'L', 'M', 'L', 'M', 'L', 'M', 'M' };

            MoveConfirmString = "marsrover1: successful move to location 1 3; vehicle now facing N ";

            marsrover1.MoveVehicle(martianplateauarea1, marsrover1, MoveVehicleInstructions1).Should().Be(MoveConfirmString);

            // MoveConfirmString = marsrover1.MoveVehicle(martianplateauarea1, marsrover1, MoveVehicleInstructions1);

            Console.WriteLine("{0}", MoveConfirmString);
            Console.WriteLine("/n");

            Occupationmap1 = martianplateauarea1.RetrieveOccupationMap();

            for (int i = 0; i < DimensionsOfPlateau1[0]; i++)
            {
                for (int j = 0; j < DimensionsOfPlateau1[1]; j++)
                {
                    Console.Write("occmapA5: {0} {1} = {2} \n", i, j, Occupationmap1[i, j]);
                }
            }


            // Now move marsrover2   ...
            // Set up new start postion on occupation map ...

            OldPosVehicle[0] = 0;
            OldPosVehicle[1] = 0;
            NewPosVehicle[0] = 3;
            NewPosVehicle[1] = 3;

            Console.WriteLine("RRRRRRRRRRRRRRRRRR OldPosVehicle = {0} {1}", OldPosVehicle[0], OldPosVehicle[1]);

            TestBool = true;
            martianplateauarea1.UpdateStatusOfCoordInOccupationMap(OldPosVehicle, NewPosVehicle).Should().Be(TestBool); // With occupation check

            if (!TestBool)
            {
                Console.WriteLine($"Attempted to initialise an occupied map location: coordinates: {NewPosVehicle[0]} {NewPosVehicle[1]} : Please try again!");
                return;
            }

            marsrover2.UpdateOrientationOfVehicle('E').Should().Be('E');

            int[] posintarray5 = { 3, 3 };

            marsrover2.UpdatePositionOfVehicle(NewPosVehicle).Should().BeEquivalentTo(posintarray5);

            TestIntegerArray1 = marsrover2.RetrievePositionOfVehicle();

            Occupationmap1 = martianplateauarea1.RetrieveOccupationMap();

            Console.WriteLine("MR2 POSITION =  {0} {1}", TestIntegerArray1[0], TestIntegerArray1[1]);

            for (int i = 0; i < DimensionsOfPlateau1[0]; i++)
            {
                for (int j = 0; j < DimensionsOfPlateau1[1]; j++)
                {
                    Console.Write("occmapC2: {0} {1} = {2} \n", i, j, Occupationmap1[i, j]);
                }
            }
           
         //  char[] MoveVehicleInstructions2 = { 'M', 'R', 'M', 'R', 'M', 'R', 'M', 'R' }; // This will trigger an occupied coord msg

             char[] MoveVehicleInstructions2 = { 'M','R', 'M', 'R', 'M', 'L' };

            MoveConfirmString = "marsrover2: successful move to location 3 2; vehicle now facing S ";

            marsrover2.MoveVehicle(martianplateauarea1, marsrover2, MoveVehicleInstructions2).Should().Be(MoveConfirmString);

            Console.WriteLine("{0}", MoveConfirmString);
            Console.WriteLine("/n");

            Occupationmap1 = martianplateauarea1.RetrieveOccupationMap();

            for (int i = 0; i < DimensionsOfPlateau1[0]; i++)
            {
                for (int j = 0; j < DimensionsOfPlateau1[1]; j++)
                {
                    Console.Write("occmapC2: {0} {1} = {2} \n", i, j, Occupationmap1[i, j]);
                }
            }


            // Now move marsrover1 again, resuming from previous end position...

            int[] PosIntArray7 = { 1, 3 };

            marsrover1.RetrieveOrientationOfVehicle().Should().Be('N');
            Console.WriteLine("MR1 / 2 ORIENT = {0} ", marsrover1.OrientationOfVehicle);

            marsrover1.RetrievePositionOfVehicle().Should().BeEquivalentTo(PosIntArray7);
            PosIntArray7 = marsrover1.RetrievePositionOfVehicle();
            Console.WriteLine("MR1 / 2 POSITION =  {0} {1}", PosIntArray7[0], PosIntArray7[1]);
            OccupationMap2 = martianplateauarea1.RetrieveOccupationMap();


            for (int i = 0; i < DimensionsOfPlateau1[0]; i++)
            {
                for (int j = 0; j < DimensionsOfPlateau1[1]; j++)
                {
                    Console.Write("occmapC2: {0} {1} = {2} \n", i, j, OccupationMap2[i, j]);
                }
            }

         // char[] MoveVehicleInstructions2 = { 'M', 'R', 'M', 'R', 'M', 'R', 'M', 'R' }; // This will trigger an occupied coord msg

            char[] MoveVehicleInstructions3  = { 'M', 'R','M', 'R', 'L', 'M', 'R', 'R', 'M', 'M' };


            MoveConfirmString = "marsrover1: successful move to location 1 4; vehicle now facing W ";

            marsrover1.MoveVehicle(martianplateauarea1, marsrover1, MoveVehicleInstructions3).Should().Be(MoveConfirmString);

            Console.WriteLine("{0}", MoveConfirmString);
            Console.WriteLine("/n");

            Occupationmap1 = martianplateauarea1.RetrieveOccupationMap();

            for (int i = 0; i < DimensionsOfPlateau1[0]; i++)
            {
                for (int j = 0; j < DimensionsOfPlateau1[1]; j++)
                {
                    Console.Write("occmapC2: {0} {1} = {2} \n", i, j, Occupationmap1[i, j]);
                }
            } 
        }
    }
}