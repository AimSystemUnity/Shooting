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
        // ���� �ε��� ������Ʈ�� �ı�����.
        Destroy(other.gameObject);
    }
}
