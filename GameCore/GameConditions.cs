using UnityEngine;

public class GameConditions : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Mover _mover;
    [SerializeField] private PositionTracker _positionTracker;
    [SerializeField] private PostsController _postsController;
    [SerializeField] private SpecialAbility _specialAbility;

    public void Initialize()
    {
        _mover.Initialize();
        _positionTracker.Initialize();
        _postsController.Initialize();
        _specialAbility.Initialize();
    }

    public void start()
    {
        _character.start();
        _positionTracker.start();
        _postsController.start();
    }

    public void reset()
    {
        _mover.reset();
        _positionTracker.reset();
        _postsController.reset();
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