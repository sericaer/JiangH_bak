using JiangH.Kernels.Mods;
using JiangH.Kernels.Runs;
using JiangH.Kernels.UI;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiangH.Kernels
{
    public partial class Facade : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static Func<string, object> InstanceXaml;
        public static Func<string, object> FindXamlElement;

        public static dynamic rootXamlView { get; set; }

        public static RunData runData { get; private set; }

        internal static ModManager modManager;

        public static void LoadMods(string path)
        {
            modManager = new ModManager(path);
        }

        public static void NewRunData()
        {
            runData = new RunData();
        }

        public static UIElement InstanceUIElement(string name, object param = null)
        {
            var def = modManager.FindUIDef(name);

            dynamic tabObj = InstanceXaml(def.xaml);

            UIElement uiElement = null;
            if (param != null)
            {
                uiElement = Activator.CreateInstance(def.type, new Object[] { param }) as UIElement;
            }
            else
            {
                uiElement = Activator.CreateInstance(def.type) as UIElement;
            }

            tabObj.DataContext = uiElement;

            UIElement.dict[uiElement] = tabObj;

            //uiElement.OnInitialized?.Invoke();

            return uiElement;
        }
    }

    public static class Log
    {
        public static Action<string> InfoFunc;

        public static void Info(string str)
        {
            InfoFunc?.Invoke(str);
        }
    }
}
