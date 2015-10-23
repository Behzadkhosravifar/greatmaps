using System;
using System.Collections.Generic;

namespace GMap.NET.ObjectModel
{
    public class ObservableCollectionThreadSafe<T> : ObservableCollection<T>
    {
        private readonly SortedList<decimal, T> _orderingList = new SortedList<decimal, T>(new DuplicateKeyComparer<decimal>());

        NotifyCollectionChangedEventHandler collectionChanged;
        public override event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add
            {
                collectionChanged += value;
            }
            remove
            {
                collectionChanged -= value;
            }
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            // Be nice - use BlockReentrancy like MSDN said
            using (BlockReentrancy())
            {
                if (collectionChanged != null)
                {
                    Delegate[] delegates = collectionChanged.GetInvocationList();

                    // Walk thru invocation list
                    foreach (NotifyCollectionChangedEventHandler handler in delegates)
                    {
#if !PocketPC
                        System.Windows.Forms.Control dispatcherObject = handler.Target as System.Windows.Forms.Control;

                        // If the subscriber is a DispatcherObject and different thread
                        if (dispatcherObject != null && dispatcherObject.InvokeRequired)
                        {
                            // Invoke handler in the target dispatcher's thread
                            dispatcherObject.Invoke(handler, this, e);
                        }
                        else // Execute handler as is 
                        {
                            collectionChanged(this, e);
                        }
#else
                  // If the subscriber is a DispatcherObject and different thread
                  if(handler != null)
                  {
                     // Invoke handler in the target dispatcher's thread
                     handler.Invoke(handler, e);
                  }
                  else // Execute handler as is 
                  {
                     collectionChanged(this, e);
                  }
#endif
                    }
                }
            }
        }


        public void Add(T obj, decimal orderNo)
        {
            try
            {
                _orderingList.Add(orderNo, obj);

                base.Add(obj);
            }
            catch (Exception)
            {
                throw new Exception("The order No. is duplicate key!");
            }
            finally
            {
                ResetOrdering();
            }
        }

        public new void Remove(T obj)
        {
            base.Remove(obj);

            var prop = typeof(T).GetProperty("SortedIndex");

            if (prop == null) return;

            int index = (int)prop.GetValue(obj);

            _orderingList.RemoveAt(index);

            ResetOrdering();
        }

        public new void Clear()
        {
            base.Clear();

            _orderingList.Clear();
        }


        void ResetOrdering()
        {
            var prop = typeof(T).GetProperty("SortedIndex");

            if (prop == null) return;

            for (int i = 0; i < _orderingList.Count; i++)
            {
                prop.SetValue(_orderingList.Values[i], i + 1);
            }
        }

        public IList<T> GetSortedList()
        {
            return _orderingList.Values;
        }
    }
}
