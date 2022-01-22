using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace UniversityTimetable.Core {
    public class WeekDayViewModel : BaseViewModel{

        #region Public Properties

        public ObservableCollection<AppointmentDataModel> Appointments { get; set; }

        #endregion

        #region Constructor

        public WeekDayViewModel() {
            Appointments = new ObservableCollection<AppointmentDataModel>();
        }
        #endregion
    }
}
