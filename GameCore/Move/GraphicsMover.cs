using UnityEngine;

public class GraphicsMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _characterRB, _post1RB, _post2RB, _startLineRB; //ѕолучаем координаты персонажа и взависимости от них двигаем тень

    private Vector2 Post1StartPosition = new Vector2(18.2f, 0.75f);
    private Vector2 Post2StartPosition = new Vector2(45.2f, 0.75f);
    private Vector2 StartLineStartPosition = new Vector2(-1, -12.5f);
    private Vector2 VectorSpeed;

    public float GraphicsSpeed = 280f;

    public void reset()
    {
        _post1RB.transform.position = Post1StartPosition; //¬озвращаем на свои места
        _post2RB.transform.position = Post2StartPosition;

        _startLineRB.transform.position = StartLineStartPosition;
    }

    public void pause()
    {
        _post1RB.velocity = Vector2.zero;
        _post2RB.velocity = Vector2.zero;
        _startLineRB.velocity = Vector2.zero;
    }

    public void Move()
    {
        MovePosts();
        MoveTapToStart();
    }

    private void MovePosts()
    {
        VectorSpeed = GraphicsSpeed * -transform.right * Time.fixedDeltaTime;

        _post1RB.velocity = VectorSpeed;
        _post2RB.velocity = VectorSpeed;
    }

    private void MoveTapToStart()
    {
        _startLineRB.velocity = VectorSpeed;
    }
}