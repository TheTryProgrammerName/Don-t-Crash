using UnityEngine;
using System.Collections.Generic;
using Unity.VectorGraphics;
using UnityEngine.UI;

public class ScoreTextDraver : Instantiator
{
    [SerializeField] private Sprite[] _numbersSprites; //Список спрайтов для отрисоввки 
    [SerializeField] private Vector2[] _numbersSizes; //Содержит размер каждого числа
    [SerializeField] private List<Vector2> _defaultNumberSizes;

    private List<SVGImage> _numbersImages;
    private List<RectTransform> _numbersRectTransforms;
    private List<int> _splitedScore;

    private int _maxContentContainerSize = 1824; //Если контейнер цифр становится больше этого значения - уменьшаем размер цифр

    private float _defaultContainerSpacing;

    private Utilits _utilits;

    public void Initialize()
    {
        _utilits = new Utilits();
        _instantiateObjects = new List<GameObject>();
        _numbersImages = new List<SVGImage>();
        _numbersRectTransforms = new List<RectTransform>();
        _splitedScore = new List<int>();

        for (int i = 0; i < _numbersSizes.Length; i++)
        {
            _defaultNumberSizes.Add(_numbersSizes[i]);
        }

        _defaultContainerSpacing = _container.gameObject.GetComponent<HorizontalLayoutGroup>().spacing;
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

        if (_container.rect.width > _maxContentContainerSize) //Если ширина текста больольше, чем нам хотелось бы
        {
            resizeContentContainer(); //Пересчитываем размер текста и отступов
        }
    }

    private void resizeContentContainer()
    {
        //Считаем реальное пространство, занимакемое текстом вместе с отсупами (rect неправильносчитает)
        float trueContainerWidth = 0;

        HorizontalLayoutGroup containerLayoutGroup = _container.gameObject.GetComponent<HorizontalLayoutGroup>();
        float contentSpacing = containerLayoutGroup.spacing; //Размер отсупов

        for (int i = 0; i < _numbersRectTransforms.Count; i++)
        {
            trueContainerWidth += _numbersRectTransforms[i].sizeDelta.x;
            trueContainerWidth += contentSpacing;
        }

        trueContainerWidth -= contentSpacing;

        //Если ширина реально оказалась больше, чем нужно
        if (trueContainerWidth > _maxContentContainerSize)
        {
            //Посчитали сколько процентов текущая ширина составляет от желаемой
            float widthCoef = trueContainerWidth / _maxContentContainerSize;

            //Resize
            for (int i = 0; i < _numbersRectTransforms.Count; i++)
            {
                _numbersRectTransforms[i].sizeDelta = _numbersRectTransforms[i].sizeDelta / widthCoef;
            }

            containerLayoutGroup.spacing = containerLayoutGroup.spacing / widthCoef;

            for (int i = 0; i < _numbersSizes.Length; i++)
            {
                _numbersSizes[i] = _numbersSizes[i] / widthCoef;
            }
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

        _container.gameObject.GetComponent<HorizontalLayoutGroup>().spacing = _defaultContainerSpacing;

        for (int i = 0; i < _numbersSizes.Length; i++)
        {
            _numbersSizes[i] = _defaultNumberSizes[i];
        }
    } 
}