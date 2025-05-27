using UnityEngine;
using UnityEngine.Pool;

public class BlockSpawner : MonoBehaviour
{
    private static BlockSpawner blockSpawnerInstance = null;
    public static BlockSpawner BlockSpawnerInstance
    {
        get
        {
            if(blockSpawnerInstance == null)
            {
                return null;
            }
            return blockSpawnerInstance;
        }
       
    }
    public GameObject BlockPrefab; // 연결할 프리팹
    public int rows = 5;
    public int cols = 20;
    public float spacingX = 1.1f;
    public float spacingY = 0.6f;
    public Vector2 startPos = new Vector2(2f, 9f); // 좌상단 시작 위치
    public IObjectPool<GameObject> blockPooling { get; private set; }

    private void Awake()
    {
        if (blockSpawnerInstance == null)
        {
            blockSpawnerInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        blockPooling = new ObjectPool<GameObject>(
            createFunc: () =>
            {
                var tmp=Instantiate(BlockPrefab);
                tmp.SetActive(false);
                return tmp;
            },
            actionOnGet: block => block.SetActive(true),
            actionOnRelease: block => block.SetActive(false),
            defaultCapacity: rows*cols,
            maxSize: rows * cols*5
            );
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Vector2 position = new Vector2(startPos.x + j * spacingX, startPos.y - i * spacingY);
                var block = blockPooling.Get();
                block.transform.position = position;
                block.transform.parent = transform;
                //Instantiate(BlockPrefab, position, Quaternion.identity, transform);
            }
        }
    }
}
