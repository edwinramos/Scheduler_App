using DXMauiApp1.Services;
using DXMauiApp1.ViewModels;

namespace DXMauiApp1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {

        public LoginPage(EventTypeService eventTypeService)
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(eventTypeService);
        }
    }
}