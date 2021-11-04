using JiangH.Kernels;
using JiangH.Kernels.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace mods.native
{
    public class PersonDetail : Dialog
    {
        public IPerson person { get; set; }

        public IBusiness selectedBusiness
        { 
            get
            {
                return _selected;
            }

            set
            {
                _selected = value;
                Log.Info($"Selected {value}");

                var ui = Facade.InstanceUIElement("mods.native.BusinessDetail");

                this.AddChild(ui, "Container");
            }
        }

        IBusiness _selected;

        public PersonDetail(IPerson person)
        {
            this.person = person;
        }
    }
}
