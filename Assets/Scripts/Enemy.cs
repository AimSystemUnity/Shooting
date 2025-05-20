using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 이동 속력
    public float speed = 7;

    // 타겟
    public GameObject target;

    // 이동 방향
    Vector3 dir;

    // 폭발 효과 Prefab
    public GameObject exploPrefab;

    void Start()
    {
        // 0 ~ 9 사의 값을 랜덤한게 뽑자.
        int rand = Random.Range(0, 10);
        // 만약에 랜덤값이 3보다 작으면 (30%)
        if(rand < 4)
        {
            // 방향을 아래로!
            dir = Vector3.down;
        }
        // 그렇지 않으면
        else
        {
            // 플레이어 (타겟) 를 찾자.
            target = GameObject.Find("Player");
            
            // 만약에 플레이어가 없다면
            if(target == null)
            {
                // 방향을 아래로!
                dir = Vector3.down;
            }
            else
            {
                // 타겟을 향하는 방향을 구하자. (Enemy ---> Player)
                dir = target.transform.position - transform.position;
                // dir크기를 1로한다.
                dir.Normalize();    
            }
        }
    }


    void Update()
    {
        // 구한 방향으로 이동하고 싶다.
        transform.position += dir * speed * Time.deltaTime;
    }


    // other : 부딪힌 객체의 정보
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("DestroyZone"))
        {

        }

        DestoryZone dz = other.GetComponent<DestoryZone>();
        if(dz == null)
        {

        }

        // 만약에 부딪힌 물체가 DestroyZone 이 아니면
        if(other.name.Contains("DestroyZone") == false)
        {
            // 부딪힌 게임오브젝트 파괴
            Destroy(other.gameObject);

            // 폭발효과 Prefab 을 하나 복제하자.
            GameObject explo = Instantiate(exploPrefab);
            // 폭발 위치를 나의 위치한다.
            explo.transform.position = transform.position;
            // 만들어지 효과에서 ParticleSystem 컴포넌트 가져오자.
            ParticleSystem ps = explo.GetComponent<ParticleSystem>();
            // 가져온 컴포넌트의 Play 함수 실행
            ps.Play();
            // 만들어진 효과를 3초뒤에 파괴하자.
            Destroy(explo, 3);
        }
        // 나도 파괴
        Destroy(gameObject);        
    }
}
