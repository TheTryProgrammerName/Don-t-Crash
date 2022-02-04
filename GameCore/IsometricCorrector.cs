using UnityEngine;
using System.Collections;

//Отвечает за правильное наложение персонажа на столбы
public class IsometricCorrector : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _characterSprite;
    [SerializeField] private SpriteRenderer[] _postCubesSprites;

    private int _lastShortingOrder;

    public bool isCharacterBeforePost {set; private get; }
    public bool lockChangeSortingOrder { set; private get; }

    public void updateShortingOrder(int upperCubeNumber)
    {
        int shortingOrder = _postCubesSprites[upperCubeNumber].sortingOrder - 1;
        _lastShortingOrder = shortingOrder;

        if (!isCharacterBeforePost)
        {  
            changeCharacterSortingOrder(shortingOrder);   
        }
    }

    public void changeCharacterSortingOrder(int SortingOrder)
    {
        if (!lockChangeSortingOrder)
        {
            _characterSprite.sortingOrder = SortingOrder;
        }
    }

    public void applyLastShoprtingOrder()
    {
        changeCharacterSortingOrder(_lastShortingOrder);
    }
}
