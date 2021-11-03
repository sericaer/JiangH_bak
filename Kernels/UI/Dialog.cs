using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JiangH.Kernels.UI
{
    public class Dialog : UIElement
    {
        public CommandClose CmdClose => new CommandClose(this);

        public class CommandClose : ICommand
        {
            public event EventHandler CanExecuteChanged;

            private UIElement _ui;

            public CommandClose(UIElement ui)
            {
                this._ui = ui;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                Destroy(_ui);
            }
        }
    }
}
