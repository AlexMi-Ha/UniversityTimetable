using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UniversityTimetable.Core.Data {
    public static class FileReader {

        public static Dictionary<string, string> Read(string filename) {
            if(String.IsNullOrWhiteSpace(filename)) {
                return null;
            }
            if (!File.Exists(filename)) {
                return null;
            }
            if (!".csuts".Equals(Path.GetExtension(filename))) {
                return null;
            }

            Dictionary<string, string> dict = new Dictionary<string, string>();

            var data = File.ReadAllLines(filename);
            foreach (var setting in data) {
                int index = setting.IndexOf("=");
                if (index >= 0) {
                    string key = setting.Substring(0, index);
                    string value = setting.Substring(index + 1);
                    if (!dict.ContainsKey(key)) {
                        dict.Add(key, value);
                    }
                }
            }

            if (dict.Count < 1) {
                return null;
            }

            return dict;
        }
    }
}
