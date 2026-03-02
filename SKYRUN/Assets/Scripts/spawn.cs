using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject[] prefabs;   // Lista de prefabs posibles
    public float timer = 3f;       // Tiempo entre spawns
    private float currentTime;

    void Start()
    {
        currentTime = timer;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            SpawnPrefab();
            currentTime = timer; // Reinicia el timer
        }
    }

    void SpawnPrefab()
    {
        // Elegir prefab aleatorio
        int randomIndex = Random.Range(0, prefabs.Length);

        // Instanciar en la posición del objeto
        Instantiate(prefabs[randomIndex], transform.position, Quaternion.identity);
    }
}
