using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace JiangH.Kernels
{
    public partial class Facade
    {
        public class UIElement : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            private static Dictionary<UIElement, dynamic> dict = new Dictionary<UIElement, dynamic>();

            public static UIElement InstanceUIElement(string name, object param = null)
            {
                var def = modManager.FindUIDef(name);

                dynamic tabObj = Facade.InstanceXaml(def.xaml);

                UIElement uiElement = null;
                if(param != null)
                {
                    uiElement = Activator.CreateInstance(def.type, new Object[] { param }) as UIElement;
                }
                else
                {
                    uiElement = Activator.CreateInstance(def.type) as UIElement;
                }

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
}
