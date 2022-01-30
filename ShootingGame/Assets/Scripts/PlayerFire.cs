using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory; //�Ѿ��� ������ ����
    public GameObject firePosition; //�ѱ�

    void Start()
    {
        
    }

    void Update()
    {
        //��ǥ : ����ڰ� �߻� ��ư�� ������ �Ѿ��� �߻��ϰ� �ʹ�
        //�ӵ� : 1. ����ڰ� �߻� ��ư�� ������
        //���� ����ڰ� �߻� ��ư�� ������
        if(Input.GetButtonDown("Fire1"))
        {
            //2. �Ѿ� ���忡�� �Ѿ��� �����
            GameObject bullet = Instantiate(bulletFactory);

            //3. �Ѿ��� �߻��Ѵ�(�Ѿ��� �ѱ� ��ġ�� �����ٳ���)
            bullet.transform.position = firePosition.transform.position;
        }
    }
}
