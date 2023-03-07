using Androsov.Desktop.Store;
using Androsov.Services.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Androsov.Desktop.Commands
{
    public class SetDesktopTextCommand : AsyncCommandBase
    {
        private readonly IApiClient apiClient;

        public SetDesktopTextCommand(DesktopTextStore desktopTextStore, IApiClient apiClient)
        {
            DesktopTextStore = desktopTextStore;
            this.apiClient = apiClient;
        }

        public DesktopTextStore DesktopTextStore { get; }

        public override async Task ExecuteAsync(object? parameter)
        {
            await apiClient.Me.Messages.Set(DesktopTextStore.Text!);

            DesktopTextStore.Text = "";
        }
    }
}
