using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leva_P2
{
    //This is the 'Fish' Class which will act as the Parent class to 3 other children classes
    //It represents a single fish in the aquarium
    //It has two methods that are able to be overridden, Swim and Print, by its child classes
    class Fish
    {
        //Protected fields 
        protected Random randomObj;
        protected string name;
        protected string shape;
        protected double price;
        protected ConsoleColor color;

        //Properties of the protected fields, get only needed
        public string Name
        {
            get { return name; }
        }

        public double Price
        {
            get { return price; }
        }

        //Paramized constructor, initializes the protected fields
        //Takes in a Random as its parameter to produce a fish object
        public Fish(Random rdn)
        {
            randomObj = rdn;
            name = (randomObj.Next(101)).ToString();
            shape = " <C>< ";
            price = 5.0;

            //CODE TAKEN FROM PROJECT SHEET
            //Creates an array with the values of ConsoleColor enumeraztion members
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            int num = randomObj.Next(colors.Length);

            color = colors[num];
        }

        //Purpose: Prints a visual representation of the fish in water
        //Return: none
        //Paramaters: int start - the location of the fish
        //            int span - the width of the water (~)
        //Restricitons/errors: none
        public void MeInWater(int start, int span)
        {
            for (int i = 0; i < start; i++)
                Console.Write("~");

            Console.ForegroundColor = color;
            Console.Write(shape);
            //Console.ForegroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray; //changed to white so i can see it on my terminal

            //Gets the remaining number of ~'s to print
            int remaining = (span - start) - shape.Length;
            for (int i = 0; i < remaining; i++)
                Console.Write("~");

            Console.WriteLine("");
        }

        //Purpose: Moves the fish a set number of spaces
        //Return: none
        //Parameters: int span - the width of the water
        //Restricitons/errors: none
        //May be overridden
        public virtual void Swim(int span)
        {
            //Gets the limit of how far the fish can move
            int num = span - shape.Length;
            int start = randomObj.Next(num);

            MeInWater(start, span);
        }

        //Purpose: Prints the fish's details
        //Return: none
        //Parameters: none
        //Restricitons/errors: none
        //May be overridden
        public virtual void Print()
        {
            Console.WriteLine("Fish {0}: {1} {2} for ${3:F2}", name, shape, color, price);
        }
    }
}

