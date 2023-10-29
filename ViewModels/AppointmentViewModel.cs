using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DXMauiApp1.Models;
using DXMauiApp1.Services;
using DXMauiApp1.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DXMauiApp1.ViewModels
{
    [QueryProperty("EventId", "EventId")]
    public partial class AppointmentViewModel : BaseViewModel
    {
        EventService eventService;
        EventTypeService eventTypeService;
        [ObservableProperty]
        Event eventModel;

        [ObservableProperty]
        int eventId;

        [ObservableProperty]
        Color eventTypeColor;
        public AppointmentViewModel(EventService eventService, EventTypeService eventTypeService) : base(eventTypeService)
        {
            Title = "Appointment View";
            this.eventService = eventService;
            this.eventTypeService = eventTypeService;
        }

        [RelayCommand]
        public async Task EditAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(EditEventPage)}", true,
                new Dictionary<string, object>
                {
                { "EventId", EventId }
                });
        }

        [RelayCommand]
        public async Task DeleteAsync()
        {
            bool answer = await Shell.Current.DisplayAlert("Delete?", $"Delete '{EventModel.Title}'?", "Yes", "No");
            if (answer)
            {
                await eventService.RemoveEvent(EventModel.Id);
                await Shell.Current.DisplayAlert("Deleted!", "", "Ok");
            }
        }

        public async override Task OnAppearing()
        {
            await base.OnAppearing();
            EventModel = await eventService.GetEventById(EventId);
            EventTypeColor = Color.FromArgb((await eventTypeService.GetEventTypeById(EventModel.EventTypeId))?.ColorCode ?? "");
        }
    }
}
