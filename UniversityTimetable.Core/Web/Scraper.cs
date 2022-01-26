
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace UniversityTimetable.Core {
    public static class Scraper {

        private static string timetableUrl;

        public static List<AppointmentDataModel>[] GetWeek(DateTime date) {
            if(String.IsNullOrWhiteSpace(timetableUrl)) {
                FileManager man = new FileManager();
                try {
                    timetableUrl = man.Settings["timetableUrl"];
                }catch(KeyNotFoundException ex) {
                    Console.WriteLine("No TimeTable URL found!");
                }
            }

            string url = $"{timetableUrl}&day={date.Day}&month={date.Month}&year={date.Year}";
            
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            
            var weekRows = doc.DocumentNode.SelectNodes("//table[@class='week_table']/tbody/tr");

            List<AppointmentDataModel>[] appointments = new List<AppointmentDataModel>[5];


            for(int i = 2; i < weekRows.Count; ++i) {
                var row = weekRows[i].SelectNodes("/td");
                for (int day = 0; day < 5; ++day) {
                    var block = row[day * 3 + 1];
                    if (block.GetClasses().Contains("week_block")) {

                        string text = block.SelectNodes("/a")[0].InnerText.Replace("&nbsp;", " ");
                        string pattern = @"^(\d{2}:\d{2}).-(\d{2}:\d{2})(.+)";
                        var matches = Regex.Matches(text, pattern);

                        if (matches.Count > 0 && matches[0].Groups.Count > 1) {
                            DateTime start = DateTime.Parse(matches[0].Groups[1].Value);
                            if (start.Hour < 8) continue;

                            DateTime end = DateTime.Parse(matches[0].Groups[2].Value);

                            appointments[day].Add(new AppointmentDataModel(start, end) {
                                AppointmentTitle = matches[0].Groups[3].Value
                            });
                        }
                    }
                }
            }

            return appointments;
        }


    }
}
