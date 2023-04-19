using CleanArchitectureCQRS.Domain.Events;
using CleanArchitectureCQRS.Domain.Exceptions;
using CleanArchitectureCQRS.Domain.ValueObjects;
using CleanArchitectureCQRS.Shared.Abstractions.Domains;

namespace CleanArchitectureCQRS.Domain.Entities;

    public class SampleEntity : AggregateRoot<SampleEntityId>
    {
        public  SampleEntityId Id { get; private set; }
        private SampleEntityName _name;
        private SampleEntityDestination _destination;

        private readonly LinkedList<SampleEntityItem> _items = new();

        internal SampleEntity(SampleEntityId id,
            SampleEntityName name,
            SampleEntityDestination destination)
        {
            Id = id;
            _name = name;
            _destination = destination;
        }

        private SampleEntity(SampleEntityId id, SampleEntityName name, SampleEntityDestination destination, LinkedList<SampleEntityItem> items)
           : this(id, name, destination)
        {
            _items = items;
        }
        public SampleEntity()
        {

        }

        public void AddItem(SampleEntityItem item)
        {
            var alreadyExists = _items.Any(i => i.Name == item.Name);

            if (alreadyExists)
            {
                throw new SampleDuplicateException(_name, item.Name);
            }

            _items.AddLast(item);
            AddEvent(new SampleEntityItemAdded(this, item));
        }


        public void AddItems(IEnumerable<SampleEntityItem> items)
        {
            foreach (var item in items)
            {
                AddItem(item);
            }
        }


        public void TakeItem(string itemName)
        {
            var item = GetItem(itemName);
            var SampleEntityItem = item with { IsTaken = true };

            _items.Find(item).Value = SampleEntityItem;
            AddEvent(new SampleEntityItemTaken(this, item));
        }

        public void RemoveItem(string itemName)
        {
            var item = GetItem(itemName);
            _items.Remove(item);
            AddEvent(new SampleEntityItemRemoved(this, item));
        }


        private SampleEntityItem GetItem(string itemName)
        {
            var item = _items.SingleOrDefault(i => i.Name == itemName);

            if (item is null)
            {
                throw new SampleInvalidException();
            }

            return item;
        }        
    }
