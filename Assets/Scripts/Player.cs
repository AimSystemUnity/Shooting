using UnityEngine;

// Ŭ���� �̸� : �빮�ڷ� ����
// �Լ� �̸� : �빮�ڷ� ����
// ���� : �ҹ��ڷ� ����

public class Player : MonoBehaviour
{
    // �̵� �ӷ�
    public float speed = 5.0f;

    void Start()
    {

    }

    void Update()
    {
        // ������� �Է� �޾ƿ���
        // a : -1, d : 1, ������ ������ 0
        float h = Input.GetAxis("Horizontal");
        // s : -1, w : 1, ������ ������ 0
        float v = Input.GetAxis("Vertical");        

        // �Է� ���� ������ �������� �ϴ� ������ ������.
        Vector3 dirH = Vector3.right * h;
        Vector3 dirV = Vector3.up * v;
        Vector3 dir = dirH + dirV;
        // dir�� ũ�⸦ 1�� ������ (����ȭ, Normalize)
        dir.Normalize();

        // �� �������� ��� �̵�����.
        // ���������� �̵��ϰ� �ʹ�.
        // P = P0 + vt
        transform.position += dir * speed * Time.deltaTime;

        CheckRange();
    }

    void CheckRange()
    {
        // ���࿡ viewport x ���� 0���� ������
        Vector3 viewportPoint = Camera.main.WorldToViewportPoint(transform.position + Vector3.left * 0.5f);
        if (viewportPoint.x < 0)
        {
            viewportPoint.x = 0;
            // ���� ��ġ x ���� viewport x �� 0 ���� 3D ��ǥ�� ��ȯ
            Vector3 pos = Camera.main.ViewportToWorldPoint(viewportPoint);
            transform.position = pos + Vector3.right * 0.5f;
        }

        viewportPoint = Camera.main.WorldToViewportPoint(transform.position + Vector3.right * 0.5f);
        if (viewportPoint.x >= 1)
        {
            viewportPoint.x = 1;
            Vector3 pos = Camera.main.ViewportToWorldPoint(viewportPoint);
            transform.position = pos + Vector3.left * 0.5f;
        }

        viewportPoint = Camera.main.WorldToViewportPoint(transform.position + Vector3.up * 0.5f);
        if (viewportPoint.y >= 1)
        {
            viewportPoint.y = 1;
            Vector3 pos = Camera.main.ViewportToWorldPoint(viewportPoint);
            transform.position = pos + Vector3.down * 0.5f;
        }

        viewportPoint = Camera.main.WorldToViewportPoint(transform.position + Vector3.down * 0.5f);
        if (viewportPoint.y < 0)
        {
            viewportPoint.y = 0;
            Vector3 pos = Camera.main.ViewportToWorldPoint(viewportPoint);
            transform.position = pos + Vector3.up * 0.5f;
        }

        // ���� ��ǥ�� �ػ� ��ǥ��� (�ػ� ����)
        //print(Camera.main.WorldToScreenPoint(transform.position));
        // ���� ��ǥ�� ī�޶� ��ǥ��� (0 ~ 1 �� ǥ��)
        //print(Camera.main.WorldToViewportPoint(transform.position));
    }
}
