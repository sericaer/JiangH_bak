using JiangH.Kernels.Mods;
using JiangH.Kernels.Runs;
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
    }

    public static class Log
    {
        public static Action<string> Info;
    }
}
