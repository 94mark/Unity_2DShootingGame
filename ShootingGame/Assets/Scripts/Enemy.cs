using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //�ʿ� �Ӽ� : �̵� �ӵ�
    public float speed = 5;

    void Update()
    {
        //1. ������ ���Ѵ�
        Vector3 dir = Vector3.down;
        //2. �̵�
        transform.position += dir * speed * Time.deltaTime;
    }
}
