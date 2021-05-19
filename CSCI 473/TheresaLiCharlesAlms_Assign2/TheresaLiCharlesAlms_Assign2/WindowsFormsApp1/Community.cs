/********************************************************************
CSCI 473 - Assignment 2 - Spring 2020

Programmers: Theresa Li (Z1814730), Charles Alms (Z1797837) 
Section:    1
TA:         Jennifer Ho & Sridivya Pagadala
Date Due:   2/13/20

Purpose:    This program is teaching us to make a real estate GUI using 
            C#
*********************************************************************/

/***************************************************************
    Class:		Community 

    Use:		This declares attributes for residential  

    ***************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TheresaLiCharlesAlms_Assign2
{
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
