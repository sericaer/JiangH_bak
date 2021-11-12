using JiangH.Kernels;
using JiangH.Kernels.Mods;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace mods.native
{
    public class RevokeBussiness : IPersonInterActive
    {
        public ReadOnlyObservableCollection<IBusiness> businesses => person2.businesses;

        public override string detailUI => "mods.native.SelectBusinessItems";

        public CommandOnRevoke cmdOnSelected
        {
            get
            {
                return _MyCommand ?? (_MyCommand = new CommandOnRevoke(this));
            }
        }

        private CommandOnRevoke _MyCommand;

        public class CommandOnRevoke : ICommand
        {
            private RevokeBussiness interactive;

            public event EventHandler CanExecuteChanged;

            public CommandOnRevoke(RevokeBussiness interactive)
            {
                this.interactive = interactive;
            }

            public bool CanExecute(object parameter)
            {
                //var business = parameter as IBusiness;
                //return business.name == "B1";
                return true;
            }

            public void Execute(object parameter)
            {
                Log.Info($"Revoke business {parameter}");

                Facade.runData.person2Business.Remove(interactive.person2, parameter as IBusiness);
            }
        }
    }

    public class RevokeBussiness2 : IPersonInterActive
    {

    }
}
