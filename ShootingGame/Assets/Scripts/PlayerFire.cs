using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory; //총알을 생산할 공장
    
    public int poolSize = 10; //탄창에 넣을 수 있는 총알의 개수
    //GameObject[] bulletObjectPool; //오브젝트 풀 배열
    public List<GameObject> bulletObjectPool; //오브젝트 풀 배열

    //태어날 대 오브젝트 풀(탄창)에 총알을 하나씩 생성
    //1. 태어날 때
    void Start()
    {
        //2. 탄창을 총알 담을 수 있는 크기로 만든다
        //bulletObjectPool = new GameObject[poolSize];
        bulletObjectPool = new List<GameObject>();

        //3. 탄창에 넣을 총알 개수만큼 반복
        for(int i = 0; i < poolSize; i++)
        {
            //4. 총알 공장에서 총알 생성
            GameObject bullet = Instantiate(bulletFactory);
            //5. 총알을 오브젝트 풀에 넣는다
            //bulletObjectPool[i] = bullet;
            bulletObjectPool.Add(bullet);

            //비활성화
            bullet.SetActive(false);
        }

//실행되는 플랫폼이 안드로이드일 경우 조이스틱 활성화
#if UNITY_ANDROID
        GameObject.Find("Joystick canvas XYBZ").SetActive(true);
#elif UNITY_ENDITOR || UNITY_STANDALONE
        GameObject.Find("Joystick canvas XYBZ").SetActive(false);
#endif
    }

    //목표 : 발사 버튼을 누르면 탄창에 있는 총알 중 비활성화된 것을 발사
    void Update()
    {
        //유니티 에디터와 PC환경일 때 동작
#if UNITY_ENDITOR || UNITY_STANDALONE
        //1. 발사 버튼 입력
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
#endif
    }

    public void Fire()
    {
        //2. 탄창 안에 총알이 있다면
        if (bulletObjectPool.Count > 0)
        {
            //3. 비활성화된 총알을 하나 가져온다
            GameObject bullet = bulletObjectPool[0];
            //4. 총알을 발사하고 싶다(활성화)
            bullet.SetActive(true);
            //오브젝트 풀에서 총알 제거
            bulletObjectPool.Remove(bullet);

            //총알을 위치시킨다
            bullet.transform.position = transform.position;
        }

        /* 오브젝트 풀 배열 사용 시 
        //2. 탄창 안에 있는 총알들 중에서
        for(int i = 0; i < poolSize; i++)
        {
            //3. 비활성화된 총알을
            //만약 총알이 비활성화됐다면
            GameObject bullet = bulletObjectPool[i];
            if(bullet.activeSelf == false)
            {
                //4. 총알을 발사(활성화)
                bullet.SetActive(true);
                //총알 위치
                bullet.transform.position = transform.position;
                //총알을 발사했기 때문에 비활성화 총알 검색 중단
                break;
            }
        } */
        //GameObject bullet = Instantiate(bulletFactory);

        //3. 총알을 발사한다(총알을 총구 위치로 가져다놓음)
        //bullet.transform.position = firePosition.transform.position;
    }
}
    

