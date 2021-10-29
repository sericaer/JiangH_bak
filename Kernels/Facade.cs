using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiangH.Kernels
{
    public class Facade : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Person player { get; set; }

        public List<Person> persons;

        public Facade()
        {
            persons = new List<Person>();
            persons.Add(new Person("P0"));
            persons.Add(new Person("P1"));

            player = persons[0];
        }

        public void ChangePlayer()
        {
            if(player == persons[1])
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

    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string name { get; set; }

        public Person(string name)
        {
            this.name = name;
        }
    }

    public static class Log
    {
        public static Action<string> Info;

    }
}
