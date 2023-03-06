namespace Androsov.Desktop.ViewModels
{
    public class ApiViewViewModel : ViewModelBase
    {
        public DesktopTextViewModel DesktopTextViewModel { get; }
        public WebTextViewModel WebTextViewModel { get; }

        public ApiViewViewModel()
        {
            DesktopTextViewModel = new DesktopTextViewModel();
            WebTextViewModel = new WebTextViewModel();
        }
    }
}
