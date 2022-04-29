using UnityEngine;

public class GameConditions : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Mover _mover;
    [SerializeField] private PositionTracker _positionTracker;
    [SerializeField] private PostController _postController;
    [SerializeField] private SpecialAbility _specialAbility;

    public void Initialize()
    {
        _mover.Initialize();
        _positionTracker.Initialize();
        _postController.Initialize();
        _specialAbility.Initialize();
    }

    public void start()
    {
        _character.start();
        _positionTracker.start();
        _postController.start();
    }

    public void reset()
    {
        _mover.reset();
        _positionTracker.reset();
        _postController.reset();
        _specialAbility.reset();
    }

    public void pause()
    {
        _mover.pause();
        _specialAbility.pause();
    }

    public void unPause()
    {
        _mover.unPause();
        _specialAbility.unPause();
    }
}