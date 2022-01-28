using UnityEngine;

public class SkinsController : SwipeManager
{
    [SerializeField] private SkinsChanger _skinsChanger;

    public override void SwipeUp()
    {
        _skinsChanger.NextColor();
    }

    public override void SwipeDown()
    {
        _skinsChanger.LastColor();
    }

    public override void SwipeRight()
    {
        _skinsChanger.NextSkin();
    }

    public override void SwipeLeft()
    {
        _skinsChanger.LastSkin();
    }
}