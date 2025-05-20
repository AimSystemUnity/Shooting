using UnityEngine;

public class BG : MonoBehaviour
{
    // 스크롤 속력
    public float speed = 1f;
    void Start()
    {
        
    }

    void Update()
    {
        // 아래로 움직이자.
        transform.position += Vector3.down * speed * Time.deltaTime;

        // 만약에 위치y 값이 -30 보다 작으면
        if(transform.position.y < -30)
        {
            // 위치를 위로 90 만큼 이동시키자.
            transform.position += Vector3.up * 90;
        }
    }
}
