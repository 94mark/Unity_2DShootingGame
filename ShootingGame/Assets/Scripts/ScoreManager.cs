using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //현재 점수 UI
    public Text currentScoreUI;
    //현재 점수
    public int currentScore;
    //최고 점수 UI
    public Text bestScoreUI;
    //최고 점수
    public int bestScore;

    void Start()
    {
        //1. 최고 점수를 불러와 bestScore에 넣어주기
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        //2. 최고 점수를 화면에 표시하기
        bestScoreUI.text = "최고 점수 : " + bestScore;
    }
}
