using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private class Node
        {
            public T Value;
            public Node Next;
            public Node Prev;

            public Node(T value)
            {
                Value = value;
            }
        }

        private Node head;
        private Node tail;
        private int count;
        public int Length => count;

        public void Add(T e)
        {
            Node newNode = new Node(e);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
            count++;
        }

        public void AddAt(int index, T e)
        {
            if (index < 0 || index > count)
                throw new ArgumentOutOfRangeException();

            Node newNode = new Node(e);

            if (index == 0)
            {
                newNode.Next = head;
                if (head != null)
                    head.Prev = newNode;
                head = newNode;
                if (tail == null) tail = head;
            }
            else if (index == count)
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
            else
            {
                Node current = GetNodeAt(index);
                Node prev = current.Prev;

                prev.Next = newNode;
                newNode.Prev = prev;
                newNode.Next = current;
                current.Prev = newNode;
            }
            count++;
        }

        private Node GetNodeAt(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();

            Node current = head;
            for (int i = 0; i < index; i++)
                current = current.Next;

            return current;
        }

        public T ElementAt(int index)
        {
            Node node = GetNodeAt(index);
            return node.Value;
        }

        public void Remove(T item)
        {
            Node current = head;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, item))
                {
                    RemoveNode(current);
                    return;
                }
                current = current.Next;
            }
        }
        private void RemoveNode(Node node)
        {
            if (node.Prev != null)
                node.Prev.Next = node.Next;
            else
                head = node.Next;

            if (node.Next != null)
                node.Next.Prev = node.Prev;
            else
                tail = node.Prev;

            count--;
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();
            Node node = GetNodeAt(index);
            T value = node.Value;
            RemoveNode(node);
            return value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DoublyLinkedListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class DoublyLinkedListEnumerator : IEnumerator<T>
        {
            private Node current;
            private DoublyLinkedList<T> list;
            private bool started;

            public DoublyLinkedListEnumerator(DoublyLinkedList<T> list)
            {
                this.list = list;
                Reset();
            }

            public T Current => current.Value;

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if (!started)
                {
                    current = list.head;
                    started = true;
                }
                else
                {
                    if (current != null) current = current.Next;
                }
                return current != null;
            }

            public void Reset()
            {
                current = null;
                started = false;
            }

            public void Dispose() { }
        }
    }
}
