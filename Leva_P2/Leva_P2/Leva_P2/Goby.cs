using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leva_P2
{
    //This class is the 'Goby' class which is a child class of the parent class 'Fish'
    //It represents a 'Goby' fish in the aquarium
    //The Goby fish is able to have a partner, PShrimp
    //Also overrides the two methods from Fish, Swim() and Print()
    //One method that is unique to this class is it can choose a partner, ChoosePShrimp
    //Which will be able to partner Goby and PShrimp together if they both do not have a partner, partner = null.
    class Goby : Fish
    {
        //Private field 
        private PShrimp partner;

        //Property of the protected field
        public PShrimp Partner
        {
            get { return partner; }
        }

        //Parameterized constructor 
        //Allow to set the name for the Goby 
        public Goby (string name, Random rnd) 
            : base (rnd)
        {
            this.name = "Goby " + name;
            partner = null;
            shape = " ౨><o))}D> ";
            price = rnd.NextDouble() * (70 - 34) + 34;

        }

        //Purpose: Supposed to find an available pistol shrinmp
        //Return: none
        //Parameters: array fish - the fish in the aquarium
        //Restricitons/errors: none
        public void ChoosePShrimp(Fish[] fish)
        {
            //Loops until Goby has a partner
            while (partner == null)
            {
                //Goes through the array of fishies
                for (int i = 0; i < fish.Length; i++)
                {
                    if (fish[i] is PShrimp newPartner)
                    {

                        //Will set this shrimp to the partner if the shrimps partner is null
                        if (newPartner.Partner == null)
                        {
                            partner = newPartner;
                            newPartner.Partner = this;
                            Console.WriteLine("\t {0} partnered with shrimp {1}", Name, newPartner.Name);
                            break;
                        }

                    }

                }
                break;
            }
        }

        //Purpose:Overrides the swim method
        //Return: none
        //Parameters: int span - the total distance of the water
        //Restrictions/errors: none
        public override void Swim(int span)
        {
            if (partner == null)
                base.Swim(span);
        }

        //Purpose: overrides the print method, prints different things depending on if pertner is null or not
        //Return: none
        //Parameters: none
        //Restrictions/errors: none
        public override void Print()
        {
            if (partner != null)
            {   
                base.Print();
                Console.WriteLine("\t riding shrimp {0}", Partner.Name);
            }

            else 
                base.Print();
        }
    }
}
