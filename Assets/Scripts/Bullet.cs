using UnityEngine;

public class Bullet : MonoBehaviour
{
    //총알 속력
    public float speed = 10;
    void Start()
    {
        
    }

    void Update()
    {
        // 위로 올라가고 싶다
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

  
}
