using JiangH.Kernels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace mods.native
{
    public class SceneMain : INotifyPropertyChanged
    {
        public static SceneMain inst;

        public event PropertyChangedEventHandler PropertyChanged;

        public Facade facade { get; set; }

        public Person player => facade.player;

        public SceneMain()
        {
            inst = this;
            facade = new Facade();
        }

        public MyCommand ClickCommand
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
                SceneMain.inst.facade.ChangePlayer();
            }
        }
    }
}
