using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leva_P2
{
    //This class represents a pistol shrimp in the aquarium
    //It is a child class of the parent class Fish class
    //They are able to pair up with a Goby fish in the aquarium
    //The two methods are overridden, Swim and Print
    class PShrimp : Fish
    {
        //Pirvate field
        private Goby partner;

        //Property for the field, has both a get adn a set
        public Goby Partner
        {
            get { return partner; }
            set { partner = value; }
        }

        //Parameterized constructor 
        public PShrimp (Random rnd) 
            : base (rnd)
        {
            Partner = null;
            shape = " D-x00x:༄ ";
            price = rnd.NextDouble() * (23 - 18) + 18;
        }

        //Purpose: overrides the swim method, depends on if this shrimp has a partner or not
        //Return: none
        //Parameters: int span - the length of the water
        //Restrictions/errors: none
        public override void Swim(int span)
        {
            Random rnd = new Random();
            int start = (rnd.Next(span - shape.Length));

            if (Partner != null)
                Partner.MeInWater(start, span);

            else
                MeInWater(start, span);
        }

        //Purpose: Overrides the Print method, will print additional info if shrimp has a partner
        //Return: none
        //Parameters: none
        //Restrictions/errors: none
        public override void Print()
        {
            if (Partner != null)
            {
                base.Print();
                Console.WriteLine("\t carrying partner {0}", Partner.Name);
            }

            else
                base.Print();
        }

    }

}
