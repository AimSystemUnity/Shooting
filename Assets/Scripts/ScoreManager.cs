using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // 현재 점수
    int currScore;
    // 최고 점수
    int bestScore;

    // 현재 점수 UI
    public TMP_Text txtCurrScore;
    // 최고 점수 UI
    public TMP_Text txtBestScore;

    void Start()
    {
        // 최고 점수 가져오자.
        bestScore = PlayerPrefs.GetInt("BEST_SCORE");
        // 최고 점수 UI 갱신하자.
        txtBestScore.SetText("최 고 : " + bestScore.ToString());
    }

    void Update()
    {
        
    }

    // 점수 증가시키는 함수
    public void AddScore(int addValue)
    {
        // 현재 점수를 addValue 만큼 증가시키자.
        currScore += addValue;
        // currScore 값을 UI 에 표현하자.
        txtCurrScore.SetText("점 수 : " +  currScore.ToString());

        // 만약에 현재 점수가 최고 점수보다 커지면
        if(currScore > bestScore)
        {
            // 최고 점수를 갱신하자.
            bestScore = currScore;
            // 최고 점수 UI 도 갱신하자.
            txtBestScore.SetText("최 고 : " + bestScore.ToString());
            // 최고 점수 저장
            PlayerPrefs.SetInt("BEST_SCORE", bestScore);
        }
    }
}
