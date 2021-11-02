using System.Collections.ObjectModel;
using System.ComponentModel;

namespace JiangH.Kernels
{
    public interface IPerson : INotifyPropertyChanged
    {
        string name { get; }

        ObservableCollection<IBusiness> businesses { get; }

        void AddBusiness();
    }

    class Person : IPerson
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string name { get; private set; }
        public ObservableCollection<IBusiness> businesses { get; private set; }

        public Person(string name)
        {
            this.name = name;
            this.businesses = new ObservableCollection<IBusiness>();
        }

        public void AddBusiness()
        {
            businesses.Add(new Business("BX"));

            Log.Info($"{name} AddBusiness {businesses.Count}");
        }
    }

    public interface IBusiness : INotifyPropertyChanged
    {
        string name { get; }
    }

    class Business : IBusiness
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string name { get; private set; }

        public Business(string name)
        {
            this.name = name;
        }
    }
}
