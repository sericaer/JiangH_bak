using JiangH.Kernels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveMarbles.PropertyChanged;
using System.IO;
using JiangH.Kernels.UI;

namespace mods.native
{
    public class SceneMain : UIElement
    {
        public static SceneMain inst;

        public event PropertyChangedEventHandler PropertyChanged;

        public IPerson player { get; private set; }

        public SceneMain()
        {
            inst = this;

            Facade.runData.WhenChanged(x => x.player).Subscribe(p => this.player = p);
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
                var ui = Facade.InstanceUIElement("mods.native.PersonDetail", SceneMain.inst.player);

                SceneMain.inst.AddChild(ui, "Container");
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
                var ui = Facade.InstanceUIElement("mods.native.BusinessTab", SceneMain.inst.player.businesses);

                SceneMain.inst.AddChild(ui, "Container");
            }
        }
    }

}
