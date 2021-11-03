using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace JiangH.Kernels.Relations
{
    class Relation_Person2Business
    {
        //public IObservable<(IPerson person, IBusiness bussiness)> OnAddOrUpdate => _OnAddOrUpdate;

        //private BehaviorSubject<(IPerson, IBusiness)> _OnAddOrUpdate;

        private class Element
        {
            public Person person;
            public Business business;

            public Element(Person person, Business business)
            {
                this.person = person;
                this.business = business;
            }
        }

        private ObservableCollection<Element> all;

        public Relation_Person2Business()
        {
            all = new ObservableCollection<Element>();
            all.CollectionChanged += (object sender, NotifyCollectionChangedEventArgs e) =>
            {
                foreach (var x in e.NewItems)
                {
                    var elem = x as Element;
                    //_OnAddOrUpdate.OnNext((elem.person, elem.business));

                    elem.person.AddBusiness(elem.business);
                    elem.business.SetOwner(elem.person);
                }

                //foreach (var y in e.)
                //{
                //    //do something
                //}
                //if (e.Action == NotifyCollectionChangedAction.Move)
                //{
                //    //do something
                //}
            };
        }

        public void AddOrUpdate(Person person, Business business)
        {
            all.Add(new Element(person, business));
        }
    }
}
