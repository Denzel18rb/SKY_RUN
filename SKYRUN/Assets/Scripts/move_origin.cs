using UnityEngine;

public class move_origin : MonoBehaviour
{
    private float initialX;
    private Rigidbody2D rb2D;
    public float speed = 5f;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        initialX = rb2D.position.x;
    }

    void FixedUpdate()
    {
        float direction = Mathf.Sign(initialX - rb2D.position.x);
        float distance = Mathf.Abs(initialX - rb2D.position.x);

        if (distance > 0.05f)
        {
            rb2D.linearVelocity = new Vector2(direction * speed, rb2D.linearVelocity.y);
        }
        else
        {
            // Detener movimiento horizontal cuando llega
            rb2D.linearVelocity = new Vector2(0f, rb2D.linearVelocity.y);
        }
    }
}
