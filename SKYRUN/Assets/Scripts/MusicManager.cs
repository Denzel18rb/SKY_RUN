using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SceneMusicEntry
{
    public string sceneName;
    public AudioClip musicClip;
}

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    [Header("Scene Music Settings")]
    public List<SceneMusicEntry> sceneMusicList;

    [Header("Fade Settings")]
    public float fadeDuration = 1f;

    private AudioSource audioSource;
    private Dictionary<string, AudioClip> sceneMusicDict;
    private Coroutine fadeCoroutine;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();

        // Convertimos la lista en diccionario para búsqueda rápida
        sceneMusicDict = new Dictionary<string, AudioClip>();
        foreach (var entry in sceneMusicList)
        {
            if (!sceneMusicDict.ContainsKey(entry.sceneName))
                sceneMusicDict.Add(entry.sceneName, entry.musicClip);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (sceneMusicDict.TryGetValue(scene.name, out AudioClip clip))
        {
            PlayMusic(clip);
        }
    }

    public void PlayMusic(AudioClip newClip)
    {
        if (audioSource.clip == newClip) return;

        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(FadeMusic(newClip));
    }

    IEnumerator FadeMusic(AudioClip newClip)
    {
        // Fade out
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }

        audioSource.Stop();
        audioSource.clip = newClip;
        audioSource.Play();

        // Fade in
        while (audioSource.volume < startVolume)
        {
            audioSource.volume += startVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }

        audioSource.volume = startVolume;
    }
}