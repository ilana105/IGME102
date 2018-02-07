using System;

namespace LevaP1
{
    //Ilana Leva
    //This program will simulate an ascii replacer
    //The user will be able to pick one out of the three ascii art
    //Then they will be able to pick which character to be replaced
    //The user can either choose the replacement character or  go with random
    //It will continue to to ask until it gets a valid response
    //At the end it will tell you what character you replaced with
    //And then the changed art
    class Program
    {
        //Purpose: Will call other methods to run the program
        static void Main(string[] args)
        {
            //Declaring variables that are needed
            Random rnd = new Random();
            string[] textArt = new string[3];
            char pickTextArt;
            char searchChar;
            char replacementChar;

            //the art initialized
            textArt[0] = 
                "       _________ \r\n" +
                "    .-'   ``-_  `-. \r\n" +
                "  .'    ___   `-.  `. \r\n" +
                " /    /'  / \\     \\  \\ \r\n" +
                "|   ,'   /  `\\    |   | \r\n" +
                "|   |   |     |   |   | \r\n" +
                "|   |   |     |   |   | \r\n" +
                "|   |   |     |   |   | \r\n" +
                "|   |   |     |   |   | \r\n" +
                "|   |    \\   /   ,'   | \r\n" +
                " \\   \\    `\\/  _/    / \r\n" +
                "  `.  `-_   ```    .' \r\n" +
                "    `-_  `-,_   ,-'";

            textArt[1] =
                "               _____ \r\n" +
                "              /     \\ \r\n" +
                "              vvvvvvv  /|__/| \r\n" +
                "                 I   /O,O   | \r\n" +
                "                 I /_____   |      /|/| \r\n" +
                "                J|/^ ^ ^ \\  |    /00  |    _//| \r\n" +
                "                 |^ ^ ^ ^ |W|   |/^^\\ |   /oo | \r\n" +
                "                  \\m___m__|_|    \\m_m_|   \\mm_|";

            textArt[2] =
                "      %%% %%%%%%%            |#| \r\n" +
                "    %%%% %%%%%%%%%%%        |#|#### \r\n" +
                "  %%%%% %         %%%       |#|=##### \r\n" +
                " %%%%% %   @    @   %%      | | ==#### \r\n" +
                "%%%%%% % (_  ()  )  %%     | |    ===## \r\n" +
                "%%  %%% %  \\_    | %%      | |       =## \r\n" +
                "%    %%%% %  u^uuu %%     | |         ==# \r\n" +
                "      %%%% %%%%%%%%%      | |           V";


            //layout of the choices of ascii art
            Console.WriteLine(
                "  .--.      .-'.      .--.      .--.      .--.      .--.      .`-.      .--. \r\n" +
                " :::::.\\::::::::.\\::::::::.\\::::::::.\\::::::::.\\::::::::.\\::::::::.\\::::::::.\\ \r\n" +
                "'      `--'      `.-'      `--'      `--'      `--'      `-.'      `--'      ");
            Console.WriteLine("Welcome to the ASCII Replacer!");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Please choose one: ");
            Console.WriteLine("");

            Console.WriteLine("a.");
            Console.WriteLine(textArt[0]);
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("b.");
            Console.WriteLine(textArt[1]);
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("b.");
            Console.WriteLine(textArt[2]);
            Console.WriteLine("");
            Console.WriteLine("");

            //Asks the user to choose one of the options
            Console.Write("Please type in your choice ('a', 'b', or 'c'): ");
            pickTextArt = GetUserChar('a', 'c');
            //This will trigger if the input is ' ' so it will go into a loop until there is a valid input
            if (pickTextArt == ' ')
            {
                while (pickTextArt != ' ')
                {
                    Console.Write("\t Please type a valid character: ");
                     char c = char.Parse(Console.ReadLine());

                    if (IsValid('a', 'c', c))
                        break;
                }
            }
            Console.WriteLine("");

            //Asks the user to choose which character they want to replace
            Console.Write("Which character would you like to replace? ");
            searchChar = GetUserChar(' ', '~');
            Console.WriteLine("");

            //Asks the user what character they would like to be the replacement or a random one
            Console.Write("Which character would you like to replace it with? (type ' ' -SPACE- if you'd like a random one)? ");
            replacementChar = GetUserChar(' ', '~');
            if (replacementChar == ' ')
                replacementChar = (char)(rnd.Next(' ', 1 + '~'));

            Console.WriteLine("");

            Console.WriteLine("Original character: {0} replaced with: {1}.", searchChar, replacementChar);
            Console.WriteLine("");

            //displays the ascii art with the replaced character
            if (pickTextArt == 'a')
                Console.WriteLine(ReplaceChar(textArt[0], searchChar, replacementChar));

            else if (pickTextArt == 'b')
                Console.WriteLine(ReplaceChar(textArt[1], searchChar, replacementChar));

            else
                Console.WriteLine(ReplaceChar(textArt[2], searchChar, replacementChar));

            Console.WriteLine("");

            //End text with links to the ASCII art 
            Console.WriteLine("Thanks for playing!! \\m/(>.<)\\m/");
            Console.WriteLine("");
            Console.WriteLine("ASCII art from: ");
            Console.WriteLine("\t a Optical Illusion- asciiworld.com (http://www.asciiworld.com/-Geometry-.html)");
            Console.WriteLine("\t b Totoro - asciiworld.com (http://www.asciiworld.com/-Mangas,48-.html)");
            Console.WriteLine("\t c Grim Reaper - chris.com (http://www.chris.com/ascii/index.php?art=creatures%2Fgrim%20reapers)");
            Console.WriteLine("");

            Console.WriteLine(
                "  .--.      .-'.      .--.      .--.      .--.      .--.      .`-.      .--. \r\n" +
                " :::::.\\::::::::.\\::::::::.\\::::::::.\\::::::::.\\::::::::.\\::::::::.\\::::::::.\\ \r\n" +
                "'      `--'      `.-'      `--'      `--'      `--'      `-.'      `--'      ");
        }

