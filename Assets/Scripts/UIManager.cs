using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI ScoreText;

    public void DisplayScore(int score)
    {
        ScoreText.text = score.ToString();
    }
}
