using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    //��� ���͸���
    public Material bgMaterial;
    //��ũ�� �ӵ�
    public float scrollSpeed = 0.2f;

    //1. �÷��̾ ��� �ִ� ���� ����
    void Update()
    {
        //������ �ʿ�
        Vector2 direction = Vector2.up;
        //��ũ�� P = P0 + vt
        bgMaterial.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;
    }
}
