using Androsov.Desktop.Commands;
using Androsov.Desktop.Store;
using System.Windows.Input;

namespace Androsov.Desktop.ViewModels
{
    public class DesktopTextViewModel : ViewModelBase
    {
        public DesktopTextStore DesktopTextStore { get; set; }

        public string? Text
        {
            get
            {
                return DesktopTextStore.Text;
            }
            set
            {
                DesktopTextStore.Text = value;
                OnPropertyChanged(nameof(Text));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        public ICommand SubmitDesktopText { get; }
        public bool CanSubmit => !string.IsNullOrEmpty(Text);

        public DesktopTextViewModel(DesktopTextStore desktopTextStore, SetDesktopTextCommand setDesktopTextCommand)
        {
            DesktopTextStore = desktopTextStore;
            SubmitDesktopText = setDesktopTextCommand;

            DesktopTextStore.TextChanged += DesktopTextStore_TextChanged;
        }

        private void DesktopTextStore_TextChanged()
        {
            OnPropertyChanged(nameof(Text));
        }

        protected override void Dispose()
        {
            DesktopTextStore.TextChanged -= DesktopTextStore_TextChanged;

            base.Dispose();
        }
    }
}
