using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private DoublyLinkedList<T> storage = new DoublyLinkedList<T>();
        public T Dequeue()
        {
            if (storage.Length == 0)
                throw new InvalidOperationException("The processor is empty.");

            return storage.RemoveAt(0);
        }

        public void Enqueue(T item)
        {
            storage.Add(item);
        }

        public T Pop()
        {
            if (storage.Length == 0)
                throw new InvalidOperationException("The processor is empty.");
            return storage.RemoveAt(storage.Length - 1);
        }

        public void Push(T item)
        {
            storage.Add(item);
        }
    }
}