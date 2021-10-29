using JiangH;
using Noesis;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

public class SceneMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var view = GetComponent<NoesisView>();
        var rootView = view.Content as SceneRootView;

        var str = File.ReadAllText(Application.streamingAssetsPath + "/mods/native/SceneMain.xaml");
        var viewComponent = XamlReader.Parse(str) as FrameworkElement;

        var asb = Assembly.LoadFrom(Application.streamingAssetsPath + "/mods/native/Assembly.dll");
        var sceneType = asb.GetType("mods.native.SceneMain");

        var sceneObj = System.Activator.CreateInstance(sceneType);
        viewComponent.DataContext = sceneObj;

        rootView.SetViewComponent(viewComponent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
