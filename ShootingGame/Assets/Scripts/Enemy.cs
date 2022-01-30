using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //필요 속성 : 이동 속도
    public float speed = 5;

    void Update()
    {
        //1. 방향을 구한다
        Vector3 dir = Vector3.down;
        //2. 이동
        transform.position += dir * speed * Time.deltaTime;
    }
}
