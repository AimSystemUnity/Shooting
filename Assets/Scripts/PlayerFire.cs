using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // �Ѿ� Prefab
    public GameObject bulletPrefab;
    // �ѱ�
    public GameObject firePos;
    public Transform firePos2;

    void Update()
    {
        // ���콺 ���� ��ư�� ������
        if(Input.GetButtonDown("Fire1"))        
        {
            // �Ѿ˰���(Prefab)���� �Ѿ��� �ϳ� ��������.
            GameObject bullet = Instantiate(bulletPrefab);
            // ������ �Ѿ��� �ѱ��� ��ġ��Ű��.
            bullet.transform.position = firePos.transform.position;

            GameObject bullet2 = Instantiate(bulletPrefab);
            bullet2.transform.position = firePos2.position;
        }
    }
}
