using UnityEngine;

public class STR_move_terrain : MonoBehaviour
{
    public float speed = 16f;
    public float lifeTime = 10f;

    private Rigidbody2D rb2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject,lifeTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2D.linearVelocity = new Vector2(-speed, 0f);
    }
}
