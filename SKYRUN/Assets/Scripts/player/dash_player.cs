using UnityEngine;
using System.Collections;

public class dash_player : MonoBehaviour
{
    [SerializeField] private float dashSpeed = 15f;
    [SerializeField] private float dashDuration = 1.5f;

    [SerializeField] private float CooldownDash = 1.2f;

    public bool IsDashing { get; private set; }

    private Rigidbody2D rb;
    private string originalTag;
    private float originalVelocityX;

    private float Cooldown;

    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalTag = gameObject.tag;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Cooldown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.X) && !IsDashing && Cooldown <= 0)
        {
            StartCoroutine(Dash());
            Cooldown = CooldownDash;
        }

        anim.SetBool("IsRoll", IsDashing);
    }

    IEnumerator Dash()
    {
        IsDashing = true;
        gameObject.tag = "Destroyer";

        // Guardamos velocidad horizontal original
        originalVelocityX = rb.velocity.x;

        float elapsed = 0f;
        

        while (elapsed < dashDuration)
        {
            // Forzamos velocidad horizontal, mantenemos vertical
            rb.velocity = new Vector2(dashSpeed, rb.velocity.y);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Restauramos velocidad horizontal
        rb.velocity = new Vector2(originalVelocityX, rb.velocity.y);

        gameObject.tag = originalTag;
        IsDashing = false;
    }
}
