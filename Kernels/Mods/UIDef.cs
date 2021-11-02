using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiangH.Kernels.Mods
{
    public class UIDef
    {
        public string xaml;
        public Type type;

        public UIDef(string xaml, Type type)
        {
            this.xaml = xaml;
            this.type = type;
        }
    }
}
