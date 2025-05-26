using UnityEngine;

public class BreakableBlock : MonoBehaviour
{
    GameManager GM;

    public GameObject itemPrefab;
    public float dropChance = 0.3f; //아이템 드랍 확률

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            GM.GetPoint(1);
            TryDropItem();
            Destroy(gameObject);
        }
    }
    private void TryDropItem()
    {
        float rand = Random.value; // 0.0 ~ 1.0 사이 랜덤 숫자
        if (rand <= dropChance)
        {
            Instantiate(itemPrefab, transform.position, Quaternion.identity);
        }
    }
}
