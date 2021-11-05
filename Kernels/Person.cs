using JiangH.Kernels.Mods;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace JiangH.Kernels
{
    public interface IPerson : INotifyPropertyChanged
    {
        string name { get; }

        ReadOnlyObservableCollection<IBusiness> businesses { get; }

        IEnumerable<IPersonInterActive> interactives { get; }
    }

    class Person : IPerson
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string name { get; private set; }

        public ReadOnlyObservableCollection<IBusiness> businesses { get; private set; }

        public IEnumerable<IPersonInterActive> interactives => _interactives;

        private ObservableCollection<IBusiness> _businesses;
        private List<IPersonInterActive> _interactives;

        public Person(string name)
        {
            this.name = name;

            _businesses = new ObservableCollection<IBusiness>();
            _interactives = new List<IPersonInterActive>();

            businesses = new ReadOnlyObservableCollection<IBusiness>(_businesses);

            foreach (var interactiveType in  ModManager.inst.inteactiveLogic.personInteractives)
            {
                var interactive = Activator.CreateInstance(interactiveType) as IPersonInterActive;
                interactive.person2 = this;

                this._interactives.Add(interactive);
            }
        }

        internal void AddBusiness(IBusiness business)
        {
            _businesses.Add(business);
        }

        internal void RemoveBusiness(Business business)
        {
            _businesses.Remove(business);
        }
    }

    public interface IBusiness : INotifyPropertyChanged
    {
        string name { get; }

        IPerson owner { get; }
    }

    class Business : IBusiness
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string name { get; private set; }

        public IPerson owner { get; private set; }

        public Business(string name)
        {
            this.name = name;
        }

        internal void SetOwner(IPerson person)
        {
            this.owner = person;
        }
    }
}
