using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float currentTime; //현재 시간
    public float createTime = 1; //일정 시간
    public GameObject enemyFactory; //적 공장

    void Update()
    {
        //1.시간이 흐르다가
        currentTime += Time.deltaTime;

        //2. 만약 현재 시간이 일정 시간이 되면
        if(currentTime > createTime)
        {
            //3. 적 공장에서 적을 생성해
            GameObject enemy = Instantiate(enemyFactory);
            //내 위치에 갖다 놓고 싶다
            enemy.transform.position = transform.position;
            //현재 시간을 0으로 초기화
            currentTime = 0;
        }
    }
}
