using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // 이동 속력
    public float speed = 7;
    // 이동 방향
    Vector3 dir;
    // 나 없어질 때 효과
    public GameObject exploPrefab;

    void Start()
    {
        // Player 찾아오자.
        GameObject player = GameObject.Find("Player");
        // 만약에 player 가 없으면
        if(player == null)
        {
            // 나를 파괴하자.
            Destroy(gameObject);
        }
        else
        {
            // Player 를 향하는 방향을 구하자. (P.위치 - 나의위치)
            dir = player.transform.position - transform.position;
            dir.Normalize();
        }
    }

    void Update()
    {
        // dir 방향으로 이동하자.
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        // exploPrefab 생성하자.
        GameObject explo = Instantiate(exploPrefab);
        // 생성된 오브젝트를 나의 위치에 놓자.        
        explo.transform.position = transform.position;

        Destroy(gameObject);
    }
}
