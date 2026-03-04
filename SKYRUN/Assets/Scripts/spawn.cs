using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject[] prefabs;
    public float spawnCooldown = 0.1f;

    private float cooldownTimer;
    private int groundContacts = 0;

    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (groundContacts == 0 && cooldownTimer <= 0f)
        {
            SpawnPrefab();
            cooldownTimer = spawnCooldown;
        }
    }

    void SpawnPrefab()
    {
        int randomIndex = Random.Range(0, prefabs.Length);

        Instantiate(
            prefabs[randomIndex],
            transform.position,
            Quaternion.identity
        );
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            groundContacts++;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            groundContacts--;

            if (groundContacts < 0)
                groundContacts = 0;
        }
    }
}
