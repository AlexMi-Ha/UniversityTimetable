using PropertyChanged;
using System.ComponentModel;

namespace UniversityTimetable.Core { 
    public class BaseViewModel : INotifyPropertyChanged {
        
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        /// <summary>
        /// Call to fire a property change event
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name) {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
