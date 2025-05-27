using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UIManager MyUIManager;

    public GameObject GameOverPanel;
    public TextMeshProUGUI OverMessage;

    public int NowScore = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MyUIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        MyUIManager.DisplayScore(NowScore);
    }

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Ball").Length  == 0)
        {
            ShowMessage("Game Over");
        }

        if (GameObject.FindGameObjectsWithTag("Block").Length == 0)
        {
            ShowMessage("You Win!");
        }
    }

    public void GetPoint(int point)
    {
        NowScore += point;
        MyUIManager.DisplayScore(NowScore);
    }

    void ShowMessage(string message)
    {
        if (GameOverPanel != null && !GameOverPanel.activeSelf)
        {
            GameOverPanel.SetActive(true);
            OverMessage.text = message;
        }

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
