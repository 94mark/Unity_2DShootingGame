using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float currentTime; //현재 시간
    public float createTime = 1; //일정 시간
    public GameObject enemyFactory; //적 공장
    public float minTime = 0.5f; //최소 시간
    public float maxTime = 1.5f; //최대 시간

    public int poolSize = 10; //오브젝트 풀 크기
    GameObject[] enemyObjectPool; //오브젝트 풀 배열
    public Transform[] spawnPoints; //SpawnPoints들

    void Start()
    {
        //태어날 때 적의 생성 시간을 설정
        createTime = Random.Range(minTime, maxTime);

        //오브젝트 풀을 에너미들을 담을 수 있는 크기로 만들어준다
        enemyObjectPool = new GameObject[poolSize];
        //오브젝트 풀에 넣을 에너미 개수만큼 반복
        for (int i = 0; i < poolSize; i++)
        {
            //에너미 공장에서 에너미 생성
            GameObject enemy = Instantiate(enemyFactory);
            //에너미를 오브젝트 풀에 넣는다
            enemyObjectPool[i] = enemy;
            //비활성화
            enemy.SetActive(false);
        }
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        //1. 생성 시간이 되었으니까
        if(currentTime > createTime)
        {
            //2. 에너미 풀 안에 있는 에너미 중에서
            for(int i = 0; i < poolSize; i++)
            {
                //3. 비활성화 된 에너미를
                //만약 에너미가 비활성화 되었다면
                GameObject enemy = enemyObjectPool[i];
                if(enemy.activeSelf == false)
                {
                    //에너미 위치시키기
                    enemy.transform.position = transform.position;
                    //4. 에너미를 활성화하고 싶다
                    enemy.SetActive(true);
                    //랜덤으로 인덱스 선택
                    int index = Random.Range(0, spawnPoints.Length);
                    //에너미 위치시키기
                    enemy.transform.position = spawnPoints[index].position;
                }
            }
            createTime = Random.Range(minTime, maxTime);
            createTime = 0;
        }
    }
}
