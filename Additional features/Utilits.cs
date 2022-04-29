using UnityEngine;
using System.Collections.Generic;

public class Utilits
{
    public List<GameObject> GetChildrenList(Transform parentTransform)
    {
        try
        {
            List<GameObject> children = new List<GameObject>();

            foreach (Transform child in parentTransform)
            {
                children.Add(child.gameObject);
            }

            return children;
        }
        catch
        {
            if (parentTransform == null)
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

    public Queue<GameObject> GetChildrenQueue(Transform parentTransform)
    {
        try
        {
            Queue<GameObject> children = new Queue<GameObject>();

            foreach (Transform child in parentTransform)
            {
                children.Enqueue(child.gameObject);
            }

            return children;
        }
        catch
        {
            if (parentTransform == null)
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

    public GameObject GetChildByName(List<GameObject> objects, string name)
    {
        try
        {
            foreach (GameObject childObject in objects)
            {
                if (childObject.name == name)
                {
                    return childObject;
                }
            }

        }
        catch
        {
            if (objects == null)
            {
                Debug.LogError("Не присвоено значение Objects");
            }
            else if (name == null)
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

    public int LoopIntValue(int value, int min, int max)
    {
        if (value < min)
        {
            value = max;
        }
        else if (value > max)
        {
            value = min;
        }

        return value;
    }

    public bool LoopBoolValue(bool value, bool nextValue)
    {
        if (value == nextValue)
        {
            return !nextValue;
        }
        else
        {
            return nextValue;
        }
    }

    public float CheckFloatLowLimit(float value, float minLimit)
    {
        if (value < minLimit)
        {
            value = minLimit;
        }

        return value;
    }

    public float CheckFloatHighLimit(float value, float maxLimit)
    {
        if (value > maxLimit)
        {
            value = maxLimit;
        }

        return value;
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

    public void intSplit(int value, List<int> listForWriting)
    {
        int valueLenght = value.ToString().Length;
        int extent = valueLenght;

        listForWriting.Clear();

        for (int i = 0; i < valueLenght; i++)
        {
            int tenInextent = intExponentiate(10, extent) / 10;
            int biggestNumberInValue = value / tenInextent;

            listForWriting.Add(biggestNumberInValue);

            value = value - biggestNumberInValue * tenInextent;
            extent--;
        }
    }


    public int GetOneOfTwoValues(int value1, int value2, int firstIntGetChance)
    {
        int probality = Random.Range(0, 100);

        if (probality < firstIntGetChance)
        {
            return value1;
        }
        else
        {
            return value2;
        }
    }

    public int GetOneOfTwoValues(int value1, int value2, float firstIntGetChance)
    {
        float probality = Random.Range(0f, 100f);

        if (probality < firstIntGetChance)
        {
            return value1;
        }
        else
        {
            return value2;
        }
    }
}