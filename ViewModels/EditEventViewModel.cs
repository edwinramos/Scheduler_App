using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DXMauiApp1.Models;
using DXMauiApp1.Services;
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
    public partial class EditEventViewModel : BaseViewModel
    {
        EventService eventService;

        [ObservableProperty]
        bool notAllDay;

        [ObservableProperty]
        int eventId;

        [ObservableProperty]
        Event eventModel;
        public EditEventViewModel(EventService eventService, EventTypeService eventTypeService) : base(eventTypeService)
        {
            Title = "Manage Events";
            
            this.eventService = eventService;
        }

        [RelayCommand]
        public async Task SaveAsync()
        {
            await eventService.SaveEvent(EventModel);
            await Shell.Current.GoToAsync("..");
        }

        public void ToggleAllDayAsync()
        {
            if (EventModel != null)
                NotAllDay = !EventModel.AllDay;
        }
        public async override Task OnAppearing()
        {
            await base.OnAppearing();
            EventModel = await eventService.GetEventById(EventId);
            NotAllDay = !EventModel.AllDay;
        }
    }
}
