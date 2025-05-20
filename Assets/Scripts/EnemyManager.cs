using Unity.VisualScripting;
using UnityEngine;


public class EnemyManager : MonoBehaviour
{
    // 생성시간
    public float createTime = 2;
    // 현재시간
    float currTime = 0;
    // Enemy Prefab
    public GameObject enemyPrefab;
    
    void Start()
    {
        
    }

    void Update()
    {
        // 현재시간을 흐르게
        currTime += Time.deltaTime;
        // 현재시간이 생성시간을 지나면
        if (currTime >= createTime)
        {
            // EnemyPrefab 에서 Enemy 를 생성한다.
            GameObject enemy = Instantiate(enemyPrefab);
            // 생성된 Enemy 의 위치를 나의 위치로 설정한다.
            enemy.transform.position = this.transform.position;
            // 현재시간 초기화
            currTime = 0;
        }        
    }
}
