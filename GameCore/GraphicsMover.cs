using UnityEngine;
using System.Collections;

public class GraphicsMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _characterRB, _post1RB, _post2RB, _startLineRB, _shadowRB; //ѕолучаем координаты персонажа и взависимости от них двигаем тень

    public float GameSpeed { private get; set; }

    private bool isPause = true;
    public bool CharacterIsAlive { set; private get; }

    public int Speed = 240;

    private Vector2 Post1StartPosition = new Vector2(18.2f, 0.75f);
    private Vector2 Post2StartPosition = new Vector2(45.2f, 0.75f);
    private Vector2 StartLineStartPosition = new Vector2(-1, -11.6875f);
    private Vector2 ShadowStartPosition = new Vector2(-3.25f, -12.505f);
    private Vector2 VectorSpeed;

    public void start()
    {
        StartCoroutine(PostMove());

        StartCoroutine(TapToStartMove());

        StartCoroutine(ShadowMove());
    }

    public void reset()
    {
        StopAllCoroutines();

        _post1RB.transform.position = Post1StartPosition; //¬озвращаем на свои места
        _post2RB.transform.position = Post2StartPosition;

        _startLineRB.transform.position = StartLineStartPosition;

        _shadowRB.transform.position = ShadowStartPosition;
    }

    public void pause()
    {
        isPause = true;

        _post1RB.velocity = Vector2.zero;
        _post2RB.velocity = Vector2.zero;
        _startLineRB.velocity = Vector2.zero;
        _shadowRB.velocity = Vector2.zero;
    }

    public void unPause()
    {
        isPause = false;
    }

    private IEnumerator PostMove()
    {
        while (CharacterIsAlive)
        {
            if (!isPause)
            {
                VectorSpeed = -transform.right * Speed * GameSpeed * Time.fixedDeltaTime;

                _post1RB.velocity = VectorSpeed;
                _post2RB.velocity = VectorSpeed;
            }

            yield return new WaitForFixedUpdate();
        }

        yield break;
    }

    private IEnumerator TapToStartMove()
    {
        while (CharacterIsAlive)
        {
            if (!isPause)
            {
                _startLineRB.velocity = VectorSpeed;
            }

            yield return new WaitForFixedUpdate();
        }

        yield break;
    }

    private IEnumerator ShadowMove()
    {
        while (CharacterIsAlive)
        {
            if (!isPause)
            {
                _shadowRB.velocity = new Vector2(_characterRB.velocity.y, 0);
            }

            yield return new WaitForFixedUpdate();
        }

        yield break;
    }
}