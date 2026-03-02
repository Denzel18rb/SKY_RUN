using UnityEngine;

public class STR_move_terrain : MonoBehaviour
{
    public float speed = 20f;
    public float destroyX = -15f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x <= destroyX)
        {
            Destroy(gameObject);
        }
    }
}
