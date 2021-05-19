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

namespace TheresaLiCharlesAlms_Assign4
{
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

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

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
            set { residentId = value; }
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
            displayPeople.Append(FirstName + "\t" + Age + "\t" + Occupation);
            return displayPeople.ToString();
        }
    }
}