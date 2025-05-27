using UnityEngine;

public class Ball : MonoBehaviour
{
    GameManager GM;

    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 BallDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(0f, -1f).normalized; //시작 시 방향 설정
        BallDirection = rb.linearVelocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            float platformX = collision.transform.position.x;
            float ballX = transform.position.x;
            float offset = ballX - platformX;

            // 튕겨 나갈 X 방향 조절: offset이 크면 더 옆으로 튕김
            float bounceX = offset * 2f; // 숫자가 클수록 더 기울어짐

            BallDirection = (Vector2.Reflect(BallDirection, collision.contacts[0].normal) + new Vector2(bounceX, 0f)).normalized;
        }
        else
        {
            BallDirection = Vector2.Reflect(BallDirection, collision.contacts[0].normal).normalized; //방향 반전
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(BallDirection * Time.deltaTime * speed);
        if (transform.position.y < -16.5 || transform.position.x > 9.5 || transform.position.x < -9.5)
        {
            Destroy(gameObject);
        }
    }
}
