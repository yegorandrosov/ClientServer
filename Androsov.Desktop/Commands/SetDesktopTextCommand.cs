using Androsov.Desktop.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Androsov.Desktop.Commands
{
    public class SetDesktopTextCommand : CommandBase
    {
        public SetDesktopTextCommand(DesktopTextStore desktopTextStore)
        {
            DesktopTextStore = desktopTextStore;
        }

        public DesktopTextStore DesktopTextStore { get; }

        public override void Execute(object? parameter)
        {
            DesktopTextStore.Text = "Clicked";
        }
    }
}
