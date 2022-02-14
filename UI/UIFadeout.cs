using UnityEngine;

//Затемняет элементы интерфейса при скролле, когда те доходят до границы экрана
public class UIFadeout : MonoBehaviour
{
    [SerializeField] private Color _defaultColor;

    [SerializeField] private GameObject[] _windowElements;

    //Вызывать действие всего этого при скролле
    //Считать следующим образом: брать spacing, текущуе расстояние до границы экрана
    //И когда значение увеличится на величину spacing - затемнять полностью

    public void OnScroll(Vector2 scrollDirection)
    {
        //Решаем, за положением которого элемента нужно следить
    }

    private void positionTrack()
    {
        //Следим и вызываем fadeout или fadein
        //Циклом вибираем в массив объекты с такой же Y-позицией до тех пор
        //Пока следующий объект не будет иметь другую Y-позицию (типо они в общем массиве по порядку идут)
        //И для каждог овызываем fadeout или fadein
    }

    private void fadeout()
    {

    }

    private void fadein()
    {

    }
}
