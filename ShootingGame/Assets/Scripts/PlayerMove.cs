using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //플레이어가 이동할 속력
    public float speed = 5;
    void Start()
    {
        
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, v, 0);
        //Vector3 dir = Vector3.right * h + Vector3.up * v; 

        //transform.Translate(dir * speed * Time.deltaTime);
        //P = P0 + vt 공식 사용
        //transform.position = transform.position + dir * speed * Time.deltaTime;
        transform.position += dir * speed * Time.deltaTime;
    }
}
