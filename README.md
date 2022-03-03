# 2D 1인용 비행기 슈팅게임 제작
## 1. 프로젝트 개요
### 1.1 개발 인원/기간 및 포지션
- 1인, 총 5일 소요
- 프로그래밍
### 1.2 개발 환경
- Unity 2020.3.13f
- test device : Galaxy s20
- 언어 : C#
- OS : Window 10			
## 2. 개발 단계
### 2.1 벤치마킹
- 고전게임 갤러그 같은 비행기 슈팅 게임 제작을 목표 
### 2.2 개발 과정
- 프로토타입 : PC 버전, 최소 기능 구현
- 알파 버전 : Prefabs/Background/Effect/Sound/UI/Text 추가
- 베타 버전 : 최적화, 디버깅, 리팩토링, 모바일 환경 전환 
## 3. 핵심 구현 내용 
### 3.1 2d 환경에서 플레이어 이동 구현
- Transform.Translate() 인자로 Vector3.Nomalized(벡터 정규화)를 사용하여 입력값 제어
- Speed * Time.deltaTime를 더해 자연스러운 등가속 이동 구현
### 3.2 총알 발사 기능 구현
- 오브젝트 풀링(Object Pooling)을 이용한 총알 메모리 관리
- 총알 객체의 Rigidbody 컴포넌트의 Constraints 속성을 모두 잠구어 총알끼리 부딪히거나 회전하여 이동하는 오류 해결
### 3.3 적기 생성/파괴 및 관리
- 랜덤한 확률로 적기의의 방향이 플레이어(30%) 또는 수직(70%)으로 이동하도록 설정(randomValue < 3), 방향 벡터 공식(target.transform.position  - transform.position).Normailzed() 사용 
- 오브젝트 풀링(Object Pooling)을 이용한 Enemy 메모리 관리
### 3.4 DestroyZone 생성
- 영역 감지용 객체의 Box Collider를 생성, Trigger 이벤트 발생을 감지 시 other.gameObject 파괴 
- 화면을 벗어나는 물체를 제거해 메모리 낭비를 줄임
### 3.5 현재/최고 점수 Text UI 추가 
- ScoreManager 싱글턴 객체 활용
- 최고 점수 값을 저장하고 불러오기 구현
	+ 1인용 플레이 모드이기 때문에 클라이언트 저장 방법을 택함
	+ PlayerPrefs.SetInt() / PlayerPrefs.GetInt() 함수 사용 
- 현재/최고 점수 최신화를 위해 GetScore/SetScore 프로퍼티 사용(캡슐화)
### 3.6 UI/UX 개선
- Player/Enemy/Bullet Prefabs 업데이트, Background Image, Sound, Effect 추가
- 모바일 조이스틱 입력 대응
## 4. 문제 해결 내용
### 4.1 오브젝트 풀 자료형 교체
- 기존의 배열형은 객체의 활성화/비활성화  여부를 검색하는 과정에서 속도가 늦어지는 현상이 있음
- 리스트형은 검색 속도는 느린 대신 데이터를 삽입/삭제하는 속도가 빠른 장점을 가지고 있음
- 비활성화된 객체만을 리스트에 담고 활성화되면 목록에서 제거하는 방식으로 성능을 향상시키기 위해 자료형을 리스트로 교체
- 리스트에는 비활성화된 객체들만 담겨 있기 때문에 검색할 필요가 없어 성능 개선
### 4.2 오브젝트 풀을 활용한 총알 발사 시 참조 오류
- 총알이 적기와 충돌 시 총알이 없어졌는데도 없는 객체를 계속 참조하려는 문제 발견
- Enemy 객체의 OnCollisionEnter 이벤트 함수 구현 시 충돌 객체가 "Bullet"인 경우 부딪힌 물체(총알)를 비활성화하는 코드 추가 
