# Prototype

## ���������
���� ������ �� ������ �� �������� �� ��������� �� ��������� �� ����� ���� ���� ��������� �� ���� ����������� �����.
�������� �������� ������ �� ��������� ���� ���������� ���������.
������� ������ � ��������� �� ���� �� ������� ������������� ��������� ���������.

## �����
������ ����� ����� �� ��������� �� ������������� ����� (������ ����� � ������� �� ����������� ��), �� �������� ���� ������. �� �� �������� ������ ��������� �� ��������, � ������� ���������.
�������� ��������� �� ������ �� ������� ���������, ��������������� ������, ���� �� �������, ��� �� �� ���� ������ ���� ��� ������� � �� � ���� ����������� �� ���� ��� �� �� �������.

## ���������
#### Prototype:
��������� ��������� �� ������ ���������.
#### Concrete Prototype:
��������� ���������� �� �����������.
#### Client:
������� ��� ����� (�������� �����), ���� ����� �� Prototype-� �� �� �������.

## �����������
�������� Prototype �� �������� ������:
*   ���� ������� ������ �� ���� ���������� �� ���� ��� ������� �������� �� ���������, ��������� (�������� ������ � �����) � ��� �� ����������.
*   ������ �������������� ������ �� ���������� �� ����� �� ������������ �� ����������.

## �������� �������
Abstract Factory. ��������� � ��, Abstract Factory-�� ���� �� �� ��������� ����� �� ���������, �� ����� �� �� �������� � �� �� ������ ������.

## ���������

![alt text](schemes/structures/prototype-structure.png)

## ������
Prototype �� ��������� �� Stormtrooper

![alt prototype-classdiagram](schemes/diagrams/prototype-classdiagram.png)

###### Abstract Stormtrooper Prototypr
~~~c#
public abstract class StormtrooperPrototype
{
    public abstract Stormtrooper Clone();
}
~~~

###### Abstract Stormtrooper Prototypr
~~~c#
public class Stormtrooper : StormtrooperPrototype
{
    public Stormtrooper(string type, int height, int weight)
    {
        Thread.Sleep(3000); // Doing something slow
        this.Type = type;
        this.Height = height;
        this.Weight = weight;
    }
    
    public string Type { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }

    public override Stormtrooper Clone()
    {
        return this.MemberwiseClone() as Stormtrooper;
    }
    
    public override string ToString()
    {
        return string.Format("Type: {0}, Height: {1}, Weight: {2}", this.Type, this.Height, this.Weight);
    }
}
~~~

###### Usage
~~~c#
public static void Main()
{
    var darkTrooper = new Stormtrooper("Dark trooper", 180, 80);
    Console.WriteLine(darkTrooper);
            
    var anotherDarkTrooper = darkTrooper.Clone();
    darkTrooper.Height = 200;
    Console.WriteLine(anotherDarkTrooper);
}
~~~