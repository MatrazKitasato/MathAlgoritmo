using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SimpleList<T> 
{
    public class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }
        public Node(T value)
        {
            Value = value;
            Next = null;

        }
    }
    public Node head;
    public int length = 0;
    public void InsertNodeAtStart(T value)
    {
        Node newNode = new Node(value);
        newNode.Next = head;
        head = newNode;
        length++;
    }
    public void InsertNodeAtEnd(T value)
    {
        Node newNode = new Node(value);
        Node lastNode = head;
        while (lastNode.Next != null)
        {
            lastNode = lastNode.Next;
        }
        lastNode.Next = newNode;
        length++;
    }
    public void ModifyAtStart(T value)
    {
        head.Value = value;
    }
    public void ModifyAtEnd(T value)
    {
        Node tmp = head;
        while (tmp.Next != null)
        {
            tmp = tmp.Next;
        }
        tmp.Value = value;
    }
    public void ModifyAtPosition(T value, int posicion)
    {
        if (posicion == 0)
        {
            ModifyAtStart(value);
        }
        else if (posicion == length)
        {
            ModifyAtEnd(value);
        }
        else if (posicion > length)
        {
            Console.WriteLine("Esa posicion no existe.");
        }
        else
        {
            Node tmp = head;
            int iterator = 0;
            while (iterator < posicion)
            {
                tmp = tmp.Next;
                iterator++;
            }
            tmp.Value = value;
        }
    }
    public T GetNodeAtStart()
    {
        return head.Value;
    }
    public T GetNodeAtEnd()
    {
        Node tmp = head;
        while (tmp.Next != null)
        {
            tmp = tmp.Next;
        }
        return tmp.Value;
    }
    public T GetNodeValueAtPosicion(int posicion)
    {
        if (posicion == 0)
        {
            return GetNodeAtStart();
        }
        else if (posicion == length - 1)
        {
            return GetNodeAtEnd();
        }
        Node tmp = head;
        int iterator = 0;
        while (iterator < posicion)
        {
            tmp = tmp.Next;
            iterator++;
        }
        return tmp.Value;
    }
    public void DeleteNodeAtStart()
    {
        Node tmp = head;
        head = head.Next;
        tmp.Next = null;
        length--;
    }
    public void DeleteNodeAtEnd()
    {
        Node tmp = head;
        while (tmp.Next.Next != null)
        {
            tmp = tmp.Next;
        }
        tmp.Next = null;
        length--;
    }
    public void DeleteNodePosition(int p)
    {
        if (p == 0)
        {
            DeleteNodeAtStart();
        }
        else if (p == length)
        {
            DeleteNodeAtEnd();
        }
        else if (p > length)
        {
            throw new NullReferenceException();
        }
        else
        {
            Node currentNode = head;
            int iterator = 0;
            while (iterator < p - 1)
            {
                currentNode = currentNode.Next;
                iterator++;
            }
            Node nextNode = currentNode.Next;
            currentNode.Next = nextNode.Next;
            nextNode.Next = null;
        }
    }
}
