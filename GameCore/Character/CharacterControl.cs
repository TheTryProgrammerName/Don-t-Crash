using UnityEngine;

public class CharacterControl : SwipeManager
{
    [SerializeField] private Character _character;

    public override void SwipeUp()
    {
        _character.MoveUp();
    }

    public override void SwipeDown()
    {
        _character.MoveDown();
    }

    public override void SwipeRight()
    {
        _character.FastFly();
    }
}