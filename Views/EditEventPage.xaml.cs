using DXMauiApp1.ViewModels;

namespace DXMauiApp1.Views;

public partial class EditEventPage : ContentPage
{
    EditEventViewModel ViewModel { get; }
    public EditEventPage(EditEventViewModel vm)
	{
		InitializeComponent();
        BindingContext = ViewModel = vm;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await ViewModel.OnAppearing();
    }

    private void Switch_HandlerChanged(object sender, EventArgs e)
    {
        ViewModel.ToggleAllDayAsync();
    }
}