        //Purpose: Grab data from the user, verify it is valid
        //and within the given bounds
        //Return: the parsed information back to the Main method
        //Parameters: char c1 - lower-bound char
        //            char c2 - upper-bound char
        //Restrictions/errors: 
        static char GetUserChar(char c1, char c2)
        {
            string input = Console.ReadLine();

            //This will check to see if the input is more than one character
            //If it is then it will go into a loop until the length is 1
            if (input.Length > 1)
            {
                while (input.Length > 1)
                {
                    Console.Write("\t Please type a valid character: ");
                    input = Console.ReadLine();

                    if (input.Length == 1)
                        break;
                }
            }
            //Once it knows the length is one, then parses to a character
            char c = char.Parse(input);

                //checks to see if the character is valid
                //If it is then breaks out of the loop, if not then continues until a valid 
                while (!IsValid(c1, c2, c))
                {
                    Console.Write("\t Please type a valid character: ");
                    c = char.Parse(Console.ReadLine());

                    if (IsValid(c1, c2, c))
                        break;

                }
            
            //retuns the parsed char
            return c;

        }

        //Purpose: Take a given string, char, and replacement char and replace all instances of the 
        // first char with a replacement char
        //Return: the new string back to the main method
        //Parameters:
        //Restrictions/errors:
        static string ReplaceChar(string s, char searchChar, char replaceChar)
        {
            char[] localArray = new char[s.Length];
            string convertedString;

            //Goes through the string of array to check and replace the characters
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == searchChar)
                    localArray[i] = replaceChar;
                else
                    localArray[i] = s[i];
            }

            //converts the array to string and returns it
            convertedString = new string(localArray);

            return convertedString;

        }

        //Purpose: Will check to see if the given character is valid
        //Return: True if the character is within the bound, false otherwise
        //Parameters: char lower - the lower-bound char
        //            char upper - the upper-bound char
        //            char input - the input of the char
        //Restricitons/errors: None
        static Boolean IsValid(char lower, char upper, char input)
        {
            if ((input <= upper) && (input >= lower))
                return true;

            else
                return false;
        }
    }
}
