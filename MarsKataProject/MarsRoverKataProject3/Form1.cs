using MarsRoverKataProject3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MarsRoverKataProject3
{
    public partial class Form1 : Form
    {
        MarsRover marsrover1 = new();
        MarsRover marsrover2 = new();
        SquareMartianPlateauArea martianplateauarea1 = new(); 
        
        private int[] DimensionsOfPlateau = { 0, 0 };
        private char[,] OccupationMap = new char[0, 0];
        private int[] PrevPositionOfVehicle1 = { 0, 0}; // All vehicles originate at 0 0
        private int[] PrevPositionOfVehicle2 = { 0, 0 };
        private int[] NewPositionOfVehicle1 = { 0, 0 }; // All vehicles originate at 0 0
        private int[] NewPositionOfVehicle2 = { 0, 0 };

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Set up the Martian location occupation map ...

            string xstring;
            string ystring;
            const int MAXDIMX = 14;
            const int MAXDIMY = 14;

            xstring = mapdimsxinput.Text;
            ystring = mapdimsyinput.Text;
            
            bool isParsablex = true;
            bool isParsabley = true;

            isParsablex = Int32.TryParse(xstring, out int xcoord);
            isParsabley = Int32.TryParse(ystring, out int ycoord);
            
            if ((!isParsablex) || (!isParsabley))
            {
                mapdimsoutput.Text = "Enter two integers representing the dimensions of the Martian plateau map";
            }
            else if (xcoord > MAXDIMX || ycoord > MAXDIMY)
            {
                mapdimsoutput.Text = "Enter two integers, each < 15, representing the dimensions of the Martian plateau map";
            }
            else
            {
                DimensionsOfPlateau[0] = xcoord;
                DimensionsOfPlateau[1] = ycoord;

                // Create a martian plateau and its occupation map ...

                OccupationMap = martianplateauarea1.ConstructOccupationMap(DimensionsOfPlateau);

                mapdimsoutput.Text = "Created Martian location map of dimensions " + xcoord + " " + ycoord;

                // Display the occupation map ...

                richTextBox1.Text = " ";

                for (int j = DimensionsOfPlateau[0]-1; j >= 0; j--)
                {
                    StringBuilder outstringbuffer = new StringBuilder(" ", 20);

                    for (int i = 0; i < DimensionsOfPlateau[1]; i++)
                    {
                        outstringbuffer.Append("    ");
                        outstringbuffer.Append(OccupationMap[i, j]);
                    }

                    richTextBox1.Invoke(new Action(() => richTextBox1.Text = String.Concat(richTextBox1.Text, Environment.NewLine, " " + outstringbuffer)));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Set up the start location of mars rover 1 ...

            string xstring;
            string ystring;
            string ostring;
            bool isParsablex = true;
            bool isParsabley = true;

            xstring = textBox2.Text;
            ystring = textBox3.Text;
            ostring = textBox4.Text;

            isParsablex = Int32.TryParse(xstring, out int xcoord);
            isParsabley = Int32.TryParse(ystring, out int ycoord);

            if ((!isParsablex) || (!isParsabley))
            {
                textBox1.Text = "Enter two integers representing the start location of Mars Rover 1:";
            }
            else if ((xcoord < 0 || ycoord < 0) || (xcoord >= DimensionsOfPlateau[0] || ycoord >= DimensionsOfPlateau[1]))
            {
                textBox1.Text = "Enter two integers >= 0 and < maximium dimensions of plateau";
            }
            else if (ostring[0] != 'N' && ostring[0] != 'S' && ostring[0] != 'E' && ostring[0] != 'W')
            {
                textBox1.Text = " " + ostring[0] + " Enter N, S, E or W representing the initial orientation of Mars Rover 1";
            }
            
            else
            {
                 textBox1.Text = " " + ostring[0];

                // Now set up marsrover1 start postion on a user-defined location  ...
                
                int[] TempOldPosVehicle;            // This is a cludge, to avoid prevent PrevPositionOfVehicle1 being incremented by NewPositionOfVehicle1 ... 
                int[] TempXYCoords = { 0, 0 };      // I can only think it's because they both previously referenced RetrievePositionOfVehicle() method.
                bool IsTrue = false;

                TempOldPosVehicle = marsrover1.RetrievePositionOfVehicle();
                TempXYCoords[0] = TempOldPosVehicle[0];
                TempXYCoords[1] = TempOldPosVehicle[1];
                NewPositionOfVehicle1[0] = xcoord;
                NewPositionOfVehicle1[1] = ycoord;

                IsTrue = martianplateauarea1.UpdateStatusOfCoordInOccupationMap(TempXYCoords, NewPositionOfVehicle1); // With occupation check

                if (!IsTrue)
                {
                    textBox1.Text = "Mars rover 1 attempted to initialise an occupied location at : " + NewPositionOfVehicle1[0] + " " + NewPositionOfVehicle1[1] + " : Please try again! ";

                    return;
                }

                PrevPositionOfVehicle1 = marsrover1.UpdatePositionOfVehicle(NewPositionOfVehicle1);

                marsrover1.UpdateOrientationOfVehicle(ostring[0]);

                // Display the occupation map ...

                richTextBox1.Text = " ";

                for (int j = DimensionsOfPlateau[0] - 1; j >= 0; j--)
                {
                    StringBuilder outstringbuffer = new StringBuilder(" ", 20);

                    for (int i = 0; i < DimensionsOfPlateau[1]; i++)
                    {
                        outstringbuffer.Append("    ");
                        outstringbuffer.Append(OccupationMap[i, j]);
                    }

                    richTextBox1.Invoke(new Action(() => richTextBox1.Text = String.Concat(richTextBox1.Text, Environment.NewLine, " " + outstringbuffer)));
                }

                textBox1.Text = "Mars rover 1 at coordinate position " + NewPositionOfVehicle1[0] + " " + NewPositionOfVehicle1[1] + "  " + " Orientation : " + marsrover1.RetrieveOrientationOfVehicle();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Now relocate mars rover 1 ...

            string MoveString;
            string MoveConfirmString;
            bool IsTrue = true;

            MoveString = textBox7.Text;


            char[] MoveChar = new char[MoveString.Length];

            for (int i = 0; i < MoveString.Length; i++)
            {
                MoveChar[i] = MoveString[i];
            }

            for (int i = 0; i < MoveString.Length; i++)
            {
                if (MoveChar[i] != 'L' && MoveChar[i] != 'R' && MoveChar[i] != 'M')
                {
                    IsTrue = false;
                    break;
                }
            }

            if (!IsTrue)
            {
                textBox6.Text = "Mars rover 1 move instructions invalid: enter a series of letters consisting of M, L or R only";
            }
            else
            {
                // Now move the vehicle ...

                MoveConfirmString = marsrover1.MoveVehicle(martianplateauarea1, marsrover1, MoveChar);

                if (MoveConfirmString[0] == 'E') // It's an error : out of bounds move or attempt to move to a pre-occupied location ...
                {
                    textBox6.Text = "Mars rover 1: " + MoveConfirmString + " Try again";
                }
                else
                {
                    OccupationMap = martianplateauarea1.RetrieveOccupationMap();

                    // Display the occupation map ...

                    richTextBox1.Text = " ";

                    for (int j = DimensionsOfPlateau[0] - 1; j >= 0; j--)
                    {
                        StringBuilder outstringbuffer = new StringBuilder(" ", 20);

                        for (int i = 0; i < DimensionsOfPlateau[1]; i++)
                        {
                            outstringbuffer.Append("    ");
                            outstringbuffer.Append(OccupationMap[i, j]);
                        }

                        richTextBox1.Invoke(new Action(() => richTextBox1.Text = String.Concat(richTextBox1.Text, Environment.NewLine, " " + outstringbuffer)));

                        if (IsTrue) textBox6.Text = "Mars rover 2 at coordinate position " + NewPositionOfVehicle1[0] + " " + NewPositionOfVehicle1[1] + "  " + " Orientation : " + marsrover1.RetrieveOrientationOfVehicle();
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Set up the start location of mars rover 2 ...

            string xstring;
            string ystring;
            string ostring;
            bool isParsablex = true;
            bool isParsabley = true;

            xstring = textBox11.Text;
            ystring = textBox12.Text;
            ostring = textBox9.Text;

            isParsablex = Int32.TryParse(xstring, out int xcoord);
            isParsabley = Int32.TryParse(ystring, out int ycoord);

            if ((!isParsablex) || (!isParsabley))
            {
                textBox10.Text = "Enter two integers representing the start location of Mars Rover 2:";
            }
            else if ((xcoord < 0 || ycoord < 0) || (xcoord >= DimensionsOfPlateau[0] || ycoord >= DimensionsOfPlateau[1]))
            {
                textBox10.Text = "Enter two integers >= 0 and < maximium dimensions of plateau";
            }
            else if (ostring[0] != 'N' && ostring[0] != 'S' && ostring[0] != 'E' && ostring[0] != 'W')
            {
                textBox10.Text = " " + ostring[0] + " Enter N, S, E or W representing the initial orientation of Mars Rover 2";
            }

            else
            {
                textBox10.Text = " " + ostring[0];

                // Now set up mars rover 2 start postion on a user-defined location  ...

                int[] TempOldPosVehicle;            // This is a cludge, to avoid prevent PrevPositionOfVehicle1 being incremented by NewPositionOfVehicle1 ... 
                int[] TempXYCoords = { 0, 0 };      // I can only think it's because they both previously referenced RetrievePositionOfVehicle() method.
                bool IsTrue = false;

                TempOldPosVehicle = marsrover2.RetrievePositionOfVehicle();
                TempXYCoords[0] = TempOldPosVehicle[0];
                TempXYCoords[1] = TempOldPosVehicle[1];
                NewPositionOfVehicle2[0] = xcoord;
                NewPositionOfVehicle2[1] = ycoord;

                IsTrue = martianplateauarea1.UpdateStatusOfCoordInOccupationMap(TempXYCoords, NewPositionOfVehicle2); // With occupation check

                if (!IsTrue)
                {
                    textBox10.Text = "Mars rover 2 attempted to initialise an occupied location at : " + NewPositionOfVehicle2[0] + " " + NewPositionOfVehicle2[1] + " Try again ";

                    return;
                }

                PrevPositionOfVehicle2 = marsrover2.UpdatePositionOfVehicle(NewPositionOfVehicle2);

                marsrover2.UpdateOrientationOfVehicle(ostring[0]);

                // Display the occupation map ...

                richTextBox1.Text = " ";

                for (int j = DimensionsOfPlateau[0] - 1; j >= 0; j--)
                {
                    StringBuilder outstringbuffer = new StringBuilder(" ", 20);

                    for (int i = 0; i < DimensionsOfPlateau[1]; i++)
                    {
                        outstringbuffer.Append("    ");
                        outstringbuffer.Append(OccupationMap[i, j]);
                    }

                    richTextBox1.Invoke(new Action(() => richTextBox1.Text = String.Concat(richTextBox1.Text, Environment.NewLine, " " + outstringbuffer)));
                }

                textBox10.Text = "Mars rover 2 at coordinate position " + NewPositionOfVehicle2[0] + " " + NewPositionOfVehicle2[1] + "  " + " Orientation : " + marsrover2.RetrieveOrientationOfVehicle();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Now relocate mars rover 2 ...

            string MoveString;
            string MoveConfirmString;
            bool IsTrue = true;

            MoveString = textBox8.Text;

            char[] MoveChar = new char[MoveString.Length];

            for (int i = 0; i < MoveString.Length; i++)
            {
                MoveChar[i] = MoveString[i];
            }

            for (int i = 0; i < MoveString.Length; i++)
            {
                if (MoveChar[i] != 'L' && MoveChar[i] != 'R' && MoveChar[i] != 'M')
                {
                    IsTrue = false;
                    break;
                }
            }

            if (!IsTrue)
            {
                textBox5.Text = "Mars rover 2 move instructions invalid: enter a series of letters consisting of M, L or R only";
            }
            else
            {
                // Now move the vehicle ...

                MoveConfirmString = marsrover2.MoveVehicle(martianplateauarea1, marsrover2, MoveChar);


                if (MoveConfirmString[0] == 'E') // It's an error : out of bounds move or attempt to move to a pre-occupied location ...
                {


                    textBox5.Text = "Mars rover 2: " + MoveConfirmString + " Try again";
                }
                else
                {
                    OccupationMap = martianplateauarea1.RetrieveOccupationMap();

                    // Display the occupation map ...

                    richTextBox1.Text = " ";

                    for (int j = DimensionsOfPlateau[0] - 1; j >= 0; j--)
                    {
                        StringBuilder outstringbuffer = new StringBuilder(" ", 20);

                        for (int i = 0; i < DimensionsOfPlateau[1]; i++)
                        {
                            outstringbuffer.Append("    ");
                            outstringbuffer.Append(OccupationMap[i, j]);
                        }

                        richTextBox1.Invoke(new Action(() => richTextBox1.Text = String.Concat(richTextBox1.Text, Environment.NewLine, " " + outstringbuffer)));

                        if (IsTrue) textBox5.Text = "Mars rover 2 at coordinate position " + NewPositionOfVehicle2[0] + " " + NewPositionOfVehicle2[1] + "  " + " Orientation : " + marsrover2.RetrieveOrientationOfVehicle();
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void mapdimsxinput_TextChanged(object sender, EventArgs e)
        {

        }

        private void mapdimsyinput_TextChanged(object sender, EventArgs e)
        {

        }
        private void mapdimsoutput_TextChanged(object sender, EventArgs e)
        {
          //  mapdimsoutput.Text = "Created Martian location map of dimensions " + xcoord + " " + ycoord;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}