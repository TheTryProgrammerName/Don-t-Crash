using UnityEngine;
using System;
using System.Collections.Generic;

public class ScoreTextDraver : MonoBehaviour
{
    [SerializeField] private Sprite[] _spriteNumbers; //������ �������� ��� ����������
    [SerializeField] private SpriteGroup[] _spriteGroup; //��������������� � ������� ����� ������������ ������ �������
    [SerializeField] private GameObject[] _numbersGroup;

    private int _numbersGroupIndex;

    private Utilits _utilits = new Utilits();

    public void DrawScoreText(int Score)
    {
        if (Score < 10001)
        {
            int ScoreLenght = Score.ToString().Length - 1;

            if (ScoreLenght > _numbersGroupIndex || ScoreLenght < _numbersGroupIndex) //���� ����� �������� ������ ��� ������, ��� ������������ ������� ������
            {
                SelectNumbersGroup(ScoreLenght); //�������� ����������
            }

            for (int i = 0; i < _numbersGroupIndex + 1; i++) //������������� ������ �������
            {
                SpriteRenderer[] Sprites = _spriteGroup[_numbersGroupIndex].Sprites;
                Sprites[i].sprite = GetSprite(i, Score);
            }
        }
        else
        {
            //�������� ������� � ���������
        }
    }

    private Sprite GetSprite(int TryNumber, int Score)
    {
        List<int> SplitScore = _utilits.intSplit(Score);

        if (_numbersGroupIndex < 4)
        {
            int DrawingSpriteNumber = SplitScore[TryNumber];
            return _spriteNumbers[DrawingSpriteNumber];
        }
        else
        {
            return _spriteNumbers[10];
        }
    }

    private void SelectNumbersGroup(int index)
    {
        _numbersGroupIndex = index;

        for (int i = 0; i < _numbersGroup.Length; i++)
        {
            if (i != index)
            {
                _numbersGroup[i].gameObject.SetActive(false);
            }
        }

        _numbersGroup[index].gameObject.SetActive(true);
    }

    public void reset()
    {
        DrawScoreText(0);
    } 

    [Serializable]
    public class SpriteGroup
    {
        public string Name;
        public SpriteRenderer[] Sprites;
    }
}