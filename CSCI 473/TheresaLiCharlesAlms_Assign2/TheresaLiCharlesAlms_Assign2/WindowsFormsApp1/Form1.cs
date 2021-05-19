/********************************************************************
CSCI 473 - Assignment 2 - Spring 2020

Programmers: Theresa Li (Z1814730), Charles Alms (Z1797837) 
Section:    1
TA:         Jennifer Ho & Sridivya Pagadala
Date Due:   2/13/20

Purpose:    This program is teaching us to make a real estate GUI using 
            C#
*********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheresaLiCharlesAlms_Assign2
{
    public partial class Form1 : Form
    {
        //objects for the DeKalb community 
        private Person person1 = null; //person object
        private House house1 = null; //house object
        private Apartment apartment1 = null; //apartment object
        private Community community1 = new Community(); //community object

        //objects for the Sycamore community 
        private Person person2 = null;
        private House house2 = null;
        private Apartment apartment2 = null;
        private Community community2 = new Community();

        Dictionary<uint, Person> personInfo = new Dictionary<uint, Person>(); //dictionary of person objects 
        Dictionary<uint, Property> propertyInfo = new Dictionary<uint, Property>(); //dictionary of property objects

        /*
         * DO NOT TOUCH ANY INPUT FILE STUFF, IT WORKS
         */
        public Form1()
        {
            InitializeComponent();

            //the DeKalb person file
            using (StreamReader inFile = new StreamReader("..\\..\\DeKalb\\p.txt")) //this is for reading in the input file 
            {
                String readFile = inFile.ReadLine(); //first we read one line 
                String[] inputPerson;

                while (readFile != null) //if the line isn't null, it will keep on storing and reading 
                {
                    //***********************Actually, I did change something fundamental about the Persons input files. 
                    //***********************They now allow for residents to be initially defined as residing at multiple residences from the very beginning. 

                    inputPerson = readFile.Split('\t'); //it is splitting based on whether or not there is a tab between the two attributes
                    person1 = new Person(inputPerson); //person object is reading in the input file 
                    community1.Residents.Add(person1); //person object is added to the community 
                    personInfo.Add(person1.Id, person1); //person object is added to the sorted dictionary

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
                    //***********************Actually, I did change something fundamental about the Persons input files. 
                    //***********************They now allow for residents to be initially defined as residing at multiple residences from the very beginning. 

                    inputPerson = readFile.Split('\t'); //it is splitting based on whether or not there is a tab between the two attributes
                    person2 = new Person(inputPerson); //person object is reading in the input file 
                    community2.Residents.Add(person2); //person object is added to the community 
                    personInfo.Add(person2.Id, person2); //person object is added to the sorted dictionary

                    readFile = inFile.ReadLine(); //continue reading
                }
            }

            //the DeKalb house file
            using (StreamReader inFile = new StreamReader("..\\..\\DeKalb\\r.txt")) //this is for reading in the input file 
            {
                String readFile = inFile.ReadLine(); //first we read one line 
                String[] inputProperty1;

                while (readFile != null) //if the line isn't null, it will keep on storing and reading 
                {
                    inputProperty1 = readFile.Split('\t'); //it is splitting based on whether or not there is a tab between the two attributes
                    house1 = new House(inputProperty1); //house object is reading in the input file 
                    community1.Props.Add(house1); //house object is added to the community 

                    propertyInfo.Add(house1.Id, house1); //house object is added to the sorted set

                    readFile = inFile.ReadLine(); //continue reading 
                }
            }

            //the Sycamore house file
            using (StreamReader inFile = new StreamReader("..\\..\\Sycamore\\r.txt")) //this is for reading in the input file 
            {
                String readFile = inFile.ReadLine(); //first we read one line 
                String[] inputProperty;

                while (readFile != null) //if the line isn't null, it will keep on storing and reading 
                {
                    inputProperty = readFile.Split('\t'); //it is splitting based on whether or not there is a tab between the two attributes
                    house2 = new House(inputProperty); //house object is reading in the input file 
                    community2.Props.Add(house2); //house object is added to the community 

                    propertyInfo.Add(house2.Id, house2); //house object is added to the sorted set

                    readFile = inFile.ReadLine(); //continue reading 
                }
            }

            //the DeKalb apartment file
            using (StreamReader inFile = new StreamReader("..\\..\\DeKalb\\a.txt")) //this is for reading in the input file 
            {
                String readFile = inFile.ReadLine(); //first we read one line 
                String[] inputProperty2;

                while (readFile != null) //if the line isn't null, it will keep on storing and reading 
                {
                    inputProperty2 = readFile.Split('\t'); //it is splitting based on whether or not there is a tab between the two attributes
                    apartment1 = new Apartment(inputProperty2); //apartment object is reading in the input file
                    community1.Props.Add(apartment1); //apartment object is added to the community 

                    propertyInfo.Add(apartment1.Id, apartment1); //apartment object is added to the sorted set

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

                    propertyInfo.Add(apartment2.Id, apartment2); //apartment object is added to the sorted set

                    readFile = inFile.ReadLine(); //continue reading 
                }
            }

            //if neither of the radio buttons are checked, it will display the population 
            if (!dekalb_radioButton.Checked && !sycamore_radioButton.Checked)
            {
                output_RichTextBox.AppendText("There are " + community1.Population + " people living in DeKalb.");
                output_RichTextBox.AppendText("\nThere are " + community2.Population + " people living in Sycamore.");
            }
        }

        /*
         * DO NOT TOUCH THIS, IT WORKS
         */
        private void dekalb_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbDeKalb = sender as RadioButton; //radio button is created 

            if (rbDeKalb == null)
            {
                MessageBox.Show("Sender is not a RadioButton"); //this is if both radiobuttons are null 
                return;
            }

            if (rbDeKalb.Checked)           //if DeKalb is checked
            {
                updateLists(true);  //this method will be called to fill in the lists 
                output_RichTextBox.Clear();
                output_RichTextBox.AppendText("The residents and properties of DeKalb are now listed."); //feedback to the user 
            }
            else
            {
                person_listBox.Items.Clear(); //clears everything once done 
                residence_listBox.Items.Clear();
                output_RichTextBox.Clear();
            }
        }

        /*
         * DO NOT TOUCH THIS, IT WORKS
         */
        private void sycamore_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbSycamore = sender as RadioButton; //radio button is created           

            if (rbSycamore == null) //this is if both radiobuttons are null 
            {
                MessageBox.Show("Sender is not a RadioButton");
                return;
            }

            if (rbSycamore.Checked)         //if Sycamore is checked
            {
                updateLists(false); //this will update the lists
                output_RichTextBox.Clear();
                output_RichTextBox.AppendText("The residents and properties of Sycamore are now listed."); //feedback to the user 
            }
            else
            {
                person_listBox.Items.Clear(); //clears out everything when done 
                residence_listBox.Items.Clear();
                output_RichTextBox.Clear();
            }
        }

        /*
         * DO NOT TOUCH THIS, IT WORKS
         */
        private void person_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            output_RichTextBox.Clear(); //clears output text 

            string[] parseList = person_listBox.SelectedItem.ToString().Split('\t'); //takes selected item and splits it

            //DeKalb
            foreach (Person i in community1.Residents) //cycles through each person in the DeKalb community and finds the right one 
            {
                if (parseList[0] == i.FirstName)
                {
                    if (parseList[1] == i.Age.ToString())
                    {
                        if (parseList[2] == i.Occupation)
                        {
                            foreach (KeyValuePair<uint, Property> pro1 in propertyInfo) //then it matches property info 
                            {
                                if (i.ResidentId == pro1.Key)
                                {
                                    //then it outputs the information to the textbox
                                    output_RichTextBox.AppendText(i.FullName + ", Age (" + i.Age + "), Occupation: " + i.Occupation + ", who resides at: " + "\n\t" + pro1.Value + "\n\n### END OUTPUT ###");
                                }
                            }
                        }
                    }
                }
            }

            //Sycamore 
            foreach (Person i in community2.Residents) //cycles through each person in the Sycamore community and finds the right one 
            {
                if (parseList[0] == i.FirstName) //cycles through each person in the DeKalb community and finds the right one 
                {
                    if (parseList[1] == i.Age.ToString())
                    {
                        if (parseList[2] == i.Occupation)
                        {
                            foreach (KeyValuePair<uint, Property> pro1 in propertyInfo) //then it matches property info 
                            {
                                if (i.ResidentId == pro1.Key)
                                {
                                    //then it outputs the information to the textbox
                                    output_RichTextBox.AppendText(i.FullName + ", Age (" + i.Age + "), Occupation: " + i.Occupation + ", who resides at: " + "\n\t" + pro1.Value);
                                }
                            }
                        }
                    }
                }
            }
        }

        /*
         * DO NOT TOUCH THIS, IT WORKS
         */
        private void residence_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            output_RichTextBox.Clear(); //clears output text 

            string[] parseList = residence_listBox.SelectedItem.ToString().Split('\t'); //takes selected item and splits it

            int oneOwner = 0; //there can only be one owner that ownes the house 
            int emptyProp = 0;

            //DeKalb 
            foreach (Property i in community1.Props) //cycles through each property in the DeKalb community and finds the right one 
            {
                if (i is House) //if it is a house 
                {
                    if (parseList[0] == i.Address) //if the selected address and the property address match
                    {
                        foreach (Person j in community1.Residents) //look for who owns that house 
                        {
                            if (i.Id == j.ResidentId) //by checking if the ids match 
                            {
                                //then it outputs the information to the textbox
                                if (oneOwner == 0)
                                {
                                    output_RichTextBox.AppendText("Residents living at " + i.Address + ", " + i.City + ", owned by " + j.FullName + ": ");
                                    output_RichTextBox.AppendText("\n----------------------------------------------------------------------------------------------");
                                    oneOwner++;
                                }
                                emptyProp = 0; //it is not empty 
                                output_RichTextBox.AppendText("\n" + j.FullName + "\t" + j.Age + "\t" + j.Occupation);
                            }
                        }

                        emptyProp++; //it is empty 
                        if (emptyProp > 0 && oneOwner == 0) //if empty, display the following 
                        {
                            output_RichTextBox.AppendText("Residents living at " + i.Address + ", " + i.City + ", owned by : ");
                            output_RichTextBox.AppendText("\n----------------------------------------------------------------------------------------------");
                            output_RichTextBox.AppendText("\n\n### END OUTPUT ###");
                        }
                    }
                }
                else if (i is Apartment) //if it is an apartment
                {
                    if (parseList[0] == i.Address) //if the selected address and the property address match
                    {
                        if (parseList[2] == i.Apt) //if the selected apartment # and the property apartment # match
                        {
                            foreach (Person j in community1.Residents) //look for who owns that apartment 
                            {
                                if (i.Id == j.ResidentId) //by checking if the ids match 
                                {
                                    //then it outputs the information to the textbox
                                    if (oneOwner == 0)
                                    {
                                        output_RichTextBox.AppendText("Residents living at " + i.Address + " #" + i.Apt + ", " + i.City + ", owned by " + j.FullName + ": ");
                                        output_RichTextBox.AppendText("\n----------------------------------------------------------------------------------------------");
                                        oneOwner++;
                                    }
                                    emptyProp = 0; //not empty 
                                    output_RichTextBox.AppendText("\n" + j.FullName + "\t" + j.Age + "\t" + j.Occupation);
                                }
                            }

                            emptyProp++; //it is empty 
                            if (emptyProp > 0 && oneOwner == 0) //if empty, display the following 
                            {
                                output_RichTextBox.AppendText("Residents living at " + i.Address + " #" + i.Apt + ", " + i.City + ", owned by : ");
                                output_RichTextBox.AppendText("\n----------------------------------------------------------------------------------------------");
                                output_RichTextBox.AppendText("\n\n### END OUTPUT ###");
                            }
                        }
                    }
                }
            }

            //Sycamore
            foreach (Property i in community2.Props) //cycles through each property in the DeKalb community and finds the right one 
            {
                if (i is House) //if it is a house 
                {
                    if (parseList[0] == i.Address) //if the selected address and the property address match
                    {
                        foreach (Person j in community2.Residents) //look for who owns that house 
                        {
                            if (i.Id == j.ResidentId) //by checking if the ids match 
                            {
                                //then it outputs the information to the textbox
                                if (oneOwner == 0)
                                {
                                    output_RichTextBox.AppendText("Residents living at " + i.Address + ", " + i.City + ", owned by " + j.FullName + ": ");
                                    output_RichTextBox.AppendText("\n----------------------------------------------------------------------------------------------");
                                    oneOwner++;
                                }
                                emptyProp = 0; //not empty
                                output_RichTextBox.AppendText("\n" + j.FullName + "\t" + j.Age + "\t" + j.Occupation);
                            }
                        }

                        emptyProp++; //it is empty 
                        if (emptyProp > 0 && oneOwner == 0) //if empty, display the following 
                        {
                            output_RichTextBox.AppendText("Residents living at " + i.Address + ", " + i.City + ", owned by : ");
                            output_RichTextBox.AppendText("\n----------------------------------------------------------------------------------------------");
                            output_RichTextBox.AppendText("\n\n### END OUTPUT ###");
                        }
                    }
                }
                else if (i is Apartment) //if it is an apartment
                {
                    if (parseList[0] == i.Address) //if the selected address and the property address match
                    {
                        if (parseList[2] == i.Apt) //if the selected apartment # and the property apartment # match
                        {
                            foreach (Person j in community2.Residents) //look for who owns that apartment 
                            {
                                if (i.Id == j.ResidentId) //by checking if the ids match 
                                {
                                    //then it outputs the information to the textbox
                                    if (oneOwner == 0)
                                    {
                                        output_RichTextBox.AppendText("Residents living at " + i.Address + " #" + i.Apt + ", " + i.City + ", owned by " + j.FullName + ": ");
                                        output_RichTextBox.AppendText("\n----------------------------------------------------------------------------------------------");
                                        oneOwner++;
                                    }
                                    emptyProp = 0; //not empty 
                                    output_RichTextBox.AppendText("\n" + j.FullName + "\t" + j.Age + "\t" + j.Occupation);
                                }
                            }

                            emptyProp++; //it is empty 
                            if (emptyProp > 0 && oneOwner == 0) //if empty, display the following 
                            {
                                output_RichTextBox.AppendText("Residents living at " + i.Address + " #" + i.Apt + ", " + i.City + ", owned by : ");
                                output_RichTextBox.AppendText("\n----------------------------------------------------------------------------------------------");
                                output_RichTextBox.AppendText("\n\n### END OUTPUT ###");
                            }
                        }
                    }
                }
            }
        }

        /*
         * DO NOT TOUCH THIS, IT WORKS
         */
        private void updateLists(bool isDeKalb) //this is for generating people and properties for the two lists
        {
            person_listBox.Items.Clear();
            residence_listBox.Items.Clear();
            Residence_dropdown.Items.Clear();

            if (isDeKalb == true) //DeKalb
            {
                foreach (Person i in community1.Residents)
                {
                    person_listBox.Items.Add(i); //cycles through each person and adds them to the listbox 
                }

                //prints the house street number and street name from file to the residence_listBox
                residence_listBox.Items.Add("Houses");
                residence_listBox.Items.Add("------------------------------");
                Residence_dropdown.Items.Add("Houses");
                Residence_dropdown.Items.Add("------------------------------");
                foreach (Property i in community1.Props)
                {
                    if (i is House)
                    {
                        residence_listBox.Items.Add(i); //cycles through each house and adds them to the listbox 
                        Residence_dropdown.Items.Add(i);
                    }
                }

                //prints the apartment street number, street name, and unit from file to the residence_listBox
                residence_listBox.Items.Add("\n");
                residence_listBox.Items.Add("Apartment");
                residence_listBox.Items.Add("------------------------------");
                Residence_dropdown.Items.Add("\n");
                Residence_dropdown.Items.Add("Apartment");
                Residence_dropdown.Items.Add("------------------------------");
                foreach (Property i in community1.Props)
                {
                    if (i is Apartment)
                    {
                        residence_listBox.Items.Add(i); //cycles through each apartment and adds them to the listbox 
                        Residence_dropdown.Items.Add(i);
                    }
                }
            }
            else //Sycamore
            {
                foreach (Person i in community2.Residents)
                {
                    person_listBox.Items.Add(i); //cycles through each person and adds them to the listbox 
                }

                //prints the house street number and street name from file to the residence_listBox
                residence_listBox.Items.Add("Houses");
                residence_listBox.Items.Add("------------------------------");
                Residence_dropdown.Items.Add("Houses");
                Residence_dropdown.Items.Add("------------------------------");
                foreach (Property i in community2.Props)
                {
                    if (i is House)
                    {
                        residence_listBox.Items.Add(i); //cycles through each house and adds them to the listbox 
                        Residence_dropdown.Items.Add(i);
                    }
                }

                //prints the apartment street number, street name, and unit from file to the residence_listBox
                residence_listBox.Items.Add("\n");
                residence_listBox.Items.Add("Apartment");
                residence_listBox.Items.Add("------------------------------");
                Residence_dropdown.Items.Add("\n");
                Residence_dropdown.Items.Add("Apartment");
                Residence_dropdown.Items.Add("------------------------------");
                foreach (Property i in community2.Props)
                {
                    if (i is Apartment)
                    {
                        residence_listBox.Items.Add(i); //cycles through each apartment and adds them to the listbox 
                        Residence_dropdown.Items.Add(i);
                    }
                }
            }
        }

        /*
         * DO NOT TOUCH THIS, IT WORKS
         */
        private void ToggleForSale_Click(object sender, EventArgs e)
        {
            output_RichTextBox.Clear(); //clears out whatever text it was displaying before 
            Button forSale_button = sender as Button;
            string[] parseList = residence_listBox.SelectedItem.ToString().Split('\t'); //takes selected item and splits it

            if (residence_listBox.SelectedIndex <= -1)
            {
                output_RichTextBox.Clear();
                output_RichTextBox.AppendText("A residence must be selected first from the box");
            }
            else
            {
                //DeKalb
                foreach (Property i in community1.Props) //cycles through each property in the DeKalb community and finds the right one 
                {
                    if (i is House) //if it is a house 
                    {
                        if (parseList[0] == i.Address) //if the selected address and the property address match
                        {
                            if (i.ForSale == true) //if the property is for sale
                            {
                                i.ForSale = false; //it will now not be
                                output_RichTextBox.AppendText(i.Address + " is now listed as NOT FOR SALE"); //user feedback
                                updateLists(true); //lists will be updated

                            }
                            else if (i.ForSale == false) //if the property is not for sale
                            {
                                i.ForSale = true; //it will now be 
                                output_RichTextBox.AppendText(i.Address + " is now listed as FOR SALE"); //user feedback 
                                updateLists(true); //lists will be updated 
                            }
                        }
                    }
                    else if (i is Apartment) //if it is an apartment
                    {
                        if (parseList[0] == i.Address) //if the selected address and the property address match
                        {
                            if (parseList[2] == i.Apt) //if the selected apartment # and the property apartment # match
                            {
                                if (i.ForSale == true) //if the property is for sale
                                {
                                    i.ForSale = false; //it will now not be
                                    output_RichTextBox.AppendText(i.Address + " is now listed as NOT FOR SALE"); //user feedback
                                    updateLists(true); //lists will be updated
                                }
                                else if (i.ForSale == false) //if the property is not for sale
                                {
                                    i.ForSale = true; //it will now be 
                                    output_RichTextBox.AppendText(i.Address + " is now listed as FOR SALE"); //user feedback 
                                    updateLists(true); //lists will be updated 
                                }
                            }
                        }
                    }
                }

                //Sycamore
                foreach (Property i in community2.Props) //cycles through each property in the Sycamore community and finds the right one 
                {
                    if (i is House) //if it is a house 
                    {
                        if (parseList[0] == i.Address) //if the selected address and the property address match
                        {
                            if (i.ForSale == true) //if the property is for sale
                            {
                                i.ForSale = false; //it will now not be
                                output_RichTextBox.AppendText(i.Address + " is now listed as NOT FOR SALE"); //user feedback
                                updateLists(false); //lists will be updated
                            }
                            else if (i.ForSale == false) //if the property is not for sale
                            {
                                i.ForSale = true; //it will now be 
                                output_RichTextBox.AppendText(i.Address + " is now listed as FOR SALE"); //user feedback 
                                updateLists(false); //lists will be updated 
                            }
                        }
                    }
                    else if (i is Apartment) //if it is an apartment
                    {
                        if (parseList[0] == i.Address) //if the selected address and the property address match
                        {
                            if (parseList[2] == i.Apt) //if the selected apartment # and the property apartment # match
                            {
                                if (i.ForSale == true) //if the property is for sale
                                {
                                    i.ForSale = false; //it will now not be
                                    output_RichTextBox.AppendText(i.Address + " is now listed as NOT FOR SALE"); //user feedback
                                    updateLists(false); //lists will be updated
                                }
                                else if (i.ForSale == false) //if the property is not for sale
                                {
                                    i.ForSale = true; //it will now be 
                                    output_RichTextBox.AppendText(i.Address + " is now listed as FOR SALE"); //user feedback 
                                    updateLists(false); //lists will be updated 
                                }
                            }
                        }
                    }
                }
            }

            if (forSale_button == null) //the button doesn't have a value 
            {
                MessageBox.Show("Sender is not a Button");
                return;
            }
        }

        /*
         * DO NOT TOUCH THIS, IT WORKS
         */
        private void buyProperty_button_Click(object sender, EventArgs e)
        {
            output_RichTextBox.Clear(); //clears out whatever text it was displaying before 
            Button buyProp_button = sender as Button;
            string[] propParseList = residence_listBox.SelectedItem.ToString().Split('\t'); //takes selected item and splits it
            string[] personParseList = person_listBox.SelectedItem.ToString().Split('\t');

            if (buyProp_button == null) //the button doesn't have a value 
            {
                MessageBox.Show("Sender is not a Button");
                return;
            }

            if (residence_listBox.SelectedIndex <= -1 && person_listBox.SelectedIndex <= -1)
            {
                output_RichTextBox.Clear();
                output_RichTextBox.AppendText("A residence and a person must be selected first");
            }
            else
            {
                //DeKalb
                foreach (Property i in community1.Props) //cycles through each property in the DeKalb community and finds the right one 
                {
                    if (i is House) //if it is a house 
                    {
                        if (propParseList[0] == i.Address) //if the selected address and the property address match
                        {
                            if (i.ForSale == true) //if the property is for sale
                            {
                                foreach (Person j in community1.Residents) //cycles through each person in the DeKalb community and finds the right one 
                                {
                                    if (personParseList[0] == j.FirstName) //checks if selected person has the same first name
                                    {
                                        if (personParseList[1] == j.Age.ToString()) //and same age
                                        {
                                            if (personParseList[2] == j.Occupation) //and same occupation 
                                            {
                                                if (j.ResidentId == i.Id) //then checks if the person already owns house
                                                {
                                                    output_RichTextBox.AppendText("ERROR: " + j.FirstName + " already owns the property found at " + i.Address + ".");
                                                }
                                                else //otherwise it is a sucessful purchase
                                                {
                                                    i.ForSale = false; //it will now not be
                                                    output_RichTextBox.AppendText("Success! " + j.FirstName + " has purchased the property at " + i.Address + "!"); //user feedback
                                                    j.ResidentId = i.Id; //new owner is set 
                                                    updateLists(true); //lists will be updated
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else if (i.ForSale == false) //if the property is not for sale
                            {
                                output_RichTextBox.AppendText("ERROR: Could not purchase the property at " + i.Address + ", as it is not listed for sale."); //user feedback 
                            }
                        }
                    }
                    else if (i is Apartment) //if it is an apartment
                    {
                        if (propParseList[0] == i.Address) //if the selected address and the property address match
                        {
                            if (propParseList[2] == i.Apt) //if the selected apartment # and the property apartment # match
                            {
                                if (i.ForSale == true) //if the property is for sale
                                {
                                    foreach (Person j in community1.Residents) //cycles through each person in the DeKalb community and finds the right one 
                                    {
                                        if (personParseList[0] == j.FirstName) //checks if selected person has the same first name
                                        {
                                            if (personParseList[1] == j.Age.ToString()) //and same age
                                            {
                                                if (personParseList[2] == j.Occupation) //and same occupation 
                                                {
                                                    if (j.ResidentId == i.Id) //then checks if the person already owns house
                                                    {
                                                        output_RichTextBox.AppendText("ERROR: " + j.FirstName + " already owns the property found at " + i.Address + ".");
                                                    }
                                                    else //otherwise it is a sucessful purchase
                                                    {
                                                        i.ForSale = false; //it will now not be
                                                        output_RichTextBox.AppendText("Success! " + j.FirstName + " has purchased the property at " + i.Address + "!"); //user feedback
                                                        j.ResidentId = i.Id; //new owner is set 
                                                        updateLists(true); //lists will be updated
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (i.ForSale == false) //if the property is not for sale
                                {
                                    output_RichTextBox.AppendText("ERROR: Could not purchase the property at " + i.Address + ", as it is not listed for sale."); //user feedback 
                                }
                            }
                        }
                    }
                }

                //Sycamore
                foreach (Property i in community2.Props) //cycles through each property in the DeKalb community and finds the right one 
                {
                    if (i is House) //if it is a house 
                    {
                        if (propParseList[0] == i.Address) //if the selected address and the property address match
                        {
                            if (i.ForSale == true) //if the property is for sale
                            {
                                foreach (Person j in community2.Residents) //cycles through each person in the DeKalb community and finds the right one 
                                {
                                    if (personParseList[0] == j.FirstName) //checks if selected person has the same first name
                                    {
                                        if (personParseList[1] == j.Age.ToString()) //and same age
                                        {
                                            if (personParseList[2] == j.Occupation) //and same occupation 
                                            {
                                                if (j.ResidentId == i.Id) //then checks if the person already owns house
                                                {
                                                    output_RichTextBox.AppendText("ERROR: " + j.FirstName + " already owns the property found at " + i.Address + ".");
                                                }
                                                else //otherwise it is a sucessful purchase
                                                {
                                                    i.ForSale = false; //it will now not be
                                                    output_RichTextBox.AppendText("Success! " + j.FirstName + " has purchased the property at " + i.Address + "!"); //user feedback
                                                    j.ResidentId = i.Id; //new owner is set 
                                                    updateLists(false); //lists will be updated
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else if (i.ForSale == false) //if the property is not for sale
                            {
                                output_RichTextBox.AppendText("ERROR: Could not purchase the property at " + i.Address + ", as it is not listed for sale."); //user feedback 
                            }
                        }
                    }
                    else if (i is Apartment) //if it is an apartment
                    {
                        if (propParseList[0] == i.Address) //if the selected address and the property address match
                        {
                            if (propParseList[2] == i.Apt) //if the selected apartment # and the property apartment # match
                            {
                                if (i.ForSale == true) //if the property is for sale
                                {
                                    foreach (Person j in community2.Residents) //cycles through each person in the DeKalb community and finds the right one 
                                    {
                                        if (personParseList[0] == j.FirstName) //checks if selected person has the same first name
                                        {
                                            if (personParseList[1] == j.Age.ToString()) //and same age
                                            {
                                                if (personParseList[2] == j.Occupation) //and same occupation 
                                                {
                                                    if (j.ResidentId == i.Id) //then checks if the person already owns house
                                                    {
                                                        output_RichTextBox.AppendText("ERROR: " + j.FirstName + " already owns the property found at " + i.Address + ".");
                                                    }
                                                    else //otherwise it is a sucessful purchase
                                                    {
                                                        i.ForSale = false; //it will now not be
                                                        output_RichTextBox.AppendText("Success! " + j.FirstName + " has purchased the property at " + i.Address + "!"); //user feedback
                                                        j.ResidentId = i.Id; //new owner is set 
                                                        updateLists(false); //lists will be updated
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (i.ForSale == false) //if the property is not for sale
                                {
                                    output_RichTextBox.AppendText("ERROR: Could not purchase the property at " + i.Address + ", as it is not listed for sale."); //user feedback 
                                }
                            }
                        }
                    }
                }
            }
        }

        /*
         * DO NOT TOUCH THIS, IT WORKS
         */
        private void addRes_button_Click(object sender, EventArgs e)
        {
            output_RichTextBox.Clear(); //clears out whatever text it was displaying before 
            Button addRes_button = sender as Button;
            string[] propParseList = residence_listBox.SelectedItem.ToString().Split('\t'); //takes selected item and splits it
            string[] personParseList = person_listBox.SelectedItem.ToString().Split('\t');

            if (addRes_button == null) //the button doesn't have a value 
            {
                MessageBox.Show("Sender is not a Button");
                return;
            }

            if (residence_listBox.SelectedIndex <= -1 && person_listBox.SelectedIndex <= -1)
            {
                output_RichTextBox.Clear();
                output_RichTextBox.AppendText("A residence and a person must be selected first");
            }
            else
            {
                //DeKalb
                foreach (Property i in community1.Props) //cycles through each property in the DeKalb community and finds the right one 
                {
                    if (i is House) //if it is a house 
                    {
                        if (propParseList[0] == i.Address) //if the selected address and the property address match
                        {
                            foreach (Person j in community1.Residents) //cycles through each person in the DeKalb community and finds the right one 
                            {
                                if (personParseList[0] == j.FirstName) //checks if selected person has the same first name
                                {
                                    if (personParseList[1] == j.Age.ToString()) //and same age
                                    {
                                        if (personParseList[2] == j.Occupation) //and same occupation 
                                        {
                                            if (j.ResidentId == i.Id) //then checks if the person already already lives here
                                            {
                                                output_RichTextBox.AppendText("ERROR: " + j.FirstName + " already resides at the property at " + i.Address + ".");
                                            }
                                            else //otherwise it is a sucessful move
                                            {
                                                output_RichTextBox.AppendText("Success! " + j.FirstName + " now resides at the property at " + i.Address + "!"); //user feedback
                                                j.ResidentId = i.Id; //new owner is set 
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (i is Apartment) //if it is an apartment
                    {
                        if (propParseList[0] == i.Address) //if the selected address and the property address match
                        {
                            if (propParseList[2] == i.Apt) //if the selected apartment # and the property apartment # match
                            {
                                foreach (Person j in community1.Residents) //cycles through each person in the DeKalb community and finds the right one 
                                {
                                    if (personParseList[0] == j.FirstName) //checks if selected person has the same first name
                                    {
                                        if (personParseList[1] == j.Age.ToString()) //and same age
                                        {
                                            if (personParseList[2] == j.Occupation) //and same occupation 
                                            {
                                                if (j.ResidentId == i.Id) //then checks if the person already already lives here
                                                {
                                                    output_RichTextBox.AppendText("ERROR: " + j.FirstName + " already resides at the property at " + i.Address + ".");
                                                }
                                                else //otherwise it is a sucessful move
                                                {
                                                    output_RichTextBox.AppendText("Success! " + j.FirstName + " now resides at the property at " + i.Address + "!"); //user feedback
                                                    j.ResidentId = i.Id; //new owner is set 
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                //Sycamore
                foreach (Property i in community2.Props) //cycles through each property in the DeKalb community and finds the right one 
                {
                    if (i is House) //if it is a house 
                    {
                        if (propParseList[0] == i.Address) //if the selected address and the property address match
                        {
                            foreach (Person j in community2.Residents) //cycles through each person in the DeKalb community and finds the right one 
                            {
                                if (personParseList[0] == j.FirstName) //checks if selected person has the same first name
                                {
                                    if (personParseList[1] == j.Age.ToString()) //and same age
                                    {
                                        if (personParseList[2] == j.Occupation) //and same occupation 
                                        {
                                            if (j.ResidentId == i.Id) //then checks if the person already already lives here
                                            {
                                                output_RichTextBox.AppendText("ERROR: " + j.FirstName + " already resides at the property at " + i.Address + ".");
                                            }
                                            else //otherwise it is a sucessful move
                                            {
                                                output_RichTextBox.AppendText("Success! " + j.FirstName + " now resides at the property at " + i.Address + "!"); //user feedback
                                                j.ResidentId = i.Id; //new owner is set 
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (i is Apartment) //if it is an apartment
                    {
                        if (propParseList[0] == i.Address) //if the selected address and the property address match
                        {
                            if (propParseList[2] == i.Apt) //if the selected apartment # and the property apartment # match
                            {
                                foreach (Person j in community2.Residents) //cycles through each person in the DeKalb community and finds the right one 
                                {
                                    if (personParseList[0] == j.FirstName) //checks if selected person has the same first name
                                    {
                                        if (personParseList[1] == j.Age.ToString()) //and same age
                                        {
                                            if (personParseList[2] == j.Occupation) //and same occupation 
                                            {
                                                if (j.ResidentId == i.Id) //then checks if the person already already lives here
                                                {
                                                    output_RichTextBox.AppendText("ERROR: " + j.FirstName + " already resides at the property at " + i.Address + ".");
                                                }
                                                else //otherwise it is a sucessful move
                                                {
                                                    output_RichTextBox.AppendText("Success! " + j.FirstName + " now resides at the property at " + i.Address + "!"); //user feedback
                                                    j.ResidentId = i.Id; //new owner is set 
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /*
         * DO NOT TOUCH THIS, IT WORKS
         */
        private void removeRes_button_Click(object sender, EventArgs e)
        {
            output_RichTextBox.Clear(); //clears out whatever text it was displaying before 
            Button removeRes_button = sender as Button;
            string[] propParseList = residence_listBox.SelectedItem.ToString().Split('\t'); //takes selected item and splits it
            string[] personParseList = person_listBox.SelectedItem.ToString().Split('\t');

            if (removeRes_button == null) //the button doesn't have a value 
            {
                MessageBox.Show("Sender is not a Button");
                return;
            }

            if (residence_listBox.SelectedIndex <= -1 && person_listBox.SelectedIndex <= -1)
            {
                output_RichTextBox.Clear();
                output_RichTextBox.AppendText("A residence and a person must be selected first");
            }
            else
            {
                //DeKalb
                foreach (Property i in community1.Props) //cycles through each property in the DeKalb community and finds the right one 
                {
                    if (i is House) //if it is a house 
                    {
                        if (propParseList[0] == i.Address) //if the selected address and the property address match
                        {
                            foreach (Person j in community1.Residents) //cycles through each person in the DeKalb community and finds the right one 
                            {
                                if (personParseList[0] == j.FirstName) //checks if selected person has the same first name
                                {
                                    if (personParseList[1] == j.Age.ToString()) //and same age
                                    {
                                        if (personParseList[2] == j.Occupation) //and same occupation 
                                        {
                                            if (j.ResidentId != i.Id) //then checks if the person doesn't live here
                                            {
                                                output_RichTextBox.AppendText("ERROR: " + j.FirstName + " doesn't currently reside at the property at " + i.Address + ".");
                                            }
                                            else //otherwise it is a sucessful moving out 
                                            {
                                                output_RichTextBox.AppendText("Success! " + j.FirstName + " no longer resides at the property at " + i.Address + "!"); //user feedback
                                                j.ResidentId = 0; //moved out 
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (i is Apartment) //if it is an apartment
                    {
                        if (propParseList[0] == i.Address) //if the selected address and the property address match
                        {
                            if (propParseList[2] == i.Apt) //if the selected apartment # and the property apartment # match
                            {
                                foreach (Person j in community1.Residents) //cycles through each person in the DeKalb community and finds the right one 
                                {
                                    if (personParseList[0] == j.FirstName) //checks if selected person has the same first name
                                    {
                                        if (personParseList[1] == j.Age.ToString()) //and same age
                                        {
                                            if (personParseList[2] == j.Occupation) //and same occupation 
                                            {
                                                if (j.ResidentId != i.Id) //then checks if the person doesn't live here
                                                {
                                                    output_RichTextBox.AppendText("ERROR: " + j.FirstName + " doesn't currently reside at the property at " + i.Address + ".");
                                                }
                                                else //otherwise it is a sucessful moving out 
                                                {
                                                    output_RichTextBox.AppendText("Success! " + j.FirstName + " no longer resides at the property at " + i.Address + "!"); //user feedback
                                                    j.ResidentId = 0; //moved out 
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                //Sycamore
                foreach (Property i in community2.Props) //cycles through each property in the DeKalb community and finds the right one 
                {
                    if (i is House) //if it is a house 
                    {
                        if (propParseList[0] == i.Address) //if the selected address and the property address match
                        {
                            foreach (Person j in community2.Residents) //cycles through each person in the DeKalb community and finds the right one 
                            {
                                if (personParseList[0] == j.FirstName) //checks if selected person has the same first name
                                {
                                    if (personParseList[1] == j.Age.ToString()) //and same age
                                    {
                                        if (personParseList[2] == j.Occupation) //and same occupation 
                                        {
                                            if (j.ResidentId != i.Id) //then checks if the person doesn't live here
                                            {
                                                output_RichTextBox.AppendText("ERROR: " + j.FirstName + " doesn't currently reside at the property at " + i.Address + ".");
                                            }
                                            else //otherwise it is a sucessful moving out 
                                            {
                                                output_RichTextBox.AppendText("Success! " + j.FirstName + " no longer resides at the property at " + i.Address + "!"); //user feedback
                                                j.ResidentId = 0; //moved out 
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (i is Apartment) //if it is an apartment
                    {
                        if (propParseList[0] == i.Address) //if the selected address and the property address match
                        {
                            if (propParseList[2] == i.Apt) //if the selected apartment # and the property apartment # match
                            {
                                foreach (Person j in community2.Residents) //cycles through each person in the DeKalb community and finds the right one 
                                {
                                    if (personParseList[0] == j.FirstName) //checks if selected person has the same first name
                                    {
                                        if (personParseList[1] == j.Age.ToString()) //and same age
                                        {
                                            if (personParseList[2] == j.Occupation) //and same occupation 
                                            {
                                                if (j.ResidentId != i.Id) //then checks if the person doesn't live here
                                                {
                                                    output_RichTextBox.AppendText("ERROR: " + j.FirstName + " doesn't currently reside at the property at " + i.Address + ".");
                                                }
                                                else //otherwise it is a sucessful moving out 
                                                {
                                                    output_RichTextBox.AppendText("Success! " + j.FirstName + " no longer resides at the property at " + i.Address + "!"); //user feedback
                                                    j.ResidentId = 0; //moved out 
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /*
         * DO NOT TOUCH THIS, IT WORKS
         * 
         */
        private void addNewProperty_button_Click(object sender, EventArgs e)
        {
            Button addProp_button = sender as Button; //button to add property 
            House newHouse = null; //new house object
            Apartment newApt = null; //new aparmtent object
            var rand = new Random(); //random seed 
            int randomID = 0; //random ID
            int randomX = rand.Next(1, 250); //random X value 
            int randomY = rand.Next(1, 250); //random Y value 
            string selectedCity = ""; //user chosen city 
            string selectedState = ""; //user chosen state 
            string selectedZip = ""; //user chosen zip
            string inputGarage = ""; //user chosen garage
            string inputAttachedGarage = ""; //user chosen attached garage 

            if (String.IsNullOrEmpty(address_textBox.Text) || String.IsNullOrWhiteSpace(address_textBox.Text))
            {
                output_RichTextBox.Clear();
                output_RichTextBox.AppendText("ERROR: Please enter an address for this property.");
            }
            else
            {
                randomID = rand.Next(10000, 99999); //generates random id 
                foreach (Property p in community1.Props) //cycles through each existing property id 
                {
                    if (randomID == p.Id) //if it is the same 
                    {
                        randomID = rand.Next(10000, 99999); //generate a new one 
                    }
                }

                foreach (Property p in community2.Props) //cycles through each existing property id 
                {
                    if (randomID == p.Id) //if it is the same 
                    {
                        randomID = rand.Next(10000, 99999); //generate a new one 
                    }
                }

                if (addProp_button == null) //the button doesn't have a value 
                {
                    MessageBox.Show("Sender is not a Button");
                    return;
                }

                if (dekalb_radioButton.Checked) //if the DeKalb radio button is selected 
                {
                    selectedCity = "DeKalb"; //then automatically, DeKalb, IL and 60115
                    selectedState = "Illinois";
                    selectedZip = "60115";
                }

                if (sycamore_radioButton.Checked) //if the Sycamore radio button is selected
                {
                    selectedCity = "Sycamore"; //then automatically, Sycamore, IL adn 60178 
                    selectedState = "Illinois";
                    selectedZip = "60178";
                }

                if (!String.IsNullOrEmpty(apt_textBox.Text) || !String.IsNullOrWhiteSpace(apt_textBox.Text)) //if so, then it is an apartment 
                {
                    //below is creating the string object that gets read into the new object 
                    string[] newPropInfo = { randomID.ToString(), randomID.ToString(), randomX.ToString(), randomY.ToString(), address_textBox.Text, selectedCity, selectedState, selectedZip, "F", beds_numericUpDown.Value.ToString(), baths_numericUpDown1.Value.ToString(), sqft_numericUpDown.Value.ToString(), apt_textBox.Text };
                    newApt = new Apartment(newPropInfo); //new object reads in string object 
                    propertyInfo.Add(newApt.Id, newApt); //house object is added to the sorted set

                    if (selectedCity == "DeKalb")
                    {
                        community1.Props.Add(newApt); //apartment object is added to the community 
                        output_RichTextBox.Clear();
                        output_RichTextBox.AppendText("New Property got added!");
                        updateLists(true);
                    }
                    else
                    {
                        community2.Props.Add(newApt); //apartment object is added to the community 
                        output_RichTextBox.Clear();
                        output_RichTextBox.AppendText("New Property got added!");
                        updateLists(false);
                    }
                }
                else //it is an house 
                {
                    if (garage_checkBox.Checked) //this is checking if the garage is checked 
                    {
                        inputGarage = "T"; //if it is, then it is set to true 
                        if (garageAttached_checkBox.Checked) //then checks the attached garage if it is checked
                        {
                            inputAttachedGarage = "T"; //then set to true 
                        }
                        else
                        {
                            inputAttachedGarage = "F"; //otherwise false 
                        }
                    }
                    else
                    {
                        inputGarage = "F"; //both are false 
                        inputAttachedGarage = "F";
                    }

                    //below is creating the string object that gets read into the new object 
                    string[] newPropInfo = { randomID.ToString(), randomID.ToString(), randomX.ToString(), randomY.ToString(), address_textBox.Text, selectedCity, selectedState, selectedZip, "F", beds_numericUpDown.Value.ToString(), baths_numericUpDown1.Value.ToString(), sqft_numericUpDown.Value.ToString(), inputGarage, inputAttachedGarage, floors_numericUpDown.Value.ToString() };
                    newHouse = new House(newPropInfo); //new object reads in string object 
                    propertyInfo.Add(newHouse.Id, newHouse); //house object is added to the sorted set

                    if (selectedCity == "DeKalb")
                    {
                        community1.Props.Add(newHouse); //house object is added to the community 
                        output_RichTextBox.Clear();
                        output_RichTextBox.AppendText("New Property got added!");
                        updateLists(true);
                    }
                    else
                    {
                        community2.Props.Add(newHouse); //house object is added to the community 
                        output_RichTextBox.Clear();
                        output_RichTextBox.AppendText("New Property got added!");
                        updateLists(false);
                    }
                }
            }
        }

        /*
        * DO NOT TOUCH THIS, IT WORKS
        */
        private void apt_textBox_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(apt_textBox.Text) || !String.IsNullOrWhiteSpace(apt_textBox.Text)) //if there's nothing in apartment
            {
                garage_checkBox.Visible = false; //garage checkbox will be hidden 
                garageAttached_checkBox.Visible = false; //attacehd garage checkbox will be hidden 
                floors_numericUpDown.Visible = false; //floor option will be hidden and the default will be set to 1 
                floors_numericUpDown.Value = 1;
                label9.Visible = false; //label for floor option will be hidden 

                if (garage_checkBox.Checked == true) //if previously the garage checkbox was checked it will be reset
                {
                    garage_checkBox.Checked = false;
                }

                if (garageAttached_checkBox.Checked == true) //if previously the attached garage checkbox was checked it will be reset
                {
                    garageAttached_checkBox.Checked = false;
                }

            }
            else
            {
                garage_checkBox.Visible = true; //otherwise, the garage checkbox will display 
                floors_numericUpDown.Visible = true; //the floor option will display 
                label9.Visible = true; //and the label for the floor option will display 
            }
        }

        /*
         * DO NOT TOUCH THIS, IT WORKS
         */
        private void garage_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (garage_checkBox.Checked) //if the garage is checked
            {
                garageAttached_checkBox.Visible = true; //then the attached garage will be visible
            }
            else
            {
                garageAttached_checkBox.Visible = false; //otherwise it won't be 
            }
        }

        /*
         * DO NOT TOUCH THIS, IT WORKS
         */
        private void addNewResident_button_Click(object sender, EventArgs e)
        {
            Button addPerson_button = sender as Button; //button to add property 
            Person newPerson = null; //creating new person object 
            string[] selProperty = null; //infor for making new person 
            var rand = new Random(); //random seed 
            int randomID = 0; //random user ID
            uint propertyID = 0; //matching property ID for new person 

            //below are if statements making sure all the fields are filled in 
            if (String.IsNullOrEmpty(name_textBox.Text) || String.IsNullOrWhiteSpace(name_textBox.Text))
            {
                output_RichTextBox.Clear();
                output_RichTextBox.AppendText("ERROR: Please enter a name for this new resident.");
            }
            else if (String.IsNullOrEmpty(occupation_textBox.Text) || String.IsNullOrWhiteSpace(occupation_textBox.Text))
            {
                output_RichTextBox.Clear();
                output_RichTextBox.AppendText("ERROR: Please enter an occupation for this new resident.");
            }
            else if (birthdayPicker.Value > DateTime.Now)
            {
                output_RichTextBox.Clear();
                output_RichTextBox.AppendText("ERROR: Birthdays cannot be defined from future dates.");
            }
            else if (Residence_dropdown.SelectedIndex <= -1)
            {
                output_RichTextBox.Clear();
                output_RichTextBox.AppendText("ERROR: Please select a residence for this new resident to reside at.");
            }
            else
            {
                randomID = rand.Next(10000, 99999); //generates random id 
                foreach (Person p in community1.Residents) //cycles through each existing property id 
                {
                    if (randomID == p.Id) //if it is the same 
                    {
                        randomID = rand.Next(10000, 99999); //generate a new one 
                    }
                }

                foreach (Person p in community2.Residents) //cycles through each existing property id 
                {
                    if (randomID == p.Id) //if it is the same 
                    {
                        randomID = rand.Next(10000, 99999); //generate a new one 
                    }
                }

                if (addPerson_button == null) //the button doesn't have a value 
                {
                    MessageBox.Show("Sender is not a Button");
                    return;
                }

                selProperty = Residence_dropdown.SelectedItem.ToString().Split('\t'); //takes what's selected from the dropdown menu and splits it 

                foreach (Property i in community1.Props) //cycles through each property and finds 
                {
                    if (i is House) //if it is a house
                    {
                        if (i.Address == selProperty[0]) //and if both addresses match 
                        {
                            propertyID = i.Id; //then that's the id the person gets cause they live there 
                        }
                    }
                    else if (i is Apartment) //if it is an apartment 
                    {
                        if (i.Address == selProperty[0] && i.Apt == selProperty[2]) //and if both addresses match 
                        {
                            propertyID = i.Id; //then that's the id the person gets cause they live there 
                        }
                    }
                }

                foreach (Property i in community2.Props) //cycles through each property and finds 
                {
                    if (i is House) //if it is a house
                    {
                        if (i.Address == selProperty[0]) //and if both addresses match 
                        {
                            propertyID = i.Id; //then that's the id the person gets cause they live there 
                        }
                    }
                    else if (i is Apartment) //if it is an apartment
                    {
                        if (i.Address == selProperty[0] && i.Apt == selProperty[2]) //and if both addresses match 
                        {
                            propertyID = i.Id; //then that's the id the person gets cause they live there 
                        }
                    }
                }

                string[] birthdayAttributes = birthdayPicker.Value.ToString("yyyy-MM-dd").Split('-'); //this is for splitting up the birthday 

                string[] fullName = name_textBox.Text.Split(' '); //this is for splitting up the full name into first and last 

                //person Info is put together 
                string[] newPersonInfo = { randomID.ToString(), fullName[0], fullName[1], occupation_textBox.Text, birthdayAttributes[0], birthdayAttributes[1], birthdayAttributes[2], propertyID.ToString() };
                newPerson = new Person(newPersonInfo); //person object is reading in the input file 
                personInfo.Add(newPerson.Id, newPerson); //person object is added to the sorted dictionary

                if (dekalb_radioButton.Checked)
                {
                    community1.Residents.Add(newPerson); //person object is added to the community 
                    output_RichTextBox.Clear();
                    output_RichTextBox.AppendText("New Person got added!");
                    updateLists(true);
                }
                else
                {
                    community2.Residents.Add(newPerson); //person object is added to the community 
                    output_RichTextBox.Clear();
                    output_RichTextBox.AppendText("New Person got added!");
                    updateLists(false);
                }
            }
        }
    }
}