using System;
namespace MyLinkedList
{
    public class CircularLinkedList
    {
        public CircularLinkedList(Node tail)
        {
            this.tail = tail;
            this.head = tail.next;
            this.size = CountNodes();
        }

        public CircularLinkedList()
        {
            this.head = null;
            this.tail = null;
            this.size = 0;
        }

        public Node head;
        public Node tail;
        public int size;

        public int Get(int index)
        {
            if (index == 0)
            {
                return head.value;
            }

            if (index == this.size - 1)
            {
                return tail.value;
            }

            Node currentNode = tail.next;

            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.next;
            }

            return currentNode.value;
        }

        public void AddAtHead(int val)
        {            
            AddAtIndex(0, val);         
        }

        public void AddAtTail(int val)
        {            
            int tailIndex = this.size - 1;
            AddAtIndex(tailIndex, val);         
        }

        public void AddAtIndex(int index, int val)
        {
            Node node = new Node(val);

            try
            {
                if (IsEmpty())
                {
                    this.head = node;
                    this.tail = node;
                    node.next = this.head;
                    return;
                }

                if (index == 0)
                {
                    node.next = this.head;
                    this.tail.next = node;
                    this.head = node;
                    return;
                }

                int tailIndex = this.size - 1;

                if (index == tailIndex)
                {
                    node.next = this.head;
                    this.tail.next = node;
                    this.tail = node;
                    return;
                }

                Node currentNode = this.head;
                int previousNodeIndex = index - 1;

                for (int i = 0; i < previousNodeIndex; i++)
                {
                    currentNode = currentNode.next;
                }

                node.next = currentNode.next;
                currentNode.next = node;
            }            
            finally
            {
                this.size++;
            }
        }

        public void DeleteAtIndex(int index)
        {
            if (IsEmpty())
            {
                return;
            }

            try
            {
                if (index == 0)
                {
                    this.head = this.head.next;
                    this.tail.next = this.head;
                    return;
                }
                
                Node currentNode = this.head;
                int previousNodeIndex = index - 1;

                for (int i = 0; i < previousNodeIndex; i++)
                {
                    currentNode = currentNode.next;
                }

                int tailIndex = this.size - 1;

                if (index == tailIndex)
                {
                    currentNode.next = this.head;
                    this.tail = currentNode;
                    return;
                }

                currentNode.next = currentNode.next.next;
            }
            finally
            {
                this.size--;
            }            
        }

        public void Traverser()
        {
            if (head != null)
            {
                Node currentNode = this.head;

                do
                {
                    Console.Write(currentNode.value + " ");
                    currentNode = currentNode.next;
                }
                while (currentNode != head);

                Console.ReadLine();
            }
        }

        private int CountNodes()
        {
            if (this.head == null)
            {
                return 0;
            }

            Node currentNode = this.head;
            int nodeNumber = 0;

            do
            {
                currentNode = currentNode.next;
                nodeNumber++;
            }
            while (currentNode != this.head);

            return nodeNumber;
        }

        public bool IsEmpty()
        {
            return this.size == 0;
        }
    }
}
