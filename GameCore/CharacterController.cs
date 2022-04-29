using UnityEngine;

public class CharacterController : SwipeManager
{
    [SerializeField] private CharacterMover _characterMover;
    [SerializeField] private SpecialAbility _specialAbility;

    protected override void SwipeUp()
    {
        _characterMover.ChangeDirectionUp();
    }

    protected override void SwipeDown()
    {
        _characterMover.ChangeDirectionDown();
    }

    protected override void SwipeRight()
    {
        _specialAbility.Apply();
    }
}