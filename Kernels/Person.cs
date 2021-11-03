using System.Collections.ObjectModel;
using System.ComponentModel;

namespace JiangH.Kernels
{
    public interface IPerson : INotifyPropertyChanged
    {
        string name { get; }

        ReadOnlyObservableCollection<IBusiness> businesses { get; }
    }

    class Person : IPerson
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string name { get; private set; }

        public ReadOnlyObservableCollection<IBusiness> businesses { get; private set; }

        private ObservableCollection<IBusiness> _businesses;

        public Person(string name)
        {
            this.name = name;

            _businesses = new ObservableCollection<IBusiness>();
            businesses = new ReadOnlyObservableCollection<IBusiness>(_businesses);
        }

        internal void AddBusiness(IBusiness business)
        {
            _businesses.Add(business);
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
