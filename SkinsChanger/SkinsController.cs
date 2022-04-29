using UnityEngine;

public class SkinsController : SwipeManager
{
    [SerializeField] private SkinsChanger _skinsChanger;

    protected override void SwipeUp()
    {
        _skinsChanger.NextColor();
    }

    protected override void SwipeDown()
    {
        _skinsChanger.LastColor();
    }

    protected override void SwipeRight()
    {
        _skinsChanger.NextSkin();
    }

    protected override void SwipeLeft()
    {
        _skinsChanger.LastSkin();
    }
}