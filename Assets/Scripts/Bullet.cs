using UnityEngine;

public class Bullet : MonoBehaviour
{
    //총알 속력
    public float speed = 10;
    void Start()
    {
        // 총 소리를 내자!
        // AudioSource 컴포넌트 가져오자.
        AudioSource audio = GetComponent<AudioSource>();
        // 가져온 컴포넌트에서 Play 함수 실행
        audio.Play();
    }

    void Update()
    {
        // 위로 올라가고 싶다
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
