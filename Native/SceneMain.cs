using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mods.native
{
    public class SceneMain : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string name { get; set; }

        public SceneMain()
        {
            name = "SceneMain";
        }

    }
}
