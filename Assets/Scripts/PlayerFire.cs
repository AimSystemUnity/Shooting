using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 총알 Prefab
    public GameObject bulletPrefab;
    // 총구
    public GameObject firePos;
    public Transform firePos2;

    void Update()
    {
        // 마우스 왼쪽 버튼을 누르면
        if(Input.GetButtonDown("Fire1"))        
        {
            // 총알공장(Prefab)에서 총알을 하나 생성하자.
            GameObject bullet = Instantiate(bulletPrefab);
            // 생성된 총알을 총구에 위치시키자.
            bullet.transform.position = firePos.transform.position;

            GameObject bullet2 = Instantiate(bulletPrefab);
            bullet2.transform.position = firePos2.position;
        }
    }
}
