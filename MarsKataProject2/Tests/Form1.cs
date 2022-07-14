using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace MarsKataProject
{
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void testBtn_Click(object sender, EventArgs e) {

            string xstring;
            string ystring;
            int xstringlen;
            int ystringlen;

            xstring    = xinput.Text;
            ystring    = yinput.Text;
            xstringlen = yinput.TextLength;
            ystringlen = yinput.TextLength;
            int xcoord = 0;
            int ycoord = 0;

      
            bool isParsablex = true;
            bool isParsabley = true;

            isParsablex = Int32.TryParse(xstring, out xcoord);
            isParsabley = Int32.TryParse(ystring, out ycoord);
            
            if (!isParsablex || !isParsabley)
            {
                //output.Text = "You must enter an x integer and a y integer ";
                output.Invoke(new Action(() => output.Text = String.Concat(output.Text, Environment.NewLine, "You must enter an x integer and a y integer ")));
            }
            else
            {
                output.Invoke(new Action(() => output.Text = String.Concat(output.Text, Environment.NewLine, "Martian Location Map Dimensions = " + xcoord + " " + ycoord)));


                // Create a martian plateau and occupation map ...

                SquareMartianPlateauArea martianplateauarea1 = new();
                MessageParser<BestLimit> parser = new MessageParser<BestLimit>(() => new BestLimit());

                martianplateauarea1.ConstructOccupationMap(DimensionsOfPlateau1).Should().BeEquivalentTo(expected_arr2D1);
                martianplateauarea1.RetrieveOccupationMap().Should().BeEquivalentTo(expected_arr2D1);

                Occupationmap1 = martianplateauarea1.RetrieveOccupationMap();

                Occupationmap1[0, 0] = 'X';

                martianplateauarea1.UpdateOccupationMap(Occupationmap1).Should().BeEquivalentTo(expected_arr2D2); // Without occupation check - it's a new map

                Occupationmap1 = martianplateauarea1.RetrieveOccupationMap();

            }
        }

    


        private void moreTestsBtn_Click( object sender, EventArgs e ) {
            switch( userinput.Text ) {
                case "":
                    output.Text = "You didn't enter anything";
                    break;
                case "hello":
                case "hi":
                    output.Text = userinput.Text+ " to you too!";
                    break;
                default:
                    output.Text = "I don't understand that!";
                    break;
            }
        }


        private void complexTestsBtn_Click( object sender, EventArgs e ) {
            string msg;
            string name;
            int msglen;
            int namelen;
            msg = userinput.Text;
            name = nameinput.Text;
            msglen = userinput.TextLength;
            namelen = nameinput.TextLength;


            if( ( msglen == 0 ) && ( namelen == 0 ) ) {
                output.Text = "You haven't entered anything!";
            } else if( ( msglen == 0 ) || ( namelen == 0 ) ) {
                output.Text = "You must enter something into both text boxes";
            } else if( ( msg != "hi" ) && ( msg != "hello" ) ) {
                output.Text = "Please enter a friendly greeting ('hi' or 'hello' would be nice)";
            } else {
                output.Text = "Well, " + msg + " to you too, " + name;
            }
        }

        private void numericalTestsBtn_Click( object sender, EventArgs e ) {
            /*
             * Try different tests such as:
             * i == i
             * i < j
             * i <= j
             * i > j
             * i >= j
             * i != j
             * i != i
             * */
            int i = 100;
            int j = 200;
            if( i > j ) {
                output.Text = "Test is true";
            } else {
                output.Text = "Test is false";
            }

        }
    

        private void userinput_TextChanged(object sender, EventArgs e)
        {

        }

        private void output_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
