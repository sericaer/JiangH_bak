using JiangH;
using JiangH.Kernels;
using Noesis;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

public class SceneMain : MonoBehaviour
{
    public NoesisView view;

    private SceneRootView rootView => view.Content as SceneRootView;

    // Start is called before the first frame update
    void Start()
    {
        Facade.FindXamlElement = (name) =>
        {
            return rootView.FindName(name);
        };

        Facade.InstanceXaml = (xaml) =>
        {
            var viewComponent = XamlReader.Parse(xaml) as FrameworkElement;
            return viewComponent;
        };

        Facade.NewRunData();


        var ui = Facade.InstanceUIElement("mods.native.SceneMain");

        rootView.SetViewComponent(ui.GetXamlObj() as FrameworkElement);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
