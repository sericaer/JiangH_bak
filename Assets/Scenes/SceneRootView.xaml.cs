#if UNITY_5_3_OR_NEWER

#define NOESIS
using UnityEngine;
using Noesis;
#else
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
#endif

using JiangH.Kernels;
using System;


namespace JiangH
{
    /// <summary>
    /// Interaction logic for JiangHMainView.xaml
    /// </summary>
    public partial class SceneRootView : UserControl
    {
        private Panel sceneContainer;

        private string modPath = "../../../Assets/StreamingAssets/mods/";

        public SceneRootView()
        {
            InitializeComponent();

            Facade.FindXamlElement = (name) =>
            {
                return FindName(name);
            };

            Facade.InstanceXaml = (xaml) =>
            {
                var viewComponent = XamlReader.Parse(xaml) as FrameworkElement;
                return viewComponent;
            };



            Facade.LoadMods(modPath);

            sceneContainer = FindName("Container") as Panel;
            Facade.rootXamlView = sceneContainer;

            Facade.NewRunData();

            var scene1st = Facade.InstanceUIElement("mods.native.Scene1st", modPath);
            sceneContainer.Children.Add(scene1st.GetXamlObj() as FrameworkElement);
            
        }

#if NOESIS
        private void InitializeComponent()
        {
            NoesisUnity.LoadComponent(this);

            JiangH.Kernels.Log.Info = Debug.Log;

            modPath = Application.streamingAssetsPath + "/mods/";
        }
#endif
    }
}
