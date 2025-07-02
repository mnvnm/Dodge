using UnityEngine;
using UnityEngine.UI;

public class HudUI : MonoBehaviour
{
    [SerializeField] Text m_scoreText;
    [SerializeField] Text m_bestScoreText; // best score
    [SerializeField] Text m_gameOverText;

    [SerializeField] Button button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Init()
    {
        Show(GameMng.Inst.IsGameOver());
        m_scoreText.text = "TIME : 0";
        m_bestScoreText.text = "BEST SCORE : 0";
        m_gameOverText.gameObject.SetActive(false);
    }
    void Start()
    {
        button.onClick.AddListener(OnClick);
        button.Invoke("OnClick", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameMng.Inst.IsGameBegin() || GameMng.Inst.IsGameOver())
            return;
        m_scoreText.text = "TIME : " + GameMng.Inst.GetCurScore();
    }

    public void Show(bool isShow)
    {
        m_gameOverText.gameObject.SetActive(isShow);
        if (isShow)
        {
            m_bestScoreText.text = "Best Time: " + GameMng.Inst.GetBestScore();
        }
    }

    void OnClick()
    {
        Debug.Log("Restart Game");
    }
}
