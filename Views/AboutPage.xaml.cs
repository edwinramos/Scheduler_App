using DXMauiApp1.Services;
using DXMauiApp1.ViewModels;

namespace DXMauiApp1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage(EventTypeService eventTypeService)
        {
            InitializeComponent();
            BindingContext = new AboutViewModel(eventTypeService);
        }
    }
}