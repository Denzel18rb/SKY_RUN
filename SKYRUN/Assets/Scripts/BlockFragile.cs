using UnityEngine;

public class BlockFragile : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Destroyer"))
            //return;

        //Vector2 closestPoint = other.ClosestPoint(transform.position);

        //if (closestPoint.x < transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
