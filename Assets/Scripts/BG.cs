using UnityEngine;

public class BG : MonoBehaviour
{
    // ��ũ�� �ӷ�
    public float speed = 1f;
    void Start()
    {
        
    }

    void Update()
    {
        // �Ʒ��� ��������.
        transform.position += Vector3.down * speed * Time.deltaTime;

        // ���࿡ ��ġy ���� -30 ���� ������
        if(transform.position.y < -30)
        {
            // ��ġ�� ���� 90 ��ŭ �̵���Ű��.
            transform.position += Vector3.up * 90;
        }
    }
}
