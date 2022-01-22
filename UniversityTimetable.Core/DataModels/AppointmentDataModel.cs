using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityTimetable.Core {
    public class AppointmentDataModel {

        #region Public Properties

        public double AppointmentMargin { get; set; }
        public double AppointmentHeight { get; set; }

        public string AppointmentTitle { get; set; }

        #endregion

        #region Constructor

        public AppointmentDataModel() {

        }

        #endregion
    }
}
