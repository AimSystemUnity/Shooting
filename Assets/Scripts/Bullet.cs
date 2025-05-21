using UnityEngine;

public class Bullet : MonoBehaviour
{
    //총알 속력
    public float speed = 10;

    void Update()
    {
        // 위로 올라가고 싶다
        transform.position += transform.up * speed * Time.deltaTime;
    }
     
    public void PlaySound()
    {
        // 총 소리를 내자!
        // AudioSource 컴포넌트 가져오자.
        AudioSource audio = GetComponent<AudioSource>();
        // 가져온 컴포넌트에서 Play 함수 실행
        audio.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        // 총알을 비활성화 
        gameObject.SetActive(false);
        // Player 를 찾자.
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            // 찾은 Player 에서 PlayerFire 컴포넌트를 가져오자.
            PlayerFire pf = player.GetComponent<PlayerFire>();
            // 가져온 컴포넌트의 bulletPool 에 총알을 추가.
            pf.bulletPool.Add(gameObject);
        }
    }
}
