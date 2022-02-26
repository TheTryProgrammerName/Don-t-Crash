using UnityEngine;
using System.Collections.Generic;

public class PostGenerator : MonoBehaviour
{
    [SerializeField] ScoreUpdater _scoreUpdater;

    private Utilits _utilits;
    private DebugInfoSender _debugInfoSender;

    //Из этих чисел выбирается минимальное и максимальное количество выключаемых кубов
    //Далее они уменьшаются, пока не становятся равны 1
    private int _minOffedCubesCount1 = 5, _minOffedCubesCount2 = 4;
    private int _maxOffedCubesCount1 = 7, _maxOffedCubesCount2 = 5;

    private int _generationNumber; //Номер генерации
    private int _difficultLevel; //Нужно только для отображения при активации DebugMode
    private int _generationNumberCoef; //Велечина прибавления коэффициента рекорда, помноженная на 100, отвечает за скорость возрастания сложности
    private int _offTwoCubesInARowChance = 100; //Базовый шанс выключить два куба подряд

    private float _scoreCoefWhenDifficultChange;
    private float _scoreCoefWhenDifficultChangeIncrement = 0.6f; //Когда сложность меняется _scoreCoefWhenDifficultChange = ScoreCoef + это значение

    public float ScoreCoef { private get; set; }

    public void Initialize()
    {
        _utilits = new Utilits();
        _debugInfoSender = new DebugInfoSender();
        InitializeDebug();
        _generationNumberCoef = (int)(_scoreUpdater.AddScoreCoefForRecord * 100);
        _scoreCoefWhenDifficultChange = ScoreCoef + _scoreCoefWhenDifficultChangeIncrement;
    }

    private void InitializeDebug()
    {
        _debugInfoSender.InitializeInfo("postGenerator", "FirstIntGenerateChance: ");
        _debugInfoSender.InitializeInfo("postGenerator", "MinOffCubesCount: ");
        _debugInfoSender.InitializeInfo("postGenerator", "MaxOffCubesCount: ");
        _debugInfoSender.InitializeInfo("postGenerator", "ScoreCoef:");
        _debugInfoSender.InitializeInfo("postGenerator", "DifficultChangeProbality:");
        _debugInfoSender.InitializeInfo("postGenerator", "DifficultChangeChance:");
        _debugInfoSender.InitializeInfo("postGenerator", "DifficultLevel:");
    }

    public Queue<bool> GenerateCubesCondition(int CubesCount)
    {
        Queue<bool> CubesCondition = new Queue<bool>();

        int FirstIntGenerateChance = 100 - _generationNumber * _generationNumberCoef;
        int MinOffCubesCount = _utilits.GetOneOfTwoValues(_minOffedCubesCount1, _minOffedCubesCount2, FirstIntGenerateChance);
        int MaxOffCubesCount = _utilits.GetOneOfTwoValues(_maxOffedCubesCount1, _maxOffedCubesCount2, FirstIntGenerateChance);
        int OffCubesCount = Random.Range(MinOffCubesCount, MaxOffCubesCount);

        _debugInfoSender.SendInfo("postGenerator", "FirstIntGenerateChance: ", FirstIntGenerateChance.ToString());
        _debugInfoSender.SendInfo("postGenerator", "MinOffCubesCount: ", MinOffCubesCount.ToString());
        _debugInfoSender.SendInfo("postGenerator", "MaxOffCubesCount: ", MaxOffCubesCount.ToString());

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

            int probality = Random.Range(0, 100);

            if (probality <= _offTwoCubesInARowChance)
            {
                List<int> cubesWhichWeCanOff = new List<int>();

                for (int i = 0; i < CubesCount - 1; i++)
                {
                    //Если куб выключен а следующий включен
                    if (OffedCubesNumberstList.Contains(i) && !OffedCubesNumberstList.Contains(i + 1))
                    {
                        if (!cubesWhichWeCanOff.Contains(i + 1))
                        {
                            cubesWhichWeCanOff.Add(i + 1);
                        }
                    } //Или если куб включен, а следующий выключен
                    else if (!OffedCubesNumberstList.Contains(i) && OffedCubesNumberstList.Contains(i + 1))
                    {
                        if (!cubesWhichWeCanOff.Contains(i))
                        {
                            cubesWhichWeCanOff.Add(i);
                        }
                    }
                }

                int randomCubeIndex = Random.Range(0, cubesWhichWeCanOff.Count);

                CubesCountList.Add(cubesWhichWeCanOff[randomCubeIndex]);
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
        int DifficultChangeChance = Mathf.RoundToInt((ScoreCoef - _scoreCoefWhenDifficultChange) * 100);

        _debugInfoSender.SendInfo("postGenerator", "ScoreCoef:", ScoreCoef.ToString("0.00"));
        _debugInfoSender.SendInfo("postGenerator", "DifficultChangeProbality:", probality.ToString());
        _debugInfoSender.SendInfo("postGenerator", "DifficultChangeChance:", DifficultChangeChance.ToString());

        if (probality < DifficultChangeChance)
        {
            _difficultLevel++;
            _scoreCoefWhenDifficultChange = ScoreCoef + _scoreCoefWhenDifficultChangeIncrement;
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

        _debugInfoSender.SendInfo("postGenerator", "DifficultLevel:", _difficultLevel.ToString());
    }

    public void reset()
    {
        _minOffedCubesCount1 = 5;
        _minOffedCubesCount2 = 3;
        _maxOffedCubesCount1 = 7; 
        _maxOffedCubesCount2 = 5;

        _generationNumber = 0;
        _difficultLevel = 0;

        _offTwoCubesInARowChance = 100;
    }
}