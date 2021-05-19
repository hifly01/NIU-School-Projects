using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TheresaLiCharlesAlms_Assign1
{
    class TheresaLiCharlesAlms_Assign1
    {
        public static void Main(string[] args)
        {
            Person person1;
            List<uint> personIDs = new List<uint>();
            List<uint> propertyIDs = new List<uint>();
            List<uint> communityIDs = new List<uint>(); 

            using (StreamReader inFile = new StreamReader("../../../p.txt"))
            {
                String[] inputPerson = inFile.ReadLine().Split('\t');           //inputPerson is the person array

                while (inFile.ReadLine() != null)
                {
                    person1 = new Person(inputPerson);
                    personIDs.Add(person1.Id);
                }
            }

            Property property1;

            using (StreamReader inFile = new StreamReader("../../../r.txt"))
            {
                String[] inputProperty = inFile.ReadLine().Split('\t');         //inputProperty is the array from the house file
                
                while (inFile.ReadLine() != null)
                {
                    //figure out what inputProperty is reading in 
                   
                    property1 = new Property(inputProperty);
                    propertyIDs.Add(property1.Id);
                }
            }
            using (StreamReader inFile = new StreamReader("../../../a.txt"))
            {
                String[] inputProperty = inFile.ReadLine().Split('\t');         //inputProperty is what the apartment is reading in

                while (inFile.ReadLine() != null)
                {
                    //figure out what inputProperty is reading in 

                    for (int i = 0; i < inputProperty.Length; i++)
                    {
                        Console.Write("i: ");
                        Console.WriteLine(i);
                        Console.WriteLine(inputProperty[i]);
                    }

                    property1 = new Property(inputProperty);
                    propertyIDs.Add(property1.Id);
                }
            }
//---------------------------------------------------------------------------------------------------

            string input = "";          //input for the user 

            Console.WriteLine("");
            Console.WriteLine("Welcome to the DeKalb realistate center");        //simple introduction 
            Console.WriteLine("Presss the number indicated to pick your selection");
            Console.WriteLine("");

            //10 availbe options below in a do while loop
            do
            {
                Console.WriteLine("\t 1. Full property list");
                Console.WriteLine("\t 2. List addresses of either House or Apartment-type properties");
                Console.WriteLine("\t 3. List addresses of all for-sale properties");
                Console.WriteLine("\t 4. List all residents of a community");
                Console.WriteLine("\t 5. List all residents of a property, by street address");
                Console.WriteLine("\t 6. Toggle a property, by street address, as being for-sale or not");
                Console.WriteLine("\t 7. Buy a for-sale property, by street address");
                Console.WriteLine("\t 8. Add yourself as an occupant to a property");
                Console.WriteLine("\t 9. Remove yourself as an occupant from a property");
                Console.WriteLine("\t 10. Quit");

                input = Console.ReadLine();         //gets user input

                //Console.WriteLine("You have picked " + input);       //testing to say what the user picked

                switch (input)
                {
                    case "1":
                        string displayMayor = " ";
                        if (person1.Id == 0)
                        {
                            displayMayor = "<" + community1.Id + "> " + community1.Name + ". Population (" + community1.Population + "). Mayor: " + person1.FullName;
                        }
                        Console.WriteLine(displayMayor);
                        //Console.WriteLine(community1.Props.);
                        break;


                    case "2":
                        Console.WriteLine("List addresses of either House or Apartment-type properties");
                        string inputHA = "";            //input for house or apartments
                        bool flag = true;
                        do
                        {
                            inputHA = Console.ReadLine();
                            if (inputHA == "House" || inputHA == "house" || inputHA == "h" || inputHA == "H")
                            {

                            }
                            else if (inputHA == "Apartment" || inputHA == "apartment" || inputHA == "a" || inputHA == "A")
                            {

                            }
                            else
                            {
                                Console.WriteLine("That is not a valid answer. Please try again");
                                flag = false;
                            }
                        } while (flag != true);
                        break;

                    case "3":
                        Console.WriteLine("List addresses of all for-sale properties");
                        //if(property for sale = true)
                        //write it out
                        break;

                    case "4":
                        Console.WriteLine("List all residents of a community");
                        break;
                        /*
                        foreach (string slacker in orderedList)
                            Console.WriteLine("{0}", slacker);
                         */ 

                    case "5":
                        Console.WriteLine("List all residents of a property, by street address");
                        Console.WriteLine("Enter a street address to look up");
                        string inputAdd = "";

                        /*
                        if(props.Contains(inputAdd) == true)
                        {
                            Console.Writeline("Found it");
                            code that displays it
                        }
                        else
                            Console.Writeline("Have not found it");

                        */
                        break;
                    case "6":
                        Console.WriteLine("Toggle a property, by street address, as being for-sale or not");
                        Console.WriteLine("Enter a street address to look up");
                        string inputFS = "";
                        /*
                        if(props.Contains(inputFS) == true)
                        {
                            Console.Writeline("Found it");
                            if(it is avaiable
                            {
                                Console.WriteLine(inputFS + "This is avaible");
                            }
                            else
                            {
                                Console.WriteLine(inputFS + "This is not avaible");
                            }
                        }
                        else
                            Console.Writeline("Have not found it");

                        */

                        break;
                    case "7":
                        Console.WriteLine("Buy a for-sale property, by street address");
                        Console.WriteLine("Enter a street address to look up and purchase");
                        string inputPurchase = "";

                        /*
                        if(props.Contains(inputPurchase) == true)
                        {
                            Console.Writeline("Found it");
                            if(it is avaiable
                            {
                                Console.WriteLine(inputFS + "This is avaible");
                                set the avaiablity to false
                            }
                            else
                            {
                                Console.WriteLine(inputFS + "This is not avaible");
                            }
                        }
                        else
                            Console.Writeline("Have not found it");
                      
                         */
                        break;
                    case "8":
                        Console.WriteLine("Add yourself as an occupant to a property");
                        Console.WriteLine("What property would you like to move into?");
                        string inputOwner = " ";

                        /*
                        if(props.Contains(inputOwner) == true)
                        {
                            Console.Writeline("Found it");
                            if(the poperty does not contain the mayor
                                add the mayor to the resident list

                            else
                                Console.WriteLine("You are already  part of this house");
                        }
                        else
                            Console.Writeline("Have not found it");
                         */
                        break;
                    case "9":
                        Console.WriteLine("Remove yourself as an occupant from a property");
                        Console.WriteLine("What property would you like to move into?");
                        string inputRem = " ";

                        /*
                        if(props.Contains(inputRem) == true)
                        {
                            Console.Writeline("Found it");
                            if(the poperty contains the mayor
                                remove the mayor to the resident list

                            else
                                Console.WriteLine("You are not part of this house");
                        }
                        else
                            Console.Writeline("Have not found it");
                         */
                        break;
                    case "10":
                        Console.WriteLine("Quiting");
                        break;

                    default:
                        Console.WriteLine("This is not an option. Please pick a number between 1 and 9. \nOr press 10 to quit");
                        break;
                }
                Console.WriteLine("");
            } while (input != "10");

            Community community1; //stores all the property and person objects, doesn't read from an input file 
            { 
            
            }
            

           /* foreach (uint i in personIDs)
            {
                foreach (uint j in propertyIDs)
                { 
                    foreach (uint k in communityIDs)
                    {
                        if (j == k || i == k || i == j)
                        {
                            Console.WriteLine("That ID already exists in the system.");
                            
                            if (j == k)
                            {
                                personIDs.Remove(j);
                            }
                            else
                            {
                                personIDs.Remove(i);
                            }
                            
                        }
                    }
                }
            }
            */
            
            
        }
    }

//----------------------------------------------------------------------------------------------------------------------
    public class Person : IComparable
    {
        private readonly uint id;                               //declare id
        private string lastName;                                
        private string firstName;
        private string occupation;
        private readonly DateTime birthday;                     //declare current date?
        private readonly int birthYear;
        private readonly int birthDay;
        private readonly int birthMonth;
        //private readonly int age;                 current year - birth year
        private List<uint> residenceIds = new List<uint>();     //LIST of IDs for residents 

        public uint Id                              //good
        {
            get { return id; }                      //do we check if the id is unique here?                                
            set { }
        }

        public string FullName => lastName + ", " + firstName;      //combine the first and last name

        public string Occupation                    //good
        {
            get { return occupation; }
            set { occupation = value; }
        }

        public DateTime Birthday                //good
        {
            get { return birthday; }
            set { }
        }

        public int BirthYear                    //good
        {
            get { return birthYear; }
            set { }
        }

        public int BirthDay                     //good
        {
            get { return birthDay; }
            set { }
        }

        public int BirthMonth                   //good
        {
            get { return birthMonth; }
            set { }
        }

        /*public int Age
        {
            get { return age = - Birthyear}
        }*/
        public uint[] ResidenceIds              
        {
            get { uint[] displayIds = residenceIds.ToArray(); return displayIds; }          //displays the ids?
        }

        public Person()                     //defult constructor 
        {
            id = 0;
            lastName = " ";
            firstName = " ";
            Occupation = " ";
            birthday = new DateTime(); 
            birthYear = 0;
            birthDay = 0;
            birthYear = 0;
            //age = 0;
            residenceIds = null; 
        }



//---------------------------------------------------------------------------------------------------------------------
        public Person(string[] newValues)
        {
            id = Convert.ToUInt32(newValues[0]);        //Array of strings holding the id, name, job, birthday info
            lastName = newValues[1];
            firstName = newValues[2];
            Occupation = newValues[3];
            birthYear = Convert.ToInt32(newValues[4]);
            birthDay = Convert.ToInt32(newValues[5]);
            birthMonth = Convert.ToInt32(newValues[6]);

            if (birthday > DateTime.Now)                //if birthday is greater than todays date
            {
                birthYear = 0;                          //i dont think we set these to 0. set it to todays date?
                birthDay = 0;
                BirthMonth = 0;
                birthday = new DateTime(); 
            }
            else
            {
                birthday = new DateTime(birthYear, birthDay, birthMonth);       //combine birthday format
            }
            residenceIds.Add(Convert.ToUInt32(newValues[7]));               //not sure what this does
        }
//----------------------my idea --------------------------------------
//          do the ToString format here and do it on last name, first name, age, and occupation?
//          
//          currentyear = new DateTime().Now;               im sure there is an easier way to do this
//          public Person(string name, string age, string job)
//          {
//              FullNamr = name;
//              age = currentyear.Year - birthyear;
//              Occupation = job;
//          }
//-----------------------------------------------------------------------------------------------------------------------------------
            public int CompareTo(Object alpha)              //good
        {
            if (alpha == null)                          //good
            {
                throw new ArgumentNullException();      //good
            }

            Person rightOp = alpha as Person;           //good

            if (rightOp != null)                        //good
            {
                return FullName.CompareTo(rightOp.FullName);        //good
            }
            else
            {
                throw new ArgumentException("[Person]: CompareTo argument is not a Person");    //good
            }
        }

        /*public override string ToString()
        {
            return base.ToString();             //return the formated string?
        }*/

        //this is what he was doing in the notes. used for option 4 with name, age, job
        /*public override string ToString()
        {
            return String.Format("{0} Age: {1} Occupation: {2}", FullName, Age, Occupation);
        }*/
    }
//----------------------------------------------------------------------------------------------------------------------------------






    public class Property : IComparable 
    {
        private readonly uint id;
        private uint ownerID;
        private readonly uint x;
        private readonly uint y;
        private string streetAddr;
        //private string streetName; //needs to be one variable and the substring gets split by a space
        private string city;
        private string state;
        private string zip;
        private bool forSale;

        enum propTypes {House, Apartment};              //enum for the housing types. 0 = hosuse, 1 = apartment 

        public uint Id
        {
            get { return id; }
            set { }
        }

        public Property()
        {
            id = 0;
            ownerID = 0;
            x = 0;
            y = 0;
            streetAddr = " ";
            //streetName = " ";
            city = " ";
            state = " ";
            zip = " ";
            forSale = false;
        }

        public Property(string[] newValues) 
        {
            id = Convert.ToUInt32(newValues[0]);
            ownerID = Convert.ToUInt32(newValues[1]);
            x = Convert.ToUInt32(newValues[2]);
            y = Convert.ToUInt32(newValues[3]);
            //streetAddr = Convert.ToUInt32(newValues[4]);          //i shifted everything down 1 after this point
            streetAddr = newValues[4];
            city = newValues[5];
            state = newValues[6];
            zip = newValues[7];
            
            for (int i = 0; i < newValues.Length; i++)          //loop through the array and set anythting labled t to true and f to false
            {
                if (newValues[i] == "T")
                {
                    newValues[i] = "True"; 
                }
                else if (newValues[i] == "F")
                {
                    newValues[i] = "False"; 
                }
            }

            forSale = Convert.ToBoolean(newValues[8]);          //if it is for sale or not

            Residential res1 = new Residential(newValues);

           // if () //variable is a string, apartment, if a bool, house
            //House house1 = new House(newValues);
            //Apartment aprtment1 = new Apartment(newValues); 
        }

        public int CompareTo(Object alpha)
        {
            if (alpha == null)                          //good
            {
                throw new ArgumentNullException();
            }

            //error for the ordering
            Property rightOp = alpha as Property;   

            if (rightOp != null)
            {
                var orderedHouse = from list in inputProperty orderby list.state, list.city, list.streetAddr, list.streetName select list;        //i think we can do this? https://stackoverflow.com/questions/4501501/custom-sorting-icomparer-on-three-fields


                /*if (state.CompareTo(rightOp.state) == 0) //check the logic of the compareTo
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
                }*/
            }
            else
            {
                throw new ArgumentException("[Property]:CompareTo argument is not a Property");         //if the vlaues are null, exception
            }
        }
    }

    public class Residential : Property             //residental extends property
    {
        private uint bedrooms;
        private uint baths;
        private uint sqft;

        public Residential()                        //defult constructor
        {
            bedrooms = 0;
            baths = 0;
            sqft = 0; 
        }

        public Residential(string [] newValues)             //constructor 
        {
            bedrooms = Convert.ToUInt32(newValues[9]);
            baths = Convert.ToUInt32(newValues[10]);
            sqft = Convert.ToUInt32(newValues[11]); 
        }
    }

    public class House : Residential 
    {
        private bool garage;
        private Nullable<bool> attachedGarage;          //if garage is attached
        private uint floors;

        public House()                                  //defult constructor
        {
            garage = false;
            attachedGarage = null;
            floors = 0; 
        }

        public House(string [] newValues)               //constructor 
        {
            for (int i = 0; i < newValues.Length; i++)      //loops throug h and writes out t for true and f for false
            {
                if (newValues[i] == "T")
                {
                    newValues[i] = "true";
                }
                else if (newValues[i] == "F")
                {
                    newValues[i] = "false";
                }
            }

            garage = Convert.ToBoolean(newValues[12]);          //at the garage portrtion of the array
            if (garage == false)                                //if no garage, set attached garage to null
            {
                attachedGarage = null;
            }
            else
            {
                attachedGarage = Convert.ToBoolean(newValues[13]);      //else, read it in and see if it is or isnt attached
            }
            floors = Convert.ToUInt32(newValues[14]);                   //floor number
        }
    }

    public class Apartment : Residential
    {
        private string unit;

        public Apartment()                          //defult constructor
        {
            unit = " "; 
        }

        public Apartment(string [] newValues)       //constructor setting the unit number to the 13th spot in the array 
        {
            unit = newValues[12];
        }

        //how to get the lists to be formated for option 2. inputProperty is what holds all of the apartment stuff from the file
        //var orderedApart = from list2 in inputProperty orderby list2.streetAddr, list2.unit, list2.city, list2.state, list2.zip select list2;

    }

    //------------------------------------------------------------------------------------------------------------------------------------
    public class Community : IComparable, IEnumerable
    {
        private SortedSet<Property> props = new SortedSet<Property>(); //what's the point of the sortedSets, stores the Property objects made before and automatically sorts them
        private SortedSet<Person> residents = new SortedSet<Person>();
        private readonly uint id;
        private readonly string name;
        private uint mayorID;
        private uint count = 0;
        private Property[] property;
        private Person[] person;

        public uint Id
        {
            get { return id; }
            set { }
        }

        public uint Population
        {
            get { foreach (Person value in residents) { count++; } return count; } 
        }

        //population = residents.Count;             //counts the population of the residents way 2

        public Community()                  //defult constructor
        {
            id = 0;
            name = " ";
            mayorID = 0;
        }

        public Community(string [] newValues)           //creates the mayor
        {                                                            
            id = 99999;
            name = "DeKalb";
            mayorID = 0; 
        }

        public int CompareTo(object alpha)              //what that Icomparable implimentation is for
        {
            if (alpha == null)
            {
                throw new ArgumentNullException();
            }

            Community rightOp = alpha as Community; 

            if (rightOp != null)
            {
                return name.CompareTo(rightOp.name);    //sorts by name by comparing 
            }
            else
            {
                throw new ArgumentException("[Community]:CompareTo argument is not a Community");
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        //this part i do not understand. why are we setting right op to null and not returning anything in commenum()?
        public CommEnum GetEnumerator() 
        {
            Object rightOp = null; //need to pass in an object
            return new CommEnum();                        //why do I need the for_each loop 
        }
    }

    public class CommEnum
    { /*
        //break statement exits the foreach loop
        if (!alpha is Student)
            //toss out an error message

        Student rightOp = alpha as Student; 

        foreach (Property i in commProperties)
        {
            if (i is House)
            }
        //add methods so foreach can compare objects */
    }

}