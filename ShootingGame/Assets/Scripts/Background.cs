using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    //배경 머터리얼
    public Material bgMaterial;
    //스크롤 속도
    public float scrollSpeed = 0.2f;

    //1. 플레이어가 살아 있는 동안 진행
    void Update()
    {
        //방향이 필요
        Vector2 direction = Vector2.up;
        //스크롤 P = P0 + vt
        bgMaterial.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;
    }
}
