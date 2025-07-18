using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Bird Bird;
    public PipeSpawner PipeSpawner;
    public UIManager UiManager;

    private int score = 0;

    void Awake()
    {
        Instance = this;
        PipeSpawner.enabled = false;
    }

    void Start()
    {
        UiManager.ShowStart();
        Bird.gameObject.SetActive(false);
    }

    public void ResetGame()
    {
        Pipe[] pipes = FindObjectsByType<Pipe>(FindObjectsSortMode.None);
        foreach(Pipe pipe in pipes)
        {
            Destroy(pipe.gameObject);
        }
        score = 0;
        UiManager.UpdateScore(score);

        UiManager.ShowStart();
        PipeSpawner.enabled = false;
        Bird.ResetBird();
        Bird.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ReadyGame()
    {
        UiManager.HideStart();
        UiManager.ShowReady();
        Bird.ResetBird();
        Bird.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        score = 0;
        UiManager.HideReady();
        PipeSpawner.enabled = true;
        Bird.StartGame();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        UiManager.ShowGameOver();
    }

    public void IncreaseScore()
    {
        score++;
        UiManager.UpdateScore(0);
    }
}
