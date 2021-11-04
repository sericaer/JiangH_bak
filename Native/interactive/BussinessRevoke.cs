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
        public ReadOnlyObservableCollection<IBusiness> businesses { get; }

        public override string detailUI => "mods.native.SelectBusinessItems";

        public class CommandOnRevoke : ICommand
        {
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                Log.Info($"Revoke business {parameter}");
            }
        }
    }

    public class RevokeBussiness2 : IPersonInterActive
    {

    }
}
