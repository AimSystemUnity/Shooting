
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 총알 Prefab
    public GameObject bulletPrefab;
    // 총구
    public GameObject firePos;
    public Transform firePos2;  

    // 생성시간
    public float createTime;
    // 현재시간
    float currTime = 0;

    // 총알을 가지고 있는 리스트
    public List<GameObject> bulletPool = new List<GameObject>();
    // 초기 총알 갯수
    public int initBulletCnt = 20;


    #region 360 도 분할 발사 관련
    
    public Transform fire360;
    public int fireCnt = 4;
    // 360 총알이 발사되고 있는지
    bool isFire360 = false;
    // 현재 발사된 총알의 갯수
    int fireBulletCnt;
    float createTime360 = 0.1f;
    float currTime360;

    #endregion



    private void Start()
    {
        // bulletPool 총알 20개 만들어서 설정
        for (int i = 0; i < initBulletCnt; i++)
        {            
            // 총알을 생성
            GameObject bullet = Instantiate(bulletPrefab);
            // Pool 에 설정
            bulletPool.Add(bullet);
            // 총알을 비활성
            bullet.SetActive(false);
        }
    }

    void Update()
    {
        // 만약에 키보드 1번키를 누르면
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            // 360 총알이 발사 시작 하자!
            isFire360 = true;            
        }

        if(isFire360)
        {
            currTime360 += Time.deltaTime;
            if(currTime360 > createTime360)
            {
                Fire360();
                currTime360 = 0;
            }
        }


        // 마우스 왼쪽 버튼을 누르면        
        if(Input.GetButtonDown("Fire1"))        
        {
           // Fire();
        }

        // 시간을 흐르게 하자.
        currTime += Time.deltaTime;
        // 만약에 현재시간이 생성시간보다 커지면
        if(currTime > createTime)
        {
            // 총알 발사
            //Fire();
            // 현재시간을 초기화
            currTime = 0;
        }
    }

    void Fire360()
    {
        // 360 / fireCnt 회전 값만큼 fire360 을 회전
        float angle = 360.0f / fireCnt;
        fire360.Rotate(0, 0, -angle);
        // fire360 위방향으로 1.5만큼 떨어진 위치를 구하자.
        Vector3 pos = transform.position + fire360.up * 1.5f;
        // 총알 발사
        MakeBullet(pos, fire360.up);

        // 발사된 총알 갯수를 증가시키자.
        fireBulletCnt++;
        // 만약에 발사된 총알 갯수가 fireCnt 와 같다면
        if(fireBulletCnt == fireCnt)
        {
            // 360발사를 멈추자.
            isFire360 = false;
            // 발사된 총알 갯수 초기화
            fireBulletCnt = 0;
        }        
    }

    void Fire()
    {
        MakeBullet(firePos.transform.position, transform.up);
        MakeBullet(firePos2.position, transform.up);
    }

    void MakeBullet(Vector3 pos, Vector3 upDir)
    {
        GameObject bullet;
        // 만약에 bulletPool 에 갯수가 없으면
        if(bulletPool.Count == 0)
        {
            // 총알 Prefab 에 총알 하나 만든다.
            bullet = Instantiate(bulletPrefab);
        }
        else
        {
            // bulletPool 에서 총알을 하나 가져오자.
            bullet = bulletPool[0];
            // bulletPool 0번째 총알 제거
            bulletPool.RemoveAt(0);
        }

        // 총알공장(Prefab)에서 총알을 하나 생성하자.
        //GameObject bullet = Instantiate(bulletPrefab);
        // 생성된 총알을 총구에 위치시키자.
        bullet.transform.position = pos;
        // 총알의 윗방향을 upDir 로 설정
        bullet.transform.up = upDir;
        // 총알을 활성화
        bullet.SetActive(true);
        // Bullet 컴포넌트 가져오자. 가져온 컴포넌트 PlaySound 함수
        bullet.GetComponent<Bullet>().PlaySound();
    }
}
