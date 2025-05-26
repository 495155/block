using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject BlockPrefab; // 연결할 프리팹
    public int rows = 5;
    public int cols = 20;
    public float spacingX = 1.1f;
    public float spacingY = 0.6f;
    public Vector2 startPos = new Vector2(2f, 9f); // 좌상단 시작 위치

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Vector2 position = new Vector2(startPos.x + j * spacingX, startPos.y - i * spacingY);

                Instantiate(BlockPrefab, position, Quaternion.identity, transform);
            }
        }
    }
}
