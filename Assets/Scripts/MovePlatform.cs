using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public float screenWidthInUnits; // 게임 화면의 너비 (단위 기준)
    public float minX;  // 왼쪽 경계
    public float maxX; // 오른쪽 경계
    
    // Update is called once per frame
    void Update()
    {
        // 마우스 위치(0~1) → 게임 월드 좌표
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;

        // x값을 제한된 범위 안으로 고정
        float clampedX = Mathf.Clamp(mousePosInUnits, minX, maxX);

        // 위치 갱신 (y와 z는 고정)
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
