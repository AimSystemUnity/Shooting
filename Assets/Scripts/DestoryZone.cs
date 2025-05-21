using UnityEngine;

public class DestoryZone : MonoBehaviour
{
    void Start()
    {
     
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // 만약에 부딪힌 오브젝트가 총알 아니면
        if(other.gameObject.layer != LayerMask.NameToLayer("Bullet"))        
        {
            // 나와 부딪힌 오브젝트를 파괴하자.
            Destroy(other.gameObject);
        } 
    }
}
