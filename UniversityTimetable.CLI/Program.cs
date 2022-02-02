using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UniversityTimetable.Core;

namespace UniversityTimetable.CLI {

    /// <summary>
    /// Console front end for testing
    /// </summary>
    public class Program {
        public static void Main(string[] args) {
            while(true) {
                // Listen to input
                Console.Write("\n$ ");
                string input = Console.ReadLine();
                ProcessInput(input);
            }
        }

        /// <summary>
        /// Processes the text input and extracts commands + calls the necessary methods for the command
        /// </summary>
        /// <param name="input"></param>
        public static void ProcessInput(string input) {
            string[] inputTokenized = input.Split(" ");
            if (inputTokenized.Length == 0) {
                Console.WriteLine("Invalid Input!");
                return;
            }
            // Read commands
            switch(inputTokenized[0].ToLower()) {
                case "getweek":
                    ManageGetWeek(inputTokenized);
                    break;
                default:
                    Console.WriteLine("Invalid Input!");
                    return;
            }
        }

        /// <summary>
        /// Manage the GetWeek command
        /// Usage: getweek date timetableUrl
        /// </summary>
        /// <param name="input"></param>
        public static void ManageGetWeek(string[] input) {
            if(input.Length != 3) {
                Console.WriteLine("Invalid number of Arguments! Usage: getweek <date> <timetableUrl>");
                return;
            } 

            // Verify date parameter
            DateTime date;
            try {
                date = DateTime.Parse(input[1]);
            } catch(FormatException ex) {
                Console.WriteLine(ex.Message + "\nError when parsing Date!");
                return;
            }

            // Verify url parameter
            string url = input[2];
            string pattern = @"(?:http[s]?://)?(?:[a-zA-Z]|[0-9]|[$-_@.&+]|[!*\(\),]|(?:%[0-9a-fA-F][0-9a-fA-F]))+";
            if(!Regex.IsMatch(url, pattern)) {
                Console.WriteLine("Invalid Url!");
                return;
            }
            // retrieve week list
            List<AppointmentDataModel>[] weekList = Scraper.GetWeek(date, url);

            // Display it
            for(int day = 0; day < 5; day++) {
                Console.WriteLine("\n-------------------------------------------\n");
                Console.WriteLine(IndexToDay(day) + "\n");
                for(int i = 0; i < weekList[day].Count; ++i) {
                    Console.WriteLine($"[{i}] {weekList[day][i]}\n");

                }
            }
        }



        #region Helper Methods

        /// <summary>
        /// Helper to convert an index to its corresponding day
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string IndexToDay(int i) {
            return i switch {
                0 => "Monday",
                1 => "Tuesday",
                2 => "Wednesday",
                3 => "Thursday",
                4 => "Friday",
                5 => "Saturday",
                6 => "Sunday",
                _ => "",
            };
        } 

        #endregion
    }
}
