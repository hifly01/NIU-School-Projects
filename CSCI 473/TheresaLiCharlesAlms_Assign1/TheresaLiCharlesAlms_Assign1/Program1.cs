/********************************************************************
CSCI 473 - Assignment 1 - Spring 2020

Programmers: Theresa Li (Z1814730), Charles Alms (Z1797837) 
Section:    1
TA:         Jennifer Ho & Sridivya Pagadala
Date Due:   1/30/20

Purpose:    This program is teaching us to make a real estate console 
            program using C#. 
*********************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TheresaLiCharlesAlms_Assign1
{
    class TheresaLiCharlesAlms_Assign1
    {
        public static void Main(string[] args) //main function runs the program 
        {
            Person person1 = null; //person object
            House house1 = null; //house object
            Apartment apartment1 = null; //apartment object
            Community community1 = new Community(); //community object

            List<uint> personIDs = new List<uint>(); //list of person object IDs
            List<uint> propertyIDs = new List<uint>(); //list of property object IDs
            List<uint> communityIDs = new List<uint>(); //list of community object IDs

            SortedDictionary<uint, Person> personInfo = new SortedDictionary<uint, Person>(); //dictionary of person objects 
            SortedDictionary<uint, Property> propertyInfo = new SortedDictionary<uint, Property>(); //dictionary of property objects

            using (StreamReader inFile = new StreamReader("../../../p.txt")) //this is for reading in the input file 
            {
                String readFile = inFile.ReadLine(); //first we read one line 
                String[] inputPerson;

                while (readFile != null) //if the line isn't null, it will keep on storing and reading 
                {
                    inputPerson = readFile.Split('\t'); //it is splitting based on whether or not there is a tab between the two attributes
                    person1 = new Person(inputPerson); //person object is reading in the input file 
                    community1.Residents.Add(person1); //person object is added to the community 
                    personInfo.Add(person1.ResidenceIds[0], person1); //person object is added to the sorted set
                    personIDs.Add(person1.ResidenceIds[0]); //person object is added to the sorted set 

                    readFile = inFile.ReadLine(); //continue reading 
                }
            }

            using (StreamReader inFile = new StreamReader("../../../r.txt")) //this is for reading in the input file 
            {
                String readFile = inFile.ReadLine(); //first we read one line 
                String[] inputProperty1;

                while (readFile != null) //if the line isn't null, it will keep on storing and reading 
                {
                    inputProperty1 = readFile.Split('\t'); //it is splitting based on whether or not there is a tab between the two attributes
                    house1 = new House(inputProperty1); //house object is reading in the input file 
                    community1.Props.Add(house1); //house object is added to the community 

                    propertyInfo.Add(house1.Id, house1); //house object is added to the sorted set
                    propertyIDs.Add(house1.Id); //house object is added to the sorted set 

                    readFile = inFile.ReadLine(); //continue reading 
                }
            }

            using (StreamReader inFile = new StreamReader("../../../a.txt")) //this is for reading in the input file 
            {
                String readFile = inFile.ReadLine(); //first we read one line 
                String[] inputProperty2;

                while (readFile != null) //if the line isn't null, it will keep on storing and reading 
                {
                    inputProperty2 = readFile.Split('\t'); //it is splitting based on whether or not there is a tab between the two attributes
                    apartment1 = new Apartment(inputProperty2); //apartment object is reading in the input file
                    community1.Props.Add(apartment1); //apartment object is added to the community 

                    propertyInfo.Add(apartment1.Id, apartment1); //apartment object is added to the sorted set
                    propertyIDs.Add(apartment1.Id); //apartment object is added to the sorted set 

                    readFile = inFile.ReadLine(); //continue reading 
                }
            }

            foreach (uint i in personIDs)
            {
                foreach (uint j in propertyIDs)
                {
                    foreach (uint k in communityIDs)
                    {
                        if (j == k || i == k || i == j) //this is for comparing if the ids are same 
                        {
                            Console.WriteLine("That ID already exists in the system.");

                            if (j == k) //if the property ID and the community ID are the same, they will be removed
                            {
                                personIDs.Remove(j);
                            }
                            else //otherwise the person ID is equal to something and then removed
                            {
                                personIDs.Remove(i);
                            }

                        }
                    }
                }
            }

            string input = ""; //for the user's decision
            int exit = 0;

            while (exit == 0) //if the user types certain characters, it will quit 
            {
                Console.WriteLine("\n1. Full property list"); //menu options
                Console.WriteLine("2. List addresses of either House or Apartment-type properties");
                Console.WriteLine("3. List addresses of all for-sale properties");
                Console.WriteLine("4. List all residents of a community");
                Console.WriteLine("5. List all residents of a property, by street address");
                Console.WriteLine("6. Toggle a property, by street address, as being for-sale or not");
                Console.WriteLine("7. Buy a for-sale property, by street address");
                Console.WriteLine("8. Add yourself as an occupant to a property");
                Console.WriteLine("9. Remove yourself as an occupant from a property");
                Console.WriteLine("10. Quit");

                input = Console.ReadLine(); //wait for the user to type something in 

                if (input == "q" || input == "Q" || input == "Quit" || input == "quit" || input == "exit" || input == "Exit") //if the user types any of these, it will quit
                {
                    exit++; 
                }

                //actions for the menu 
                switch (input)
                {
                    case "1": //full property list
                        string displayMayor = " ";

                        //this will search through each person in the community until the mayor is found with an id of 0 and displays them first
                        foreach (Person i in community1.Residents) 
                        {
                            if (i.Id == 0)
                            {
                                displayMayor = "<" + community1.Id + "> " + community1.Name + ". Population (" + community1.Population + "). Mayor: " + i.FullName;
                                Console.WriteLine(displayMayor);
                                Console.WriteLine("------------------------------------------------------------------------");
                            }
                        }

                        //then for each person, it will display their info along with what property they own 
                        foreach (KeyValuePair<uint, Person> per1 in personInfo)
                        {
                            foreach (KeyValuePair<uint, Property> pro1 in propertyInfo)
                            {
                                if (per1.Key == pro1.Key) //this is from the sortedDictionary, and it aligns the person and property through the dictionary keys or ids
                                {
                                    Console.WriteLine(pro1.Value); 

                                    Console.WriteLine(per1.Value + "\n");
                                }
                            }
                        }
                        break;

                    case "2": //list addresses of either House or Apartment-type properties
                        Console.WriteLine("Enter property type (House/Apartment): ");
                        Console.WriteLine("------------------------------------------------------------------------");
                        string inputHA = "";
                        bool flag = false;

                        while (flag == false)
                        {
                            inputHA = Console.ReadLine(); //this is asking if the user wants to see addresses of apartment of houses
                            if (inputHA == "House" || inputHA == "house" || inputHA == "h" || inputHA == "H") //possible inputs for houses
                            {
                                foreach (Property i in community1.Props) //cycles through properties
                                {
                                    if (i is House) //and picks out the hosue objects
                                    {
                                        Console.WriteLine(i.Address + " " + i.City + ", " + i.State + ", " + i.Zip);
                                    }
                                }

                                flag = true; //exits out
                            }
                            else if (inputHA == "Apartment" || inputHA == "apartment" || inputHA == "a" || inputHA == "A") //possible inputs for apartment
                            { 
                                foreach (Property i in community1.Props) //cycles through properties
                                {
                                    if (i is Apartment) //and picks out the apartment objects
                                    {
                                        Console.WriteLine(i);
                                    }
                                }

                                flag = true; //exits out
                            }
                            else
                            {
                                Console.WriteLine("That is not a valid answer. Please try again"); //if the user types anything other than h or a
                                flag = false; //loop continues
                            }
                        }
                        break;

                    case "3": //list addresses of all for-sale properties 
                        Console.WriteLine("List addresses of all FOR SALE properties in the DeKalb community");
                        Console.WriteLine("------------------------------------------------------------------------");

                        foreach (Property i in community1.Props) //cycles through properties
                        {
                            if (i.ForSale == true) //if the property is for sale 
                            {
                                if (i is House) //and it is a house, it will display in that format
                                {
                                    Console.WriteLine(i.Address + " " + i.City + ", " + i.State + ", " + i.Zip);
                                }

                                if (i is Apartment) //and it is an aparmtnet, ti will display in that format 
                                {
                                    Console.WriteLine(i.Address + " Apt.# " + i.Apt + " " + i.City + ", " + i.State + ", " + i.Zip);
                                }
                            }
                        }
                        break;

                    case "4": //list all residents of a community 
                        Console.WriteLine("List all resident living in the DeKalb community");
                        Console.WriteLine("------------------------------------------------------------------------");

                        foreach (Person i in community1.Residents) //cycles through all the people in the community 
                        {
                            Console.WriteLine(i.FullName + ", Age (" + i.Age + "), Occupation: " + i.Occupation + "\n");
                        }

                        break;

                    case "5": //list all residents of a property, by street address
                        Console.WriteLine("Enter the street address to lookup: ");
                        string inputAdd = "";
                        bool flag5 = false; //for getting out of the loop 

                        while (flag5 == false)
                        {
                            inputAdd = Console.ReadLine(); //user types in address

                            foreach (Property i in community1.Props)        //loops through all the properties in the community1 sorted set
                            {
                                if (i is House)                             //if the type is a house
                                {
                                    if (i.Address.Contains(inputAdd)) //checks if the address and user input is the same 
                                    {
                                        Console.WriteLine("List of residents living at " + i.Address + ": ");
                                        Console.WriteLine("------------------------------------------------------------------------");
                                        foreach (KeyValuePair<uint, Person> per1 in personInfo) //for each person pair in sorted set
                                        {
                                            if (per1.Key == i.Id) //if the person key matches the property key, then it will display residents 
                                            {
                                                Console.WriteLine(per1.Value.FullName + ", Age (" + per1.Value.Age + "), Occupation: " + per1.Value.Occupation + "\n");
                                            }
                                        }
                                        flag5 = true; //exits loop 
                                    }
                                }
                                else if (i is Apartment) //if the type is an apartment 
                                {
                                    if (i.Address.Contains(inputAdd))
                                    {
                                        Console.WriteLine("List of residents living at " + i.Address + ": ");
                                        Console.WriteLine("------------------------------------------------------------------------");
                                        foreach (KeyValuePair<uint, Person> per1 in personInfo) //for each person pair in sorted set
                                        {
                                            if (per1.Key == i.Id) //if the person key matches the property key, then it will display residents 
                                            {
                                                Console.WriteLine(per1.Value.FullName + ", Age (" + per1.Value.Age + "), Occupation: " + per1.Value.Occupation + "\n");
                                            }
                                        }
                                        flag5 = true; //exits loop 
                                    }
                                }
                            }
                        }
                        break;

                    case "6": //toggle a property, by street address, as begin for-sale or not
                        Console.WriteLine("Toggle a property, by street address, as being for-sale or not");
                        Console.WriteLine("Enter a street address to look up");
                        string inputFS = ""; //FS stands for for sale 
                        bool flag6 = false; //for exiting 

                        while (flag6 == false)
                        {
                            inputFS = Console.ReadLine();
                            foreach (Property i in community1.Props)        //loops through all the properties in the community1 sorted set
                            {
                                if (i is House)                             //if the type is a house
                                {
                                    if (i.Address == inputFS)          //look at the address of the house and compare it to thte input
                                    {
                                        if (i.ForSale == true)         //look at the house if it was found to check the forsale 
                                        {
                                            i.ForSale = false;  //toggles it to false from true 
                                            Console.WriteLine(i.Address + " is now listed as NOT for sale!");
                                        }
                                        else if (i.ForSale == false)
                                        {
                                            i.ForSale = true; //toggles it to true from false 
                                            Console.WriteLine(i.Address + " is now listed as FOR sale!");
                                        }
                                        flag6 = true;           //break out of the while loop
                                    }
                                }
                                else if (i is Apartment)                    //looks to see if the value is an apartment
                                {
                                    if (i.Address == inputFS)          //look at the address of the house and compare it to thte input
                                    {
                                        if (i.ForSale == true)         //look at the house if it was found to check the forsale 
                                        {
                                            i.ForSale = false; //toggles it to false from true 
                                            Console.WriteLine(i.Address + " is now listed as NOT for sale!");
                                        }
                                        else if (i.ForSale == false)
                                        {
                                            i.ForSale = true; //toggles it to true from false 
                                            Console.WriteLine(i.Address + " is now listed as FOR sale!");
                                        }
                                        flag6 = true;           //break out of the while loop
                                    }
                                }
                            }
                            if (flag6 == false)              //breaks out of the foreach loop to prevent multiple messages
                            {
                                Console.WriteLine("That is not a valid address. Please try again");
                            }
                        }

                        break;

                    case "7": //buy a for-sale property, by street address
                        Console.WriteLine("Enter a street address to look up and purchase");
                        string inputPurchase = "";
                        bool flag7 = false; //exit loop 

                        while (flag7 == false)
                        {
                            inputPurchase = Console.ReadLine();
                            foreach (Property i in community1.Props)        //loops through all the properties in the community1 sorted set
                            {
                                if (i is House)                             //if the type is a house
                                {
                                    if (i.Address == inputPurchase)          //look at the address of the house and compare it to thte input
                                    {
                                        if (i.ForSale == true)         //look at the house if it was found to check the forsale 
                                        {
                                            i.ForSale = false;  //toggles it to false since it is bought

                                            foreach (KeyValuePair<uint, Person> per1 in personInfo)
                                            {
                                                foreach (KeyValuePair<uint, Property> pro1 in propertyInfo)
                                                {
                                                    if (i.Id == per1.Key && per1.Key == pro1.Key) //it will display the current property info after being bought 
                                                    {
                                                        Console.WriteLine("Congratulations! You have successfully purchased this property!");
                                                        Console.WriteLine(pro1.Value); //need to use compareTo in order for it to be ordered right
                                                        Console.WriteLine(per1.Value + "\n");
                                                    }
                                                }
                                            }
                                        }
                                        else if (i.ForSale == false)
                                        {
                                            Console.WriteLine("This property is not for sale, and stealing is wrong.");
                                        }
                                        flag7 = true;           //break out of the while loop
                                    }
                                }
                                else if (i is Apartment)                    //looks to see if the value is an apartment
                                {
                                    if ((i.Address + " " + i.Apt) == inputPurchase)          //look at the address of the house and compare it to thte input
                                    {
                                        if (i.ForSale == true)         //look at the house if it was found to check the forsale 
                                        {
                                            i.ForSale = false; //toggles it to false since it is bought

                                            foreach (KeyValuePair<uint, Person> per1 in personInfo)
                                            {
                                                foreach (KeyValuePair<uint, Property> pro1 in propertyInfo)
                                                {
                                                    if (i.Id == per1.Key && per1.Key == pro1.Key) //it will display the current property info after being bought 
                                                    {
                                                        Console.WriteLine("Congratulations! You have successfully purchased this property!");
                                                        Console.WriteLine(pro1.Value); //need to use compareTo in order for it to be ordered right
                                                        Console.WriteLine(per1.Value + "\n");
                                                    }
                                                }
                                            }
                                        }
                                        else if (i.ForSale == false)
                                        {
                                            Console.WriteLine("This property is not for sale, and stealing is wrong.");
                                        }
                                        flag7 = true;           //break out of the while loop
                                    }
                                }
                            }
                            if (flag7 == false)              //breaks out of the foreach loop to prevent multiple messages
                            {
                                Console.WriteLine("That is not a valid address. Please try again");
                            }
                        }
                        break;

                    case "8":
                        Console.WriteLine("Enter the street address to lookup: ");
                        string inputMoving = "";
                        bool flag8 = false;
                        uint newKey = 0;
                        int stealing = 0;
                        int fakeAddress = 0;
                        int foundIt = 0; 

                        while (flag8 == false)
                        {
                            inputMoving = Console.ReadLine();
                            foreach (Property i in community1.Props)        //loops through all the properties in the community1 sorted set
                            {
                                if (i is House && i.ForSale == true)                             //if the type is a house
                                {
                                    if (i.Address.Contains(inputMoving))          //look at the address of the house and compare it to thte input
                                    {
                                        fakeAddress = 0; 
                                        foreach (KeyValuePair<uint, Person> per1 in personInfo)
                                        {
                                            if (per1.Key == i.Id)
                                            {
                                                foundIt++; 
                                                newKey = (uint)per1.Key; //saving the key where the mayor matches up to a new variable 
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (foundIt == 0)
                                        {
                                            fakeAddress++; //checks if the address is in the system 
                                        }
                                    }
                                }
                                else if (i is Apartment && i.ForSale == true)
                                {
                                    if ((i.Address + " " + i.Apt).Contains(inputMoving))          //look at the address of the house and compare it to thte input
                                    {
                                        fakeAddress = 0;

                                        foreach (KeyValuePair<uint, Person> per1 in personInfo)
                                        {
                                            if (per1.Key == i.Id)
                                            {
                                                foundIt++;
                                                newKey = (uint)per1.Key; //saving the key where the mayor matches up to a new variable 
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (foundIt == 0)
                                        {
                                            fakeAddress++; //checks if the address is in the system 
                                        }
                                    }
                                }
                                else
                                {
                                    if (i.Address.Contains(inputMoving))          //look at the address of the house and compare it to thte input
                                    {
                                        fakeAddress = 0;
                                        foundIt++; 
                                        Console.WriteLine("Stealing properties is wrong."); //accounts for if the property is not for sale 
                                        stealing++;
                                        flag8 = true;
                                    }
                                }
                            }

                            if (fakeAddress > 0)
                            {
                                Console.WriteLine("I'm sorry, I don't recognize this address"); //if the address is fake 
                                flag8 = true;
                            }

                            foreach (Person mayor in community1.Residents)
                            {
                                if (mayor.Id == 0) //if this is the mayor
                                {
                                    if (newKey == mayor.ResidentId) //sees if the mayor owns the property 
                                    {
                                        Console.WriteLine("You are already a resident at this property.");
                                        flag8 = true;
                                    }
                                    else if (newKey != mayor.ResidentId && stealing == 0 && fakeAddress == 0) //if they don't, then the mayor can add his own property 
                                    {
                                        Console.WriteLine("Success! You have been added as a resident at this property");
                                        personInfo[newKey] = mayor;
                                        mayor.ResidentId = newKey; 
                                        flag8 = true;
                                    }
                                }
                            }
                        }
                        break;

                    case "9":
                        Console.WriteLine("Enter the street address to lookup: ");
                        string inputMovingOut = "";
                        bool flag9 = false;
                        uint newKey2 = 0;
                        int fakeAddress2 = 0;
                        int foundIt2 = 0;

                        while (flag9 == false)
                        {
                            inputMovingOut = Console.ReadLine();
                            foreach (Property i in community1.Props)        //loops through all the properties in the community1 sorted set
                            {
                                if (i is House && i.ForSale == true)                             //if the type is a house
                                {
                                    if (i.Address.Contains(inputMovingOut))          //look at the address of the house and compare it to thte input
                                    {
                                        fakeAddress2 = 0;
                                        foreach (KeyValuePair<uint, Person> per1 in personInfo)
                                        {
                                            if (per1.Key == i.Id)
                                            {
                                                foundIt2++;
                                                newKey2 = (uint)per1.Key; //saving the key where the mayor matches up to a new variable 
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (foundIt2 == 0)
                                        {
                                            fakeAddress2++; //accounts for if the address is fake 
                                        }
                                    }
                                }
                                else if (i is Apartment && i.ForSale == true)
                                {
                                    if ((i.Address + " " + i.Apt).Contains(inputMovingOut))          //look at the address of the house and compare it to thte input
                                    {
                                        fakeAddress2 = 0;

                                        foreach (KeyValuePair<uint, Person> per1 in personInfo)
                                        {
                                            if (per1.Key == i.Id)
                                            {
                                                foundIt2++;
                                                newKey2 = (uint)per1.Key; //saving the key where the mayor matches up to a new variable 
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (foundIt2 == 0)
                                        {
                                            fakeAddress2++; //accounts for if the address is fake 
                                        }
                                    }
                                }
                                else
                                {
                                    if (i.Address.Contains(inputMovingOut))          //look at the address of the house and compare it to thte input
                                    {
                                        fakeAddress2 = 0;
                                        foundIt2++;
                                        Console.WriteLine("You are not a resident at this property.");
                                        flag9 = true;
                                    }
                                }
                            }

                            if (fakeAddress2 > 0)
                            {
                                Console.WriteLine("I'm sorry, I don't recognize this address"); //accounts for if the address is fake 
                                flag9 = true;
                            }

                            Person blankPerson = new Person(); 
                            foreach (Person mayor in community1.Residents)
                            {
                                if (mayor.Id == 0) //if this is the mayor
                                {
                                    if (newKey2 == mayor.ResidentId && fakeAddress2 == 0) //sees if the mayor owns the property 
                                    {
                                        Console.WriteLine("Success! You have been removed as a resident at this property");
                                        personInfo[newKey2] = blankPerson;
                                        mayor.ResidentId = 0;
                                        flag9 = true;
                                    }
                                }
                            }
                        }
                        break;

                    case "10": 
                        exit++; 
                        break;

                    default:
                        if (input != "q" && input != "Q" && input != "Quit" && input != "quit" && input != "exit" && input != "Exit")
                        {
                            Console.WriteLine("This is not an option. Please pick a number between 1 and 9. \nOr press 10 to quit");
                        }
                    break;
                }
            }
        }
    }

    /***************************************************************
    Class:		Person

    Use:		This declares attributes for person 

    ***************************************************************/

    public class Person : IComparable
    {
        private readonly uint id; 
        private string lastName;
        private string firstName;
        private string occupation;
        private readonly DateTime birthday; 
        private readonly int birthYear;
        private readonly int birthDay;
        private readonly int birthMonth;
        private uint residentId; 
        private List<uint> residenceIds = new List<uint>();

        //below are properties for each attribute, so they all have a get and set method 
        public uint Id 
        {
            get { return id; }                                                      
            set { }
        }

        public string FullName => lastName + ", " + firstName;

        public string Occupation
        {
            get { return occupation; }
            set { occupation = value; }
        }

        public DateTime Birthday
        {
            get { return birthday; }
            set { }
        }

        public int BirthYear
        {
            get { return birthYear; }
            set { }
        }

        public int BirthDay
        {
            get { return birthDay; }
            set { }
        }

        public int BirthMonth
        {
            get { return birthMonth; }
            set { }
        }

        public int Age //this get has fancy math to calculate your age from your birthday
        {
            get { DateTime today = DateTime.Today; int age = today.Year - birthday.Year; if (birthday.Date > today.AddYears(-age)) { age--; } return age; }
            set { }
        }

        public uint ResidentId
        {
            get { return residentId; }
            set { residentId = value;  }
        }

        public uint[] ResidenceIds
        {
            get { uint[] displayIds = residenceIds.ToArray(); return displayIds; }
        }

        /***************************************************************
        Function: Person()

        Use: Default Constructor that sets stuff to default empty values  

        Arguments: None

        Returns:   None
        ***************************************************************/
        public Person()
        {
            id = 0;
            lastName = " ";
            firstName = " ";
            Occupation = " ";
            birthday = new DateTime(); 
            birthYear = 0;
            birthDay = 0;
            birthYear = 0;
            residentId = 0; 
            residenceIds = null; 
        }

        /***************************************************************
        Function: Person()

        Use: Constructor for reading in values from the input file 

        Arguments: None

        Returns:   None
        ***************************************************************/
        public Person(string[] newValues)
        {
            id = Convert.ToUInt32(newValues[0]);
            lastName = newValues[1];
            firstName = newValues[2];
            Occupation = newValues[3];
            birthYear = Convert.ToInt32(newValues[4]);
            birthDay = Convert.ToInt32(newValues[5]);
            birthMonth = Convert.ToInt32(newValues[6]);
            if (birthday > DateTime.Now)
            {
                birthYear = 0;
                birthDay = 0;
                BirthMonth = 0;
                birthday = new DateTime(); 
            }
            else
            {
                birthday = new DateTime(birthYear, birthDay, birthMonth);
            }
            residentId = Convert.ToUInt32(newValues[7]); 
            residenceIds.Add(Convert.ToUInt32(newValues[7]));
        }

        /***************************************************************
        Function: CompareTo()

        Use: Sorts out last name and first name of people in alphabetical order

        Arguments: Object

        Returns:   int
        ***************************************************************/
        public int CompareTo(Object alpha)
        {
            if (alpha == null)
            {
                throw new ArgumentNullException();
            }

            Person rightOp = alpha as Person;

            if (rightOp != null)
            {
                return FullName.CompareTo(rightOp.FullName);
            }
            else
            {
                throw new ArgumentException("[Person]: CompareTo argument is not a Person");
            }
        }

        /***************************************************************
        Function: ToString()

        Use: Builds a statement to display attributes of people 

        Arguments: None

        Returns:   string
        ***************************************************************/
        public override string ToString()
        {
            StringBuilder displayPeople = new StringBuilder();
            displayPeople.Append("\tOwned by " + FullName + ", Age (" + Age + "), Occupation: " + Occupation);
            return displayPeople.ToString();
        }
    }

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

        enum propTypes {House, Apartment};

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
            set { forSale = value;  }
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

            displayProperty.Append("Property Address: " + Address + " / " + City + " / " + State + " / " + Zip);

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
            StringBuilder displayResidential = new StringBuilder();

            if (ForSale == false)
            {
                displayResidential.Append("\t(NOT for sale) " + Bedrooms + " bedrooms \\ " + Baths + " baths \\ " + Sqft + " sq.ft.");
            }
            else if (ForSale == true)
            {
                displayResidential.Append("\t(FOR SALE) " + Bedrooms + " bedrooms \\ " + Baths + " baths \\ " + Sqft + " sq.ft.");
            }

            return base.ToString() + "\n" + displayResidential.ToString();
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

        public House(string [] newValues) : base(newValues) //need IComparable
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
        public Apartment(string [] newValues) : base(newValues)
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

            displayApartment.Append(" Apt.# " + Apt);

            return base.ToString() + displayApartment.ToString();
        }
    }

    /***************************************************************
    Class:		Community 

    Use:		This declares attributes for residential  

    ***************************************************************/
    public class Community : IComparable, IEnumerable
    {
        private SortedSet<Property> props = new SortedSet<Property>(); 
        private SortedSet<Person> residents = new SortedSet<Person>();
        private readonly uint id;
        private readonly string name;
        private uint mayorID;

        //below are properties for each attribute, so they all have a get and set method 
        public uint Id
        {
            get { return id; }
            set { }
        }

        public int Population
        {
            get { return residents.Count; } 
            set { }
        }

        public string Name
        {
            get { return name; }
            set { }
        }

        public uint MayorID
        {
            get { return mayorID; }
            set { }
        }

        public SortedSet<Property> Props 
        {
            get { return props; }
            set { props = value; }
        }

        public SortedSet<Person> Residents
        {
            get { return residents; }
            set { residents = value; }
        }

        /***************************************************************
        Function: Community()

        Use: Constructor for reading in values from the input file 

        Arguments: None

        Returns:   None
        ***************************************************************/
        public Community()
        {
            id = 99999;
            name = "DeKalb";
            mayorID = 0;
        }

        /***************************************************************
        Function: CompareTo()

        Use: Sorts out community attributes

        Arguments: Object

        Returns:   int
        ***************************************************************/
        public int CompareTo(object alpha)
        {
            if (alpha == null)
            {
                throw new ArgumentNullException();
            }

            Community rightOp = alpha as Community; 

            if (rightOp != null)
            {
                return name.CompareTo(rightOp.name);
            }
            else
            {
                throw new ArgumentException("[Community]:CompareTo argument is not a Community");
            }
        }

        IEnumerator IEnumerable.GetEnumerator() //this is an enumerator 
        {
            return (IEnumerator)GetEnumerator();
        }

        public CommEnum GetEnumerator() //this gets the enumerator 
        {
            return new CommEnum(props.ToArray());                     
        }
    }

    public class CommEnum : IEnumerator //this has methods for the enumerator 
    {
        public Property[] _prop;

        int position = -1;

        public CommEnum(Property[] list)
        {
            _prop = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _prop.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Property Current
        {
            get
            {
                try
                {
                    return _prop[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}