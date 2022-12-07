using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4
{
    public class MyStorage<T>
    {
        private T[] arr;
        public int Capacity => arr.Length;
        public int Count { get; private set; }

        public T this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }
        }
        private void TryResize()
        {
            Count++;
            if (arr.Length < Count)
            {
                Array.Resize(ref arr, arr.Length == 0 ? 1 : arr.Length * 2);
            }
        }
        public void RemoveAt(int pos)
        {
            for (var i = pos; i < Count-1; i++)
            {
                arr[i] = arr[i + 1];
            }
            arr[Count - 1] = default(T);
            Count--;
        }
        public MyStorage()
        {
            arr = new T[0];
            arr.Initialize();
        }

        public MyStorage(int l)
        {
            if (l > 0)
            {
                arr = new T[l];
                arr.Initialize();
            }
            else
            {
                throw new Exception("Length cannot be less than 0");
            }
        }
        public void Add(T item)
        {
            TryResize();
            arr[this.Count - 1] = item;
        }
        public void setObject(T element, int pos)
        {
            if (pos > 0 && pos < arr.Length)
                arr.SetValue(element, pos);
            else throw new ArgumentOutOfRangeException();
        }
        public int size()
        {
            return arr.Length;
        }
        public T getObject(int index)
        {
            if (index >= 0 && index < arr.Length)
                return arr[index];
            else return default(T);

        }
        public T getObjectAndDelete(int index)
        {
            if (index >= 0 && index < arr.Length && empty() == false)
            {
                T tmp = getObject(index);
                RemoveAt(index);
                return tmp;
            }
            else throw new Exception("Invalid index");

        }
        public bool empty()
        {
            if (arr.Length == 0) return true;
            else return false;
        }
        public void Print()
        {
            for (int i = 0; i < size(); i++)
                if (arr[i] != null)
                    Console.WriteLine(arr[i]);
                else Console.WriteLine(default(T));
        }



    }

}
