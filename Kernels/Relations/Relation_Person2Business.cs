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
    public class Relation_Person2Business
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
                switch(e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        foreach (var x in e.NewItems)
                        {
                            var elem = x as Element;

                            elem.person.AddBusiness(elem.business);
                            elem.business.SetOwner(elem.person);
                        }
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        foreach (var x in e.OldItems)
                        {
                            var elem = x as Element;

                            elem.person.RemoveBusiness(elem.business);
                            elem.business.SetOwner(null);
                        }
                        break;
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

        public void Add(IPerson person, IBusiness business)
        {
            all.Add(new Element(person as Person, business as Business));
        }

        public void Remove(IPerson person, IBusiness business)
        {
            var find = all.SingleOrDefault(x => x.person == person && x.business == business);
            all.Remove(find);
        }
    }
}
