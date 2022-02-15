using UnityEngine;

public class CharacterControl : SwipeManager
{
    [SerializeField] private CharacterMover _characterMover;
    [SerializeField] private Mover _mover;

    public override void SwipeUp()
    {
        _characterMover.ChangeDirectionUp();
    }

    public override void SwipeDown()
    {
        _characterMover.ChangeDirectionDown();
    }

    public override void SwipeRight()
    {
        _mover.FastFly();
    }
}