using UnityEngine;

public class Enemy : MonoBehaviour
{
    // �̵� �ӷ�
    public float speed = 7;

    // Ÿ��
    public GameObject target;

    // �̵� ����
    Vector3 dir;

    void Start()
    {
        // 0 ~ 9 ���� ���� �����Ѱ� ����.
        int rand = Random.Range(0, 10);
        // ���࿡ �������� 3���� ������ (30%)
        if(rand < 4)
        {
            // ������ �Ʒ���!
            dir = Vector3.down;
        }
        // �׷��� ������
        else
        {
            // �÷��̾� (Ÿ��) �� ã��.
            target = GameObject.Find("Player");
            
            // ���࿡ �÷��̾ ���ٸ�
            if(target == null)
            {
                // ������ �Ʒ���!
                dir = Vector3.down;
            }
            else
            {
                // Ÿ���� ���ϴ� ������ ������. (Enemy ---> Player)
                dir = target.transform.position - transform.position;
                // dirũ�⸦ 1���Ѵ�.
                dir.Normalize();    
            }
        }
    }


    void Update()
    {
        // ���� �������� �̵��ϰ� �ʹ�.
        transform.position += dir * speed * Time.deltaTime;
    }


    // other : �ε��� ��ü�� ����
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("DestroyZone"))
        {

        }

        DestoryZone dz = other.GetComponent<DestoryZone>();
        if(dz == null)
        {

        }

        // ���࿡ �ε��� ��ü�� DestroyZone �� �ƴϸ�
        if(other.name.Contains("DestroyZone") == false)
        {
            // �ε��� ���ӿ�����Ʈ �ı�
            Destroy(other.gameObject);
        }
        // ���� �ı�
        Destroy(gameObject);        
    }
}
