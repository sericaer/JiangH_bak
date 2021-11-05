using JiangH.Kernels.Relations;
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

        public IEnumerable<IPerson> persons => _persons;
        public IEnumerable<IBusiness> businesses => _businesses;

        private List<Person> _persons;
        private List<Business> _businesses;

        public Relation_Person2Business person2Business;

        public RunData()
        {
            _persons = new List<Person>();
            _persons.Add(new Person("P0"));
            _persons.Add(new Person("P1"));

            _businesses = new List<Business>();
            _businesses.Add(new Business("B0"));
            _businesses.Add(new Business("B1"));
            _businesses.Add(new Business("B2"));
            _businesses.Add(new Business("B3"));
            _businesses.Add(new Business("B4"));

            person2Business = new Relation_Person2Business();

            player = _persons[0];

            person2Business.Add(_persons[0], _businesses[0]);
            person2Business.Add(_persons[0], _businesses[1]);

            person2Business.Add(_persons[1], _businesses[2]);
            person2Business.Add(_persons[1], _businesses[3]);
            person2Business.Add(_persons[1], _businesses[4]);
        }

        public void ChangePlayer()
        {
            if (player == _persons[1])
            {
                Log.Info("player changed to 0");

                player = _persons[0];
            }
            else
            {
                Log.Info("player changed to 1");

                player = _persons[1];
            }
        }
    }
}
