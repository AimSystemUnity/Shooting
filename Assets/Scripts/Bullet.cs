using UnityEngine;

public class Bullet : MonoBehaviour
{
    //�Ѿ� �ӷ�
    public float speed = 10;
    void Start()
    {
        
    }

    void Update()
    {
        // ���� �ö󰡰� �ʹ�
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

  
}
