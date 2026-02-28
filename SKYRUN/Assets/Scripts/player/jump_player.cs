using UnityEngine;

public class jump_player : MonoBehaviour
{
    [SerializeField] private float upForce = 5f;
    [SerializeField] private int maxJumps = 1;

    private int jumpCount;

    private Rigidbody2D dinoRb;
    private Animator anim; //variable tipo Animator

    private bool IsGrounded; //Para comprobar si choca con el suelo, para animacion.

    void Start()
    {
        dinoRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); //Obtiene el Componente
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            dinoRb.AddForce(Vector2.up * upForce, ForceMode2D.Impulse);
            jumpCount++;
            IsGrounded = false;
        }

        anim.SetBool("IsJump", !IsGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            IsGrounded = true;
        }
    }
}
