using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float currentTime; //���� �ð�
    public float createTime = 1; //���� �ð�
    public GameObject enemyFactory; //�� ����
    public float minTime = 0.5f; //�ּ� �ð�
    public float maxTime = 1.5f; //�ִ� �ð�

    public int poolSize = 10; //������Ʈ Ǯ ũ��
    //GameObject[] enemyObjectPool; //������Ʈ Ǯ �迭
    public List<GameObject> enemyObjectPool; //������Ʈ Ǯ �迭
    public Transform[] spawnPoints; //SpawnPoints��

    void Start()
    {
        //�¾ �� ���� ���� �ð��� ����
        createTime = Random.Range(minTime, maxTime);

        //������Ʈ Ǯ�� ���ʹ̵��� ���� �� �ִ� ũ��� ������ش�
        //enemyObjectPool = new GameObject[poolSize];
        enemyObjectPool = new List<GameObject>();

        //������Ʈ Ǯ�� ���� ���ʹ� ������ŭ �ݺ�
        for (int i = 0; i < poolSize; i++)
        {
            //���ʹ� ���忡�� ���ʹ� ����
            GameObject enemy = Instantiate(enemyFactory);
            //���ʹ̸� ������Ʈ Ǯ�� �ִ´�
            //enemyObjectPool[i] = enemy;
            enemyObjectPool.Add(enemy);
            //��Ȱ��ȭ
            enemy.SetActive(false);
        }
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        //1. ���� �ð��� �Ǿ����ϱ�
        if(currentTime > createTime)
        {
            /*2. ���ʹ� Ǯ �ȿ� �ִ� ���ʹ� �߿���
            for(int i = 0; i < poolSize; i++)
            {
                //3. ��Ȱ��ȭ �� ���ʹ̸�
                //���� ���ʹ̰� ��Ȱ��ȭ �Ǿ��ٸ�
                GameObject enemy = enemyObjectPool[i];
                if(enemy.activeSelf == false)
                {
                    //���ʹ� ��ġ��Ű��
                    enemy.transform.position = transform.position;
                    //4. ���ʹ̸� Ȱ��ȭ�ϰ� �ʹ�
                    enemy.SetActive(true);
                    //�������� �ε��� ����
                    int index = Random.Range(0, spawnPoints.Length);
                    //���ʹ� ��ġ��Ű��
                    enemy.transform.position = spawnPoints[index].position;
                }
            }*/

            //2. ������Ʈ Ǯ�� ���ʹ̰� �ִٸ�
            if(enemyObjectPool.Count > 0)
            {
                //������ƮǮ���� enemy�� ������ ���
                GameObject enemy = enemyObjectPool[0];
                //������ƮǮ���� ���ʹ� ����
                enemyObjectPool.Remove(enemy);
                //�������� �ε��� ����
                int index = Random.Range(0, spawnPoints.Length);
                //���ʹ� ��ġ��Ű��
                enemy.transform.position = spawnPoints[index].position;
                //���ʹ� Ȱ��ȭ
                enemy.SetActive(true);
            }
            createTime = Random.Range(minTime, maxTime);
            createTime = 0;
        }
    }
}
