using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    AudioManager audioManager;
    public GameObject gameWinUI, gameLoseUI, winGamePanel, loseGamePanel;
    public bool isGameOver = false;
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
        gameWinUI.SetActive(false);
        gameLoseUI.SetActive(false);
        winGamePanel.SetActive(false);
        loseGamePanel.SetActive(false);
        isGameOver = false;
    }
    public void WinGame()
    {
        if (!isGameOver)
        {
            Debug.Log("You win!");
            isGameOver = true;
            gameWinUI.SetActive(true);
            winGamePanel.SetActive(true);
            audioManager.PlayWinTheme();
        }
    }
    public void LoseGame()
    {
        if (!isGameOver)
        {
            Debug.Log("You lose!");
            isGameOver = true;
            gameLoseUI.SetActive(true);
            loseGamePanel.SetActive(true);
            audioManager.PlayLoseTheme();
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
