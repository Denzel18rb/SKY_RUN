using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boton : MonoBehaviour
{
    [Header("Acción del botón")]
    [Tooltip("Si está activado, el botón cerrará el juego")]
    public bool cerrarJuego = false;

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
        if (letrasImage != null && spritePresionado != null)
            letrasImage.sprite = spritePresionado;

        if (frameImage != null && spritePresionadoFrame != null)
            frameImage.sprite = spritePresionadoFrame;

        if (audioSource != null && sonidoClick != null)
            audioSource.PlayOneShot(sonidoClick);

        StartCoroutine(AccionConDelay(0.3f));
    }

    IEnumerator AccionConDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (cerrarJuego)
        {
            CerrarJuego();
        }
        else
        {
            if (string.IsNullOrEmpty(nombreCuarto))
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            else
                SceneManager.LoadScene(nombreCuarto);
        }
    }

    void CerrarJuego()
    {
        Debug.Log("Cerrando juego...");

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}