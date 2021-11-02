using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiangH.Kernels.Runs
{
    public class RunData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IPerson player { get; set; }

        public List<IPerson> persons;

        public RunData()
        {
            persons = new List<IPerson>();
            persons.Add(new Person("P0"));
            persons.Add(new Person("P1"));

            player = persons[0];

            persons[0].businesses.Add(new Business("B0"));
            persons[0].businesses.Add(new Business("B1"));

            persons[1].businesses.Add(new Business("B2"));
            persons[1].businesses.Add(new Business("B3"));
            persons[1].businesses.Add(new Business("B4"));
        }

        public void ChangePlayer()
        {
            if (player == persons[1])
            {
                Log.Info("player changed to 0");

                player = persons[0];
            }
            else
            {
                Log.Info("player changed to 1");

                player = persons[1];
            }
        }
    }
}
