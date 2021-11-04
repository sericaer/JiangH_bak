using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JiangH.Kernels.Mods
{
    class ModManager
    {
        public static ModManager inst;


        public InteactiveLogic inteactiveLogic;


        private string path;

        private Dictionary<string, Mod> modDict;

        public ModManager(string path)
        {
            inst = this;

            this.path = path;

            modDict = new Dictionary<string, Mod>();

            foreach(var sub in Directory.EnumerateDirectories(path))
            {
                modDict.Add(Path.GetFileName(sub), new Mod(sub));
            }

            inteactiveLogic = new InteactiveLogic()
            {
                personInteractives = modDict.Values.SelectMany(x => x.inteactiveLogic.personInteractives)
            };
        }

        internal UIDef FindUIDef(string name)
        {
            var splits = name.Split('.');
            if(splits.Count() != 3)
            {
                throw new Exception();
            }

            if(splits[0] != "mods")
            {
                throw new Exception();
            }

            return modDict[splits[1]].GetUIDef(splits[2]);
        }
    }

    class Mod
    {

        public InteactiveLogic inteactiveLogic;

        private Dictionary<string, UIDef> uiDefDict;

        private string path;

        private string name => Path.GetFileName(path);

        private Assembly assembly;

        public Mod(string path)
        {
            this.path = path;

            assembly = Assembly.Load(File.ReadAllBytes(path + "/Assembly.dll"));

            uiDefDict = LoadUIDef(path);

            inteactiveLogic = InteactiveLogic.Load(assembly);
        }

        private Dictionary<string, UIDef> LoadUIDef(string path)
        {
            var defDict = new Dictionary<string, UIDef>();

            foreach (var xamlPath in Directory.EnumerateFiles(path, "*.xaml"))
            {
                var content = File.ReadAllText(xamlPath);

                var xamlName = Path.GetFileNameWithoutExtension(xamlPath);

                var type = assembly.GetType($"mods.{name}.{xamlName}");

                defDict.Add(xamlName, new UIDef(content, type));
            }

            return defDict;
        }

        internal UIDef GetUIDef(string name)
        {
            return uiDefDict[name];
        }
    }
}
