using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //현재 점수 UI
    public Text currentScoreUI;
    //현재 점수
    private int currentScore;
    //최고 점수 UI
    public Text bestScoreUI;
    //최고 점수
    private int bestScore;
    //싱글턴 객체
    public static ScoreManager Instance = null;

    //싱글턴 객체에 값이 없으면 생성된 자기 자신을 할당
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        //1. 최고 점수를 불러와 bestScore에 넣어주기
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        //2. 최고 점수를 화면에 표시하기
        bestScoreUI.text = "최고 점수 : " + bestScore;
    }

    //currentScore에 값을 넣고 화면에 표시
    public void SetScore(int value)
    {
        //3. ScoreMananger 클래스의 속성에 값 할당
        currentScore++;
        //4. 화면에 현재 점수 표시하기
        currentScoreUI.text = "현재 점수 : " + currentScore;

        //최고 점수 표시하기
        //1. 현재 점수가 최고 점수보다 큼 
        //-> 만약 현재 점수가 최고 점수를 초과했다면
        if (currentScore > bestScore)
        {
            //2. 최고 점수를 갱신시킨다
            bestScore = currentScore;
            //3. 최고 점수 UI에 표시
            bestScoreUI.text = "최고 점수 : " + bestScore;
            //목표 : 최고 점수를 저장
            PlayerPrefs.SetInt("Best Score", bestScore);
        }

    }
    //currentScore 값 가져오기
    public int GetScore()
    {
        return currentScore;
    }
}
