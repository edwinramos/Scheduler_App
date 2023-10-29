using DXMauiApp1.Services;

namespace DXMauiApp1.ViewModels
{
    public class PopupViewModel : BaseViewModel
    {
        public PopupViewModel(EventTypeService eventTypeService) : base(eventTypeService)
        {
            Title = "Popup";
        }
    }
}