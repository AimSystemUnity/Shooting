using Unity.VisualScripting;
using UnityEngine;


public class EnemyManager : MonoBehaviour
{
    // �����ð�
    public float createTime = 2;
    // ����ð�
    float currTime = 0;
    // Enemy Prefab
    public GameObject enemyPrefab;
    
    void Start()
    {
        
    }

    void Update()
    {
        // ����ð��� �帣��
        currTime += Time.deltaTime;
        // ����ð��� �����ð��� ������
        if (currTime >= createTime)
        {
            // EnemyPrefab ���� Enemy �� �����Ѵ�.
            GameObject enemy = Instantiate(enemyPrefab);
            // ������ Enemy �� ��ġ�� ���� ��ġ�� �����Ѵ�.
            enemy.transform.position = this.transform.position;
            // ����ð� �ʱ�ȭ
            currTime = 0;
        }        
    }
}
