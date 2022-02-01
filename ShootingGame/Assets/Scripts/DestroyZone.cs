using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    //영역 안에 다른 물체가 감지될 경우
    private void OnTriggerEnter(Collider other)
    {
        //1. 만약 부딪힌 물체가 Bullet이거나 Enemy일 경우
        if (other.gameObject.name.Contains("Bullet") || other.gameObject.name.Contains("Enemy"))
        {
                //2. 부딪힌 물체를 비활성화
                other.gameObject.SetActive(false);
        }
    }
}
