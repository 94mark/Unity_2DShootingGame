using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float currentTime; //���� �ð�
    public float createTime = 1; //���� �ð�
    public GameObject enemyFactory; //�� ����

    void Update()
    {
        //1.�ð��� �帣�ٰ�
        currentTime += Time.deltaTime;

        //2. ���� ���� �ð��� ���� �ð��� �Ǹ�
        if(currentTime > createTime)
        {
            //3. �� ���忡�� ���� ������
            GameObject enemy = Instantiate(enemyFactory);
            //�� ��ġ�� ���� ���� �ʹ�
            enemy.transform.position = transform.position;
            //���� �ð��� 0���� �ʱ�ȭ
            currentTime = 0;
        }
    }
}
