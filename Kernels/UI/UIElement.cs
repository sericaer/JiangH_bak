using JiangH.Kernels.Mods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace JiangH.Kernels.UI
{
    public class UIElement : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        internal static Dictionary<UIElement, dynamic> dict = new Dictionary<UIElement, dynamic>();

  
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

        //public virtual void OnInitialized()
        //{

        //}
    }
}
