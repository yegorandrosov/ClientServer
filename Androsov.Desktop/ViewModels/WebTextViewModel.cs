using Androsov.Services.API.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Androsov.Desktop.ViewModels
{
    public class WebTextViewModel : ViewModelBase
    {
        private string? _text;
        private readonly IApiClient apiClient;

        public string? Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        public WebTextViewModel(IApiClient apiClient)
        {
            DispatcherTimerSetup();
            this.apiClient = apiClient;
        }

        private void DispatcherTimerSetup()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(5);
            dispatcherTimer.Tick += new EventHandler(CheckForText);
            dispatcherTimer.Start();
        }

        private async void CheckForText(object? sender, EventArgs e)
        {
            var response = await apiClient.Users["Web"].Messages.Get();
            Text = response.Text;
        }
    }
}
