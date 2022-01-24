
using UniversityTimetable.Core;
using Xamarin.Forms;

namespace UniversityTimetable {
    public class BasePage<VM> : ContentPage where VM : BaseViewModel, new() {

        #region Private Attributes
        private VM _viewModel;
        #endregion

        #region Public Properties

        /// <summary>
        /// View Model to bind to
        /// </summary>
        public VM ViewModel {
            get { return _viewModel; }
            set {
                if (_viewModel == value)
                    return;

                _viewModel = value;
                this.BindingContext = _viewModel;
            }
        }

        #endregion

        #region Constructor

        public BasePage() {
            // Add a new ViewModel
            this.ViewModel = new VM();
        }
        #endregion
    }
}
