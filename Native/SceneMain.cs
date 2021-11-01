using JiangH.Kernels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveMarbles.PropertyChanged;

namespace mods.native
{
    public class SceneMain : INotifyPropertyChanged
    {
        public static SceneMain inst;

        public event PropertyChangedEventHandler PropertyChanged;

        public Facade facade { get; set; }

        public IPerson player { get; private set; }

        public SceneMain()
        {
            inst = this;

            facade = new Facade();

            facade.WhenChanged(x => x.player).Subscribe(p => this.player = p);
        }

        public MyCommand ClickPlayerCommand
        {
            get
            {
                return new MyCommand();
            }
        }

        public MyCommand2 ClickBusinessCommand
        {
            get
            {
                return new MyCommand2();
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

        public class MyCommand2 : ICommand
        {
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                Log.Info("Execute MyCommand2");
                SceneMain.inst.player.AddBusiness();
            }
        }
    }

}
