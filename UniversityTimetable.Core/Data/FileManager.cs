using System;
using System.Collections.Generic;
using System.Text;
using UniversityTimetable.Core.Data;

namespace UniversityTimetable.Core {
    public class FileManager {

        private readonly static string SettingsPath = "settings.csuts";

        private Dictionary<string, string> _settingsDict;

        public Dictionary<string,string> Settings {
            get {
                if(_settingsDict == null || _settingsDict.Count == 0) {
                    _settingsDict = FileReader.Read(SettingsPath);
                }
                return _settingsDict;
            }
        }

        public void SaveChanges() {
            if(_settingsDict == null || _settingsDict.Count == 0) {
                return;
            }
            FileWriter.Write(_settingsDict, SettingsPath);
        }

    }
}
