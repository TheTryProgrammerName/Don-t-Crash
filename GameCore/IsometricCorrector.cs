using UnityEngine;

//Отвечает за правильное наложение персонажа на столбы
public class IsometricCorrector : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _characterSprite;

    [SerializeField] private SpriteRenderer[] _postCubesSprites;

    public bool isCharacterBeforePost {set; private get; }

    public void updateCharacterSortingOrder(int UpperCubeNumber)
    {
        if (!isCharacterBeforePost)
        {
            changeCharacterSortingOrder(_postCubesSprites[UpperCubeNumber].sortingOrder - 1);
        }
    }

    public void changeCharacterSortingOrder(int SortingOrder)
    {
        _characterSprite.sortingOrder = SortingOrder;
    }
}
