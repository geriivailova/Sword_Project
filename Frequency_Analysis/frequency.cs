using System.Text.RegularExpressions;


namespace Project
{
    class Program
    {

        static void Main(string[] args)
        {
            //A path to the Sample.txt file
            string fileName = @"C:\Test\Sample.txt";

            try
            {
                // Open the file using a StreamReader
                using (StreamReader sr = new StreamReader(fileName))
                {
                    // Read the contents of the file into a string
                    string contents = sr.ReadToEnd();

                    //Replacing the white spaces including (tab, newline, or carriage return) from the contents of the text file.
                    string pattern = @"\s+";
                    string input = Regex.Replace(contents, pattern, "");


                    int total_character = input.Length;

                    //Arrays for lower case and upper case to keep track of their frequency
                    int[] lowerCharArray = new int[26];
                    int[] upperCharArray = new int[26];

                    //2D array to keep the int(number of frequence) and char(the character itself)
                    Tuple<int, char>[] myArray = new Tuple<int, char>[1000];

                    //Creating a switch function as a menu with two options for the user
                    Console.WriteLine("Do you want this analysis is to be case sensitive?");
                    Console.WriteLine("If yes type yes and press 'Enter', if not then press 'Enter'");
                    string menuChoice = Console.ReadLine();

                    switch (menuChoice)
                    {
                        //A case for Case Insensitive 
                        case "yes":
                            //Going through all of the characters in the input string converting them into lower case; Adding the chars to the array
                            foreach (char c in input)
                            {
                                if (char.IsLetter(c))
                                {
                                    lowerCharArray[char.ToLower(c) - 'a']++;
                                }
                            }

                            //Adding all the characters of the alphabet to the main array with the char itself and its frequency
                            for (int i = 0; i < 26; i++)
                            {
                                myArray[i] = Tuple.Create(lowerCharArray[i], (char)('a' + i));
                            }


                            Console.WriteLine("Total characters: " + total_character);

                            //Sorting the list in ascending order
                            Array.Sort(myArray);
                            Array.Reverse(myArray);

                            //keep count of most frequent occuring characters
                            int count = 0;

                            //Printing the 2D array to the stdout
                            foreach (Tuple<int, char> tuple in myArray)
                            {

                                Console.WriteLine(tuple.Item2 + " (" + tuple.Item1 + ")");
                                count++;
                                if (count == 10)
                                {
                                    break;
                                }

                            }
                            break;

                        //A default case for Case Sensitive
                        //Following the same logic as above with indifference to the upper case letters
                        default:
                            foreach (char c in input)
                            {
                                if (char.IsLetter(c))
                                {
                                    if (char.IsLower(c))
                                    {
                                        lowerCharArray[c - 'a']++;
                                    }
                                    else if (char.IsUpper(c))
                                    {
                                        upperCharArray[c - 'A']++;
                                    }
                                }
                            }

                            //Adding chars and their frequency to the lowerCaseCount array
                            for (int i = 0; i < 26; i++)
                            {
                                myArray[i] = Tuple.Create(lowerCharArray[i], (char)('a' + i));
                            }

                            //Adding chars and their frequency to the upperCaseCount array
                            for (int i = 0; i < 26; i++)
                            {
                                myArray[i + 26] = Tuple.Create(upperCharArray[i], (char)('A' + i));
                            }


                            Console.WriteLine("Total characters: " + total_character);
                            Array.Sort(myArray);
                            Array.Reverse(myArray);

                            //keep count of most frequent occuring characters
                            int count1 = 0;

                            foreach (Tuple<int, char> tuple in myArray)
                            {

                                Console.WriteLine(tuple.Item2 + " (" + tuple.Item1 + ")");
                                count1++;
                                if (count1 == 10)
                                {
                                    break;
                                }
                            }
                            break;
                    }
                }

            }

            //An exception if the Sample.txt can't be read
            catch (Exception e)
            {
                Console.WriteLine("Error reading file: " + e.Message);
            }

            //Resume the application
            Main(null);


        }
    }
}