using System;
using System.Collections.Generic;

namespace MyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            // Singly Linked List
            Node nodeA = new Node(1);
            Node nodeB = new Node(2);
            Node nodeC = new Node(3);
            Node nodeD = new Node(4);
            Node nodeE = new Node(5);
            //Node nodeF = new Node(6);
            //Node nodeG = new Node(7);
            //Node nodeH = new Node(8);
            //Node nodeI = new Node(9);
            //Node nodeJ = new Node(10);

            nodeA.next = nodeB;
            nodeB.next = nodeC;
            nodeC.next = nodeD;
            nodeD.next = nodeE;
            //nodeE.next = nodeF;
            //nodeF.next = nodeG;
            //nodeG.next = nodeH;
            //nodeH.next = nodeI;
            //nodeI.next = nodeJ;

            LinkedList linkedList = new LinkedList();
            //Node NodeCycle = linkedList.DetectCycle(nodeA);
            //Node NodeCycleV2 = linkedList.DetectCycleV2(nodeA);
            //Node intersectionNode = linkedList.GetIntersectionNode(nodeA, nodeF);
            //Node intersectionNodeV2 = linkedList.GetIntersectionNodeV2(nodeA, nodeF);
            Node listNode = linkedList.RemoveNthFromEnd(nodeA, 2);

            List<List<int>> list = new List<List<int>>() {                
                new List<int> { 2, 3 },
                new List<int> { -1, 4 },
                new List<int> { -1, 5 },
                new List<int> { -1, -1 },
                new List<int> { -1, -1 }
            };

            List<List<int>> list2 = new List<List<int>>() {
                new List<int> { 2, 3 },
                new List<int> { -1, -1 },
                new List<int> { -1, -1 },                
            };

            List<int> queries = new List<int>() { 1, 2 };
            List<int> queries2 = new List<int>() { 2, 1, 1 };

            List<List<int>> result = linkedList.SwapNodes(list, queries);
            List<List<int>> result2 = linkedList.SwapNodes(list2, queries2);

            // linkedList.AddAtHead(55);
            // linkedList.AddAtTail(3);
            // linkedList.AddAtIndex(1, 2);            
            // linkedList.Get(1);
            // linkedList.DeleteAtIndex(1);
            // linkedList.Get(1);

            // Circular Singly Linked List
            // Node nodeE = new Node(1);
            // Node nodeF = new Node(2);
            //Node nodeG = new Node(3);
            //Node nodeH = new Node(4);

            // nodeE.next = nodeF;
            // nodeF.next = nodeG;
            // nodeG.next = nodeH;
            //nodeH.next = nodeG;

            //CircularLinkedList circularLinkedList = new CircularLinkedList(nodeH);
            //circularLinkedList.AddAtTail(5);
            //circularLinkedList.AddAtHead(0);
            //circularLinkedList.AddAtIndex(3, 99);
            //circularLinkedList.DeleteAtIndex(1);
            //circularLinkedList.Traverser();
        }
    }
}
