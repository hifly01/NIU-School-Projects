/********************************************************************
CSCI 473 - Assignment 4 - Spring 2020

Programmers: Theresa Li (Z1814730), Charles Alms (Z1797837) 
Section:    1
TA:         Jennifer Ho & Sridivya Pagadala
Date Due:   4/2/20

Purpose:    This program is teaching us to make a real estate map using C#
*********************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TheresaLiCharlesAlms_Assign4
{
    /***************************************************************
    Class:		Property 

    Use:		This declares attributes for property  

    ***************************************************************/
    public class Property : IComparable, IEnumerable 
    {
        private readonly uint id;
        private uint ownerID;
        private readonly uint x;
        private readonly uint y;
        private string address;
        private uint streetAddr;
        private string streetName;
        private string city;
        private string state;
        private string zip;
        private bool forSale;
        private uint price;
        string apt = "";

        private Property[] _property;

        enum propTypes { House, Apartment };

        //below are properties for each attribute, so they all have a get and set method 
        public uint Id
        {
            get { return id; }
            set { }
        }

        public string Apt
        {
            get { return apt; }
            set { apt = value; }
        }

        public uint OwnerId
        {
            get { return ownerID; }
            set { }
        }

        public int Xcord
        {
            get { return (int)x; }
            set { }
        }

        public int Ycord
        {
            get { return (int)y; }
            set { }
        }

        public string StreetName
        {
            get { return streetName; }
            set { }
        }

        public string Address
        {
            get { return address; }
            set { }
        }

        public string City
        {
            get { return city; }
            set { }
        }

        public string State
        {
            get { return state; }
            set { }
        }

        public string Zip
        {
            get { return zip; }
            set { }
        }

        public bool ForSale
        {
            get { return forSale; }
            set { forSale = value; }
        }
        
        public uint Price
        {
            get { return price; }
            set { price = value; }
        }

        /***************************************************************
        Function: Property()

        Use: Constructor for reading in values from the input file 

        Arguments: None

        Returns:   None
        ***************************************************************/
        public Property()
        {
            id = 0;
            ownerID = 0;
            x = 0;
            y = 0;
            address = " ";
            streetAddr = 0;
            streetName = " ";
            city = " ";
            state = " ";
            zip = " ";
            forSale = false;
            price = 0;
        }

        /***************************************************************
        Function: Property()

        Use: Constructor for reading in values from the input file 

        Arguments: None

        Returns:   None
        ***************************************************************/
        public Property(string[] newValues) //IComparable
        {
            id = Convert.ToUInt32(newValues[0]);
            ownerID = Convert.ToUInt32(newValues[1]);
            x = Convert.ToUInt32(newValues[2]);
            y = Convert.ToUInt32(newValues[3]);

            address = newValues[4];
            string[] separateAddress = address.Split(' ');
            streetAddr = Convert.ToUInt32(separateAddress[0]);
            streetName = separateAddress[1] + " " + separateAddress[2];

            city = newValues[5];
            state = newValues[6];
            zip = newValues[7];

            Property[] _property;

            string[] separateForSale = newValues[8].Split(':');
            if (separateForSale[0].Equals("T"))
            {
                forSale = true;
                price = Convert.ToUInt32(separateForSale[1]);
            }
            else if (separateForSale[0].Equals("F"))
            {
                forSale = false;
                price = 0; 
            }
        }

       /***************************************************************
       Function: CompareTo()

       Use: Sorts out residential attributes

       Arguments: Object

       Returns:   int
       ***************************************************************/
        public int CompareTo(Object alpha)
        {
            if (alpha == null)
             {
                 throw new ArgumentNullException();
             }

             Property rightOp = alpha as Property;

             if (rightOp != null)
             {
                 if (apt.CompareTo(rightOp.apt) == 0)
                 {
                     if (state.CompareTo(rightOp.state) == 0)
                     {
                         if (city.CompareTo(rightOp.city) == 0)
                         {
                             if (streetAddr.CompareTo(rightOp.streetAddr) == 0)
                             {
                                 return streetName.CompareTo(rightOp.streetName);
                             }
                             else
                             {
                                 return streetAddr.CompareTo(rightOp.streetAddr);
                             }
                         }
                         else
                         {
                             return city.CompareTo(rightOp.city);
                         }
                     }
                     else
                     {
                         return state.CompareTo(rightOp.state);
                     }
                 }
                 else
                 {
                     return apt.CompareTo(rightOp.apt);
                 }
             }
             else
             {
                 throw new ArgumentException("[Property]:CompareTo argument is not a Property");
             }

            return 0;
        }

        /***************************************************************
        Function: ToString()

        Use: Builds a statement to display attributes of property 

        Arguments: None

        Returns:   string
        ***************************************************************/
        public override string ToString()
        {
            return "";  
        }

        IEnumerator IEnumerable.GetEnumerator() //this is an enumerator 
        {
            return (IEnumerator)GetEnumerator();
        }

        public CommEnum GetEnumerator() //this gets the enumerator 
        {
            return new CommEnum(_property);
        }
    }

    /***************************************************************
    Class:		Business 

    Use:		This declares attributes for Business  

    ***************************************************************/
    public class Business : Property
    {
        private string name;
        private uint currentBusiness;
        private enum BusinessType { Grocery, Bank, Repair, Fast_Food, Department_Store };
        private readonly string yearEstablished;
        private uint activeRecruitment;

        public string Name
        {
            get { return name; }
            set { Name = value; }
        }

        public string YearEstablished
        {
            get { return yearEstablished; }
            set { }
        }

        public uint ActiveRecruitment
        {
            get { return activeRecruitment; }
            set { activeRecruitment = value; }
        }

        public Business()
        {
            name = "";
            currentBusiness = 0;
            yearEstablished = "";
            activeRecruitment = 0;
        }

        public Business(string[] newValues) : base(newValues)
        {
            name = newValues[9];
            currentBusiness = Convert.ToUInt32(newValues[10]);
            yearEstablished = newValues[11];
            activeRecruitment = Convert.ToUInt32(newValues[12]);
        }

        public override string ToString() 
        {
            StringBuilder displayResidential = new StringBuilder();

            displayResidential.Append(Name + ", a " + Enum.GetName(typeof(BusinessType), currentBusiness) + " type of business, established in " + YearEstablished);

            return base.ToString() + "\n" + displayResidential.ToString();
        }
    }

    /***************************************************************
    Class:		School 

    Use:		This declares attributes for School  

    ***************************************************************/
    public class School : Property
    {
        private string name;
        private uint currentSchool;
        private enum SchoolType { Elementary, HighSchool, CommunityCollege, University };
        private readonly string yearEstablished;
        private uint enrolled;

        public string Name
        {
            get { return name; }
            set { Name = value; }
        }

        public string YearEstablished
        {
            get { return yearEstablished; }
            set { }
        }

        public uint Enrolled
        {
            get { return enrolled; }
            set { enrolled = value; }
        }

        public School()
        {
            name = "";
            currentSchool = 0;
            yearEstablished = "";
            enrolled = 0;
        }

        public School(string[] newValues) : base(newValues)
        {
            name = newValues[9];

            if (name.Contains("Elementary"))
            {
                currentSchool = 0;
            }
            else if (name.Contains("High"))
            {
                currentSchool = 1;
            }
            else if (name.Contains("Community"))
            {
                currentSchool = 2;
            }
            else
            {
                currentSchool = 3;
            }

            yearEstablished = newValues[10];
            enrolled = Convert.ToUInt32(newValues[11]);
        }

        public override string ToString() 
        {
            StringBuilder displayResidential = new StringBuilder();

            displayResidential.Append(Name + ", established in " + YearEstablished + "\n");
            displayResidential.Append(Enrolled + " students enrolled\t\t$" + Price);
            
            return base.ToString() + displayResidential.ToString();
        }
    }

    /***************************************************************
    Class:		Residential 

    Use:		This declares attributes for residential  

    ***************************************************************/
    public class Residential : Property //IComparable
    {
        private uint bedrooms;
        private uint baths;
        private uint sqft;

        //below are properties for each attribute, so they all have a get and set method 
        public uint Bedrooms
        {
            get { return bedrooms; }
            set { }
        }

        public uint Baths
        {
            get { return baths; }
            set { }
        }
        public uint Sqft
        {
            get { return sqft; }
            set { }
        }

        /***************************************************************
        Function: Residential()

        Use: Constructor for reading in values from the input file 

        Arguments: None

        Returns:   None
        ***************************************************************/

        public Residential() : base()
        {
            bedrooms = 0;
            baths = 0;
            sqft = 0;
        }

        /***************************************************************
        Function: Residential()

        Use: Constructor for reading in values from the input file 

        Arguments: None

        Returns:   None
        ***************************************************************/
        public Residential(string[] newValues) : base(newValues)
        {
            bedrooms = Convert.ToUInt32(newValues[9]);
            baths = Convert.ToUInt32(newValues[10]);
            sqft = Convert.ToUInt32(newValues[11]);
        }

        /***************************************************************
        Function: ToString()

        Use: Builds a statement to display attributes of residential 

        Arguments: None

        Returns:   string
        ***************************************************************/
        public override string ToString()
        {
            StringBuilder displayResidential = new StringBuilder();

            displayResidential.Append(Bedrooms + " beds, " + Baths + " baths, " + Sqft + " sq.ft.");   
            
            return base.ToString() + displayResidential.ToString();
        }

    }

    /***************************************************************
    Class:		House 

    Use:		This declares attributes for house  

    ***************************************************************/

    public class House : Residential //need IComparable
    {
        private bool garage;
        private Nullable<bool> attachedGarage;
        private uint floors;

        //below are properties for each attribute, so they all have a get and set method 
        public uint Floors
        {
            get { return floors; }
            set { }
        }

        public bool Garage
        {
            get { return garage; }
            set { }
        }

        public Nullable<bool> AttachedGarage
        {
            get { return attachedGarage; }
            set { }
        }

        /***************************************************************
        Function: House()

        Use: Constructor for reading in values from the input file 

        Arguments: None

        Returns:   None
        ***************************************************************/
        public House()
        {
            garage = false;
            attachedGarage = null;
            floors = 0;
        }

        /***************************************************************
        Function: House()

        Use: Constructor for reading in values from the input file 

        Arguments: None

        Returns:   None
        ***************************************************************/

        public House(string[] newValues) : base(newValues) //need IComparable
        {
            if (newValues[12].CompareTo("T") == 0)
            {
                garage = true;
            }
            else if (newValues[12].CompareTo("F") == 0)
            {
                garage = false;
            }

            if (garage == false)
            {
                attachedGarage = null;
            }
            else
            {
                if (newValues[13].CompareTo("T") == 0)
                {
                    attachedGarage = true;
                }
                else if (newValues[13].CompareTo("F") == 0)
                {
                    attachedGarage = false;
                }
            }
            floors = Convert.ToUInt32(newValues[14]);
        }

        /***************************************************************
        Function: ToString()

        Use: Builds a statement to display attributes of house 

        Arguments: None

        Returns:   string
        ***************************************************************/
        public override string ToString()
        {
             StringBuilder displayHouse = new StringBuilder();

             if (garage == true)
             {
                 if (attachedGarage == true)
                 {
                     displayHouse.Append("\n with an attached garage : " + floors + " floors.");
                 }
                 else
                 {
                     displayHouse.Append("\n with a detached garage : " + floors + " floors.");
                 }
             }
             else
             {
                 displayHouse.Append("\n with no garage : " + floors + " floors.");
             }
             
            return base.ToString() + displayHouse.ToString();
        }
    }

    /***************************************************************
    Class:		Apartment 

    Use:		This declares attributes for residential  

    ***************************************************************/

    public class Apartment : Residential
    {
        private string unit;

        //below are properties for each attribute, so they all have a get and set method 
        public string Unit => unit;

        /***************************************************************
        Function: Apartment()

        Use: Constructor for reading in values from the input file 

        Arguments: None

        Returns:   None
        ***************************************************************/
        public Apartment() : base()
        {
            unit = " ";
        }

        /***************************************************************
        Function: Apartment()

        Use: Constructor for reading in values from the input file 

        Arguments: None

        Returns:   None
        ***************************************************************/
        public Apartment(string[] newValues) : base(newValues)
        {
            Apt = newValues[12];
            unit = newValues[12]; //add in # to string
        }

        /***************************************************************
        Function: ToString()

        Use: Builds a statement to display attributes of apartment 

        Arguments: None

        Returns:   string
        ***************************************************************/
        public override string ToString()           //Property tostring
        {
            // StringBuilder displayApartment = new StringBuilder();

            //displayApartment.Append(" \t#\t" + unit);

            //displayApartment.ToString()
            return base.ToString();
        }
    }
}