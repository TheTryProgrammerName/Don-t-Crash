using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _characterRigidbody;

    private Vector2 _startPosition = new Vector2(-6, -11.255f);
    private Vector2 _direction;
    private Vector2 _vectorSpeed;

    public float GameSpeed { private get; set; }
    public float CharacterSpeed = 6f;

    public void reset()
    {
        _characterRigidbody.transform.position = _startPosition;
        _characterRigidbody.velocity = Vector2.zero;

        _direction = -transform.up;
    }

    public void pause()
    {
        _characterRigidbody.simulated = false;
    }

    public void unPause()
    {
        _characterRigidbody.simulated = true;
    }

    public void ChangeDirectionUp()
    {
        _direction = transform.up;
    }

    public void ChangeDirectionDown()
    {
        _direction = -transform.up;
    }

    public void Move()
    {
        _vectorSpeed = GameSpeed * CharacterSpeed * _direction * Time.fixedDeltaTime;
        _characterRigidbody.AddForce(_vectorSpeed);
    }
}
