using UnityEngine;

public class move_origin : MonoBehaviour
{
    [Header("Referencia opcional")]
    public GameObject referenceObject; // Objeto cuyo origen queremos usar

    private float initialX;
    private Rigidbody2D rb2D;

    public float speed = 5f;

    private dash_player dash;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        dash = GetComponent<dash_player>();

        // Si hay objeto de referencia, usamos su posición inicial
        if (referenceObject != null)
        {
            initialX = referenceObject.transform.position.x;
        }
        else
        {
            // Si no, usamos nuestra propia posición
            initialX = rb2D.position.x;
        }
    }

    void FixedUpdate()
    {
            if (dash != null && dash.IsDashing)
            {
                return;
            }

            float direction = Mathf.Sign(initialX - rb2D.position.x);
            float distance = Mathf.Abs(initialX - rb2D.position.x);

            if (distance > 0.05f)
            {
                rb2D.velocity = new Vector2(direction * speed, rb2D.velocity.y);
            }
            else
            {
                rb2D.velocity = new Vector2(0f, rb2D.velocity.y);
            }
    }
}