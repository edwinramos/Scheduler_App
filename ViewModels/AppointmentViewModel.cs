using CommunityToolkit.Mvvm.ComponentModel;
using DXMauiApp1.Models;
using DXMauiApp1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXMauiApp1.ViewModels
{
    [QueryProperty("Appointment", "Appointment")]
    public partial class AppointmentViewModel : BaseViewModel
    {
        EventService eventService;
        [ObservableProperty]
        Event appointment;
        public AppointmentViewModel(EventService eventService)
        {
            Title = "Appointment View";
            this.eventService = eventService;
        }

        public async Task SelectEventAsync(int id)
        {
            var obj = await eventService.GetEventById(id);
            await Shell.Current.DisplayAlert("Selected!", $"Selected {obj.Title}", "Ok");
        }
    }
}
