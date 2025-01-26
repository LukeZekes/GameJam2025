using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    AudioManager audioManager;
    public GameObject gameWinUI, gameLoseUI, winGamePanel, loseGamePanel;
    public bool isGameOver = false;
    private static GameManager instance;
    float buttonHeldTimer = 0f;
    float maxButtonHeldTime = 2f;
    PlayerMovement player;
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
        player = FindAnyObjectByType<PlayerMovement>();
    }

    void Update()
    {
        // if (isGameOver)
        // {
        //     if (Input.GetKey(KeyCode.R))
        //     {
        //         RestartGame();
        //     } else if (Input.GetKey(KeyCode.Escape)) {
        //         buttonHeldTimer += Time.deltaTime;
        //         if (buttonHeldTimer >= maxButtonHeldTime) {
        //             Debug.Log("Quit Game");
        //             Application.Quit();
        //         }
        //     } else {
        //         buttonHeldTimer = 0;
        //     }
        // }
    }
    public void WinGame()
    {
        if (!isGameOver)
        {
            Debug.Log("You win!");
            player.FreezeManager(true);
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
            player.FreezeManager(true);
            isGameOver = true;
            gameLoseUI.SetActive(true);
            loseGamePanel.SetActive(true);
            audioManager.PlayLoseTheme();
        }
    }
    public void RestartGame()
    {
        // audioManager.StopAll();
        // SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
    }
}
