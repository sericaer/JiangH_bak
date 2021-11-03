using JiangH.Kernels;
using JiangH.Kernels.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace mods.native
{
    class BusinessTab : UIElement
    {
        public static BusinessTab inst;

        public ReadOnlyObservableCollection<IBusiness> businesses { get; set; }

        public BusinessTab(ReadOnlyObservableCollection<IBusiness> businesses)
        {
            inst = this;

            this.businesses = businesses;
        }

        public MyCommand ClickCloseCommand
        {
            get
            {
                return new MyCommand();
            }
        }

        public class MyCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                Destroy(BusinessTab.inst);
            }
        }
    }
}
