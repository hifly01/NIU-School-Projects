/********************************************************************
CSCI 473 - Assignment 4 - Spring 2020

Programmers: Theresa Li (Z1814730), Charles Alms (Z1797837) 
Section:    1
TA:         Jennifer Ho & Sridivya Pagadala
Date Due:   4/2/20

Purpose:    This program is teaching us to make a real estate map using C#
*********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging; 
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheresaLiCharlesAlms_Assign4
{
    public partial class Form1 : Form
    {
        //objects for the DeKalb community 
        private Person person1 = null; //person object
        private House house1 = null; //house object
        private Apartment apartment1 = null; //apartment object
        private Business business1 = null; //business object 
        private School school1 = null; //school object 
        private Community community1 = new Community(); //community object

        //objects for the Sycamore community 
        private Person person2 = null; //person object 
        private House house2 = null; //house object
        private Business business2 = null; //business object
        private School school2 = null; //school object
        private Apartment apartment2 = null; //apartment object
        private Community community2 = new Community(); //community object 

        //Creates area 
        static Bitmap Canvas = new Bitmap(500, 250);

        //Makes area a canvas to draw
        Graphics g = Graphics.FromImage(Canvas);

        //Create pen 
        Pen blackPen = new Pen(Color.Black, 1); //street
        Pen purplePen = new Pen(Color.Purple, 1); //residential 
        Pen redPen = new Pen(Color.Red, 1); //school
        Pen bluePen = new Pen(Color.Blue, 1); //business 
        Pen orangePen = new Pen(Color.DarkOrange, 1); //curves

        //Create font and brush.
        Font drawFont = new Font("Arial", 5);
        SolidBrush drawBrush = new SolidBrush(Color.Black);

        private Point start = Point.Empty;      //starting point of the map
        double startingZoom = 1;                   //starting zoom at 1

        public Form1()
        {
            InitializeComponent();
            //DeKalb person file
            using (StreamReader inFile = new StreamReader("..\\..\\DeKalb\\p.txt")) //this is for reading in the input file 
            {
                String readFile = inFile.ReadLine(); //first we read one line 
                String[] inputPerson;

                while (readFile != null) //if the line isn't null, it will keep on storing and reading 
                {
                    inputPerson = readFile.Split('\t'); //it is splitting based on whether or not there is a tab between the two attributes
                    person1 = new Person(inputPerson); //person object is reading in the input file 
                    community1.Residents.Add(person1); //person object is added to the community 

                    readFile = inFile.ReadLine(); //continue reading
                }
            }

            //Sycamore person file
            using (StreamReader inFile = new StreamReader("..\\..\\Sycamore\\p.txt")) //this is for reading in the input file 
            {
                String readFile = inFile.ReadLine(); //first we read one line 
                String[] inputPerson;

                while (readFile != null) //if the line isn't null, it will keep on storing and reading 
                {
                    inputPerson = readFile.Split('\t'); //it is splitting based on whether or not there is a tab between the two attributes
                    person2 = new Person(inputPerson); //person object is reading in the input file 
                    community2.Residents.Add(person2); //person object is added to the community 

                    readFile = inFile.ReadLine(); //continue reading
                }
            }

            //DeKalb house file
            using (StreamReader inFile = new StreamReader("..\\..\\DeKalb\\r.txt")) //this is for reading in the input file 
            {
                String readFile = inFile.ReadLine(); //first we read one line 
                String[] inputProperty1;

                while (readFile != null) //if the line isn't null, it will keep on storing and reading 
                {
                    inputProperty1 = readFile.Split('\t'); //it is splitting based on whether or not there is a tab between the two attributes
                    house1 = new House(inputProperty1); //house object is reading in the input file 
                    community1.Props.Add(house1); //house object is added to the community 

                    readFile = inFile.ReadLine(); //continue reading 
                }
            }

            //Sycamore house file
            using (StreamReader inFile = new StreamReader("..\\..\\Sycamore\\r.txt")) //this is for reading in the input file 
            {
                String readFile = inFile.ReadLine(); //first we read one line 
                String[] inputProperty;

                while (readFile != null) //if the line isn't null, it will keep on storing and reading 
                {
                    inputProperty = readFile.Split('\t'); //it is splitting based on whether or not there is a tab between the two attributes
                    house2 = new House(inputProperty); //house object is reading in the input file 
                    community2.Props.Add(house2); //house object is added to the community 

                    readFile = inFile.ReadLine(); //continue reading 
                }
            }

            //DeKalb apartment file
            using (StreamReader inFile = new StreamReader("..\\..\\DeKalb\\a.txt")) //this is for reading in the input file 
            {
                String readFile = inFile.ReadLine(); //first we read one line 
                String[] inputProperty2;

                while (readFile != null) //if the line isn't null, it will keep on storing and reading 
                {
                    inputProperty2 = readFile.Split('\t'); //it is splitting based on whether or not there is a tab between the two attributes
                    apartment1 = new Apartment(inputProperty2); //apartment object is reading in the input file
                    community1.Props.Add(apartment1); //apartment object is added to the community 

                    readFile = inFile.ReadLine(); //continue reading 
                }
            }

            //Sycamore apartment file
            using (StreamReader inFile = new StreamReader("..\\..\\Sycamore\\a.txt")) //this is for reading in the input file 
            {
                String readFile = inFile.ReadLine(); //first we read one line 
                String[] inputProperty2;

                while (readFile != null) //if the line isn't null, it will keep on storing and reading 
                {
                    inputProperty2 = readFile.Split('\t'); //it is splitting based on whether or not there is a tab between the two attributes
                    apartment2 = new Apartment(inputProperty2); //apartment object is reading in the input file
                    community2.Props.Add(apartment2); //apartment object is added to the community 

                    readFile = inFile.ReadLine(); //continue reading 
                }
            }

            //DeKalb business file
            using (StreamReader inFile = new StreamReader("..\\..\\DeKalb\\b.txt")) //this is for reading in the input file 
            {
                String readFile = inFile.ReadLine(); //first we read one line 
                String[] inputProperty2;

                while (readFile != null) //if the line isn't null, it will keep on storing and reading 
                {
                    inputProperty2 = readFile.Split('\t'); //it is splitting based on whether or not there is a tab between the two attributes
                    business1 = new Business(inputProperty2); //apartment object is reading in the input file
                    community1.Props.Add(business1); //apartment object is added to the community 

                    readFile = inFile.ReadLine(); //continue reading 
                }
            }

            //Sycamore business file
            using (StreamReader inFile = new StreamReader("..\\..\\Sycamore\\b.txt")) //this is for reading in the input file 
            {
                String readFile = inFile.ReadLine(); //first we read one line 
                String[] inputProperty2;

                while (readFile != null) //if the line isn't null, it will keep on storing and reading 
                {
                    inputProperty2 = readFile.Split('\t'); //it is splitting based on whether or not there is a tab between the two attributes
                    business2 = new Business(inputProperty2); //apartment object is reading in the input file
                    community2.Props.Add(business2); //apartment object is added to the community 

                    readFile = inFile.ReadLine(); //continue reading 
                }
            }

            //DeKalb school file
            using (StreamReader inFile = new StreamReader("..\\..\\DeKalb\\s.txt")) //this is for reading in the input file 
            {
                String readFile = inFile.ReadLine(); //first we read one line 
                String[] inputProperty2;

                while (readFile != null) //if the line isn't null, it will keep on storing and reading 
                {
                    inputProperty2 = readFile.Split('\t'); //it is splitting based on whether or not there is a tab between the two attributes
                    school1 = new School(inputProperty2); //apartment object is reading in the input file
                    community1.Props.Add(school1); //apartment object is added to the community 

                    readFile = inFile.ReadLine(); //continue reading 
                }
            }

            //Sycamore school file
            using (StreamReader inFile = new StreamReader("..\\..\\Sycamore\\s.txt")) //this is for reading in the input file 
            {
                String readFile = inFile.ReadLine(); //first we read one line 
                String[] inputProperty2;

                while (readFile != null) //if the line isn't null, it will keep on storing and reading 
                {
                    inputProperty2 = readFile.Split('\t'); //it is splitting based on whether or not there is a tab between the two attributes
                    school2 = new School(inputProperty2); //apartment object is reading in the input file
                    community2.Props.Add(school2); //apartment object is added to the community 

                    readFile = inFile.ReadLine(); //continue reading 
                }
            }

            updateDropDownMenu();
            attachedGarage_checkbox.Visible = false;

            map_paint(start, startingZoom);     //call the paint function
        }
        
        //creates the map
        private void map_paint(Point move, double zoom)
        {
            Graphics g = Graphics.FromImage(Canvas);
            g.Clear(Color.White);
            
            SortedDictionary<uint, int> storingX = new SortedDictionary<uint, int>(); //Storing x-coordinates into dictionary 
            SortedDictionary<uint, int> storingY = new SortedDictionary<uint, int>(); //Storing y-coordinates into dictionary

            // Create the ToolTip and associate with the Form container.
            ToolTip propertyInfo = new ToolTip();
            Rectangle rect;

            //Display properties in DeKalb
            foreach (Property i in community1.Props) //foreach property 
            {
                if (i is House || i is Apartment) //if it's residential
                {
                    //Multiple properties on street 
                    storingX.Add(i.Id, i.Xcord); //add x-coordinate to dictionary 
                    storingY.Add(i.Id, i.Ycord); //add y-coordinate to dictionary 

                    //Create residencial 
                    rect = new Rectangle((int)(i.Xcord * zoom) + move.X, (int)(i.Ycord * zoom) + move.Y, (int)(10 * zoom), (int)(10 * zoom));

                    //Draw rectangle to screen.
                    g.DrawRectangle(purplePen, rect);
                }
                else if (i is Business)
                {

                    //Create residencial 
                    rect = new Rectangle((int)(i.Xcord * zoom) + move.X, (int)(i.Ycord * zoom) + move.Y, (int)(10 * zoom), (int)(10 * zoom));

                    //Draw rectangle to screen.
                    g.DrawRectangle(bluePen, rect);
                }
                else if (i is School)
                {

                    //Create residencial 
                    rect = new Rectangle((int)(i.Xcord * zoom) + move.X, (int)(i.Ycord * zoom) + move.Y, (int)(10 * zoom), (int)(10 * zoom));

                    //Draw rectangle to screen.
                    g.DrawRectangle(redPen, rect);
                }
            }

            //Displays properties in Sycamore 
            foreach (Property i in community2.Props) //foreach property 
            {
                if (i is House || i is Apartment) //if it's residential
                {
                    
                    //Multiple properties on street 
                    storingX.Add(i.Id, i.Xcord + 250); //add x-coordinate to dictionary 
                    storingY.Add(i.Id, i.Ycord); //add y-coordinate to dictionary 

                    //Create residencial 
                    rect = new Rectangle((int)((i.Xcord + 250) * zoom) + move.X, (int)(i.Ycord * zoom) + move.Y, (int)(10 * zoom), (int)(10 * zoom));

                    //Draw rectangle to screen.
                    g.DrawRectangle(purplePen, rect);
                }
                else if (i is Business)
                {

                    //Create residencial 
                    rect = new Rectangle((int)((i.Xcord + 250) * zoom) + move.X, (int)(i.Ycord * zoom) + move.Y, (int)(10 * zoom), (int)(10 * zoom));

                    //Draw rectangle to screen.
                    g.DrawRectangle(bluePen, rect);
                }
                else if (i is School)
                {

                    //Create residencial 
                    rect = new Rectangle((int)((i.Xcord + 250) * zoom) + move.X, (int)(i.Ycord * zoom) + move.Y, (int)(10 * zoom), (int)(10 * zoom));

                    //Draw rectangle to screen.
                    g.DrawRectangle(redPen, rect);
                }
            }
            List<int> uniqueX = storingX.Values.Distinct().ToList(); //convert sortedDictionary to unique x-coordinate 
            List<int> uniqueY = storingY.Values.Distinct().ToList(); //convert sortedDictionary to unique y-coordinate

            List<int> nonCurveX = new List<int>(); //holds x-coordinates for noncurved streets 
            List<int> nonCurveY = new List<int>(); //holds y-coordinates for noncurved streets 

            Dictionary<int, int> occurancesX = new Dictionary<int, int>(); //counts how many of each x there is 
            Dictionary<int, int> occurancesY = new Dictionary<int, int>(); //counts how many of each y there is 

            //drawing out streets 
            foreach (int entry1 in uniqueX) //for each unique x
            {
                int count = 0; //reset count

                foreach (KeyValuePair<uint, int> entry2 in storingX) //go through each x stored in dictionary 
                {
                    if (entry1 == entry2.Value) //if unique x equals x stored in dictionary 
                    {
                        count++; //count it 
                        CreateNewOrUpdateExisting(occurancesX, entry2.Value, count);
                    }
                }
            }

            foreach (KeyValuePair<int, int> entry in occurancesX) //go through each x stored in dictionary 
            {
                if (entry.Value > 2)
                {
                    foreach (Property i in community1.Props) //go through each property 
                    {
                        if (entry.Key == i.Xcord) //match the key of the x to the property 
                        {
                            if ((i is House) || (i is Apartment))
                            {
                                //Set format of string to display next to street 
                                StringFormat drawFormat = new StringFormat();
                                drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;

                                float x = i.Xcord; //store x coordinate 
                                nonCurveX.Add(i.Xcord);
                                nonCurveY.Add(i.Ycord);

                                //Draw string to screen.
                                g.DrawString(i.StreetName, drawFont, drawBrush, (int)(x*zoom)+move.X, (int)(125*zoom) + move.Y, drawFormat);

                                //Making two points 
                                Point pt1 = new Point((int)(i.Xcord * zoom) + move.X, 0);
                                Point pt2 = new Point((int)(i.Xcord * zoom) + move.X, map.Height);

                                //Drawing lines 
                                g.DrawLine(blackPen, pt1, pt2);
                            }
                        }
                    }

                    foreach (Property i in community2.Props) //go through each property 
                    {
                        if (entry.Key == i.Xcord) //match the key of the x to the property 
                        {
                            if ((i is House) || (i is Apartment))
                            {
                                //Set format of string to display next to street 
                                StringFormat drawFormat = new StringFormat();
                                drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;

                                float x = i.Xcord + 250; //store x coordinate 
                                nonCurveX.Add(i.Xcord + 250);
                                nonCurveY.Add(i.Ycord);

                                //Draw string to screen.
                                g.DrawString(i.StreetName, drawFont, drawBrush, (int)(x * zoom) + move.X, (int)(125 * zoom) + move.Y, drawFormat);

                                //Making two points 
                                Point pt1 = new Point((int)((i.Xcord + 250) * zoom) + move.X, 0);
                                Point pt2 = new Point((int)((i.Xcord + 250) * zoom) + move.X, map.Height);

                                //Drawing lines 
                                g.DrawLine(blackPen, pt1, pt2);
                            }
                        }
                    }
                }
            }

            foreach (int entry1 in uniqueY) //for each unique y
            {
                int count = 0; //reset count

                foreach (KeyValuePair<uint, int> entry2 in storingY) //go through each y stored in dictionary 
                {
                    if (entry1 == entry2.Value) //if unique y equals y stored in dictionary 
                    {
                        count++; //count it 
                        CreateNewOrUpdateExisting(occurancesY, entry2.Value, count);
                    }
                }
            }

            foreach (KeyValuePair<int, int> entry in occurancesY) //go through each x stored in dictionary 
            {
                if (entry.Value > 2)
                {
                    foreach (Property i in community1.Props) //go through each property 
                    {
                        if (entry.Key == i.Ycord) //match the key of the x to the property 
                        {
                            if ((i is House) || (i is Apartment))
                            {
                                //Set format of string to display next to street 
                                StringFormat drawFormat = new StringFormat();
                                drawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;

                                float x = i.Xcord; //store x coordinate 
                                nonCurveX.Add(i.Xcord);
                                nonCurveY.Add(i.Ycord);

                                //Draw string to screen.
                                g.DrawString(i.StreetName, drawFont, drawBrush, (int)(125*zoom)+move.X, (int)(i.Ycord * zoom) + move.Y, drawFormat);

                                //Making two points 
                                Point pt1 = new Point(0, (int)(i.Ycord * zoom) + move.Y);
                                Point pt2 = new Point(map.Width, (int)(i.Ycord * zoom) + move.Y);

                                //Drawing lines 
                                g.DrawLine(blackPen, pt1, pt2);
                            }
                        }
                    }

                    foreach (Property i in community2.Props) //go through each property 
                    {
                        if (entry.Key == i.Ycord) //match the key of the x to the property 
                        {
                            if ((i is House) || (i is Apartment))
                            {
                                //Set format of string to display next to street 
                                StringFormat drawFormat = new StringFormat();
                                drawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;

                                float x = i.Xcord + 250; //store x coordinate 
                                nonCurveX.Add(i.Xcord + 250);
                                nonCurveY.Add(i.Ycord);

                                //Draw string to screen.
                                g.DrawString(i.StreetName, drawFont, drawBrush, (int)(125 * zoom) + move.X, (int)(i.Ycord * zoom) + move.Y, drawFormat);

                                //Making two points 
                                Point pt1 = new Point(0, (int)(i.Ycord * zoom) + move.Y);
                                Point pt2 = new Point(map.Width, (int)(i.Ycord * zoom) + move.Y);

                                //Drawing lines 
                                g.DrawLine(blackPen, pt1, pt2);
                            }
                        }
                    }
                }
            }

            //for drawing curves
            List<int> CurveX = new List<int>(); //holds x-coordinates for curved streets 
            CurveX = storingX.Values.ToList().Except(nonCurveX).ToList(); //has all the x-coordinates for curved streets 

            //drawing out curves
            foreach (Property i in community1.Props) //goes through all the properties in DeKalb 
            {
                foreach (int xCord in CurveX) //goes through all the curves 
                {
                    if (i.Xcord == xCord) //finds each curve in DeKalb
                    {
                        if ((i is House) || (i is Apartment)) //if it's residential
                        {
                            //create points to draw curve
                            Point pt1 = new Point((int)((i.Xcord - 10)*zoom) + move.X, (int)((i.Ycord +10)* zoom) + move.Y);
                            Point pt2 = new Point((int)(i.Xcord*zoom)+move.X, (int)(i.Ycord*zoom)+move.Y);
                            Point pt3 = new Point((int)((i.Xcord + 10) * zoom) + move.X, (int)((i.Ycord + 10) * zoom) + move.Y);
                            Point[] curvePoints = { pt1, pt2, pt3 };

                            g.DrawCurve(orangePen, curvePoints); //draws curve 
                        }
                    }
                }
            }

            foreach (Property i in community2.Props) //goes through all the properties in Sycamore 
            {
                foreach (int xCord in CurveX) //goes through all the curves 
                {
                    if (i.Xcord + 250 == xCord) //finds each curve in Sycamore
                    {
                        if ((i is House) || (i is Apartment)) //if it's residential
                        {
                            //create points to draw curve
                            Point pt1 = new Point((int)((i.Xcord - 10) * zoom) + move.X, (int)((i.Ycord + 10) * zoom) + move.Y);
                            Point pt2 = new Point((int)(i.Xcord * zoom) + move.X, (int)(i.Ycord * zoom) + move.Y);
                            Point pt3 = new Point((int)((i.Xcord + 10) * zoom) + move.X, (int)((i.Ycord + 10) * zoom) + move.Y);
                            Point[] curvePoints = { pt1, pt2, pt3 };

                            g.DrawCurve(orangePen, curvePoints); //draws curve 
                        }
                    }
                }
            }
            map.Image = Canvas; //image gets updated on canvas
        }

        private void drawStreets()
        {
            SortedDictionary<uint, int> storingX = new SortedDictionary<uint, int>(); //Storing x-coordinates into dictionary 
            SortedDictionary<uint, int> storingY = new SortedDictionary<uint, int>(); //Storing y-coordinates into dictionary

            //Create the ToolTip and associate with the Form container.
            ToolTip propertyInfo = new ToolTip();

            //Display properties in DeKalb
            foreach (Property i in community1.Props) //foreach property 
            {
                if (i is House || i is Apartment) //if it's residential
                {
                    //Multiple properties on street 
                    storingX.Add(i.Id, i.Xcord); //add x-coordinate to dictionary 
                    storingY.Add(i.Id, i.Ycord); //add y-coordinate to dictionary 
                }
            }

            //Displays properties in Sycamore 
            foreach (Property i in community2.Props) //foreach property 
            {
                if (i is House || i is Apartment) //if it's residential
                {
                    //Multiple properties on street 
                    storingX.Add(i.Id, i.Xcord + 250); //add x-coordinate to dictionary 
                    storingY.Add(i.Id, i.Ycord); //add y-coordinate to dictionary 
                }
            }

            List<int> uniqueX = storingX.Values.Distinct().ToList(); //convert sortedDictionary to unique x-coordinate 
            List<int> uniqueY = storingY.Values.Distinct().ToList(); //convert sortedDictionary to unique y-coordinate

            List<int> nonCurveX = new List<int>(); //holds x-coordinates for noncurved streets 
            List<int> nonCurveY = new List<int>(); //holds y-coordinates for noncurved streets 

            Dictionary<int, int> occurancesX = new Dictionary<int, int>(); //counts how many of each x there is 
            Dictionary<int, int> occurancesY = new Dictionary<int, int>(); //counts how many of each y there is 

            //drawing out streets 
            foreach (int entry1 in uniqueX) //for each unique x
            {
                int count = 0; //reset count

                foreach (KeyValuePair<uint, int> entry2 in storingX) //go through each x stored in dictionary 
                {
                    if (entry1 == entry2.Value) //if unique x equals x stored in dictionary 
                    {
                        count++; //count it 
                        CreateNewOrUpdateExisting(occurancesX, entry2.Value, count);
                    }
                }
            }

            foreach (KeyValuePair<int, int> entry in occurancesX) //go through each x stored in dictionary 
            {
                if (entry.Value > 2)
                {
                    foreach (Property i in community1.Props) //go through each property 
                    {
                        if (entry.Key == i.Xcord) //match the key of the x to the property 
                        {
                            if ((i is House) || (i is Apartment))
                            {
                                //Set format of string to display next to street 
                                StringFormat drawFormat = new StringFormat();
                                drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;

                                float x = i.Xcord; //store x coordinate 
                                nonCurveX.Add(i.Xcord);
                                nonCurveY.Add(i.Ycord);

                                //Draw string to screen.
                                g.DrawString(i.StreetName, drawFont, drawBrush, x, 125, drawFormat);

                                //Making two points 
                                Point pt1 = new Point(i.Xcord, 0);
                                Point pt2 = new Point(i.Xcord, map.Height);

                                //Drawing lines 
                                g.DrawLine(blackPen, pt1, pt2);
                            }
                        }
                    }

                    foreach (Property i in community2.Props) //go through each property 
                    {
                        if (entry.Key == i.Xcord) //match the key of the x to the property 
                        {
                            if ((i is House) || (i is Apartment))
                            {
                                //Set format of string to display next to street 
                                StringFormat drawFormat = new StringFormat();
                                drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;

                                float x = i.Xcord + 250; //store x coordinate 
                                nonCurveX.Add(i.Xcord + 250);
                                nonCurveY.Add(i.Ycord);

                                //Draw string to screen.
                                g.DrawString(i.StreetName, drawFont, drawBrush, x, 125, drawFormat);

                                //Making two points 
                                Point pt1 = new Point(i.Xcord + 250, 0);
                                Point pt2 = new Point(i.Xcord + 250, map.Height);

                                //Drawing lines 
                                g.DrawLine(blackPen, pt1, pt2);
                            }
                        }
                    }
                }
            }

            foreach (int entry1 in uniqueY) //for each unique y
            {
                int count = 0; //reset count

                foreach (KeyValuePair<uint, int> entry2 in storingY) //go through each y stored in dictionary 
                {
                    if (entry1 == entry2.Value) //if unique y equals y stored in dictionary 
                    {
                        count++; //count it 
                        CreateNewOrUpdateExisting(occurancesY, entry2.Value, count);
                    }
                }
            }

            foreach (KeyValuePair<int, int> entry in occurancesY) //go through each x stored in dictionary 
            {
                if (entry.Value > 2)
                {
                    foreach (Property i in community1.Props) //go through each property 
                    {
                        if (entry.Key == i.Ycord) //match the key of the x to the property 
                        {
                            if ((i is House) || (i is Apartment))
                            {
                                //Set format of string to display next to street 
                                StringFormat drawFormat = new StringFormat();
                                drawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;

                                float x = i.Xcord; //store x coordinate 
                                nonCurveX.Add(i.Xcord);
                                nonCurveY.Add(i.Ycord);

                                //Draw string to screen.
                                g.DrawString(i.StreetName, drawFont, drawBrush, 125, i.Ycord, drawFormat);

                                //Making two points 
                                Point pt1 = new Point(0, i.Ycord);
                                Point pt2 = new Point(map.Width, i.Ycord);

                                //Drawing lines 
                                g.DrawLine(blackPen, pt1, pt2);
                            }
                        }
                    }

                    foreach (Property i in community2.Props) //go through each property 
                    {
                        if (entry.Key == i.Ycord) //match the key of the x to the property 
                        {
                            if ((i is House) || (i is Apartment))
                            {
                                //Set format of string to display next to street 
                                StringFormat drawFormat = new StringFormat();
                                drawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;

                                float x = i.Xcord + 250; //store x coordinate 
                                nonCurveX.Add(i.Xcord + 250);
                                nonCurveY.Add(i.Ycord);

                                //Draw string to screen.
                                g.DrawString(i.StreetName, drawFont, drawBrush, 125, i.Ycord, drawFormat);

                                //Making two points 
                                Point pt1 = new Point(0, i.Ycord);
                                Point pt2 = new Point(map.Width, i.Ycord);

                                //Drawing lines 
                                g.DrawLine(blackPen, pt1, pt2);
                            }
                        }
                    }
                }
            }

            List<int> CurveX = new List<int>(); //holds x-coordinates for curved streets 
            CurveX = storingX.Values.ToList().Except(nonCurveX).ToList(); //has all the x-coordinates for curved streets 

            //drawing out curves
            foreach (Property i in community1.Props) //goes through all the properties in DeKalb 
            {
                foreach (int xCord in CurveX) //goes through all the curves 
                {
                    if (i.Xcord == xCord) //finds each curve in DeKalb
                    {
                        if ((i is House) || (i is Apartment)) //if it's residential
                        {
                            //create points to draw curve
                            Point pt1 = new Point(i.Xcord - 10, i.Ycord + 10);      //makes the top left point
                            Point pt2 = new Point(i.Xcord, i.Ycord);                //the center point
                            Point pt3 = new Point(i.Xcord + 10, i.Ycord + 10);      //makes the top right point
                            Point[] curvePoints = { pt1, pt2, pt3 };

                            g.DrawCurve(orangePen, curvePoints); //draws curve 
                        }
                    }
                }
            }

            foreach (Property i in community2.Props) //goes through all the properties in Sycamore 
            {
                foreach (int xCord in CurveX) //goes through all the curves 
                {
                    if (i.Xcord + 250 == xCord) //finds each curve in Sycamore
                    {
                        if ((i is House) || (i is Apartment)) //if it's residential
                        {
                            //create points to draw curve
                            Point pt1 = new Point(xCord - 10, i.Ycord + 10);
                            Point pt2 = new Point(xCord, i.Ycord);
                            Point pt3 = new Point(xCord + 10, i.Ycord + 10);
                            Point[] curvePoints = { pt1, pt2, pt3 };

                            g.DrawCurve(orangePen, curvePoints); //draws curve 
                        }
                    }
                }
            }
            map.Image = Canvas; //image gets updated on canvas 
        }



        /*private void map_MouseMove(object sender, MouseEventArgs e)
        {
            StringBuilder propInformation = new StringBuilder(); //displays all the info about properties 

            foreach (Property i in community1.Props) //goes through properties in DeKalb 
            {
                if ((e.X == i.Xcord) && (e.Y == i.Ycord)) //if the mouse hovers over a properties' coordinates 
                {
                    //below is the query for selecting a house or apartment 
                    var resQuery = from N in community1.Props
                                   where ((N.Xcord == e.X) && (N.Ycord == e.Y) && (N is House || N is Apartment))
                                   select N;

                    //below is the query for selecting a business
                    var businessQuery = from N in community1.Props
                                        where ((N.Xcord == e.X) && (N.Ycord == e.Y) && (N is Business))
                                        select N;

                    //below is the query for selecting a school 
                    var schoolQuery = from N in community1.Props
                                      where ((N.Xcord == e.X) && (N.Ycord == e.Y) && (N is School))
                                      select N;

                    //goes through what was selected, matches up owner and displays information
                    foreach (var res in resQuery)
                    {
                        var personQuery = from N in community1.Residents
                                          where (res.OwnerId == N.Id) //finds matching property owner id and person who owns it
                                          select N;

                        foreach (var person in personQuery)
                        {
                            if (res is House) //if it is a hosue, it will display the following 
                            {
                                propInformation.Clear();
                                propInformation.Append(res.Address + " " + res.City + ", " + res.State + " " + res.Zip + "\n");
                                propInformation.Append("Owner: " + person.FullName + " | " + res.ToString() + "\t\t$" + res.Price + "\n\n");
                            }
                            else if (res is Apartment) //if it is an apartment, it will display the following 
                            {
                                propInformation.Append(res.Address + " Apt. # " + (res as Apartment).Unit + " " + res.City + ", " + res.State + " " + res.Zip + "\n");
                                propInformation.Append("Owner: " + person.FullName + " | " + res.ToString() + "\t\t$" + res.Price + "\n\n");
                            }
                        }
                    }

                    int outofTown = 0; //this is for checking if the owner is from out of town 
                                       //goes through what was selected, matches up owner and displays information
                    foreach (var business in businessQuery)
                    {
                        var personQuery2 = from N in community1.Residents
                                           where (business.OwnerId == N.Id) //finds matching property owner id and person who owns it
                                           select N;

                        var personQuery3 = from N in community2.Residents
                                           where (business.OwnerId == N.Id) //finds matching property owner id and person who owns it
                                           select N;

                        foreach (var person in personQuery2) //if person is from DeKalb, will display the following about business 
                        {
                            propInformation.Append(business.Address + " " + business.City + ", " + business.State + " " + business.Zip + "\n");
                            propInformation.Append("Owner: " + person.FullName + " | " + "\t$" + business.Price);
                            propInformation.Append(business.ToString() + "\n\n");
                            outofTown++;
                        }

                        if (outofTown == 0) //this is for matching up to an owner that doesn't live in the same town as business
                        {
                            foreach (var person2 in personQuery3) //if person is from Sycamore, will dipslay the following about business 
                            {
                                propInformation.Append(business.Address + " " + business.City + ", " + business.State + " " + business.Zip + "\n");
                                propInformation.Append("Owner: " + person2.FullName + " | " + "\t$" + business.Price);
                                propInformation.Append(business.ToString() + "\n\n");
                            }
                        }
                    }

                    //goes through what was selected, matches up owner and displays information
                    foreach (var school in schoolQuery)
                    {
                        var personQuery = from N in community1.Residents //finds matching property owner id and person who owns it
                                          where (school.OwnerId == N.Id)
                                          select N;
                        foreach (var person in personQuery) //once owner is found, then displays the following information 
                        {
                            propInformation.Append(school.Address + " " + school.City + ", " + school.State + " " + school.Zip + " | Owner: " + person.FullName + "\n");
                            propInformation.Append(school.ToString() + "\n\n");
                        }
                    }

                    propInformation.Append("\n");

                    propertyInfo.SetToolTip(map, propInformation.ToString()); //this is the tooltip that will display the property info 
                }
                else
                {
                    propInformation.Clear(); //if mouse isn't hovering over a property, the tooltip with property info will be cleared 
                }
            }

            foreach (Property i in community2.Props) //goes through properties in DeKalb 
            {
                if ((e.X == i.Xcord + 250) && (e.Y == i.Ycord)) //if the mouse hovers over a properties' coordinates 
                {
                    //below is the query for selecting a house or apartment 
                    var resQuery = from N in community2.Props
                                   where ((N.Xcord + 250 == e.X) && (N.Ycord == e.Y) && (N is House || N is Apartment))
                                   select N;

                    //below is the query for selecting a business
                    var businessQuery = from N in community2.Props
                                        where ((N.Xcord + 250 == e.X) && (N.Ycord == e.Y) && (N is Business))
                                        select N;

                    //below is the query for selecting a school 
                    var schoolQuery = from N in community2.Props
                                      where ((N.Xcord + 250 == e.X) && (N.Ycord == e.Y) && (N is School))
                                      select N;

                    //goes through what was selected, matches up owner and displays information
                    foreach (var res in resQuery)
                    {
                        var personQuery = from N in community2.Residents
                                          where (res.OwnerId == N.Id) //finds matching property owner id and person who owns it
                                          select N;

                        foreach (var person in personQuery)
                        {
                            if (res is House) //if it is a hosue, it will display the following 
                            {
                                propInformation.Append(res.Address + " " + res.City + ", " + res.State + " " + res.Zip + "\n");
                                propInformation.Append("Owner: " + person.FullName + " | " + res.ToString() + "\t\t$" + res.Price + "\n\n");
                            }
                            else if (res is Apartment) //if it is an apartment, it will display the following 
                            {
                                propInformation.Append(res.Address + " Apt. # " + (res as Apartment).Unit + " " + res.City + ", " + res.State + " " + res.Zip + "\n");
                                propInformation.Append("Owner: " + person.FullName + " | " + res.ToString() + "\t\t$" + res.Price + "\n\n");
                            }
                        }
                    }

                    int outofTown = 0; //this is for checking if the owner is from out of town 
                                       //goes through what was selected, matches up owner and displays information
                    foreach (var business in businessQuery)
                    {
                        var personQuery2 = from N in community2.Residents
                                           where (business.OwnerId == N.Id) //finds matching property owner id and person who owns it
                                           select N;

                        var personQuery3 = from N in community1.Residents
                                           where (business.OwnerId == N.Id) //finds matching property owner id and person who owns it
                                           select N;

                        foreach (var person in personQuery2) //if person is from DeKalb, will display the following about business 
                        {
                            propInformation.Append(business.Address + " " + business.City + ", " + business.State + " " + business.Zip + "\n");
                            propInformation.Append("Owner: " + person.FullName + " | " + "\t$" + business.Price);
                            propInformation.Append(business.ToString() + "\n\n");
                            outofTown++;
                        }

                        if (outofTown == 0) //this is for matching up to an owner that doesn't live in the same town as business
                        {
                            foreach (var person2 in personQuery3) //if person is from Sycamore, will dipslay the following about business 
                            {
                                propInformation.Append(business.Address + " " + business.City + ", " + business.State + " " + business.Zip + "\n");
                                propInformation.Append("Owner: " + person2.FullName + " | " + "\t$" + business.Price);
                                propInformation.Append(business.ToString() + "\n\n");
                            }
                        }
                    }

                    //goes through what was selected, matches up owner and displays information
                    foreach (var school in schoolQuery)
                    {
                        var personQuery = from N in community2.Residents //finds matching property owner id and person who owns it
                                          where (school.OwnerId == N.Id)
                                          select N;
                        foreach (var person in personQuery) //once owner is found, then displays the following information 
                        {
                            propInformation.Append(school.Address + " " + school.City + ", " + school.State + " " + school.Zip + " | Owner: " + person.FullName + "\n");
                            propInformation.Append(school.ToString() + "\n\n");
                        }
                    }

                    propInformation.Append("\n");

                    propertyInfo.SetToolTip(map, propInformation.ToString()); //this is the tooltip that will display the property info 
                }
                else
                {
                    propInformation.Clear(); //if mouse isn't hovering over a property, the tooltip with property info will be cleared 
                }
            }
        }*/

        public static void CreateNewOrUpdateExisting<TKey, TValue>(Dictionary<TKey, TValue> map, TKey key, TValue value)
        {
            map[key] = value; //this either updates or creates a new dictionary 
        }

        private void updateDropDownMenu()
        {
            school_comboBox.Items.Clear(); //dropdown menu is cleared 
            school_comboBox.Items.Add("DeKalb:"); //labels are added 
            school_comboBox.Items.Add("------------------------------");

            foreach (Property i in community1.Props) //loop goes through each property in DeKalb and finds each school and adds it to dropdown menu 
            {
                if (i is School)
                {
                    school_comboBox.Items.Add((i as School).Name);
                }
            }

            school_comboBox.Items.Add("");
            school_comboBox.Items.Add("Sycamore:"); //label are added 
            school_comboBox.Items.Add("------------------------------");

            foreach (Property i in community2.Props) //loop goes through each property in Sycamore and finds each school and adds it to dropdown menu 
            {
                if (i is School)
                {
                    school_comboBox.Items.Add((i as School).Name);
                }
            }

            if (showAllRes_Check.Checked == true)
            {
                business_comboBox.Items.Clear(); //dropdown menu is cleared 
                business_comboBox.Items.Add("DeKalb:"); //label are added 
                business_comboBox.Items.Add("------------------------------");

                foreach (Property i in community1.Props) //loop goes through each property in DeKalb and finds each for sale residential property and adds it to dropdown menu 
                {
                    if (i is House || i is Apartment)
                    {
                        if (i.ForSale == true)
                        {
                            business_comboBox.Items.Add(i.Address);
                        }
                    }
                }

                business_comboBox.Items.Add("");
                business_comboBox.Items.Add("Sycamore:"); //label are added 
                business_comboBox.Items.Add("------------------------------");

                foreach (Property i in community2.Props) //loop goes through each property in Sycamore and finds each for sale residential property and adds it to dropdown menu 
                {
                    if (i is House || i is Apartment)
                    {
                        if (i.ForSale == true)
                        {
                            business_comboBox.Items.Add(i.Address);
                        }
                    }
                }
            }
            else
            {
                business_comboBox.Items.Clear(); //dropdown menu is cleared 
                if (max_trackBar.Value > 0)
                {

                    var resQuery = from N in community1.Props
                                   where ((min_trackBar.Value <= N.Price) && (max_trackBar.Value >= N.Price) && (N.ForSale == true) && (N is House || N is Apartment))
                                   select N;

                    var resQuery2 = from N in community2.Props
                                    where ((min_trackBar.Value <= N.Price) && (max_trackBar.Value >= N.Price) && (N.ForSale == true) && (N is House || N is Apartment))
                                    select N;

                    business_comboBox.Items.Clear(); //dropdown menu is cleared 
                    business_comboBox.Items.Add("DeKalb:"); //label are added 
                    business_comboBox.Items.Add("------------------------------");

                    //goes through what was selected, matches up owner and displays information
                    foreach (var res in resQuery)
                    {
                        business_comboBox.Items.Add(res.Address);
                    }

                    business_comboBox.Items.Add("");
                    business_comboBox.Items.Add("Sycamore:"); //label are added 
                    business_comboBox.Items.Add("------------------------------");

                    foreach (var res in resQuery2)
                    {
                        business_comboBox.Items.Add(res.Address);
                    }
                }
            }
        }

        private void min_trackBar_Scroll(object sender, EventArgs e)        //min price track bar
        {
            string minPrice; //takes in min price
            string maxPrice; //takes in max price 

            if (min_trackBar.Value > max_trackBar.Value) //makes the min and max values the same 
            {
                max_trackBar.Value = min_trackBar.Value;
            }

            minPrice = String.Format("{0: $0,0.00}", min_trackBar.Value); //formats the min and max prices so they look like prices 
            maxPrice = String.Format("{0: $0,0.00}", max_trackBar.Value);

            MinPrice_label.Text = "Min Price: " + minPrice; //label is added 
            MaxPrice_label.Text = "Max Price: " + maxPrice;
        }

        private void max_trackBar_Scroll(object sender, EventArgs e)        //max price track bar
        {
            string minPrice; //stores the min price 
            string maxPrice; //takes in max price 

            if (min_trackBar.Value > max_trackBar.Value) //makes the min and max values the same 
            {
                min_trackBar.Value = max_trackBar.Value;
            }

            minPrice = String.Format("{0: $0,0.00}", min_trackBar.Value); //formats the max price to look like a price 
            maxPrice = String.Format("{0: $0,0.00}", max_trackBar.Value);

            MinPrice_label.Text = "Min Price: " + minPrice; //label is added 
            MaxPrice_label.Text = "Max Price: " + maxPrice; //adds label 

            updateDropDownMenu();
        }

        private void forSalePriceRange()        //min and max price query button
        {
            string maxPrice; //takes in max price
            string minPrice; //takes in min price 
            minPrice = String.Format("{0: $0,0.00}", min_trackBar.Value); //formats it to look like a price 
            maxPrice = String.Format("{0: $0,0.00}", max_trackBar.Value);
            int results = 0; //this is for the display message of nothing from the ranges 

            //g.Clear(Color.Transparent); //clear map 
            results_richTextBox.Clear(); //clears text box 
            drawStreets(); //draws streets 

            if (residental_checkBox1.Checked) //if the residential checkbox is checked 
            {
                //below is the query for selecting a house or apartment 
                var resQuery = from N in community1.Props
                               where ((min_trackBar.Value <= N.Price) && (max_trackBar.Value >= N.Price) && (N.ForSale == true) && (N is House || N is Apartment))
                               select N;

                var resQuery2 = from N in community2.Props
                                where ((min_trackBar.Value <= N.Price) && (max_trackBar.Value >= N.Price) && (N.ForSale == true) && (N is House || N is Apartment))
                                select N;

                //goes through what was selected, matches up owner and displays information
                foreach (var res in resQuery)
                {
                    results++;
                    //Create residencial 
                    Rectangle rect = new Rectangle(res.Xcord, res.Ycord, 10, 10);
                    //Draw rectangle to screen.
                    g.DrawRectangle(purplePen, rect);
                }

                foreach (var res in resQuery2)
                {
                    results++;
                    //Create residencial 
                    Rectangle rect = new Rectangle(res.Xcord + 250, res.Ycord, 10, 10);
                    //Draw rectangle to screen.
                    g.DrawRectangle(purplePen, rect);
                }
            }
            if (businesss_checkBox.Checked) //if the business checkbox is checked 
            {
                //below is the query for selecting a business
                var businessQuery = from N in community1.Props
                                    where ((min_trackBar.Value <= N.Price) && (max_trackBar.Value >= N.Price) && (N.ForSale == true) && (N is Business))
                                    select N;

                var businessQuery2 = from N in community2.Props
                                     where ((min_trackBar.Value <= N.Price) && (max_trackBar.Value >= N.Price) && (N.ForSale == true) && (N is Business))
                                     select N;

                //goes through what was selected, matches up owner and displays information
                foreach (var business in businessQuery)
                {
                    results++;
                    //Create residencial 
                    Rectangle rect = new Rectangle(business.Xcord, business.Ycord, 10, 10);

                    //Draw rectangle to screen.
                    g.DrawRectangle(bluePen, rect);
                }

                foreach (var business in businessQuery2)
                {
                    results++;
                    //Create residencial 
                    Rectangle rect = new Rectangle(business.Xcord + 250, business.Ycord, 10, 10);

                    //Draw rectangle to screen.
                    g.DrawRectangle(bluePen, rect);
                }
            }
            if (school_checkBox.Checked) //if the school checkbox is checked 
            {
                //below is the query for selecting a school
                var schoolQuery1 = from N in community1.Props
                                   where ((min_trackBar.Value <= N.Price) && (max_trackBar.Value >= N.Price) && (N.ForSale == true) && (N is School))
                                   select N;

                var schoolQuery2 = from N in community2.Props
                                   where ((min_trackBar.Value <= N.Price) && (max_trackBar.Value >= N.Price) && (N.ForSale == true) && (N is School))
                                   select N;

                //goes through what was selected, matches up owner and displays information
                foreach (var school in schoolQuery1)
                {
                    results++;
                    //Create residencial 
                    Rectangle rect = new Rectangle(school.Xcord, school.Ycord, 10, 10);

                    //Draw rectangle to screen.
                    g.DrawRectangle(redPen, rect);
                }

                foreach (var school in schoolQuery2)
                {
                    results++;
                    //Create residencial 
                    Rectangle rect = new Rectangle(school.Xcord + 250, school.Ycord, 10, 10);

                    //Draw rectangle to screen.
                    g.DrawRectangle(redPen, rect);
                }
            }

            if (results == 0)
            {
                results_richTextBox.AppendText("\nThere are no for sale properties within the range you specified.\n\n");
            }

            map.Image = Canvas; //image gets updated on canvas
        }

        private void hiringBusinessRange()
        {
            int distanceWanted = (int)distanceBus_numericUpDown.Value; //gets the distance from the box
            int resX = 0; //house x coordinate
            int resY = 0; //house y coordinate 
            double powerOf1 = 0; //taking the power of the x 
            double powerOf2 = 0; //taking the power of the y 
            double distanceAway = 0; //distance between house and business
            double distanceDifference = 0; //calculating distance difference between house and business 
            double unitsAway = 0; //then put it into units 
            int results = 0; //this is for the display message of nothing from the ranges 
            bool inDeKalb = false; //checks if residences are in DeKalb 

            results_richTextBox.Clear(); //clears textbox
            drawStreets(); //draws streets 

            if (business_comboBox.SelectedIndex == -1) //a business has to be selected to move forward 
            {
                results_richTextBox.Clear();
                //results_richTextBox.AppendText("ERROR: You need to select a residence");
            }
            else
            {
                foreach (Property i in community1.Props) //for each property 
                {
                    if (i is House || i is Apartment) //if it is a hosue or apartment 
                    {
                        if (business_comboBox.SelectedItem.ToString() == i.Address) //and the address selected is equal to the property 
                        {
                            resX = i.Xcord; //then the x and y coordinates will be saved
                            resY = i.Ycord;
                            inDeKalb = true;

                            //Create residencial 
                            Rectangle rect = new Rectangle(i.Xcord, i.Ycord, 10, 10);
                            //Draw rectangle to screen.
                            g.DrawRectangle(purplePen, rect);
                        }
                    }
                }

                foreach (Property i in community2.Props) //for each property 
                {
                    if (i is House || i is Apartment) //if it is a hosue or apartment 
                    {
                        if (business_comboBox.SelectedItem.ToString() == i.Address) //and the address selected is equal to the property 
                        {
                            resX = i.Xcord + 250; //then the x and y coordinates will be saved
                            resY = i.Ycord;
                            inDeKalb = false;

                            //Create residencial 
                            Rectangle rect = new Rectangle(i.Xcord + 250, i.Ycord, 10, 10);
                            //Draw rectangle to screen.
                            g.DrawRectangle(purplePen, rect);
                        }
                    }
                }

                //DeKalb Query for finding businesses 
                var businessQuery = from N in community1.Props
                                    where (N is Business && (N as Business).ActiveRecruitment > 0)
                                    select N;

                //Sycamore Query for finding businesses 
                var businessQuery2 = from N in community2.Props
                                     where (N is Business && (N as Business).ActiveRecruitment > 0)
                                     select N;

                if (inDeKalb == true)
                {
                    foreach (var business in businessQuery) //goes through each business that matches the query 
                    {
                        powerOf1 = Math.Pow((resX - business.Xcord), 2); //does some math for calculating distance 
                        powerOf2 = Math.Pow((resY - business.Ycord), 2);
                        distanceAway = Math.Sqrt(powerOf1 + powerOf2);

                        if (distanceAway <= distanceWanted) //if what is calculated is within range 
                        {
                            results++;
                            distanceDifference = distanceWanted - distanceAway; //does more calculations for calculating units away 
                            unitsAway = distanceWanted - distanceDifference;

                            //Create business 
                            Rectangle rect = new Rectangle(business.Xcord, business.Ycord, 10, 10);
                            //Draw rectangle to screen.
                            g.DrawRectangle(bluePen, rect);
                        }
                    }
                }

                if (inDeKalb == false)
                {
                    foreach (var business in businessQuery2) //goes through each business that matches the query 
                    {
                        powerOf1 = Math.Pow((resX - (business.Xcord + 250)), 2); //does some math for calculating distance 
                        powerOf2 = Math.Pow((resY - business.Ycord), 2);
                        distanceAway = Math.Sqrt(powerOf1 + powerOf2);

                        if (distanceAway <= distanceWanted) //if what is calculated is within range 
                        {
                            results++;
                            distanceDifference = distanceWanted - distanceAway; //does more calculations for calculating units away 
                            unitsAway = distanceWanted - distanceDifference;

                            //Create business 
                            Rectangle rect = new Rectangle(business.Xcord + 250, business.Ycord, 10, 10);
                            //Draw rectangle to screen.
                            g.DrawRectangle(bluePen, rect);
                        }
                    }
                }

                //the following displays if there is nothing found 
                if (results == 0)
                {
                    results_richTextBox.AppendText("\nThere are no hiring businesses within the range you specified.\n\n");
                }

                map.Image = Canvas; //image gets updated on canvas
            }
        }

        private void forSaleSchoolRange()
        {
            int distanceWanted = (int)distanceSch_numericUpDown.Value; //gets the distance from the box
            int resX = 0; //house x coordinate
            int resY = 0; //house y coordinate 
            double powerOf1 = 0; //taking the power of the x 
            double powerOf2 = 0; //taking the power of the y 
            double distanceAway = 0; //distance between house and business
            double distanceDifference = 0; //calculating distance difference between house and school 
            double unitsAway = 0; //then put it into units 
            int results = 0; //this is for the display message of nothing from the ranges 
            bool inDeKalb = false; //checks if residences is in DeKalb

            results_richTextBox.Clear(); //clears textbox
            drawStreets(); //draws streets 

            if (school_comboBox.SelectedIndex == -1) //a school has to be selected to move forward 
            {
                results_richTextBox.Clear();
                //results_richTextBox.AppendText("ERROR: You need to select a School");
            }
            else
            {
                foreach (Property i in community1.Props) //for each property 
                {
                    if (i is School) //if it is a hosue or apartment 
                    {
                        if (school_comboBox.SelectedItem.ToString() == (i as School).Name) //and the name selected is equal to the school 
                        {
                            resX = i.Xcord; //then the x and y coordinates will be saved
                            resY = i.Ycord;

                            //Create school 
                            Rectangle rect = new Rectangle(i.Xcord, i.Ycord, 10, 10);
                            //Draw rectangle to screen.
                            g.DrawRectangle(redPen, rect);

                            inDeKalb = true;
                        }
                    }
                }

                foreach (Property i in community2.Props) //for each property 
                {
                    if (i is School) //if it is a hosue or apartment 
                    {
                        if (school_comboBox.SelectedItem.ToString() == (i as School).Name) //and the name selected is equal to the school 
                        {
                            resX = i.Xcord + 250; //then the x and y coordinates will be saved
                            resY = i.Ycord;

                            //Create school 
                            Rectangle rect = new Rectangle(i.Xcord + 250, i.Ycord, 10, 10);
                            //Draw rectangle to screen.
                            g.DrawRectangle(redPen, rect);

                            inDeKalb = false;
                        }
                    }
                }

                //DeKalb Query for finding residences 
                var schoolQuery = (from N in community1.Props
                                   where ((N is House || N is Apartment) && N.ForSale == true)
                                   select N);

                //Sycamore Query for finding residences 
                var schoolQuery2 = (from N in community2.Props
                                    where ((N is House || N is Apartment) && N.ForSale == true)
                                    select N);

                if (inDeKalb == true)
                {
                    foreach (var living in schoolQuery) //goes through each residence that matches the query 
                    {
                        powerOf1 = Math.Pow((resX - living.Xcord), 2); //does some math for calculating distance 
                        powerOf2 = Math.Pow((resY - living.Ycord), 2);
                        distanceAway = Math.Sqrt(powerOf1 + powerOf2);

                        if (distanceAway <= distanceWanted) //if what is calculated is within range 
                        {
                            results++;
                            distanceDifference = distanceWanted - distanceAway; //does more calculations for calculating units away 
                            unitsAway = distanceWanted - distanceDifference;

                            //Create residencial 
                            Rectangle rect = new Rectangle(living.Xcord, living.Ycord, 10, 10);
                            //Draw rectangle to screen.
                            g.DrawRectangle(purplePen, rect);
                        }
                    }
                }

                if (inDeKalb == false)
                {
                    foreach (var living in schoolQuery2) //goes through each business that matches the query 
                    {
                        powerOf1 = Math.Pow((resX - living.Xcord), 2); //does some math for calculating distance 
                        powerOf2 = Math.Pow((resY - living.Ycord), 2);
                        distanceAway = Math.Sqrt(powerOf1 + powerOf2);

                        if (distanceAway <= distanceWanted) //if what is calculated is within range 
                        {
                            results++;
                            distanceDifference = distanceWanted - distanceAway; //does more calculations for calculating units away 
                            unitsAway = distanceWanted - distanceDifference;

                            //Create residencial 
                            Rectangle rect = new Rectangle(living.Xcord, living.Ycord, 10, 10);
                            //Draw rectangle to screen.
                            g.DrawRectangle(purplePen, rect);
                        }
                    }
                }

                //the following displays if there is nothing found 
                if (results == 0)
                {
                    results_richTextBox.AppendText("\nThere are no for sale residences within the range you specified.\n\n");
                }

                map.Image = Canvas; //image gets updated on canvas
            }
        }

        private void specificRangeParameter()
        {
            int results = 0; //for checking if there are any query results 
            results_richTextBox.Clear();
            drawStreets(); //draws streets 

            if (!house_checkBox.Checked && !apartment_checkBox.Checked) //if neither a house or an apartment are selected 
            {
                results++;
                //results_richTextBox.AppendText("Plese select either a house or apartment");
            }
            else if (house_checkBox.Checked && apartment_checkBox.Checked) //if both a house and an apartment are selected
            {
                //when house and apartment are both checked, all the garage related stuff gets set to false 
                garage_checkBox.Checked = false;
                attachedGarage_checkbox.Checked = false;
                garage_checkBox.Visible = false;
                attachedGarage_checkbox.Visible = false;

                //DeKalb query that checks if criteria was met 
                var paraProp = from N in community1.Props
                               where ((N is Apartment || N is House) && ((N as Residential).Baths >= bath_numericUpDown.Value) && ((N as Residential).Bedrooms >= bednumericUpDown.Value) && ((N as Residential).Sqft >= minSq_numeric.Value) && (N.ForSale == true))
                               select N;

                //Sycamore query that checks if criteria was met 
                var paraProp2 = from N in community2.Props
                                where ((N is Apartment || N is House) && ((N as Residential).Baths >= bath_numericUpDown.Value) && ((N as Residential).Bedrooms >= bednumericUpDown.Value) && ((N as Residential).Sqft >= minSq_numeric.Value) && (N.ForSale == true))
                                select N;

                //goes through all the residences form the query 
                foreach (var res in paraProp)
                {
                    results++; //information is displayed about the house 

                    //Create residences 
                    Rectangle rect = new Rectangle(res.Xcord, res.Ycord, 10, 10);
                    //Draw rectangle to screen.
                    g.DrawRectangle(purplePen, rect);
                }

                //goes through all the residences form the query 
                foreach (var res in paraProp2)
                {
                    results++; //information is displayed about the house 

                    //Create residences 
                    Rectangle rect = new Rectangle(res.Xcord + 250, res.Ycord, 10, 10);
                    //Draw rectangle to screen.
                    g.DrawRectangle(purplePen, rect);
                }
            }
            else if (house_checkBox.Checked && !apartment_checkBox.Checked) //if only a house is checked
            {
                bool isGarage = false;
                bool isAttached = false;

                if (garage_checkBox.Checked) //checks to see if there is a garage
                {
                    isGarage = true;
                    if (attachedGarage_checkbox.Checked) //check if garage is attached 
                    {
                        isAttached = true;
                    }
                    else //otherwise detached 
                    {
                        isAttached = false;
                    }
                }
                else //or there isn't a garage 
                {
                    isGarage = false;
                    isAttached = false;
                }

                if (isGarage == false)
                {
                    //DeKalb query that checks if criteria was met 
                    var paraProp = from N in community1.Props
                                   where (N is House && ((N as House).Sqft >= minSq_numeric.Value && bath_numericUpDown.Value <= (N as House).Baths) && (bednumericUpDown.Value <= (N as House).Bedrooms) && (N.ForSale == true) && ((N as House).Garage == isGarage))
                                   select N;

                    //Sycamore query that checks if criteria was met 
                    var paraProp2 = from N in community2.Props
                                    where (N is House && ((N as House).Sqft >= minSq_numeric.Value && (N as House).Baths >= bath_numericUpDown.Value) && ((N as House).Bedrooms >= bednumericUpDown.Value) && (N.ForSale == true) && ((N as House).Garage == isGarage))
                                    select N;

                    //goes through all the houses form the query 
                    foreach (var houses in paraProp)
                    {
                        results++; //information is displayed about the house 

                        //Create residences 
                        Rectangle rect = new Rectangle(houses.Xcord, houses.Ycord, 10, 10);
                        //Draw rectangle to screen.
                        g.DrawRectangle(purplePen, rect);
                    }

                    //goes through all the houses form the query 
                    foreach (var houses in paraProp2)
                    {
                        results++; //information is displayed about the house 

                        //Create residences 
                        Rectangle rect = new Rectangle(houses.Xcord + 250, houses.Ycord, 10, 10);
                        //Draw rectangle to screen.
                        g.DrawRectangle(purplePen, rect);
                    }
                }
                else
                {
                    //DeKalb query that checks if criteria was met 
                    var paraProp = from N in community1.Props
                                   where (N is House && ((N as House).Sqft >= minSq_numeric.Value && bath_numericUpDown.Value <= (N as House).Baths) && (bednumericUpDown.Value <= (N as House).Bedrooms) && (N.ForSale == true) && ((N as House).Garage == isGarage) && ((N as House).AttachedGarage == isAttached))
                                   select N;

                    //Sycamore query that checks if criteria was met 
                    var paraProp2 = from N in community2.Props
                                    where (N is House && ((N as House).Sqft >= minSq_numeric.Value && (N as House).Baths >= bath_numericUpDown.Value) && ((N as House).Bedrooms >= bednumericUpDown.Value) && (N.ForSale == true) && ((N as House).Garage == isGarage) && ((N as House).AttachedGarage == isAttached))
                                    select N;

                    //goes through all the houses form the query 
                    foreach (var houses in paraProp)
                    {
                        results++; //information is displayed about the house 

                        //Create residences 
                        Rectangle rect = new Rectangle(houses.Xcord, houses.Ycord, 10, 10);
                        //Draw rectangle to screen.
                        g.DrawRectangle(purplePen, rect);
                    }

                    //goes through all the houses form the query 
                    foreach (var houses in paraProp2)
                    {
                        results++; //information is displayed about the house 

                        //Create residences 
                        Rectangle rect = new Rectangle(houses.Xcord + 250, houses.Ycord, 10, 10);
                        //Draw rectangle to screen.
                        g.DrawRectangle(purplePen, rect);
                    }
                }
            }
            else if (!house_checkBox.Checked && apartment_checkBox.Checked)
            {
                //when apartment is checked, all the garage related stuff gets set to false 
                garage_checkBox.Checked = false;
                attachedGarage_checkbox.Checked = false;
                garage_checkBox.Visible = false;
                attachedGarage_checkbox.Visible = false;

                //DeKalb query that checks if criteria was met 
                var paraProp = from N in community1.Props
                               where (N is Apartment && ((N as Apartment).Baths >= bath_numericUpDown.Value) && ((N as Apartment).Bedrooms >= bednumericUpDown.Value) && ((N as Apartment).Sqft >= minSq_numeric.Value) && (N.ForSale == true))
                               select N;

                //Sycamore query that checks if criteria was met 
                var paraProp2 = from N in community2.Props
                                where (N is Apartment && ((N as Apartment).Baths >= bath_numericUpDown.Value) && ((N as Apartment).Bedrooms >= bednumericUpDown.Value) && ((N as Apartment).Sqft >= minSq_numeric.Value) && (N.ForSale == true))
                                select N;

                //goes through all the apartments form the query 
                foreach (var apartments in paraProp)
                {
                    results++; //information is displayed about the house 

                    //Create residences 
                    Rectangle rect = new Rectangle(apartments.Xcord, apartments.Ycord, 10, 10);
                    //Draw rectangle to screen.
                    g.DrawRectangle(purplePen, rect);
                }

                //goes through all the apartments form the query 
                foreach (var apartments in paraProp2)
                {
                    results++; //information is displayed about the house 

                    //Create residences 
                    Rectangle rect = new Rectangle(apartments.Xcord + 250, apartments.Ycord, 10, 10);
                    //Draw rectangle to screen.
                    g.DrawRectangle(purplePen, rect);
                }
            }

            //displays if there are no results 
            if (results == 0)
            {
                results_richTextBox.AppendText("\nThere are no for sale residences within the range you specified.\n\n");
            }

            map.Image = Canvas; //image gets updated on canvas

        }
        
        //updates the canvas from the query 
        private void enterButton_Query(object sender, EventArgs e)
        {
            g.Clear(Color.Transparent); //clears canvas 
            zoomBarLabel.Text = "Zoom Bar"; //displays zoom value 
            zoomBar.Value = 100;
            showZoomLabel.Text = "|----|----|"; //shows on the map how much is being zoomed in 

            forSalePriceRange(); //displays properties within price range 
            hiringBusinessRange(); //displays business' within resident range 
            forSaleSchoolRange(); //displays residences within school range
            specificRangeParameter(); //displays residences based on features desired

            map.Image = Canvas; //image gets updated on canvas
            
        }

        //checks to see if it is an apartment 
        private void apartment_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            garage_checkBox.Checked = false; //clears out the garage and attached garage checkmark 
            attachedGarage_checkbox.Checked = false;

            if (apartment_checkBox.Checked) //if apartment is checked 
            {
                garage_checkBox.Visible = false; //all the garage stuff will disappear
                attachedGarage_checkbox.Visible = false;
            }
            else
            {
                garage_checkBox.Visible = true; //otherwise it will show 
            }
        }

        //shows garage attached boxes
        private void garage_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            attachedGarage_checkbox.Checked = false; //clears out the attached garage checkmark
            if (garage_checkBox.Checked) //if garage is checked
            {
                attachedGarage_checkbox.Visible = true;  //then attached garage will appear
            }
            else
            {
                attachedGarage_checkbox.Visible = false; //otherwise it won't 
            }
        }

        private void showAllRes_Check_CheckedChanged(object sender, EventArgs e)
        {
            updateDropDownMenu(); //if show residence checkbox changes, the for sale residence dropdown should change 
        }

        private void distanceSch_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            updateDropDownMenu(); //if the distance value changes, the for sale residence dropdown should change 
        }

        //zoom for the track bar
        private void zoomBar_Scroll(object sender, EventArgs e)
        {
            zoomBarLabel.Text = "Zoom Bar: " + zoomBar.Value + "%"; //displays zoom value 
            zoomCanvas();         //call the zoom function
        }

        //zoom for the mouse wheel
        private void map_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0) //if mouse scroll is moving up 
            {
                if (zoomBar.Value < 175)
                {
                    zoomBar.Value += 25;                
                }
                //prevents crashing when scrolling too far in the up direction
                else
                {
                    zoomBar.Value = 175;
                }
            }

            if (e.Delta < 0) //if mouse scroll is moving down 
            {
                if (zoomBar.Value > 100)
                {
                    zoomBar.Value -= 25;                
                }
                //prevents crashing when scrolling too far in the down direction
                else
                {
                    zoomBar.Value = 100;
                }
            }
            zoomBarLabel.Text = "Zoom Bar: " + zoomBar.Value + "%"; //displays zoom value 
            zoomCanvas();   //call zoom method
        }

        //method for calling zoom
        public void zoomCanvas()      //zoom in on the map 
        {
            double zoomFactor = 1.0;

            if (zoomBar.Value >= 100 && zoomBar.Value < 125)
            {
                showZoomLabel.Text = "|----|----|"; //shows on the map how much is being zoomed in 

                Size newSize = new Size((int)(500 * zoomFactor), (int)(250 * zoomFactor));
                Bitmap newCanvas = new Bitmap(Canvas, newSize);

                map.Image = newCanvas;
            }
            else if (zoomBar.Value >= 125 && zoomBar.Value < 150)
            {
                showZoomLabel.Text = "|------|------|";

                zoomFactor = 1.25; //zoomfactor is changed and new zoomed in image is drawn to screen 
                Size newSize = new Size((int)(500 * zoomFactor), (int)(250 * zoomFactor));
                Bitmap newCanvas = new Bitmap(Canvas, newSize);

                map.Image = newCanvas;
            }
            else if (zoomBar.Value >= 150 && zoomBar.Value < 175)
            {
                showZoomLabel.Text = "|--------|--------|";

                zoomFactor = 1.5; //zoomfactor is changed and new zoomed in image is drawn to screen 
                Size newSize = new Size((int)(500 * zoomFactor), (int)(250 * zoomFactor));
                Bitmap newCanvas = new Bitmap(Canvas, newSize);

                map.Image = newCanvas;
            }
            else if (zoomBar.Value == 175)
            {
                showZoomLabel.Text = "|----------|----------|";

                zoomFactor = 1.75; //zoomfactor is changed and new zoomed in image is drawn to screen 
                Size newSize = new Size((int)(500 * zoomFactor), (int)(250 * zoomFactor));
                Bitmap newCanvas = new Bitmap(Canvas, newSize);         //this is the new image

                map.Image = newCanvas;
            }
        }
        
        //this will be for moving the map. Holding the mouse will allow you to drag it
        private Point startingPoint = Point.Empty;
        private Point movingPoint = Point.Empty;
        bool drag = false;          //if you are trying to drag
        private void map_MouseDown(object sender, MouseEventArgs e)     //starts when you click and hold the map
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) //this is when the image gets clicked on 
            {
                startingPoint = new Point(e.Location.X, e.Location.Y);      //grabs the starting points
                drag = true;
            }
        }
        //when you relase the map, turn the drag bool to false
        private void map_MouseUp(object sender, MouseEventArgs e)     //when you let go of the mouse button
        {
            drag = false;
        }
        
        //method to calculate the displacement of the points from moving
        private Point movedPoint = Point.Empty; //the new moved point
        private void moveMapCord(Point start, Point moveTo)  //pass in the starting cords
        {
            movedPoint = new Point((start.X - moveTo.X), (start.Y - moveTo.Y));     //new cords are the starting minus the moved to 

            double zoomVal = 1;

            if(zoomBar.Value == 125)
            {
                zoomVal = 1.25;
            }
            else if(zoomBar.Value == 150)
            {
                zoomVal = 1.5;
            }
            else if(zoomBar.Value == 175)
            {
                zoomVal = 1.75;
            }
            else
            {
                zoomVal = 1;
            }

            map_paint(movedPoint, zoomVal);     //call the paint method again
        }
        
        //the actions done when the mouse moves
        private void map_MouseMove(object sender, MouseEventArgs e)     //when you move the mouse and hold the map
        {
            results_richTextBox.Clear();
            results_richTextBox.AppendText(e.Location.ToString());      //to see where you ar e on the map. helpful for finding the right point for info
            
            if (drag == true && zoomBar.Value >100)         //want to move the map when it is held down and zoomed in at least once
            {
                Cursor.Current = Cursors.NoMove2D;          //change the cursor to show you can move it

                moveMapCord(startingPoint, e.Location);     //passs in the locations of the starting point and where the mouse is now
            }
            
            //if the user is not dragging the map, we want to display the houses
            else
            {
                StringBuilder propInformation = new StringBuilder(); //displays all the info about properties 

                if (propInformation.Length > 0)
                {
                    propInformation.Clear();
                }

                foreach (Property i in community1.Props) //goes through properties in DeKalb 
                {
                    if ((e.X == i.Xcord * ((int)zoomBar.Value / 100)) && (e.Y == i.Ycord * ((int)zoomBar.Value/100))) //if the mouse hovers over a properties' coordinates 
                    {
                        //below is the query for selecting a house or apartment 
                        var resQuery = from N in community1.Props
                                       where ((N.Xcord == e.X) && (N.Ycord == e.Y) && (N is House || N is Apartment))
                                       select N;

                        //below is the query for selecting a business
                        var businessQuery = from N in community1.Props
                                            where ((N.Xcord == e.X) && (N.Ycord == e.Y) && (N is Business))
                                            select N;

                        //below is the query for selecting a school 
                        var schoolQuery = from N in community1.Props
                                          where ((N.Xcord == e.X) && (N.Ycord == e.Y) && (N is School))
                                          select N;

                        //goes through what was selected, matches up owner and displays information
                        foreach (var res in resQuery)
                        {
                            var personQuery = from N in community1.Residents
                                              where (res.OwnerId == N.Id) //finds matching property owner id and person who owns it
                                              select N;

                            foreach (var person in personQuery)
                            {
                                if (res is House) //if it is a hosue, it will display the following 
                                {
                                    propInformation.Append(res.Address + " " + res.City + ", " + res.State + " " + res.Zip + "\n");
                                    propInformation.Append("Owner: " + person.FullName + " | " + res.ToString() + "\t\t$" + res.Price + "\n\n");
                                }
                                else if (res is Apartment) //if it is an apartment, it will display the following 
                                {
                                    propInformation.Append(res.Address + " Apt. # " + (res as Apartment).Unit + " " + res.City + ", " + res.State + " " + res.Zip + "\n");
                                    propInformation.Append("Owner: " + person.FullName + " | " + res.ToString() + "\t\t$" + res.Price + "\n\n");
                                }
                            }
                        }

                        int outofTown = 0; //this is for checking if the owner is from out of town 
                                           //goes through what was selected, matches up owner and displays information
                        foreach (var business in businessQuery)
                        {
                            var personQuery2 = from N in community1.Residents
                                               where (business.OwnerId == N.Id) //finds matching property owner id and person who owns it
                                               select N;

                            var personQuery3 = from N in community2.Residents
                                               where (business.OwnerId == N.Id) //finds matching property owner id and person who owns it
                                               select N;

                            foreach (var person in personQuery2) //if person is from DeKalb, will display the following about business 
                            {
                                propInformation.Append(business.Address + " " + business.City + ", " + business.State + " " + business.Zip + "\n");
                                propInformation.Append("Owner: " + person.FullName + " | " + "\t$" + business.Price);
                                propInformation.Append(business.ToString() + "\n\n");
                                outofTown++;
                            }

                            if (outofTown == 0) //this is for matching up to an owner that doesn't live in the same town as business
                            {
                                foreach (var person2 in personQuery3) //if person is from Sycamore, will dipslay the following about business 
                                {
                                    propInformation.Append(business.Address + " " + business.City + ", " + business.State + " " + business.Zip + "\n");
                                    propInformation.Append("Owner: " + person2.FullName + " | " + "\t$" + business.Price);
                                    propInformation.Append(business.ToString() + "\n\n");
                                }
                            }
                        }

                        //goes through what was selected, matches up owner and displays information
                        foreach (var school in schoolQuery)
                        {
                            var personQuery = from N in community1.Residents //finds matching property owner id and person who owns it
                                              where (school.OwnerId == N.Id)
                                              select N;
                            foreach (var person in personQuery) //once owner is found, then displays the following information 
                            {
                                propInformation.Append(school.Address + " " + school.City + ", " + school.State + " " + school.Zip + " | Owner: " + person.FullName + "\n");
                                propInformation.Append(school.ToString() + "\n\n");
                            }
                        }

                        propInformation.Append("\n");

                        propertyInfo.SetToolTip(map, propInformation.ToString()); //this is the tooltip that will display the property info
                    }
                    else
                    {
                        propInformation.Clear(); //if mouse isn't hovering over a property, the tooltip with property info will be cleared 
                    }
                }

                foreach (Property i in community2.Props) //goes through properties in DeKalb 
                {
                    if ((e.X == i.Xcord + 250) && (e.Y == i.Ycord)) //if the mouse hovers over a properties' coordinates 
                    {
                        //below is the query for selecting a house or apartment 
                        var resQuery = from N in community2.Props
                                       where ((N.Xcord + 250 == e.X) && (N.Ycord == e.Y) && (N is House || N is Apartment))
                                       select N;

                        //below is the query for selecting a business
                        var businessQuery = from N in community2.Props
                                            where ((N.Xcord + 250 == e.X) && (N.Ycord == e.Y) && (N is Business))
                                            select N;

                        //below is the query for selecting a school 
                        var schoolQuery = from N in community2.Props
                                          where ((N.Xcord + 250 == e.X) && (N.Ycord == e.Y) && (N is School))
                                          select N;

                        //goes through what was selected, matches up owner and displays information
                        foreach (var res in resQuery)
                        {
                            var personQuery = from N in community2.Residents
                                              where (res.OwnerId == N.Id) //finds matching property owner id and person who owns it
                                              select N;

                            foreach (var person in personQuery)
                            {
                                if (res is House) //if it is a hosue, it will display the following 
                                {
                                    propInformation.Append(res.Address + " " + res.City + ", " + res.State + " " + res.Zip + "\n");
                                    propInformation.Append("Owner: " + person.FullName + " | " + res.ToString() + "\t\t$" + res.Price + "\n\n");
                                }
                                else if (res is Apartment) //if it is an apartment, it will display the following 
                                {
                                    propInformation.Append(res.Address + " Apt. # " + (res as Apartment).Unit + " " + res.City + ", " + res.State + " " + res.Zip + "\n");
                                    propInformation.Append("Owner: " + person.FullName + " | " + res.ToString() + "\t\t$" + res.Price + "\n\n");
                                }
                            }
                        }

                        int outofTown = 0; //this is for checking if the owner is from out of town 
                                           //goes through what was selected, matches up owner and displays information
                        foreach (var business in businessQuery)
                        {
                            var personQuery2 = from N in community2.Residents
                                               where (business.OwnerId == N.Id) //finds matching property owner id and person who owns it
                                               select N;

                            var personQuery3 = from N in community1.Residents
                                               where (business.OwnerId == N.Id) //finds matching property owner id and person who owns it
                                               select N;

                            foreach (var person in personQuery2) //if person is from DeKalb, will display the following about business 
                            {
                                propInformation.Append(business.Address + " " + business.City + ", " + business.State + " " + business.Zip + "\n");
                                propInformation.Append("Owner: " + person.FullName + " | " + "\t$" + business.Price);
                                propInformation.Append(business.ToString() + "\n\n");
                                outofTown++;
                            }

                            if (outofTown == 0) //this is for matching up to an owner that doesn't live in the same town as business
                            {
                                foreach (var person2 in personQuery3) //if person is from Sycamore, will dipslay the following about business 
                                {
                                    propInformation.Append(business.Address + " " + business.City + ", " + business.State + " " + business.Zip + "\n");
                                    propInformation.Append("Owner: " + person2.FullName + " | " + "\t$" + business.Price);
                                    propInformation.Append(business.ToString() + "\n\n");
                                }
                            }
                        }

                        //goes through what was selected, matches up owner and displays information
                        foreach (var school in schoolQuery)
                        {
                            var personQuery = from N in community2.Residents //finds matching property owner id and person who owns it
                                              where (school.OwnerId == N.Id)
                                              select N;
                            foreach (var person in personQuery) //once owner is found, then displays the following information 
                            {
                                propInformation.Append(school.Address + " " + school.City + ", " + school.State + " " + school.Zip + " | Owner: " + person.FullName + "\n");
                                propInformation.Append(school.ToString() + "\n\n");
                            }
                        }

                        propInformation.Append("\n");

                        propertyInfo.SetToolTip(map, propInformation.ToString()); //this is the tooltip that will display the property info 
                    }
                    else
                    {
                        propInformation.Clear(); //if mouse isn't hovering over a property, the tooltip with property info will be cleared 
                    }
                }
            }
        }

        //reset the map back to the defult layout
        private void resetbutton_Click(object sender, EventArgs e)
        {
            g.Clear(Color.Transparent); //clears canvas 
            zoomBarLabel.Text = "Zoom Bar"; //displays zoom value 
            zoomBar.Value = 100;
            showZoomLabel.Text = "|----|----|"; //shows on the map how much is being zoomed in 

            startingPoint.X = 0;        //set the starting points to 0,0
            startingPoint.Y = 0;

            map_paint(startingPoint, startingZoom);     //call the paint function
        }
    }
}