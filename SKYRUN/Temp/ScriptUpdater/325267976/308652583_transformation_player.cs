using UnityEngine;

public class transformation_player : MonoBehaviour
{
    public GameObject golem;
    public GameObject condor;

    public float CooldownTrasform_FINAL = 1;
    public float Cooldown;

    private bool IsGolem = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        golem.SetActive(true);
        condor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Cooldown -= 1 * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Z) && Cooldown <= 0)
        {
            transform_me();
            Cooldown = CooldownTrasform_FINAL;        
        }
    }

    void transform_me()
    {
        GameObject current = IsGolem ? golem : condor;
        GameObject next = IsGolem ? condor : golem;

        Rigidbody2D currentRB = current.GetComponent<Rigidbody2D>();
        Rigidbody2D nextRB = next.GetComponent<Rigidbody2D>();

        // Copiar estado
        Vector3 position = current.transform.position;
        float rotation = currentRB.rotation;
        Vector2 velocity = currentRB.linearVelocity;

        // Cambiar estado
        current.SetActive(false);
        next.SetActive(true);

        // Aplicar estado al nuevo
        next.transform.position = position;
        nextRB.rotation = rotation;
        nextRB.linearVelocity = velocity;

        IsGolem = !IsGolem;
    }
}
