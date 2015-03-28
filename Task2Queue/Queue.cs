using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Task2Queue
{
    public class CustomQueue<T> : IEnumerable<T>
    {
        private T[] array;
        private int size;
        private int capacity;
        private int head;
        private int tail;
        private int growFactor;

        public CustomQueue()
        {
            this.capacity = 10;
            this.array = new T[capacity];
            this.growFactor = 2;
            this.size = 0;
            this.head = -1;
            this.tail = 0;
        }

        public CustomQueue(CustomQueue<T> item)
        {
            this.capacity = item.size;
            this.array = new T[capacity];
            this.growFactor = 2;
            this.size = 0;
            this.head = -1;
            this.tail = 0;
            T[] buf = item.ToArray();
            for (int i = 0; i < item.size; ++i)
                this.Enqueue(buf[i]);
        }
        public CustomQueue(int capacity)
        {
            this.capacity = capacity;
            this.array = new T[capacity];
            this.size = 0;
            this.head = -1;
            this.tail = 0;
            this.growFactor = 2;
        }

        public CustomQueue(int capacity, int growFactor)
        {
            this.capacity = capacity;
            this.array = new T[capacity];
            if (growFactor > 1 && growFactor < 10)
                this.growFactor = growFactor;
            else throw new ArgumentException();
            this.size = 0;
            this.head = -1;
            this.tail = 0;
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public void Enqueue(T newElement)
        {
            if (this.size == this.capacity)
            {
                T[] newQueue = new T[growFactor * capacity];
                Array.Copy(array, 0, newQueue, 0, array.Length);
                array = newQueue;
                capacity *= 2;
            }
            size++;
            array[tail++ % capacity] = newElement;
        }

        public T Dequeue()
        {
            if (this.size == 0)
            {
                throw new InvalidOperationException();
            }
            size--;
            return array[++head % capacity];
        }

        public T Peek()
        {
            if (this.size == 0)
            {
                throw new InvalidOperationException();
            }
            return array[head + 1 % capacity];
        }

        public T[] ToArray()
        {
            T[] newArray = new T[size];
            T[] oldArray = new T[capacity];
            Array.Copy(array, oldArray, capacity);
            int index = 0;
            for (int i = head + 1; i < size + head + 1; ++i)
            {
                newArray[index++] = oldArray[i % capacity];
            }
            return newArray;
        }

        public void Clear()
        {
            while (this.size != 0)
            {
                this.Dequeue();
            }
        }

        public bool Contains(T item)
        {
            for (int i = head + 1; i < size + head + 1; ++i)
                if (EqualityComparer<T>.Default.Equals(array[i % capacity],item)) return true;
            return false;
        }

        public int Count
        {
            get
            {
                return this.size;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CustomQueueEnum(array, size, head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class CustomQueueEnum : IEnumerator<T>
        {
            private T[] array;
            private int size;
            private int head;

            private int position;

            public CustomQueueEnum(T[] array, int size, int head)
            {
                this.array = array;
                this.size = size;
                this.head = head;
                position = -1;
            }

            public bool MoveNext()
            {
                position++;
                return (position < size);
            }

            public void Reset()
            {
                position = -1;
            }

            public T Current
            {
                get
                {
                    try
                    {
                        return array[(position + head + 1) % array.Length];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            void IDisposable.Dispose() { }
        }
    }
}

