using DXMauiApp1.Services;
using DXMauiApp1.Views;
using Application = Microsoft.Maui.Controls.Application;

namespace DXMauiApp1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<NavigationService>();
            Routing.RegisterRoute(typeof(ItemDetailPage).FullName, typeof(ItemDetailPage));
            Routing.RegisterRoute(typeof(NewItemPage).FullName, typeof(NewItemPage));
            Routing.RegisterRoute(nameof(DayViewPage), typeof(DayViewPage));
            Routing.RegisterRoute(nameof(AppointmentPage), typeof(AppointmentPage));
            MainPage = new MainPage();
        }
    }
}