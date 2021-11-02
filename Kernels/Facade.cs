using JiangH.Kernels.Mods;
using JiangH.Kernels.Runs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiangH.Kernels
{
    public class Facade : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static Func<string, object> InstanceXaml;
        public static Func<string, object> FindXamlElement;

        public static RunData runData { get; private set; }

        private static ModManager modManager;

        public static void LoadMods(string path)
        {
            modManager = new ModManager(path);
        }

        public static void NewRunData()
        {
            runData = new RunData();
        }

        public class UIElement : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            private static Dictionary<UIElement, dynamic> dict = new Dictionary<UIElement, dynamic>();

            public static UIElement InstanceUIElement(string name, object param = null)
            {
                var def = modManager.FindUIDef(name);

                UIElement uiElement = null;
                if(param != null)
                {
                    uiElement = Activator.CreateInstance(def.type, new Object[] { param }) as UIElement;
                }
                else
                {
                    uiElement = Activator.CreateInstance(def.type) as UIElement;
                }

                dynamic tabObj = Facade.InstanceXaml(def.xaml);
                tabObj.DataContext = uiElement;

                dict[uiElement] = tabObj;

                return uiElement;
            }

            public static void Destroy(UIElement ui)
            {
                dynamic xamlObj = dict[ui];
                xamlObj.Parent.Children.Remove(xamlObj);

                dict.Remove(ui);
            }

            //public UIElement FindUIElement(string name)
            //{
            //    var xamlObj = dict[this].FindName(name);

            //    foreach (var dictElem in dict)
            //    {
            //        if (dictElem.Value == xamlObj)
            //        {
            //            return dictElem.Key;
            //        }
            //    }
            //    return null;
            //}

            public void AddChild(UIElement uiElem, string parentLabel = null)
            {
                dynamic xamlContainer = this.GetXamlObj();

                if (parentLabel != null)
                {
                    xamlContainer = this.GetXamlObj().FindName(parentLabel);
                }
                xamlContainer.Children.Add(dict[uiElem]);
            }

            public dynamic GetXamlObj()
            {
                return dict[this];
            }
        }
    }

    public static class Log
    {
        public static Action<string> Info;
    }
}
