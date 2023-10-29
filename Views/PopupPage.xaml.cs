using DXMauiApp1.Services;
using DXMauiApp1.ViewModels;

namespace DXMauiApp1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupPage : ContentPage
    {
        public PopupPage(EventTypeService eventTypeService)
        {
            InitializeComponent();
            BindingContext = new PopupViewModel(eventTypeService);
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            Popup.IsOpen = true;
        }
    }
}