using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    //���� �ȿ� �ٸ� ��ü�� ������ ���
    private void OnTriggerEnter(Collider other)
    {
        //1. ���� �ε��� ��ü�� Bullet�̰ų� Enemy�� ���
        if (other.gameObject.name.Contains("Bullet") || other.gameObject.name.Contains("Enemy"))
        {
                //2. �ε��� ��ü�� ��Ȱ��ȭ
                other.gameObject.SetActive(false);
        }
    }
}
