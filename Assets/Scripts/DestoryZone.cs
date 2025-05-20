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
        // 나와 부딪힌 오브젝트를 파괴하자.
        Destroy(other.gameObject);
    }
}
