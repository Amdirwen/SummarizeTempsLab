using System;
using System.IO;

namespace SummarizeTempsLab
{
    class Program
    {
        static void Main(string[] args)
        {
            // note: temperature data is in temps.txt for this lab

            Console.WriteLine("Summarizing Temperatures Lab");
            String fileName;

            //prompt the user for file name
            Console.WriteLine("Enter the file name for temperature database.");
            fileName = Console.ReadLine();

            //test whether file exists

            if (File.Exists(fileName))
            {
                //enter threshold
                Console.WriteLine("Enter temperature threshold");
                string input;
                int threshold;
                input = Console.ReadLine();
                threshold = int.Parse(input);

                int sumTemps = 0;
                int numAbove = 0;
                int numBelow = 0;
                int tempCount = 0;

                using (StreamReader sr = File.OpenText(fileName))
                {
                    //reads lines of text file
                    string line = sr.ReadLine();
                    int temp;

                    //while line that is not null
                    while (line != null)
                    {
                        temp = int.Parse(line);
                        sumTemps += temp;
                        tempCount += 1;

                        //threshold calculations
                        if (temp >= threshold)
                        {
                            numAbove += 1;
                        }
                        else
                        {
                            numBelow += 1;
                        }
                        line = sr.ReadLine();
                    }
                }
                //calculate and print values
                int average = sumTemps / tempCount;
                Console.WriteLine("Temperatures above = " + numAbove);
                Console.WriteLine("Temperatures below = " + numBelow);
                Console.WriteLine("Average temperature = " + average);
            }
            else
            {
                //else file does not exist tell user it does not exist
                Console.WriteLine("File does not exist.");
            }


        } 
    } 
}

