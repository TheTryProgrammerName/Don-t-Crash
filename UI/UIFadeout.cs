using UnityEngine;
using Unity.VectorGraphics;
using UnityEngine.UI;
using System.Collections.Generic;

//Затемняет элементы интерфейса при скролле, когда те доходят до границы экрана
public class UIFadeout : MonoBehaviour
{
    [SerializeField] private RectTransform _contentContainer;
    [SerializeField] private Color[] _colors;

    private Utilits _utilits;

    private List<GameObject> _content;
    private List<GameObject> _trackedElements;

    private float _contentSpacing;
    private float _contentHeigh;
    private float _elementBehindScreenPoint;

    private int _elementsCountInRow; //Сколько элементов в строке
    private int _lastSelectedElementIndex; //Номер последнего элемента, за которым сейчас следим
    private int _selectedRowIndex; //Номер строки, на которой расположены элементы, за которыми сейчас следим
    private int lastFadeoutNumber;

    private int[] _fadoutWhenPositionsAttitude;

    public void Initialize()
    {
        _utilits = new Utilits();
        _trackedElements = new List<GameObject>();

        _content = _utilits.GetChildrenList(_contentContainer);

        if (_contentContainer.GetComponent<VerticalLayoutGroup>() != null)
        {
            _contentSpacing = _contentContainer.GetComponent<VerticalLayoutGroup>().spacing;
            _elementsCountInRow = 1;
        }
        else
        {
            _contentSpacing = _contentContainer.GetComponent<GridLayoutGroup>().spacing.y;
            _elementsCountInRow = 3; //Считать реальное количество
        }

        _contentHeigh = _content[0].GetComponent<LayoutElement>().preferredHeight;
        _elementBehindScreenPoint = _contentHeigh + _contentSpacing;

        _lastSelectedElementIndex = -1;
        _selectedRowIndex = -1;

        _fadoutWhenPositionsAttitude = new int[5] { 5, 25, 45, 65, 85 };
    }

    public void Start() //Del
    {
        _trackedElements = new List<GameObject>();
        Enable();
    }

    public void Enable()
    {
        selectElements();
    }

    public void Disable()
    {
        StopAllCoroutines();
    }

    public void OnScroll(Vector2 scrollDirection)
    {
        //Совершенно не представляю, как назвать эту переменную. По сути это отношение текущей ползиции contentContainer'а к позиции, при которой строка для которой будет применён fadeout уйдёт за экран
        int positionsAttitude = (int)(_contentContainer.localPosition.y / (_elementBehindScreenPoint * (_selectedRowIndex + 1)) * 100);

        for (int i = 0; i < _fadoutWhenPositionsAttitude.Length; i++)
        {
            if (positionsAttitude == _fadoutWhenPositionsAttitude[i] && _fadoutWhenPositionsAttitude[i] != lastFadeoutNumber)
            {
                lastFadeoutNumber = _fadoutWhenPositionsAttitude[i];

                for (int b = 0; b < _trackedElements.Count; b++)
                {
                    fadeout(_trackedElements[b]);
                }
                
                return;
            }
        }

        if (positionsAttitude >= 100)
        {
            selectElements();
        }
    }

    private void selectElements() //Берём элементы, за которыми будем следить
    {
        _selectedRowIndex++;

        _trackedElements.Clear();

        for (int i = 0; i < _elementsCountInRow; i++)
        {
            _lastSelectedElementIndex++;
            _trackedElements.Add(_content[_lastSelectedElementIndex]);
        }
    }

    private void fadeout(GameObject element)
    {
        element.GetComponent<SVGImage>().color = _colors[_lastSelectedElementIndex];
    }

    private void fadein(GameObject element)
    {

    }
}
