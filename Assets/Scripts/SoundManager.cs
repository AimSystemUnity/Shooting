using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // 이펙트 효과음 종류
    public enum ESoundType
    {
        EFT_BULLET,
        EFT_DESTROY,
    }

    // 배경음 종류
    public enum EBgmType
    {
        BGM_MAIN,
        BGM_RESULT
    }

    // 나를 가지는 변수
    public static SoundManager instance;

    // 효과음 들
    public AudioClip[] eftAudios;
    // 배경음 들
    public AudioClip[] bgmAudios;

    // 효과음 AudioSource
    public AudioSource eft;
    // 배경음 AudioSource
    public AudioSource bgm;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayEftSound(ESoundType type)
    {
        int eftIdx = (int)type;
        // 플레이!
        eft.PlayOneShot(eftAudios[eftIdx]);
    }
    public void PlayBgmSound(EBgmType type)
    {
        int bgmIdx = (int)type;
        // 플레이 할 AudioClip 설정
        bgm.clip = bgmAudios[bgmIdx];
        // 플레이!
        bgm.Play();
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
