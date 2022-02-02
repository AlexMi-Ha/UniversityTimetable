using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityTimetable.Core {
    public class AppointmentDataModel {

        #region Public Properties

        public double AppointmentMargin { get; set; }
        public double AppointmentHeight { get; set; }

        public string AppointmentTitle { get; set; }


        private double _heightPerHour;


        private DateTime _startTime;
        /// <summary>
        /// Always set StartTime before EndTime!!!
        /// </summary>
        public DateTime StartTime { 
            get {
                return _startTime;
            } 
            set {
                if(_startTime != null && _startTime.Equals(value)) {
                    return;
                }
                _startTime = value;
            }
        }

        private TimeSpan _duration;
        /// <summary>
        /// Always set StartTime before EndTime!!!
        /// </summary>
        public DateTime EndTime {
            get {
                return StartTime.Add(_duration);
            }
            set {
                if(StartTime == null) {
                    return;
                }
                _duration = value.Subtract(StartTime);
            }    
        }

        #endregion

        #region Constructor

        public AppointmentDataModel(double _heightPerHour) {
            this._heightPerHour = _heightPerHour;
        }

        public AppointmentDataModel(double heightPerHour, DateTime start, DateTime end) {
            this._heightPerHour = heightPerHour;
            StartTime = start;
            EndTime = end;
        }

        public AppointmentDataModel(DateTime start, DateTime end) {
            StartTime = start;
            EndTime = end;
        }

        #endregion


        #region Methods 

        public void UpdateView() {
            AppointmentHeight = _duration.TotalHours * (_heightPerHour + .9);
        }


        public override string ToString() {
            return $"({StartTime.ToString("hh:mm")} - {EndTime.ToString("hh:mm")}): {AppointmentTitle}";
        }
        #endregion
    }
}
