using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //���� ���� UI
    public Text currentScoreUI;
    //���� ����
    public int currentScore;
    //�ְ� ���� UI
    public Text bestScoreUI;
    //�ְ� ����
    public int bestScore;

    void Start()
    {
        //1. �ְ� ������ �ҷ��� bestScore�� �־��ֱ�
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        //2. �ְ� ������ ȭ�鿡 ǥ���ϱ�
        bestScoreUI.text = "�ְ� ���� : " + bestScore;
    }
}
