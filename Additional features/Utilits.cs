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
                Debug.LogError("Не присвоено значение Object");
            }
            else
            {
                Debug.LogError("Неизвестная ошибка");
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
                Debug.LogError("Не присвоено значение Object");
            }
            else
            {
                Debug.LogError("Неизвестная ошибка");
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
                Debug.LogError("Не присвоено значение Objects");
            }
            else if (Name == null)
            {
                Debug.LogError("Не присвоено значение Name");
            }
            else
            {
                Debug.LogError("Неизвестная ошибка");
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

    //Как это работает:
    //1)Получили стартовое значение value
    //Например 232
    //2)Выяснили его длину - 3, у числа 24 длина - 2, у числа 5361 - 4 и т.д. по аналогии
    //3)Присвоили степень extent числу
    //Она равна длине числа, над которым производится операция
    //4)Зпустили цикл, количество проходов которого равно длине изначального числа - ValueLenght
    //5)Возвели 10 в степень числа для операций, в случае с 232 10 в 3 степени и разделили на 10 (TenInextent)
    //Разделили 232 на TenInextent и получили 2 - т.е. сотни
    //Занесли в лист
    //Далее уменьшили число value на 2 * 100 т.е. исключили из него сотни
    //И повторили тоже самое с ним, начиная с действия 5

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