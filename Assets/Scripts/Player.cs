using UnityEngine;
using UnityEngine.SceneManagement;

// 클래스 이름 : 대문자로 시작
// 함수 이름 : 대문자로 시작
// 변수 : 소문자로 시작

public class Player : MonoBehaviour
{
    // 이동 속력
    public float speed = 5.0f;


    void Start()
    {
    }

    void Update()
    {
        // 사용자의 입력 받아오자
        // a : -1, d : 1, 누르지 않으면 0
        float h = Input.GetAxis("Horizontal");
        // s : -1, w : 1, 누르지 않으면 0
        float v = Input.GetAxis("Vertical");        

        // 입력 받은 값으로 움직여야 하는 방향을 구하자.
        Vector3 dirH = Vector3.right * h;
        Vector3 dirV = Vector3.up * v;
        Vector3 dir = dirH + dirV;
        // dir의 크기를 1로 만들자 (정규화, Normalize)
        dir.Normalize();

        // 그 방향으로 계속 이동하자.
        // 오른쪽으로 이동하고 싶다.
        // P = P0 + vt
        transform.position += dir * speed * Time.deltaTime;

        CheckRange();
    }

    // HPBar UI
    public HPBar hpBar;

    private void OnTriggerEnter(Collider other)
    {
        // 부딪힌 오브젝트가 Enemy 라면
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            // HPBar 의 UpdateHP 를 호출
            float currHP = hpBar.UpdateHP(-15);
            // 만약에 hp 0 보다 같거나 작으면
            if(currHP <= 0)
            {
                // 결과 Scene 으로 전환하자.
                SceneManager.LoadScene("ResultScene");
            }
        }
    }

    void CheckRange()
    {
        // 만약에 viewport x 값이 0보다 작으면
        Vector3 viewportPoint = Camera.main.WorldToViewportPoint(transform.position + Vector3.left * 0.5f);
        if (viewportPoint.x < 0)
        {
            viewportPoint.x = 0;
            // 나의 위치 x 값을 viewport x 의 0 값을 3D 좌표로 변환
            Vector3 pos = Camera.main.ViewportToWorldPoint(viewportPoint);
            transform.position = pos + Vector3.right * 0.5f;
        }

        viewportPoint = Camera.main.WorldToViewportPoint(transform.position + Vector3.right * 0.5f);
        if (viewportPoint.x >= 1)
        {
            viewportPoint.x = 1;
            Vector3 pos = Camera.main.ViewportToWorldPoint(viewportPoint);
            transform.position = pos + Vector3.left * 0.5f;
        }

        viewportPoint = Camera.main.WorldToViewportPoint(transform.position + Vector3.up * 0.5f);
        if (viewportPoint.y >= 1)
        {
            viewportPoint.y = 1;
            Vector3 pos = Camera.main.ViewportToWorldPoint(viewportPoint);
            transform.position = pos + Vector3.down * 0.5f;
        }

        viewportPoint = Camera.main.WorldToViewportPoint(transform.position + Vector3.down * 0.5f);
        if (viewportPoint.y < 0)
        {
            viewportPoint.y = 0;
            Vector3 pos = Camera.main.ViewportToWorldPoint(viewportPoint);
            transform.position = pos + Vector3.up * 0.5f;
        }

        // 나의 좌표를 해상도 좌표계로 (해상도 범위)
        //print(Camera.main.WorldToScreenPoint(transform.position));
        // 나의 좌표를 카메라 좌표계로 (0 ~ 1 로 표현)
        //print(Camera.main.WorldToViewportPoint(transform.position));
    }
}
