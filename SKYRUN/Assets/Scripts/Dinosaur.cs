using UnityEngine;

public class Dinosaur : MonoBehaviour
{
    [SerializeField] private float upForce = 5f;
    [SerializeField] private int maxJumps = 1;

    private int jumpCount;
    private Rigidbody2D dinoRb;

    void Start()
    {
        dinoRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            dinoRb.AddForce(Vector2.up * upForce, ForceMode2D.Impulse);
            jumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }
}