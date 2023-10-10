using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colas<Q>
{
    public class Node
    {
        public Q Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }
        public Node(Q q)
        {
            Value = q;
            Next = null;
            Previous = null;
        }
    }
    public Node Head;
    public Node Tail;
    public int length = 0;
    public void Enqueue(Q value)
    {
        if(Head == null)
        {
            Node newNode = new Node(value);
            Head = newNode;
            Tail = newNode;
            length++;
        }
        else
        {
            Node newNode = new Node(value);
            Tail.Next = newNode;
            newNode.Previous = Tail;
            Tail = newNode;
            length++;
        }
    }
    public void Dequeue()
    {
        if (length > 0)
        {
            Node newHead = Head.Next;
            newHead.Previous = null;
            Head.Next = null;
            Head = newHead;
            length--;
        }
    }
}
