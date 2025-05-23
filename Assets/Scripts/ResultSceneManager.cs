using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultSceneManager : MonoBehaviour
{
    // 최고 점수 UI
    public TMP_Text bestScore;
    // 현재 점수 UI
    public TMP_Text currScore;
    // 다시하기 버튼 
    public Button btnRetry;

    void Start()
    {
        // 최고 점수 UI 갱신
        bestScore.SetText("최고 점수 : " + DataManager.instance.bestScore);
        // 현재 점수 UI 갱신
        currScore.SetText("현재 점수 : " + DataManager.instance.currScore);
    }

    void Update()
    {
        
    }

    public void OnClickRetry()
    {
        // MainScene 을 다시로드 하자.
        SceneManager.LoadScene("MainScene");
    }
}
