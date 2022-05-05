using UnityEngine;

public class Control : SwipeManager
{
    [SerializeField] private Mover _mover;
    [SerializeField] private SpecialAbility _specialAbility;

    protected override void SwipeUp()
    {
        _mover.ChangeCharacterDirectionUp();
    }

    protected override void SwipeDown()
    {
        _mover.ChangeCharacterDirectionDown();
    }

    protected override void SwipeRight()
    {
        _specialAbility.Apply();
    }
}