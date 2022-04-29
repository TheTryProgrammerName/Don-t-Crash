using UnityEngine;

public class GraphicsMover : MonoBehaviour
{
    [SerializeField] private ObjectsPool _postsPool;
    [SerializeField] private Rigidbody2D _startLineRB;

    private Rigidbody2D[] _postsRigidbody;
    private Transform[] _postsTransform;

    private Vector2[] _postsStartPositions =
    {
        new Vector2(18.2f, 0.75f),
        new Vector2(45.2f, 0.75f) 
    };

    private Vector2 _startLineStartPosition = new Vector2(-1, -12.5f);
    private Vector2 _vectorSpeed;

    public float GraphicsSpeed = 280f;

    public void Initialize()
    {
        _postsRigidbody = new Rigidbody2D[_postsPool.ObjectsCount];
        _postsTransform = new Transform[_postsPool.ObjectsCount];

        for (int i = 0; i < _postsPool.ObjectsCount; i++)
        {
            _postsRigidbody[i] = _postsPool.Objects[i].GetComponent<Rigidbody2D>();
            _postsTransform[i] = _postsPool.Objects[i].GetComponent<Transform>();
        }
    }

    public void reset()
    {
        for (int i = 0; i < _postsPool.ObjectsCount; i++)
        {
            _postsTransform[i].position = _postsStartPositions[i];
        }

        _startLineRB.transform.position = _startLineStartPosition;
    }

    public void pause()
    {
        for (int i = 0; i < _postsPool.ObjectsCount; i++)
        {
            _postsRigidbody[i].velocity = Vector2.zero;
        }

        _startLineRB.velocity = Vector2.zero;
    }

    public void Move()
    {
        MovePosts();
        MoveTapToStart();
    }

    private void MovePosts()
    {
        _vectorSpeed = GraphicsSpeed * -transform.right * Time.fixedDeltaTime;

        for (int i = 0; i < _postsPool.ObjectsCount; i++)
        {
            _postsRigidbody[i].velocity = _vectorSpeed;
        }
    }

    private void MoveTapToStart()
    {
        _startLineRB.velocity = _vectorSpeed;
    }
}