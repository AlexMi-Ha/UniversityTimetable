using System;
using System.Collections.Generic;
using System.IO;

namespace UniversityTimetable.Core.Data {
    public static class FileWriter {


        public static bool Write(Dictionary<string,string> dict, string filename) {
            if (String.IsNullOrWhiteSpace(filename)) {
                return false;
            }
            if (!".csuts".Equals(Path.GetExtension(filename))) {
                return false;
            }
            if (!File.Exists(filename)) {
                File.Create(filename).Close();
            }

            using (var file = new StreamWriter(filename)) {
                foreach (var entry in dict) {
                    file.WriteLine(entry.Key + "=" + entry.Value);
                }
                file.Close();
            }

            return true;
        }

    }
}
