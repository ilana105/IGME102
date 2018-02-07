using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leva_P2
{
    //Ilana Leva
    //This class will simulate the aquarium being stocked
    //It contians 2 other methods along with the main method
    //The user is able to stock the aquarium with at least 17 fish for it to run properly
    //The user can call broadcast on the array of fish    
    //Then the user can partner the Goby's and shrimp in the tank together
    //The user can also print the full aquarium and the fish details and get the total price
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.WriteLine("Ilana Leva, Aquarium Project");
            Console.WriteLine("");

            //Stocks the aquarium
            Fish[] fishies = StockAquarium(17, rnd);

            //Goes through the fish array 
            //Uses the first knifefish in the array to broadcast to the rest
            foreach (Fish f in fishies)
            {
                if (f is Knifefish fish)
                {
                    fish.Broadcast(fishies);
                    break;
                }

            }
            Console.WriteLine("");

            //Partners the Goby's and Shrimp together
            PartnerGobies(fishies);
            Console.WriteLine("");
            
            //Prints the full aquarium with all the fishies
            Console.WriteLine("The full aquarium:");
            foreach (Fish f in fishies)
            {
                f.Swim(50);
            }

            Console.WriteLine("");

            //Prints each fishs' details (name, shape, color, price)
            Console.WriteLine("***** Stock details *****");

            double total = 0.0;
            foreach (Fish f in fishies)
            {
                f.Print();
                total += f.Price; //adds up the price
            }

            //Prints the total price of the aquarium
            Console.WriteLine("");
            Console.WriteLine("Total starting cost: ${0:F2}", total);

        }
        //Purpose: Stocks the aquarium with fish
        //Return: Array of Fish - the aquarium with numFish fishes
        //Parameters: int numFish - number of fish in the aquarium
        //            Random rnd - used to summon the 4 types of fishes
        //Restricitons/errors: none
        static Fish[] StockAquarium(int numFish, Random rnd)
        {
            //allocates space for numFish 
            Fish[] fishies = new Fish[numFish];
            int gene;
            Console.WriteLine("***** Stocking the aquariums! *****");

            //goes through the empty array
            for (int i = 0; i < fishies.Length; i++)
            {
                gene = rnd.Next(4);

                //switch-case block that will fill it with fish
                switch (gene)
                {
                    case 0:
                        fishies[i] = new PShrimp(rnd);
                        break;

                    case 1:
                        fishies[i] = new Goby(i.ToString(), rnd);
                        break;

                    case 2:
                        fishies[i] = new Knifefish(i.ToString(), rnd);
                        break;

                    case 3:
                        fishies[i] = new Fish(rnd);
                        break;
                }
            }

            return fishies;
        }

        //Purpose: Try to find partners for all the Goby fish in the Fish array
        //Return: Fish Array - the array of fish that will partner with the goby fish
        //Parameters:
        //Restrictions/errors: none
        static void PartnerGobies(Fish[] fishies)
        {
            Console.WriteLine("Attempting to partner goby fish. . . ");
            
            for (int i = 0; i < fishies.Length; i++)
            {
                if (fishies[i] is Goby fish)
                    fish.ChoosePShrimp(fishies);
                
            }
        }
    }
}

