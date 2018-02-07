using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leva_P2
{
    //This class is the 'Knifefish' class, which is a child class
    //The parent is the 'Fish' class
    //This class represents a Ghost Knifefish in the aquarium 
    //The Knifefish has one unique method, Broadcast
    //Which will search the aquarium for other Knifefish and send a broadcast to them 
    class Knifefish : Fish
    {
        //Paramterized constructor 
        public Knifefish(string name, Random rnd)
            : base(rnd)
        {
            this.name = "Ghost Knife " + name;
            shape = " <w||><t ";
            price = rnd.NextDouble() * (50 - 20) + 20;
        }

        //Purpose: Communicates with other nearby Knifefish (via electriacl pulses)
        //Return: none
        //Parameters: array Fish - Goes through the fish array to check for other Knifefish
        //Restricitons/error: none
        public void Broadcast(Fish[] fish)
        {
            //bool that will check if there are other knifefish
            bool heardBrdcst = false;

            //Goes through the fish array
            for (int i = 0; i < fish.Length; i++)
            {
                //checks to see if the FIsh is a KnifeFIsh and if it isnt the same
                if ((fish[i] is Knifefish) && (this != fish[i]))
                {
                    Console.Write("{0}, ", fish[i].Name);
                    heardBrdcst = true;
                }
            }
            
            //Will print this message if the broadcast was heard
            //Only happens when there are at least 2 KinfeFish in the array
            if (heardBrdcst)
                Console.WriteLine("and the NSA heard the bzzzz broadcast by {0}", Name);
        }
    }
}
