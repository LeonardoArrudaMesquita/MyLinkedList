using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLinkedList
{
    public class LinkedList
    {
        public LinkedList(Node node)
        {
            this.head = node;
            this.size = CountNodes(node);
        }

        public LinkedList()
        {
            this.head = null;
            this.size = 0;
        }

        public Node head;
        public int size;

        public int Get(int index)
        {
            if (this.size == 0 || index >= this.size)
            {
                return -1;
            }

            Node currentNode = head;
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
            AddAtIndex(size, val);
        }

        public void AddAtIndex(int index, int val)
        {
            if (this.size < index)
            {
                return;
            }

            Node newNode = new Node(val);
            Node prevNode = head;

            for (int i = 0; i < index - 1; i++)
            {
                prevNode = prevNode.next;
            }

            if (index == 0)
            {
                newNode.next = prevNode;
                this.head = newNode;
            }
            else
            {
                newNode.next = prevNode.next;
                prevNode.next = newNode;
            }

            this.size++;
        }

        public void DeleteAtIndex(int index)
        {
            if (this.size == 0 || index >= this.size)
            {
                return;
            }

            Node prevNode = head;

            for (int i = 0; i < index - 1; i++)
            {
                prevNode = prevNode.next;
            }

            prevNode.next = prevNode.next.next;
            this.size--;
        }

        private int CountNodes(Node head)
        {
            int count = 1;
            Node currentNode = head;
            while (currentNode.next != null)
            {
                count++;
                currentNode = currentNode.next;
            }

            return count;
        }

        public bool HasCycle(Node head)
        {
            if (head == null)
            {
                return false;
            }

            Node nodePointerOne = head;
            Node nodePointerTwo = head;

            do
            {
                if (nodePointerOne.next == null || nodePointerTwo.next.next == null)
                {
                    return false;
                }

                nodePointerOne = nodePointerOne.next;
                nodePointerTwo = nodePointerTwo.next.next;
            }
            while (nodePointerOne != nodePointerTwo);

            return true;
        }

        public Node DetectCycle(Node head)
        {
            HashSet<Node> nodeSet = new HashSet<Node>();
            Node currentNode = head;

            while (!nodeSet.Contains(currentNode))
            {
                if (currentNode == null)
                {
                    return null;
                }
                nodeSet.Add(currentNode);
                currentNode = currentNode.next;
            }

            return currentNode;
        }

        public Node DetectCycleV2(Node head)
        {
            Node pointer = head;
            Node intersection = GetIntersect(head);

            if (intersection == null)
            {
                return null;
            }

            do
            {
                intersection = intersection.next;
                pointer = pointer.next;
            } while (intersection != pointer);

            return pointer;
        }

        private Node GetIntersect(Node head)
        {
            if (head == null)
            {
                return null;
            }

            Node nodePointerOne = head;
            Node nodePointerTwo = head;

            do
            {
                if (nodePointerOne.next == null || nodePointerTwo.next.next == null)
                {
                    return null;
                }

                nodePointerOne = nodePointerOne.next;
                nodePointerTwo = nodePointerTwo.next.next;
            }
            while (nodePointerOne != nodePointerTwo);

            return nodePointerOne;
        }

        public Node GetIntersectionNode(Node headA, Node headB)
        {
            HashSet<Node> nodeSet = new HashSet<Node>();
            Node currentNodeA = headA;
            Node currentNodeB = headB;

            while (currentNodeA != null)
            {
                if (!nodeSet.Contains(currentNodeA))
                {
                    nodeSet.Add(currentNodeA);
                    currentNodeA = currentNodeA.next;
                }
            }

            while (currentNodeB != null)
            {
                if (nodeSet.Contains(currentNodeB))
                {
                    return currentNodeB;
                }

                nodeSet.Add(currentNodeB);
                currentNodeB = currentNodeB.next;
            }

            return null;
        }

        public Node GetIntersectionNodeV2(Node headA, Node headB)
        {
            Node currentNodeA = headA;
            Node currentNodeB = headB;
            int nodeALength = 0;
            int nodeBLength = 0;
            int startPoint;

            while (currentNodeA != null)
            {
                nodeALength++;
                currentNodeA = currentNodeA.next;
            }

            while (currentNodeB != null)
            {
                nodeBLength++;
                currentNodeB = currentNodeB.next;
            }

            currentNodeA = headA;
            currentNodeB = headB;
            startPoint = Math.Abs((nodeALength - nodeBLength));

            if (nodeALength > nodeBLength)
            {
                for (int i = 0; i < startPoint; i++)
                {
                    currentNodeA = currentNodeA.next;
                }
            }
            else
            {
                for (int i = 0; i < startPoint; i++)
                {
                    currentNodeB = currentNodeB.next;
                }
            }

            while (currentNodeA != null || currentNodeB != null)
            {
                if (currentNodeA == currentNodeB)
                {
                    return currentNodeA;
                }

                currentNodeA = currentNodeA.next;
                currentNodeB = currentNodeB.next;
            }

            return null;
        }

        public Node GetIntersectionNodeV3(Node headA, Node headB)
        {
            Node p1 = headA;
            Node p2 = headB;

            while (p1 != p2)
            {
                p1 = p1 == null ? headB : p1.next;
                p2 = p2 == null ? headA : p2.next;
            }

            return p1;
        }

        public Node RemoveNthFromEnd(Node head, int n)
        {
            try
            {
                Node p1 = head;
                Node p2 = head;
                int count = 1;
                int stop;

                while (p1.next != null)
                {
                    count++;
                    p1 = p1.next;
                }

                if (n == count)
                {
                    return head.next;
                }

                stop = count - n - 1;

                for (int i = 0; i < stop; i++)
                {
                    p2 = p2.next;
                }

                p1 = p2.next.next;
                p2.next = p1;
                return head;
            }
            finally
            {
                this.size--;
            }

        }

        private void Swap(List<int> list)
        {
            int aux = list[0];
            list[0] = list[1];
            list[1] = aux;
        }

        public List<List<int>> SwapNodes(List<List<int>> indexes, List<int> queries)
        {                      
            List<int> nodesToSwapQty = queries.Select(x => (int)Math.Pow(2, x - 1)).ToList() ;

            for (int i = 0; i < queries.Count; i++)
            {                
                for (int j = 0; j < nodesToSwapQty[i]; j++)
                {
                    List<int> index = indexes[queries[i] + j - 1];
                    Swap(index);
                }
            }

            return indexes;
        }

        public Node SwapNodes(Node head, int k)
        {
            Node currentNode = head;
            Node start = null;
            Node end = null;
            int count = 0;

            if (head.next == null)
            {
                return head;
            }

            while (currentNode != null)
            {       
                currentNode = currentNode.next;
                count++;
            }

            currentNode = head;

            for (int i = 0; i < count; i++)
            {
                if (i == k - 1)
                {
                    start = currentNode;
                }

                if (i == count - k)
                {
                    end = currentNode;
                }

                currentNode = currentNode.next;
            }

            SwapNode(start, end);

            return head;
        }

        public void SwapNode(Node from, Node to)
        {
            Node aux = from;

            from.value = to.value;
            to.value = aux.value;
        }
    }
}