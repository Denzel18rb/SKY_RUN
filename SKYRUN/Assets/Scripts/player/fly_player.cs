using UnityEngine;

public class fly_player : MonoBehaviour
{
    [SerializeField] private float upForce = 5f;
    [SerializeField] private float CooldownUp = 2f;

    private float cooldown_var;

    private Rigidbody2D rb2D;
    private Animator anim; //variable tipo Animator

    private bool Isfly;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); //Obtiene el Componente
    }

    void Update()
    {
        cooldown_var -= 1;

        if (Input.GetKeyDown(KeyCode.Space) && cooldown_var <= 0)
        {
            rb2D.AddForce(Vector2.up * upForce, ForceMode2D.Impulse);
            cooldown_var = CooldownUp;

            Isfly = true;
        }
        if (cooldown_var <= 0)
        {
            Isfly = false;
        }

        anim.SetBool("IsFly", Isfly);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //VACIO
        }
    }
}
