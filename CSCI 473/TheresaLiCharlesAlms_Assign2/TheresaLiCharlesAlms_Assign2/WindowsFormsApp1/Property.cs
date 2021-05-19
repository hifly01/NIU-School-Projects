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
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TheresaLiCharlesAlms_Assign2
{
    /***************************************************************
    Class:		Property 

    Use:		This declares attributes for property  

    ***************************************************************/
    public class Property : IComparable
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

        string apt = "";

        enum propTypes { House, Apartment };

        //below are properties for each attribute, so they all have a get and set method 
        public uint Id
        {
            get { return id; }
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

        public string Apt => apt;

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
            apt = "";
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
            streetName = separateAddress[1] + separateAddress[2];

            city = newValues[5];
            state = newValues[6];
            zip = newValues[7];

            if (newValues[8].CompareTo("T") == 0)
            {
                forSale = true;
            }
            else if (newValues[8].CompareTo("F") == 0)
            {
                forSale = false;
            }

            if (newValues[12] != "T" && newValues[12] != "F")
            {
                apt = newValues[12];
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
        }

        /***************************************************************
        Function: ToString()

        Use: Builds a statement to display attributes of property 

        Arguments: None

        Returns:   string
        ***************************************************************/
        public override string ToString()
        {
            StringBuilder displayProperty = new StringBuilder();

            if (forSale == false)
            {
                displayProperty.Append(Address);
            }
            else if (forSale == true)
            {
                if (Apt == null || Apt == "")
                {
                    displayProperty.Append(Address + "\t*"); //doesn't affect just displaying the unit
                }
                else
                {
                    displayProperty.Append(Address); 
                }
            }
            

            return displayProperty.ToString();
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
        Function: Property()

        Use: Constructor for reading in values from the input file 

        Arguments: None

        Returns:   None
        ***************************************************************/

        public Residential()
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
            /*   StringBuilder displayResidential = new StringBuilder();

               if (ForSale == false)
               {
                   displayResidential.Append("\t(NOT for sale) " + Bedrooms + " bedrooms \\ " + Baths + " baths \\ " + Sqft + " sq.ft.");
               }
               else if (ForSale == true)
               {
                   displayResidential.Append("\t(FOR SALE) " + Bedrooms + " bedrooms \\ " + Baths + " baths \\ " + Sqft + " sq.ft.");
               }*/

            //used to be base.ToString() + "\n" + displayResidential.ToString()

            return base.ToString();
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
           /* StringBuilder displayHouse = new StringBuilder();

            if (garage == true)
            {
                if (attachedGarage == true)
                {
                    displayHouse.Append("\n\t... with an attached garage : " + floors + " floors.");
                }
                else
                {
                    displayHouse.Append("\n\t... with a detached garage : " + floors + " floors.");
                }
            }
            else
            {
                displayHouse.Append("\n\t... with no garage : " + floors + " floors.");
            }
            */
            //used to be base.ToString() + displayHouse.ToString(); 
            return base.ToString();
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
        public Apartment()
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
            unit = newValues[12];
        }

        /***************************************************************
        Function: ToString()

        Use: Builds a statement to display attributes of apartment 

        Arguments: None

        Returns:   string
        ***************************************************************/
        public override string ToString()           //Property tostring
        {
            StringBuilder displayApartment = new StringBuilder();

            if (ForSale == false)
            {
                displayApartment.Append("\t#\t" + Apt);
            }
            else if (ForSale == true)
            {
                displayApartment.Append("\t#\t" + Apt + "\t*");
            }
            

            return base.ToString() + displayApartment.ToString();
        }
    }
}