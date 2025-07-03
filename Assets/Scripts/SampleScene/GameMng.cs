using UnityEngine;

public class GameMng : MonoBehaviour
{
    private static GameMng _Inst;

    public static GameMng Inst
    {
        get
        {
            if (_Inst == null)
            {
                _Inst = FindFirstObjectByType<GameMng>();
                if (_Inst == null)
                {
                    GameObject obj = new GameObject("GameMng");
                    _Inst = obj.AddComponent<GameMng>();
                }
            }
            return _Inst;
        }
    }

    bool isGameBegin = true;
    bool isGameOver = false;

    float bestScore = 0.0f;
    float currentScore = 0.0f;
    public GameUI gameUI;
    public HudUI hudUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Init()
    {
        currentScore = 0.0f;
        bestScore = PlayerPrefs.GetFloat("BestScore", 0.0f);
        gameUI.Init();
        hudUI.Init();
    }
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameBegin) currentScore += Time.deltaTime;
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartGame();
            }
        }
    }

    public void RestartGame()
    {
        isGameBegin = true;
        isGameOver = false;
        Init();
    }

    public void EndGame()
    {
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetFloat("BestScore", bestScore);
        }
        isGameBegin = false;
        isGameOver = true;

        hudUI.Show(isGameOver);
        gameUI.StopFire();
    }

    public bool IsGameBegin()
    {
        return isGameBegin;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public float GetBestScore()
    {
        return bestScore;
    }

    public float GetCurScore()
    {
        return currentScore;
    }
}