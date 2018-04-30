# Creational Patterns

## Singleton/���������

 * �������� �� ��������, �� �� ���������, �� �� ����� ���� ���� �� ���� ��������� ���� ���������� ���������
 * ��� ����� �� ������������ ������ �� �����, �� ����� ������������ ����������� ���������� ���������
 * ������������ �� ����� �� ����� ����� ������������ � ������������ �� �������, ������ �� �������� thread-safe �������������

�������� ��������� � ���� �� ���-����� ��������� ������� � ����������� �����������. � �������� �� ���� � ����, ����� ��������� �� ���� �� ���� �� ���� ��������� ���������� ��������� � ���� ������ �� ���� ���������.

���-����� ���� ������� �� ���������� �� �� ������� ��������� ��� ����������� �� �����������, ��� ���� ��� ������� �������� ����� ���� �� ��������� �� ��������� � �������� ��������� �� ����� �� ������� �������.

���������� ��������� �� ��������� ����������� � �� �� ���� ��������� ��� ����� ���� �.���. *lazy loading*, �.�. �������������� �� �� ������ ����, ������ �� ����� ��� ��� ����� �� �����������.

�������� �� ����� �� �������� �� *thread-safe* ������������, �� �� ���� ���������� ��� ��� ������ ����� ������������ �� �������� ��������� �� �����.


## ���� ��������:

![Singleton pattern](http://www.dofactory.com/images/diagrams/net/singleton.gif)

����������:

 * *__Singleton:__* �������� �������� �� ����������� � ������������ �� ���������� �������� ��������� �� �����.

�������� ��� � ���������� �� Lazy\<T>:

```
public sealed class Singleton
{
    private static readonly Lazy<Singleton> lazy =
        new Lazy<Singleton>(() => new Singleton());
    
    public static Singleton Instance { get { return lazy.Value; } }

    private Singleton()
    {
    }
}
```
�������� ��� � ���������� �� ������ ����������:

```
public sealed class Singleton
{
    private static Singleton instance = null;
    private static readonly object padlock = new object();

    private Singleton()
    {
    }

    public static Singleton Instance
    {
        get
        {
            if (instance == null)
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                }
            }
            return instance;
        }
    }
}
```
