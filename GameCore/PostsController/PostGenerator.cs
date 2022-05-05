using UnityEngine;
using System.Collections.Generic;

public class PostGenerator
{
    private Utilits _utilits;
    private DebugInfoSender _debugInfoSender;

    private int _minOffedCubesCount = 5;
    private int _maxOffedCubesCount = 7;

    private int _minMinOffedCubesCount = 3;
    private int _minMaxOffedCubesCount = 4;

    private int _difficultLevel; //Нужно только для отображения при активации DebugMode

    private int _minOffTwoCubesInARowChance = 100, _maxOffTwoCubesInARowChance = 100; //Базовый шанс выключить два куба подряд
    private int _minOffTwoCubesInARowChance1 = 5, _minOffTwoCubesInARowChance2 = 15; //Минимальбные шансы выключить два куба подряд
    private int _subtractMinOffTwoCubesInARowChance, _subtractMaxOffTwoCubesInARowChance; //Отнимать эти значения от соотсветствующих чисел при смене сложности

    private float _difficultCoef; //Коэфициент сложности текущего _difficultLevel, когда становится равен 1, сложность повышается
    private float _subtractCoef = 1.75f;

    public float AddDifficultCoefForGeneration { private get; set; }

    public PostGenerator(float addDifficultCoefForGeneration)
    {
        _utilits = new Utilits();
        _debugInfoSender = new DebugInfoSender();
        InitializeDebug();

        AddDifficultCoefForGeneration = addDifficultCoefForGeneration;

        _subtractMinOffTwoCubesInARowChance = (int)((_minOffTwoCubesInARowChance - _minOffTwoCubesInARowChance1) / ((_minOffedCubesCount - _minMinOffedCubesCount) * _subtractCoef));
        _subtractMaxOffTwoCubesInARowChance = (int)((_maxOffTwoCubesInARowChance - _minOffTwoCubesInARowChance2) / ((_maxOffedCubesCount - _minMaxOffedCubesCount) * _subtractCoef));
    }

    private void InitializeDebug()
    {
        _debugInfoSender.SendInfo("postGenerator", "DifficultCoef", 0);
        _debugInfoSender.SendInfo("postGenerator", "DifficultLevel", 0);
        _debugInfoSender.SendInfo("postGenerator", "OffTwoCubesInARowProbality", 0);
        _debugInfoSender.SendInfo("postGenerator", "MinOffTwoCubesInARowChance", 0);
        _debugInfoSender.SendInfo("postGenerator", "MaxOffTwoCubesInARowChance", 0);
        _debugInfoSender.SendInfo("postGenerator", "OffTwoCubesInARowChance", 0);
    }

    public Queue<bool> GenerateCubesCondition(int CubesCount)
    {
        Queue<bool> CubesCondition = new Queue<bool>();

        _debugInfoSender.SendInfo("postGenerator", "DifficultCoef", _difficultCoef.ToString("0.000"));
        _debugInfoSender.SendInfo("postGenerator", "MinOffTwoCubesInARowChance", _minOffTwoCubesInARowChance);
        _debugInfoSender.SendInfo("postGenerator", "MaxOffTwoCubesInARowChance", _maxOffTwoCubesInARowChance);
        _debugInfoSender.SendInfo("postGenerator", "DifficultLevel", _difficultLevel.ToString());

        int OffCubesCount = _utilits.GetOneOfTwoValues(_minOffedCubesCount, _maxOffedCubesCount, _difficultCoef * 100);

        List<int> OffedCubesNumberstList = new List<int>();

        if (OffCubesCount > 1) //Если больше одного
        {
            List<int> CubesCountList = new List<int>();

            for (int i = 0; i < CubesCount; i++)
            {
                CubesCountList.Add(i); //Заполнили номерами кубов, доступных для выключения
            }

            void offRandomCube()
            {
                int OffedCubeNumber = Random.Range(0, CubesCountList.Count); //Выбрали случайный куб

                OffedCubesNumberstList.Add(CubesCountList[OffedCubeNumber]); //Добавили его номер в список выключаемых
                CubesCountList.Remove(CubesCountList[OffedCubeNumber]); //Убрали из списка доступных
            }

            for (int i = 0; i < OffCubesCount - 1; i++) //Запустили цикл
            {
                offRandomCube();
            }

            int offTwoCubesInARowProbality = Random.Range(0, 100);
            int _offTwoCubesInARowChance = Random.Range(_minOffTwoCubesInARowChance, _maxOffTwoCubesInARowChance);

            if (offTwoCubesInARowProbality <= _offTwoCubesInARowChance)
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

                OffedCubesNumberstList.Add(cubesWhichWeCanOff[randomCubeIndex]);
            }
            else
            {
                offRandomCube();
            }

            OffedCubesNumberstList.Sort();

            _debugInfoSender.SendInfo("postGenerator", "OffTwoCubesInARowProbality", offTwoCubesInARowProbality);
            _debugInfoSender.SendInfo("postGenerator", "OffTwoCubesInARowChance", _offTwoCubesInARowChance);
        }
        else
        {
            int RandomRange = Random.Range(1, CubesCount);
            OffedCubesNumberstList.Add(RandomRange);

            _debugInfoSender.SendInfo("postGenerator", "OffTwoCubesInARowProbality", 0);
            _debugInfoSender.SendInfo("postGenerator", "OffTwoCubesInARowChance", 0);
        }

        for (int i = 0; i < CubesCount; i++)
        {
            if (OffedCubesNumberstList.Contains(i))
            {
                CubesCondition.Enqueue(false);
            }
            else
            {
                CubesCondition.Enqueue(true);
            }
        }

        _difficultCoef = _difficultCoef + AddDifficultCoefForGeneration;

        if (System.Math.Round(_difficultCoef, 4) >= 1)
        {
            ChangeDifficult();
        }

        return CubesCondition;
    }

    private void ChangeDifficult()
    {
        _difficultLevel++;
        _difficultCoef = 0;

        _minOffTwoCubesInARowChance = _minOffTwoCubesInARowChance - _subtractMinOffTwoCubesInARowChance;
        _maxOffTwoCubesInARowChance = _maxOffTwoCubesInARowChance - _subtractMaxOffTwoCubesInARowChance;

        if (_minOffTwoCubesInARowChance < _minOffTwoCubesInARowChance1)
        {
            _minOffTwoCubesInARowChance = _minOffTwoCubesInARowChance1;
        }

        if (_maxOffTwoCubesInARowChance < _minOffTwoCubesInARowChance2)
        {
            _maxOffTwoCubesInARowChance = _minOffTwoCubesInARowChance2;
        }

        if (_minOffedCubesCount > _minMinOffedCubesCount)
        {
            _minOffedCubesCount--;
        }

        if (_maxOffedCubesCount > _minMaxOffedCubesCount)
        {
            _maxOffedCubesCount--;
        }
    }

    public void reset()
    {
        _minOffedCubesCount = 5;
        _maxOffedCubesCount = 7;

        _difficultCoef = 0;
        _difficultLevel = 0;

        _minOffTwoCubesInARowChance = 100;
        _maxOffTwoCubesInARowChance = 100;
    }
}