using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JiangH.Kernels.Mods
{
    public abstract class IPersonInterActive
    {
        public string name => GetType().FullName;

        public virtual string detailUI { get; }

        public IPerson person2 { get; set; }

        public CommandTrigger cmdTrigger => new CommandTrigger(this);

        public class CommandTrigger : ICommand
        {
            public IPersonInterActive interactive;

            public event EventHandler CanExecuteChanged;

            public CommandTrigger(IPersonInterActive interactive)
            {
                this.interactive = interactive;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                Log.Info($"Trigger {GetType().FullName}");

                dynamic xamlObj = parameter;
                xamlObj.Children.Clear();

                if (interactive.detailUI != null)
                {
                    var def = ModManager.inst.FindUIDef(interactive.detailUI);
                    dynamic ui = Facade.InstanceXaml(def.xaml);
                    xamlObj.DataContext = interactive;

                    xamlObj.Children.Add(ui);
                }
            }
        }
    }
}
