
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace UniversityTimetable.Core {
    public static class Scraper {

        private static string timetableUrl;

        public static List<AppointmentDataModel>[] GetWeek(DateTime date, string _timetableUrl) {
            timetableUrl = _timetableUrl;
            return GetWeek(date);
        }

        public static List<AppointmentDataModel>[] GetWeek(DateTime date) {
            // if no timetable url is saved, get it from the FileManager
            if(String.IsNullOrWhiteSpace(timetableUrl)) {
                FileManager man = new FileManager();
                try {
                    timetableUrl = man.Settings["timetableUrl"];
                }catch(KeyNotFoundException ex) {
                    Console.WriteLine("No TimeTable URL found!");
                }
            }

            // assemble the full url
            string url = $"{timetableUrl}&day={date.Day}&month={date.Month}&year={date.Year}";
            
            // Scrape the timetable
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            
            var weekRows = doc.DocumentNode.SelectNodes("//table[@class='week_table']/tbody/tr");

            List<AppointmentDataModel>[] appointments = new List<AppointmentDataModel>[5];
            for(int i = 0; i < 5; ++i) {
                appointments[i] = new List<AppointmentDataModel>();
            }


            for(int i = 2; i < weekRows.Count; ++i) { // skip fist two header rows
                var row = weekRows[i].SelectNodes("./td");
                int day = 0;
                for (int col = 1; col < row.Count; ++col) {
                    // Loop until we find a back seperator element of a cell
                    if(!(row[col].GetClasses().Contains("week_separatorcell_black") || row[col].GetClasses().Contains("week_separatorcell"))) {
                        continue;
                    }
                    // Check if the element infront of the back seperator is a week block (appointment)
                    if(row[col - 1].GetClasses().Contains("week_block")) {

                        // Extract information from text using regex
                        string text = row[col - 1].SelectNodes("./a")[0].InnerText.Replace("&nbsp;", " ");

                        // TODO maybe rework regex pattern to not cut of at 'erstellt'. ... Find a smarter way
                        string pattern = @"^(\d{2}:\d{2}).{6}-(\d{2}:\d{2})(.+)erstellt.+";
                        var matches = Regex.Matches(text, pattern);

                        if (matches.Count > 0 && matches[0].Groups.Count > 1) {
                            DateTime start = DateTime.Parse(matches[0].Groups[1].Value);
                            if (start.Hour < 8) continue; // Skip if it starts before 8;
                            // TODO some appointments before 8 are information about the day -> maybe display it somehow?

                            DateTime end = DateTime.Parse(matches[0].Groups[2].Value);


                            appointments[day].Add(new AppointmentDataModel(start, end) {
                                AppointmentTitle = matches[0].Groups[3].Value
                            });
                        }
                    }
                    // After finding a back seperator element of a cell, skip to the next day
                    ++day;
                }
            }

            return appointments;
        }


    }
}
