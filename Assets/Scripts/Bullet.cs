using UnityEngine;

public class Bullet : MonoBehaviour
{
    //�Ѿ� �ӷ�
    public float speed = 10;
    void Start()
    {
        // �� �Ҹ��� ����!
        // AudioSource ������Ʈ ��������.
        AudioSource audio = GetComponent<AudioSource>();
        // ������ ������Ʈ���� Play �Լ� ����
        audio.Play();
    }

    void Update()
    {
        // ���� �ö󰡰� �ʹ�
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
