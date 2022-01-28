using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class PostGenerator : MonoBehaviour
{
    [SerializeField] ScoreUpdater _scoreUpdater;
    [SerializeField] TextMeshProUGUI[] text;

    //Из этих чисел выбирается минимальное и максимальное количество выключаемых кубов
    //Далее они уменьшаются, пока не становятся равны 1
    private int _minOffedCubesCount1 = 5, _minOffedCubesCount2 = 4;
    private int _maxOffedCubesCount1 = 7, _maxOffedCubesCount2 = 5;

    private int _generationNumber; //Номер генерации
    private int _difficultLevel;
    private int _minProbalityDifficultChange = 60; //Минимальный шанс смены сложности. Если генерируется число меньше этого - сложность не меняется
    private int _generationNumberCoef; //Велечина прибавления коэффициента рекорда, помноженная на 100, отвечает за скорость возрастания сложности

    private float _startScoreCoef;

    public float ScoreCoef { private get; set; }

    public void Initialize()
    {
        _generationNumberCoef = (int)(_scoreUpdater.AddScoreCoefForRecord * 100);
        _startScoreCoef = _scoreUpdater.ScoreCoef;
    }

    public Queue<bool> GenerateCubesCondition(int CubesCount)
    {
        Queue<bool> CubesCondition = new Queue<bool>();
        //Рассчитывать этьо изходя из вероятности смены сложности
        int FirstIntGenerateChance = 100 -_generationNumber * _generationNumberCoef;

        if (FirstIntGenerateChance < 0)
        {
            FirstIntGenerateChance = 0;
        }

        int MinOffCubesCount = GetRandomValue(_minOffedCubesCount1, _minOffedCubesCount2, FirstIntGenerateChance);
        int MaxOffCubesCount = GetRandomValue(_maxOffedCubesCount1, _maxOffedCubesCount2, FirstIntGenerateChance);
        int OffCubesCount = Random.Range(MinOffCubesCount, MaxOffCubesCount);

        text[0].text = "FirstIntGenerateChance: " + FirstIntGenerateChance; //Del
        text[1].text = "MinOffCubesCount: " + MinOffCubesCount; //Del
        text[2].text = "MaxOffCubesCount: " + MaxOffCubesCount; //Del

        if (OffCubesCount > 1) //Если больше одного
        {
            List<int> CubesCountList = new List<int>();
            List<int> OffedCubesNumberstList = new List<int>();

            for (int i = 0; i < CubesCount; i++)
            {
                CubesCountList.Add(i); //Заполнили номерами кубов, доступных для выключения
            }

            for (int i = 0; i < OffCubesCount; i++) //Запустили цикл
            {
                int OffedCubeNumber = Random.Range(0, CubesCountList.Count); //Выбрали случайный куб

                OffedCubesNumberstList.Add(CubesCountList[OffedCubeNumber]); //Добавили его номер в список выключаемых
                CubesCountList.Remove(CubesCountList[OffedCubeNumber]); //Убрали из списка доступных
            }

            CubesCountList.Sort();

            for (int i = 0; i < CubesCount; i++)
            {
                if (CubesCountList.Count != 0 && CubesCountList[0] == i)
                {
                    CubesCondition.Enqueue(true);
                    CubesCountList.RemoveAt(0);
                }
                else
                {
                    CubesCondition.Enqueue(false);
                }
            }
        }
        else
        {
            int OffedCubeNumber = Random.Range(1, CubesCount);
            
            for (int i = 0; i < CubesCount; i++)
            {
                if (i != OffedCubeNumber)
                {
                    CubesCondition.Enqueue(true);
                }
                else
                {
                    CubesCondition.Enqueue(false);
                }
            }
        }

        _generationNumber++;
        TryGhangeDifficult();
        return CubesCondition;
    }

    private void TryGhangeDifficult()
    {
        int probality = Random.Range(0, 100);
        int DifficultChangeChance = Mathf.RoundToInt((ScoreCoef - _startScoreCoef - _difficultLevel) * 100);
        //Сохранять scoreCoef, на котором сменилась сложность начинать считать DifficultChangeChance от этого числа
        if (DifficultChangeChance <= _minProbalityDifficultChange)
        { 
            DifficultChangeChance = 0;
        }
        else
        {
            DifficultChangeChance = DifficultChangeChance - _minProbalityDifficultChange;
        }

        text[3].text = "ScoreCoef: " + ScoreCoef.ToString("0.00"); ; //Del
        text[4].text = "DifficultChangeProbality: " + probality; //Del
        text[5].text = "DifficultChangeChance: " + DifficultChangeChance; //Del

        if (probality < DifficultChangeChance)
        {
            _difficultLevel++;
            _generationNumber = 0;
            
            if (_minOffedCubesCount1 > 1)
            {
                _minOffedCubesCount1--;
            }

            if (_minOffedCubesCount2 > 1)
            {
                _minOffedCubesCount2--;
            }

            if (_maxOffedCubesCount1 > 1)
            {
                _maxOffedCubesCount1--;
            }

            if (_maxOffedCubesCount2 > 1)
            {
                _maxOffedCubesCount2--;
            }
        }
        text[6].text = "DifficultLevel: " + _difficultLevel; //Del
    }

    //Выдаёт первое значение с вероятностью chance
    //Если не выходит - выдаёт второе 
    private int GetRandomValue(int value1, int value2, int chance)
    {
        int probality = Random.Range(0, 100);

        if (probality < chance)
        {
            return value1;
        }
        else
        {
            return value2;
        }
    }

    public void reset()
    {
        _minOffedCubesCount1 = 5;
        _minOffedCubesCount2 = 3;
        _maxOffedCubesCount1 = 7; 
        _maxOffedCubesCount2 = 5;

        _generationNumber = 0;
        _difficultLevel = 0;
    }
}