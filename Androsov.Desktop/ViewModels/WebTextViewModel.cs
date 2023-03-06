using System;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Androsov.Desktop.ViewModels
{
    public class WebTextViewModel : ViewModelBase
    {
        private string? _text;
        public string? Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        public WebTextViewModel()
        {
            DispatcherTimerSetup();
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
            Text = Text + "1";
        }
    }
}
