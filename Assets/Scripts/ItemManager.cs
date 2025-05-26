using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public float speed = 1.0f;
    public GameObject ballPrefab;
    private Rigidbody2D rb;
    private Vector2 ItemDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(0f, -1f).normalized; //시작 시 방향 설정
        ItemDirection = rb.linearVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(ItemDirection * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Instantiate(ballPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
