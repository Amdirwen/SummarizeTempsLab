using System;
using System.IO;

namespace SummarizeTempsLab
{
    class Program
    {
        static void Main(string[] args)
        {
            // note: temperature data is in temps.txt for this lab.
            String fileName;

            Console.WriteLine("Summarizing Temperatures Lab");

            //prompt the user for file name
            Console.WriteLine("Enter the file name for temperature database.");
            //convert input into file name
            fileName = Console.ReadLine();

            //test whether file exists
            if (File.Exists(fileName))
            {

                //if file exists:
                //ask user for temp threshold
                //loop
                Console.WriteLine("Enter a temperature threshold or press Q to quit.");
                
                string input;
                input = Console.ReadLine();
                
                bool cont = true;
                while (cont)
                    if (input == "Q")
                    {
                        cont = false;
                    }
                    else
                    {
                        int threshold;

                        threshold = int.Parse(input);

                        int sumTemps = 0;
                        int numAbove = 0;
                        int numBelow = 0;
                        int tempCount = 0;
                        int average = 0;


                        //read a line into a string variable
                        using (StreamReader sr = File.OpenText(fileName))
                        {
                            string line = sr.ReadLine();
                            int temp;

                            //while the line is not null:

                            while ((line != null))
                            {
                                //convert (parse) temp from line into an integer variable
                                temp = int.Parse(line);

                                //add temperature to my summing variable

                                sumTemps += temp;

                                //increment temp count

                                tempCount += 1;

                                if (temp >= threshold)
                                {
                                    //if curTemp value is >= threshold increment 'above' counter by 1
                                    numAbove += 1;
                                }
                                else
                                {
                                    //else curTemp value < temp increment 'below' counter by 1
                                    numBelow += 1;
                                }
                                line = sr.ReadLine();

                                //sum below and above counters, divide by summing variable
                                average = sumTemps / (numAbove + numBelow);
                                //print to console temperatures above threshold
                                Console.WriteLine("Temperatures above =" + numAbove);
                                //print to console temperatures below threshold
                                Console.WriteLine("Temperatures below =" + numBelow);
                                //print to console average temperatures
                                Console.WriteLine("Temperature average = " + average);
                            }
                        }



                    }


                }
                else
                {
                //else file does not exist tell user it does not exist
                Console.WriteLine("File Does Not Exist");
                }
            }
            
        }








    }


