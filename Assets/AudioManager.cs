using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip winTheme, loseTheme, mainTheme;
    AudioSource audioSource, voiceAudioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        voiceAudioSource = transform.GetChild(0).GetComponent<AudioSource>();
    }

    public void PlayWinTheme() {
        if (winTheme == null) Debug.LogWarning("Win Theme not set in Audio Manager on GameManager");
        audioSource.Stop();
        audioSource.loop = false;
        audioSource.clip = winTheme;
        StartCoroutine(PlayVoiceWithDelay());
        audioSource.Play();
    }
    private IEnumerator PlayVoiceWithDelay()
        {
            yield return new WaitForSeconds(1f);
            voiceAudioSource.Play();
        }
    
    public void PlayLoseTheme() {
        if (loseTheme == null) Debug.LogWarning("Lose Theme not set in Audio Manager on GameManager");
        audioSource.Stop();
        audioSource.loop = false;
        audioSource.clip = loseTheme;
        audioSource.Play();
    }
    public void PlayMainTheme() {
        if (mainTheme == null) Debug.LogWarning("Main Theme not set in Audio Manager on GameManager");
        audioSource.Stop();
        audioSource.loop = true;
        audioSource.clip = mainTheme;
        audioSource.Play();
    }
    public void StopAll() {
        audioSource.Stop();
        voiceAudioSource.Stop();
    }
}
