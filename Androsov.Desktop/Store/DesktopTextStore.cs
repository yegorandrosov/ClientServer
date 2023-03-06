using System;

namespace Androsov.Desktop.Store
{
    public class DesktopTextStore
    {
        private string? _text;
        public string? Text
        {
            get { return _text; }
            set
            {
                _text = value;
                TextChanged?.Invoke();
            }
        }

        public event Action? TextChanged;
    }
}
