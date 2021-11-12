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

        internal static dynamic rootXamlObj;

        public static void Destroy(UIElement ui)
        {
            dynamic xamlObj = dict[ui];
            xamlObj.Parent.Children.Remove(xamlObj);

            dict.Remove(ui);
        }

        public void AddChild(UIElement uiElem, string parentLabel = null)
        {
            dynamic xamlContainer = this.GetXamlObj();

            if (parentLabel != null)
            {
                xamlContainer = this.GetXamlObj().FindName(parentLabel);
            }
            xamlContainer.Children.Add(dict[uiElem]);
        }

        public void AddRootChild(UIElement uiElem)
        {
            Facade.rootXamlView.Children.Add(dict[uiElem]);
        }

        public dynamic GetXamlObj()
        {
            return dict[this];
        }

        protected void ReplaceSceneView(UIElement ui)
        {
            Facade.rootXamlView.Children.Clear();
            Facade.rootXamlView.Children.Add(ui.GetXamlObj());
        }
    }
}
