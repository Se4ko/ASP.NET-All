﻿using System;

partial class BinarySearchTree<T>
{
    private Node root = null;

    public int Count { get; private set; }

    // private unsafe void Add(ref Node current, T key)
    // {
    //     if (current == null)
    //     {
    //         current = new Node(key);
       
    //         this.Count++;
    //     }
       
    //     else
    //     {
    //         int compared = current.Key.CompareTo(key);
       
    //         if (compared == 0) return;
       
    //         else if (compared > 0) Add(ref current.Left, key);
    //         else if (compared < 0) Add(ref current.Right, key);
    //     }
    // }
       
    // public void Add(T key)
    // {
    //     Add(ref this.root, key);
    // }

    public void Add(T key)
    {
        if (root == null)
        {
            root = new Node(key);
        }

        else
        {
            Node current = this.root;

            while (true)
            {
                int compared = current.Key.CompareTo(key);

                if (compared == 0) return; // Don't increase count

                else if (compared < 0)
                {
                    if (current.Right == null)
                    {
                        current.Right = new Node(key);
                        break;
                    }

                    current = current.Right;
                }

                else if (compared > 0)
                {
                    if (current.Left == null)
                    {
                        current.Left = new Node(key);
                        break;
                    }

                    current = current.Left;
                }
            }
        }

        this.Count++;
    }

    public void Remove(T key)
    {
        // TODO

        this.Count--;
    }

    public bool Contains(T key)
    {
        Node current = this.root;

        while (current != null)
        {
            int compared = current.Key.CompareTo(key);

            if (compared == 0) return true;

            else if (compared < 0) current = root.Left;
            else if (compared > 0) current = root.Right;
        }

        return false;
    }
}
