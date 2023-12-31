using DXMauiApp1.ViewModels;

namespace DXMauiApp1.Views;

public partial class AppointmentPage : ContentPage
{
    AppointmentViewModel ViewModel { get; }
    public AppointmentPage(AppointmentViewModel vm)
    {
        InitializeComponent();
        BindingContext = ViewModel = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await ViewModel.OnAppearing();
    }
}