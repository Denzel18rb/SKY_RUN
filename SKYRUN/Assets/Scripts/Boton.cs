using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boton : MonoBehaviour
{
    [Header("Nombre del cuarto a Cargar")]
    [Tooltip("Escribe el nombre exacto de la escena")]
    public string nombreCuarto = "";

    [Header("Referencia a Letras")]
    public Image letrasImage;
    public Sprite spriteNormal;
    public Sprite spritePresionado;

    [Header("Referencia a Frame")]
    public Image frameImage;
    public Sprite spriteNormalFrame;
    public Sprite spritePresionadoFrame;




    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip sonidoClick;

    private Button boton;

    void Start()
    {
        boton = GetComponent<Button>();

        if (boton != null)
            boton.onClick.AddListener(AlPresionar);
        else
            Debug.LogError("No se encontró Button en el objeto.");
    }

    void AlPresionar()
    {
        // Cambiar sprite SOLO de las letras
        if (letrasImage != null && spritePresionado != null)
            letrasImage.sprite = spritePresionado;

        // Cambiar sprite SOLO del frame
        if (frameImage != null && spritePresionadoFrame != null)
            frameImage.sprite = spritePresionadoFrame;

        // Reproducir sonido
        if (audioSource != null && sonidoClick != null)
            audioSource.PlayOneShot(sonidoClick);

        // Esperar antes de cambiar escena
        StartCoroutine(CargarConDelay(0.3f));
    }

    IEnumerator CargarConDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (string.IsNullOrEmpty(nombreCuarto))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else
            SceneManager.LoadScene(nombreCuarto);
    }
}
