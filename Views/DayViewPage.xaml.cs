using DXMauiApp1.ViewModels;

namespace DXMauiApp1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DayViewPage : ContentPage
    {
        public DayViewPage(DayViewViewModel vm)
        {
            InitializeComponent();
            BindingContext = ViewModel = vm;
        }

        DayViewViewModel ViewModel { get; }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.OnAppearing();
        }

        private void DayView_Tap(object sender, DevExpress.Maui.Scheduler.SchedulerGestureEventArgs e)
        {
            if (e.AppointmentInfo != null) 
            {
                ViewModel.SelectEventAsync((int)e.AppointmentInfo.Appointment.Id);
            }
        }
    }
}