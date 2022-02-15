using UnityEngine;
using System.Collections;

public class GraphicsMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _characterRB, _post1RB, _post2RB, _startLineRB, _shadowRB; //ѕолучаем координаты персонажа и взависимости от них двигаем тень

    public float GameSpeed { private get; set; }

    public float GraphicsSpeed = 24f;

    private Vector2 Post1StartPosition = new Vector2(18.2f, 0.75f);
    private Vector2 Post2StartPosition = new Vector2(45.2f, 0.75f);
    private Vector2 StartLineStartPosition = new Vector2(-1, -11.6875f);
    private Vector2 ShadowStartPosition = new Vector2(-3.25f, -12.505f);
    private Vector2 VectorSpeed;

    public void reset()
    {
        _post1RB.transform.position = Post1StartPosition; //¬озвращаем на свои места
        _post2RB.transform.position = Post2StartPosition;

        _startLineRB.transform.position = StartLineStartPosition;

        _shadowRB.transform.position = ShadowStartPosition;
    }

    public void pause()
    {
        _post1RB.velocity = Vector2.zero;
        _post2RB.velocity = Vector2.zero;
        _startLineRB.velocity = Vector2.zero;
        _shadowRB.velocity = Vector2.zero;
    }

    public void Move()
    {
        MovePosts();
        MoveTapToStart();
        MoveShadow();
    }

    private void MovePosts()
    {
        VectorSpeed = GameSpeed * GraphicsSpeed * -transform.right * Time.fixedDeltaTime;

        _post1RB.velocity = VectorSpeed;
        _post2RB.velocity = VectorSpeed;
    }

    private void MoveTapToStart()
    {
        _startLineRB.velocity = VectorSpeed;
    }

    private void MoveShadow()
    {
        _shadowRB.velocity = new Vector2(_characterRB.velocity.y, 0);
    }
}