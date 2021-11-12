using JiangH.Kernels;
using JiangH.Kernels.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace mods.native
{
    public class Scene1st : UIElement
    {
        private static Scene1st inst;

        public Scene1st(string modPath)
        {
            inst = this;
        }

        public MyCommand cmdStart => new MyCommand();

        public class MyCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                var ui = Facade.InstanceUIElement("mods.native.SceneMain");

                inst.ReplaceSceneView(ui);
            }
        }
    }
}
