using UnityEngine;
using System.Collections.Generic;

public class Utilits
{
    public List<GameObject> GetChildrenList(GameObject Object)
    {
        try
        {
            List<GameObject> Children = new List<GameObject>();

            foreach (Transform child in Object.gameObject.transform)
            {
                Children.Add(child.gameObject);
            }

            return Children;
        }
        catch
        {
            if (Object == null)
            {
                Debug.LogError("�� ��������� �������� Object");
            }
            else
            {
                Debug.LogError("����������� ������");
            }
        }

        return null;
    }

    public Queue<GameObject> GetChildrenQueue(GameObject Object)
    {
        try
        {
            Queue<GameObject> Children = new Queue<GameObject>();

            foreach (Transform child in Object.gameObject.transform)
            {
                Children.Enqueue(child.gameObject);
            }

            return Children;
        }
        catch
        {
            if (Object == null)
            {
                Debug.LogError("�� ��������� �������� Object");
            }
            else
            {
                Debug.LogError("����������� ������");
            }
        }

        return null;
    }

    public GameObject GetChildByName(List<GameObject> Objects, string Name)
    {
        try
        {
            for (int i = 0; i < Objects.Count; i++)
            {
                if (Objects[i].name == Name)
                {
                    return Objects[i];
                }
            }

        }
        catch
        {
            if (Objects == null)
            {
                Debug.LogError("�� ��������� �������� Objects");
            }
            else if (Name == null)
            {
                Debug.LogError("�� ��������� �������� Name");
            }
            else
            {
                Debug.LogError("����������� ������");
            }
        }

        return null;
    }

    public int LoopIntValue(int Value, int Min, int Max)
    {
        if (Value < Min)
        {
            Value = Max;
        }
        else if (Value > Max)
        {
            Value = Min;
        }

        return Value;
    }

    public bool LoopBoolValue(bool Value, bool NextValue)
    {
        if (Value == NextValue)
        {
            return !NextValue;
        }
        else
        {
            return NextValue;
        }
    }

    public float CheckFloatLowLimit(float Value, float MinLimit)
    {
        if (Value < MinLimit)
        {
            Value = MinLimit;
        }

        return Value;
    }

    public float CheckFloatHighLimit(float Value, float MaxLimit)
    {
        if (Value > MaxLimit)
        {
            Value = MaxLimit;
        }

        return Value;
    }

    public int intExponentiate(int value, int extent)
    {
        int defaultValue = value;

        for (int i = 0; i < extent - 1; i++)
        {
            value = value * defaultValue;
        }

        return value;
    }

    //��� ��� ��������:
    //1)�������� ��������� �������� value
    //�������� 232
    //2)�������� ��� ����� - 3, � ����� 24 ����� - 2, � ����� 5361 - 4 � �.�. �� ��������
    //3)��������� ������� extent �����
    //��� ����� ����� �����, ��� ������� ������������ ��������
    //4)�������� ����, ���������� �������� �������� ����� ����� ������������ ����� - ValueLenght
    //5)������� 10 � ������� ����� ��� ��������, � ������ � 232 10 � 3 ������� � ��������� �� 10 (TenInextent)
    //��������� 232 �� TenInextent � �������� 2 - �.�. �����
    //������� � ����
    //����� ��������� ����� value �� 2 * 100 �.�. ��������� �� ���� �����
    //� ��������� ���� ����� � ���, ������� � �������� 5

    public List<int> intSplit(int value)
    {
        int ValueLenght = value.ToString().Length;
        int extent = ValueLenght;

        List<int> intList = new List<int>();

        for (int i = 0; i < ValueLenght; i++)
        {
            int TenInextent = intExponentiate(10, extent) / 10;
            int BiggestNumberInValue = value / TenInextent;

            intList.Add(BiggestNumberInValue);

            value = value - BiggestNumberInValue * TenInextent;
            extent--;
        }

        return intList;
    }
}