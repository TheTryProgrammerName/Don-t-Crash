using UnityEngine;
using System.Collections.Generic;
using Unity.VectorGraphics;

public class ScoreTextDraver : Instantiator
{
    [SerializeField] private Sprite[] _numbersSprites; //Список спрайтов для отрисоввки 
    [SerializeField] private Vector2[] _numbersSizes; //Содержит размер каждого числа

    private List<SVGImage> _numbersImages;
    private List<RectTransform> _numbersRectTransforms;
    private List<int> _splitedScore;

    private Utilits _utilits;

    public void Initialize()
    {
        _utilits = new Utilits();
        _instantiateObjects = new List<GameObject>();
        _numbersImages = new List<SVGImage>();
        _numbersRectTransforms = new List<RectTransform>();
        _splitedScore = new List<int>();
    }

    public void DrawScoreText(int Score)
    {
        int ScoreLenght = Score.ToString().Length;

        if (ScoreLenght > _instantiateObjects.Count) //Если нужно нарисовать больше символов, чем у нас спрайтов на сцене
        {
            CreateObject(); //Добавляем новый спрайт
            _numbersImages.Add(_instantiateObjects[ScoreLenght - 1].GetComponent<SVGImage>());
            _numbersRectTransforms.Add(_instantiateObjects[ScoreLenght - 1].GetComponent<RectTransform>());
        }

        _utilits.intSplit(Score, _splitedScore);

        for (int i = 0; i < ScoreLenght; i++)
        {
            _numbersRectTransforms[i].sizeDelta = _numbersSizes[_splitedScore[i]];
            _numbersImages[i].sprite = _numbersSprites[_splitedScore[i]];
        }
    }

    public void reset()
    {
        int instantiateObjectsCount = _instantiateObjects.Count;

        for (int i = 0; i < instantiateObjectsCount - 1; i++) //Удаляем все лишние объекты
        {
            DestroyObject();
            _numbersImages.RemoveAt(0);
            _numbersRectTransforms.RemoveAt(0);
        }
    } 
}