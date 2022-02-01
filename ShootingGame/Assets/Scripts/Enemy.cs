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

    void OnEnable()
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
        ScoreManager.Instance.Score++;
        //ScoreManager.Instance.SetScore(ScoreManager.Instance.GetScore() + 1);
        /*1. ������ ScroeManager ��ü ȣ��
        GameObject smObject = GameObject.Find("ScoreManager");
        //2. ScoreMananger ���� ������Ʈ ������
        ScoreManager sm = smObject.GetComponent<ScoreManager>();
        //3. ScoreManager�� Get/Set �Լ��� ����
        sm.SetScore(sm.GetScore() + 1);*/

        //���� ȿ�� ���忡�� ���� ȿ�� ����
        GameObject explosion = Instantiate(explosionFactory);
        //���� ȿ�� ��ġ��Ű��
        explosion.transform.position = transform.position;

        //���� �ε��� ��ü�� bullet�� ��� ��Ȱ��ȭ���� źâ�� �ٽ� ����
        //1. ���� �ε��� ��ü�� bullet�̶��
        if(other.gameObject.name.Contains("Bullet"))
        {
            //2. �ε��� ��ü�� ��Ȱ��ȭ
            other.gameObject.SetActive(false);

            //PlayerFire Ŭ���� ������
            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            //����Ʈ�� �Ѿ� ����
            player.bulletObjectPool.Add(other.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
        //Destroy�� ���ִ� ���, ��Ȱ��ȭ�� Ǯ�� �ڿ��� �ݳ�
        //Destroy(gameObject);
        gameObject.SetActive(false);

        //EnemyManager Ŭ���� ������
        GameObject emObject = GameObject.Find("EnemyManager");
        EnemyManager manager = emObject.GetComponent<EnemyManager>();
        //����Ʈ�� �Ѿ� ����
        manager.enemyObjectPool.Add(gameObject);
    }
}
