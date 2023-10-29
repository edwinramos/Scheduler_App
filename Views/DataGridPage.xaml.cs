using DXMauiApp1.Services;
using DXMauiApp1.ViewModels;

namespace DXMauiApp1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataGridPage : ContentPage
    {
        public DataGridPage(EventTypeService eventTypeService)
        {
            InitializeComponent();
            BindingContext = ViewModel = new DataGridViewModel(eventTypeService);
        }

        DataGridViewModel ViewModel { get; }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.OnAppearing();
        }
    }
}