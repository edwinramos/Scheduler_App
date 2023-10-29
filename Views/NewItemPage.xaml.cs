using DXMauiApp1.Services;
using DXMauiApp1.ViewModels;

namespace DXMauiApp1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public NewItemPage(EventTypeService eventTypeService)
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel(eventTypeService);
        }
    }
}