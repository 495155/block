using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public float screenWidthInUnits; // ���� ȭ���� �ʺ� (���� ����)
    public float minX;  // ���� ���
    public float maxX; // ������ ���
    
    // Update is called once per frame
    void Update()
    {
        // ���콺 ��ġ(0~1) �� ���� ���� ��ǥ
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;

        // x���� ���ѵ� ���� ������ ����
        float clampedX = Mathf.Clamp(mousePosInUnits, minX, maxX);

        // ��ġ ���� (y�� z�� ����)
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
