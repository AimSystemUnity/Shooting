using UnityEngine;

public class DataManager : MonoBehaviour
{
    // 나를 담을 변수
    public static DataManager instance;

    // 현재 점수
    public float currScore;
    // 최고 점수
    public float bestScore;

    private void Awake()
    {
        // 만약에 instance 값이 없다면
        if(instance == null)
        {
            // 나를 instance 에 담자.
            instance = this;
            // 나의 게임브젝트가 파괴되 않게 하자.
            DontDestroyOnLoad(gameObject);
        }
        // 그렇지 않으면
        else
        {
            // 나의 게임오브젝트를 파괴하자.
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
