
using System.Threading.Tasks;

namespace UniversityTimetable.Core {
    public class WeekPageViewModel : BaseViewModel {

        #region Public Properties

        public WeekDayViewModel Monday { get; set; }
        public WeekDayViewModel Tuesday { get; set; }
        public WeekDayViewModel Wednesday { get; set; }
        public WeekDayViewModel Thursday { get; set; }
        public WeekDayViewModel Friday { get; set; }

        public int GridHeight { 
            get {
                return HasGridHeight.GetGridHeight();
            }
        }
        public IHasGridHeight HasGridHeight { get; set; }

        #endregion

        #region Constructor

        public WeekPageViewModel() {
            
        }

        #endregion

        #region Methods

        /// <summary>
        /// this method gets called by the view
        /// </summary>
        public async Task SetupWeekSchedule() {
            await Task.Delay(3000);
            var oneHourHeight = (float)GridHeight / 10.0;

            Monday = new WeekDayViewModel {
                Appointments = new System.Collections.ObjectModel.ObservableCollection<AppointmentDataModel> {
                    new AppointmentDataModel {
                        AppointmentTitle = "Bro",
                        AppointmentHeight = 4.25*(oneHourHeight+.9),
                        AppointmentMargin = 0.5*(oneHourHeight+.9)
                    },
                    new AppointmentDataModel {
                        AppointmentTitle = "Bro",
                        AppointmentHeight = 2.5*(oneHourHeight+.9),
                        AppointmentMargin = 0.75*(oneHourHeight+.9)
                    }

                }
            };
            Tuesday = new WeekDayViewModel {
                Appointments = new System.Collections.ObjectModel.ObservableCollection<AppointmentDataModel> {
                    new AppointmentDataModel {
                        AppointmentTitle = "Bro",
                        AppointmentHeight = 3.25*(oneHourHeight+.9),
                        AppointmentMargin = 0.5*(oneHourHeight+.9)
                    },
                    new AppointmentDataModel {
                        AppointmentTitle = "Bro",
                        AppointmentHeight = 1.5*(oneHourHeight+.9),
                        AppointmentMargin = 1.25*(oneHourHeight+.9)
                    }

                }
            };
            Wednesday = new WeekDayViewModel {
                Appointments = new System.Collections.ObjectModel.ObservableCollection<AppointmentDataModel> {
                    new AppointmentDataModel {
                        AppointmentTitle = "Bro",
                        AppointmentHeight = 3.25*(oneHourHeight+.9),
                        AppointmentMargin = 0.5*(oneHourHeight+.9)
                    },
                    new AppointmentDataModel {
                        AppointmentTitle = "Bro",
                        AppointmentHeight = 2.5*(oneHourHeight+.9),
                        AppointmentMargin = .75*(oneHourHeight+.9)
                    }

                }
            };
            Thursday = new WeekDayViewModel {
                Appointments = new System.Collections.ObjectModel.ObservableCollection<AppointmentDataModel> {
                    new AppointmentDataModel {
                        AppointmentTitle = "Bro",
                        AppointmentHeight = 4.25*(oneHourHeight+.9)
                    },
                    new AppointmentDataModel {
                        AppointmentTitle = "Bro",
                        AppointmentHeight = 1.5*(oneHourHeight+.9),
                        AppointmentMargin = .75*(oneHourHeight+.9)
                    }

                }
            };
            Friday = new WeekDayViewModel {
                Appointments = new System.Collections.ObjectModel.ObservableCollection<AppointmentDataModel> {
                    new AppointmentDataModel {
                        AppointmentTitle = "Bro",
                        AppointmentHeight = 3.25*(oneHourHeight+.9),
                        AppointmentMargin = 0.5*(oneHourHeight+.9)
                    },
                    new AppointmentDataModel {
                        AppointmentTitle = "Bro",
                        AppointmentHeight = 2.5*(oneHourHeight+.9),
                        AppointmentMargin = 1.25*(oneHourHeight+.9)
                    }

                }
            };

        }

        #endregion
    }
}
