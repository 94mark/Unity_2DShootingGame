using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //�ʿ� �Ӽ� : �̵� �ӵ�
    public float speed = 5;
    //������ ���� ������ ����� Start�� Update���� ���
    Vector3 dir;
    //���� ���� �ּ�(�ܺο��� ���� �־��ش�)
    public GameObject explosionFactory;

    void Start()
    {
        //Vector3 dir;
        //0���� 9���� 10���� �� �߿� �ϳ��� �������� �����´�
        int randValue = Random.Range(0, 10);
        //���� 3���� ������ �÷��̾� ����
        if(randValue < 3)
        {
            //�÷��̾ ã�� target���� �Ѵ�
            GameObject target = GameObject.Find("Player");
            //������ ���ϰ� �ʹ�. target - me
            dir = target.transform.position - transform.position;
            //������ ũ�⸦ 1�� �Ѵ�(���� ���� ����)
            dir.Normalize();
        }
        //�׷��� ������ �Ʒ� �������� ���Ѵ�
        else
        {
            dir = Vector3.down;
        }
    }
    void Update()
    {
        //1. ������ ���Ѵ�
        //Vector3 dir = Vector3.down;
        //2. �̵�
        transform.position += dir * speed * Time.deltaTime;
    }

    //���� ����
    private void OnCollisionEnter(Collision other)
    {
        //���ʹ̸� ���� ������ ���� ���� ǥ��
        //1. ������ ScroeManager ��ü ȣ��
        GameObject smObject = GameObject.Find("ScoreManager");
        //2. ScoreMananger ���� ������Ʈ ������
        ScoreManager sm = smObject.GetComponent<ScoreManager>();
        //3. ScoreMananger Ŭ������ �Ӽ��� �� �Ҵ�
        sm.currentScore++;
        //4. ȭ�鿡 ���� ���� ǥ���ϱ�
        sm.currentScoreUI.text = "���� ���� : " + sm.currentScore;

        //�ְ� ���� ǥ���ϱ�
        //1. ���� ������ �ְ� �������� ŭ 
        //-> ���� ���� ������ �ְ� ������ �ʰ��ߴٸ�
        if(sm.currentScore > sm.bestScore)
        {
            //2. �ְ� ������ ���Ž�Ų��
            sm.bestScore = sm.currentScore;
            //3. �ְ� ���� UI�� ǥ��
            sm.bestScoreUI.text = "�ְ� ���� : " + sm.bestScore;
        }

        //���� ȿ�� ���忡�� ���� ȿ�� ����
        GameObject explosion = Instantiate(explosionFactory);
        //���� ȿ�� ��ġ��Ű��
        explosion.transform.position = transform.position;

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
