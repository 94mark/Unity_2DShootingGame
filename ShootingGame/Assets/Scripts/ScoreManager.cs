using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //���� ���� UI
    public Text currentScoreUI;
    //���� ����
    private int currentScore;
    //�ְ� ���� UI
    public Text bestScoreUI;
    //�ְ� ����
    private int bestScore;
    //�̱��� ��ü
    public static ScoreManager Instance = null;

    //�̱��� ��ü�� ���� ������ ������ �ڱ� �ڽ��� �Ҵ�
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        //1. �ְ� ������ �ҷ��� bestScore�� �־��ֱ�
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        //2. �ְ� ������ ȭ�鿡 ǥ���ϱ�
        bestScoreUI.text = "�ְ� ���� : " + bestScore;
    }

    //currentScore�� ���� �ְ� ȭ�鿡 ǥ��
    public void SetScore(int value)
    {
        //3. ScoreMananger Ŭ������ �Ӽ��� �� �Ҵ�
        currentScore++;
        //4. ȭ�鿡 ���� ���� ǥ���ϱ�
        currentScoreUI.text = "���� ���� : " + currentScore;

        //�ְ� ���� ǥ���ϱ�
        //1. ���� ������ �ְ� �������� ŭ 
        //-> ���� ���� ������ �ְ� ������ �ʰ��ߴٸ�
        if (currentScore > bestScore)
        {
            //2. �ְ� ������ ���Ž�Ų��
            bestScore = currentScore;
            //3. �ְ� ���� UI�� ǥ��
            bestScoreUI.text = "�ְ� ���� : " + bestScore;
            //��ǥ : �ְ� ������ ����
            PlayerPrefs.SetInt("Best Score", bestScore);
        }

    }
    //currentScore �� ��������
    public int GetScore()
    {
        return currentScore;
    }
}
