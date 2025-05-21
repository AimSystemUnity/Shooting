
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // �Ѿ� Prefab
    public GameObject bulletPrefab;
    // �ѱ�
    public GameObject firePos;
    public Transform firePos2;  

    // �����ð�
    public float createTime;
    // ����ð�
    float currTime = 0;

    // �Ѿ��� ������ �ִ� ����Ʈ
    public List<GameObject> bulletPool = new List<GameObject>();
    // �ʱ� �Ѿ� ����
    public int initBulletCnt = 20;


    #region 360 �� ���� �߻� ����
    
    public Transform fire360;
    public int fireCnt = 4;
    // 360 �Ѿ��� �߻�ǰ� �ִ���
    bool isFire360 = false;
    // ���� �߻�� �Ѿ��� ����
    int fireBulletCnt;
    float createTime360 = 0.1f;
    float currTime360;

    #endregion



    private void Start()
    {
        // bulletPool �Ѿ� 20�� ���� ����
        for (int i = 0; i < initBulletCnt; i++)
        {            
            // �Ѿ��� ����
            GameObject bullet = Instantiate(bulletPrefab);
            // Pool �� ����
            bulletPool.Add(bullet);
            // �Ѿ��� ��Ȱ��
            bullet.SetActive(false);
        }
    }

    void Update()
    {
        // ���࿡ Ű���� 1��Ű�� ������
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            // 360 �Ѿ��� �߻� ���� ����!
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


        // ���콺 ���� ��ư�� ������        
        if(Input.GetButtonDown("Fire1"))        
        {
           // Fire();
        }

        // �ð��� �帣�� ����.
        currTime += Time.deltaTime;
        // ���࿡ ����ð��� �����ð����� Ŀ����
        if(currTime > createTime)
        {
            // �Ѿ� �߻�
            //Fire();
            // ����ð��� �ʱ�ȭ
            currTime = 0;
        }
    }

    void Fire360()
    {
        // 360 / fireCnt ȸ�� ����ŭ fire360 �� ȸ��
        float angle = 360.0f / fireCnt;
        fire360.Rotate(0, 0, -angle);
        // fire360 ���������� 1.5��ŭ ������ ��ġ�� ������.
        Vector3 pos = transform.position + fire360.up * 1.5f;
        // �Ѿ� �߻�
        MakeBullet(pos, fire360.up);

        // �߻�� �Ѿ� ������ ������Ű��.
        fireBulletCnt++;
        // ���࿡ �߻�� �Ѿ� ������ fireCnt �� ���ٸ�
        if(fireBulletCnt == fireCnt)
        {
            // 360�߻縦 ������.
            isFire360 = false;
            // �߻�� �Ѿ� ���� �ʱ�ȭ
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
        // ���࿡ bulletPool �� ������ ������
        if(bulletPool.Count == 0)
        {
            // �Ѿ� Prefab �� �Ѿ� �ϳ� �����.
            bullet = Instantiate(bulletPrefab);
        }
        else
        {
            // bulletPool ���� �Ѿ��� �ϳ� ��������.
            bullet = bulletPool[0];
            // bulletPool 0��° �Ѿ� ����
            bulletPool.RemoveAt(0);
        }

        // �Ѿ˰���(Prefab)���� �Ѿ��� �ϳ� ��������.
        //GameObject bullet = Instantiate(bulletPrefab);
        // ������ �Ѿ��� �ѱ��� ��ġ��Ű��.
        bullet.transform.position = pos;
        // �Ѿ��� �������� upDir �� ����
        bullet.transform.up = upDir;
        // �Ѿ��� Ȱ��ȭ
        bullet.SetActive(true);
        // Bullet ������Ʈ ��������. ������ ������Ʈ PlaySound �Լ�
        bullet.GetComponent<Bullet>().PlaySound();
    }
}
