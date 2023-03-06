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
            }
        }

        public ICommand SubmitDesktopText { get; }

        public DesktopTextViewModel()
        {
            DesktopTextStore = new DesktopTextStore();
            SubmitDesktopText = new SetDesktopTextCommand(DesktopTextStore);

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
