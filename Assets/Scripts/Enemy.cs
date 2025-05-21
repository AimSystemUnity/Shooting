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

    // 외형들을 가지고 있는 배열
    public GameObject[] models;

    // 총알 Prefab
    public GameObject enemyBulletPrefab;
    // 총알 생성 시간
    float createTime;
    // 현재 시간
    float currTime;

    void Start()
    {
        // 총알 생성 시간을 설정 (0.5 ~ 1.5)
        createTime = Random.Range(0.5f, 1.5f);

        // 몇 번째 외형을 선택할지
        int randModel = Random.Range(0, models.Length);
        models[randModel].SetActive(true);

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
            if (target == null)
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
                // 나의 up 방향을 이동방향의 반대로 한다.
                //transform.up = -dir;
                transform.rotation = Quaternion.LookRotation(Vector3.forward, -dir);
            }
        }
    }


    void Update()
    {
        // 구한 방향으로 이동하고 싶다.
        transform.position += dir * speed * Time.deltaTime;

        // 시간을 흐르게 하자.
        currTime += Time.deltaTime;
        // 만약에 현재시간이 생성시간보다 커지면
        if(currTime > createTime)
        {
            // 총알 생성하자.
            GameObject bullet = Instantiate(enemyBulletPrefab);
            // 생성된 총알을 나의 위치에 놓자.
            bullet.transform.position = transform.position;
            // 현재 시간 초기화
            currTime = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
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
            // 만약에 부딪힌 물체가 총알이 아니면
            if(other.name.Contains("Bullet")== false)
            {
                // 부딪힌 게임오브젝트 파괴
                Destroy(other.gameObject);
            }

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

            // ScoreManager 게임오브젝트 찾자.
            GameObject go = GameObject.Find("ScoreManager");
            // 찾아온 게임오브젝트에서 ScoreManager 컴포넌트 가져오자.
            ScoreManager sm = go.GetComponent<ScoreManager>();
            // 가져온 컴포넌트의 AddScore 함수 실행
            sm.AddScore(10);
        }
        // 나도 파괴
        Destroy(gameObject);        
    }
}
