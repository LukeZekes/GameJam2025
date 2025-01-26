using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip winTheme, loseTheme, mainTheme;
    AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayWinTheme() {
        if (winTheme == null) Debug.LogWarning("Win Theme not set in Audio Manager on GameManager");
        audioSource.clip = winTheme;
        audioSource.Play();
    }
    public void PlayLoseTheme() {
        if (loseTheme == null) Debug.LogWarning("Lose Theme not set in Audio Manager on GameManager");
        audioSource.clip = loseTheme;
        audioSource.Play();
    }
    public void PlayMainTheme() {
        if (mainTheme == null) Debug.LogWarning("Main Theme not set in Audio Manager on GameManager");
        audioSource.clip = mainTheme;
        audioSource.Play();
    }
}
