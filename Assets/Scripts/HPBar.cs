using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    // 최대 HP
    float maxHP = 100;
    // 현재 HP
    float currHP = 0;
    // HPBar 이미지
    Image imgHPBar;

    void Start()
    {
        // 현재 HP 를 최대 HP 로 설정
        currHP = maxHP;
        // imgHPBar 컴포넌트 가져오자.
        // GetComponent
        // GetComponentInChildren
        // GetComponentInParent
        // GetComponentsInChildren<Image>();
        Image[] images = GetComponentsInChildren<Image>();
        imgHPBar = images[1];
    }

    void Update()
    {
        
    }

    public float UpdateHP(float value)
    {
        // 현재 HP 를 value 만큼 더하자.
        currHP += value;
        // imgHPBar 의 fillAmount 값을 변경하자.        
        imgHPBar.fillAmount = currHP / maxHP;

        // 현재 HP 를 반환하자.
        return currHP;
    }
}
