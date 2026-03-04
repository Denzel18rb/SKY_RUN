using UnityEngine;

public class jump_player : MonoBehaviour
{
    [SerializeField] private float upForce = 5f;
    [SerializeField] private int maxJumps = 1;

    private int jumpCount;

    private Rigidbody2D dinoRb;
    private Animator anim;

    private bool IsGrounded;

    void Start()
    {
        dinoRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            dinoRb.velocity = new Vector2(dinoRb.velocity.x, 0f); // Evita acumulación vertical
            dinoRb.AddForce(Vector2.up * upForce, ForceMode2D.Impulse);

            jumpCount++;
            IsGrounded = false;
        }

        anim.SetBool("IsJump", !IsGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
            return;

        foreach (ContactPoint2D contact in collision.contacts)
        {
            // Solo cuenta como suelo si la superficie está debajo del jugador
            if (contact.normal.y > 0.5f)
            {
                jumpCount = 0;
                IsGrounded = true;
                break;
            }
        }
    }
}