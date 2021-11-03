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

        public PersonDetail(IPerson person)
        {
            this.person = person;
        }

        private void PrintText(object sender, SelectionChangedEventArgs args)
        {
            dynamic item = sender;
            if (item != null)
            {
                Log.Info(item);
            }
        }
    }
}
