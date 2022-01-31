using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //필요 속성 : 이동 속도
    public float speed = 5;
    //방향을 전역 변수로 만들어 Start와 Update에서 사용
    Vector3 dir;
    //폭발 공장 주소(외부에서 값을 넣어준다)
    public GameObject explosionFactory;

    void Start()
    {
        //Vector3 dir;
        //0부터 9까지 10개의 값 중에 하나를 랜덤으로 가져온다
        int randValue = Random.Range(0, 10);
        //만약 3보다 작으면 플레이어 방향
        if(randValue < 3)
        {
            //플레이어를 찾아 target으로 한다
            GameObject target = GameObject.Find("Player");
            //방향을 구하고 싶다. target - me
            dir = target.transform.position - transform.position;
            //방향의 크기를 1로 한다(방향 벡터 설정)
            dir.Normalize();
        }
        //그렇지 않으면 아래 방향으로 정한다
        else
        {
            dir = Vector3.down;
        }
    }
    void Update()
    {
        //1. 방향을 구한다
        //Vector3 dir = Vector3.down;
        //2. 이동
        transform.position += dir * speed * Time.deltaTime;
    }

    //층돌 시작
    private void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
