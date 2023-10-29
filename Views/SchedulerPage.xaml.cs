using DXMauiApp1.Services;
using DXMauiApp1.ViewModels;

namespace DXMauiApp1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SchedulerPage : ContentPage
    {
        SchedulerViewModel ViewModel { get; }
        public SchedulerPage(SchedulerViewModel vm)
        {
            InitializeComponent();
            BindingContext = ViewModel = vm;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.OnAppearing();
        }

        private async void MonthView_Tap(object sender, DevExpress.Maui.Scheduler.SchedulerGestureEventArgs e)
        {
            await ViewModel.SelectDayAsync(e.IntervalInfo.Start);
        }
    }
}