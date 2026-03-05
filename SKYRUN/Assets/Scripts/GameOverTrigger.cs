using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTrigger : MonoBehaviour
{
    public string nombreCuarto = "";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (string.IsNullOrEmpty(nombreCuarto))
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            else
                SceneManager.LoadScene(nombreCuarto);
        }
    }
}