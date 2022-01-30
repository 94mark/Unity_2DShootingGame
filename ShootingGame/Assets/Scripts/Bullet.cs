using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //필요 속성 : 이동 속도
    public float speed = 5;

    void Update()
    {
        //1. 방향을 구함
        Vector3 dir = Vector3.up;
        //2. 이동 P = P0 + vt
        transform.position += dir * speed * Time.deltaTime;
    }
}
