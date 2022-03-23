using UnityEngine;
using Unity.VectorGraphics;
using UnityEngine.UI;
using System.Collections.Generic;

//��������� �������� ���������� ��� �������, ����� �� ������� �� ������� ������
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

    private int _elementsCountInRow; //������� ��������� � ������
    private int _lastSelectedElementIndex; //����� ���������� ��������, �� ������� ������ ������
    private int _selectedRowIndex; //����� ������, �� ������� ����������� ��������, �� �������� ������ ������
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
            _elementsCountInRow = 3; //������� �������� ����������
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
        //���������� �� �����������, ��� ������� ��� ����������. �� ���� ��� ��������� ������� �������� contentContainer'� � �������, ��� ������� ������ ��� ������� ����� ������� fadeout ���� �� �����
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

    private void selectElements() //���� ��������, �� �������� ����� �������
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
