using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTimetable.Core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniversityTimetable {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeekPage : BasePage<WeekPageViewModel>, IHasGridHeight {
        public WeekPage() {
            InitializeComponent();
            this.ViewModel.HasGridHeight = this;
            ViewModel.SetupWeekSchedule();
        }

        public int GetGridHeight() {
            return (int)_calendarGrid.Height;
        }
    }
}