#if UNITY_5_3_OR_NEWER
#define NOESIS
using Noesis;
using System;
#else
using System;
using System.Windows.Controls;
#endif

namespace JiangH
{
    /// <summary>
    /// Interaction logic for JiangHMainView.xaml
    /// </summary>
    public partial class SceneRootView : UserControl
    {
        public SceneRootView()
        {
            InitializeComponent();
        }

#if NOESIS
        private void InitializeComponent()
        {
            NoesisUnity.LoadComponent(this);
        }

        internal void SetViewComponent(FrameworkElement viewComponent)
        {
            var container = FindName("Container") as Grid;
            container.Children.Add(viewComponent);
        }
#endif
    }
}
