using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    AudioManager audioManager;
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<GameManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("GameManager");
                    instance = go.AddComponent<GameManager>();
                    go.AddComponent<AudioManager>();
                    go.AddComponent<AudioSource>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        audioManager = GetComponent<AudioManager>();
        audioManager.PlayMainTheme();
    }
    public void WinGame()
    {
        Debug.Log("You win!");
        audioManager.PlayWinTheme();
    }
    public void LoseGame()
    {
        Debug.Log("You lose!");
        audioManager.PlayLoseTheme();
    }
    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
