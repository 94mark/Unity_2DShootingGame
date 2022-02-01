using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory; //�Ѿ��� ������ ����
    
    public int poolSize = 10; //źâ�� ���� �� �ִ� �Ѿ��� ����
    //GameObject[] bulletObjectPool; //������Ʈ Ǯ �迭
    public List<GameObject> bulletObjectPool; //������Ʈ Ǯ �迭

    //�¾ �� ������Ʈ Ǯ(źâ)�� �Ѿ��� �ϳ��� ����
    //1. �¾ ��
    void Start()
    {
        //2. źâ�� �Ѿ� ���� �� �ִ� ũ��� �����
        //bulletObjectPool = new GameObject[poolSize];
        bulletObjectPool = new List<GameObject>();

        //3. źâ�� ���� �Ѿ� ������ŭ �ݺ�
        for(int i = 0; i < poolSize; i++)
        {
            //4. �Ѿ� ���忡�� �Ѿ� ����
            GameObject bullet = Instantiate(bulletFactory);
            //5. �Ѿ��� ������Ʈ Ǯ�� �ִ´�
            //bulletObjectPool[i] = bullet;
            bulletObjectPool.Add(bullet);

            //��Ȱ��ȭ
            bullet.SetActive(false);
        }
    }

    //��ǥ : �߻� ��ư�� ������ źâ�� �ִ� �Ѿ� �� ��Ȱ��ȭ�� ���� �߻�
    void Update()
    {
        //1. �߻� ��ư �Է�
        if(Input.GetButtonDown("Fire1"))
        {
            //2. źâ �ȿ� �Ѿ��� �ִٸ�
            if(bulletObjectPool.Count > 0)
            {
                //3. ��Ȱ��ȭ�� �Ѿ��� �ϳ� �����´�
                GameObject bullet = bulletObjectPool[0];
                //4. �Ѿ��� �߻��ϰ� �ʹ�(Ȱ��ȭ)
                bullet.SetActive(true);
                //������Ʈ Ǯ���� �Ѿ� ����
                bulletObjectPool.Remove(bullet);

                //�Ѿ��� ��ġ��Ų��
                bullet.transform.position = transform.position;
            }

            /* ������Ʈ Ǯ �迭 ��� �� 
            //2. źâ �ȿ� �ִ� �Ѿ˵� �߿���
            for(int i = 0; i < poolSize; i++)
            {
                //3. ��Ȱ��ȭ�� �Ѿ���
                //���� �Ѿ��� ��Ȱ��ȭ�ƴٸ�
                GameObject bullet = bulletObjectPool[i];
                if(bullet.activeSelf == false)
                {
                    //4. �Ѿ��� �߻�(Ȱ��ȭ)
                    bullet.SetActive(true);
                    //�Ѿ� ��ġ
                    bullet.transform.position = transform.position;
                    //�Ѿ��� �߻��߱� ������ ��Ȱ��ȭ �Ѿ� �˻� �ߴ�
                    break;
                }
            } */
            //GameObject bullet = Instantiate(bulletFactory);

            //3. �Ѿ��� �߻��Ѵ�(�Ѿ��� �ѱ� ��ġ�� �����ٳ���)
            //bullet.transform.position = firePosition.transform.position;
        }
    }
}
