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
                Console.Write("\n$ ");
                string input = Console.ReadLine();
                ProcessInput(input);
            }
        }

        public static void ProcessInput(string input) {
            string[] inputTokenized = input.Split(" ");
            if (inputTokenized.Length == 0) {
                Console.WriteLine("Invalid Input!");
                return;
            }
            switch(inputTokenized[0].ToLower()) {
                case "getweek":
                    ManageGetWeek(inputTokenized);
                    break;
                default:
                    Console.WriteLine("Invalid Input!");
                    return;
            }
        }


        public static void ManageGetWeek(string[] input) {
            if(input.Length != 3) {
                Console.WriteLine("Invalid number of Arguments! Usage: getweek <date> <timetableUrl>");
                return;
            } 
            DateTime date;
            try {
                date = DateTime.Parse(input[1]);
            } catch(FormatException ex) {
                Console.WriteLine(ex.Message + "\nError when parsing Date!");
                return;
            }

            string url = input[2];
            string pattern = @"(?:http[s]?://)?(?:[a-zA-Z]|[0-9]|[$-_@.&+]|[!*\(\),]|(?:%[0-9a-fA-F][0-9a-fA-F]))+";
            if(!Regex.IsMatch(url, pattern)) {
                Console.WriteLine("Invalid Url!");
                return;
            }
            List<AppointmentDataModel>[] weekList = Scraper.GetWeek(date, url);
            for(int day = 0; day < 5; day++) {
                Console.WriteLine("\n-------------------------------------------\n");
                Console.WriteLine(IndexToDay(day) + "\n");
                for(int i = 0; i < weekList[day].Count; ++i) {
                    Console.WriteLine($"[{i}] {weekList[day][i]}\n");

                }
            }
        }



        #region Helper Methods

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
