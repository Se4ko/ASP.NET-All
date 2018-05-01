﻿using System;
using System.Text;

abstract class Node
{
    protected static int Stack = 0;

    protected static readonly StringBuilder Renderer = new StringBuilder();

    protected static void Indent()
    {
        Node.Renderer.Append(' ', 4 * Node.Stack);
    }

    public abstract void Render();

    public override string ToString()
    {
        this.Render();

        string info = Node.Renderer.ToString();

        Node.Renderer.Clear();

        return info;
    }
}
