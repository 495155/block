using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager MyUIManager;

    public int NowScore = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MyUIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        MyUIManager.DisplayScore(NowScore);
    }

    public void GetPoint(int point)
    {
        NowScore += point;
        MyUIManager.DisplayScore(NowScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
