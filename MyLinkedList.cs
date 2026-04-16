using System.Collections;

namespace MyLinkedListLibrary
{
    public class MyLinkedList : IEnumerable<int>
    {
        private Node? head;
        public int Count { get; private set; }

        public void Add(int value)
        {
            Node newNode = new Node(value);

            if (head == null)
            {
                head = newNode;
                Count++;
                return;
            }

            newNode.Next = head.Next;
            head.Next = newNode;
            Count++;
        }

        public int this[int index]
        {
            get
            {
                ValidateIndex(index);

                Node? current = head;
                int currentIndex = 0;

                while (current != null)
                {
                    if (currentIndex == index)
                    {
                        return current.Value;
                    }

                    current = current.Next;
                    currentIndex++;
                }

                throw new ArgumentOutOfRangeException(nameof(index), "Індекс виходить за межі списку.");
            }
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            if (index == 0)
            {
                head = head!.Next;
                Count--;
                return;
            }

            Node current = head!;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next!;
            }

            current.Next = current.Next!.Next;
            Count--;
        }

        public int FindFirstGreaterThan(int value)
        {
            Node? current = head;

            while (current != null)
            {
                if (current.Value > value)
                {
                    return current.Value;
                }

                current = current.Next;
            }

            throw new InvalidOperationException("У списку немає елемента, більшого за задане значення.");
        }

        public int GetSumOfElementsLessThan(int value)
        {
            int sum = 0;
            Node? current = head;

            while (current != null)
            {
                if (current.Value < value)
                {
                    sum += current.Value;
                }

                current = current.Next;
            }

            return sum;
        }

        public MyLinkedList GetNewListWithElementsGreaterThan(int value)
        {
            MyLinkedList newList = new MyLinkedList();
            Node? current = head;

            while (current != null)
            {
                if (current.Value > value)
                {
                    newList.AddToEnd(current.Value);
                }

                current = current.Next;
            }

            return newList;
        }

        public void RemoveElementsAfterMaximum()
        {
            if (head == null)
            {
                return;
            }

            Node? current = head;
            Node? maxNode = head;
            int currentIndex = 0;
            int maxIndex = 0;

            while (current != null)
            {
                if (current.Value > maxNode!.Value)
                {
                    maxNode = current;
                    maxIndex = currentIndex;
                }

                current = current.Next;
                currentIndex++;
            }

            maxNode!.Next = null;
            Count = maxIndex + 1;
        }

        public MyLinkedList Clone()
        {
            MyLinkedList newList = new MyLinkedList();
            Node? current = head;

            while (current != null)
            {
                newList.AddToEnd(current.Value);
                current = current.Next;
            }

            return newList;
        }

        public IEnumerator<int> GetEnumerator()
        {
            Node? current = head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void AddToEnd(int value)
        {
            Node newNode = new Node(value);

            if (head == null)
            {
                head = newNode;
                Count++;
                return;
            }

            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
            Count++;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Індекс виходить за межі списку.");
            }
        }
    }
}