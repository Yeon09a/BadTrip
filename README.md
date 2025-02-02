# Bad Trip
2024년 서울여자대학교 디지털미디어학과 캡스톤디자인설계 졸업 프로젝트<br/>

2D 픽셀 스토리 PC 게임<br/>
청소년 마약 범죄의 심각성을 알리고 마약 중독에 대한 경각심을 심어주는 것이 목표인 스토리텔링형 시리어스 게임<br/>
* 본 프로젝트는 서울여자대학교 디지털미디어학과 졸업 프로젝트 결과물입니다.

## 게임 소개
'Bad Trip'은 단순 재미 제공보다는 청소년 마약 중독이라는 사회적 문제를 시사하고 교훈을 주는 메시지를 전달하는 데 초점을 맞힌 스토리텔링형 시리어스 게임입니다.<br>
청소년기 마약 중독에 대한 경각심을 함양하고, 청소년 마약 범죄에 관한 사회 시스템의 구조적 문제점을 시사하는 것을 프로젝트 목적으로 하고 있습니다. <br/>

> 마약 중독으로 망가져버린 나의 삶...<br/>
> 악마와의 계약을 통해 고등학생으로 돌아갈 수 있는 기회를 얻었다. 과연 나는 이 기회를 놓치지 않고 마약 중독으로부터 벗어나 현재를 바꿀 수 있을까?

### 게임 특징
* 마약을 했을 때의 증상 체험 및 경험 연출
  * 인지 능력 저하, 환청, 환각 등과 같은 마약을 했을 때의 증상과 마약을 통해 겪을 수 있는 끔찍한 경험을 Post Processing, 오디오 연출, 횡스크롤 게임과 같은 방법으로 제공합니다.
  <br/><img width="50%" src="https://github.com/user-attachments/assets/69e6011a-d0f9-4444-8180-b3e8b3d8cf41"/><img width="50%" src="https://github.com/user-attachments/assets/0526926f-d0b7-4fa6-8133-817cb939c6a7"/>
* 마약 중독 부작용 및 금단 증상 연출
  *  가려움증, 탈모, 신경통, 메스버그 환각과 같은 마약의 신체적 부작용과 금단 증상을 그래픽 연출, 미니게임, 스토리로 제공합니다.
  <br/><img width="50%" src="https://github.com/user-attachments/assets/c29e0e77-6f84-4a1d-87fe-d450a148165f"/><img width="50%" src="https://github.com/user-attachments/assets/007ab649-ffae-4da2-aa9c-ca6a6d613e25"/>
* 미니게임
  * 메스버그 미니게임, 몬스터와의 전투, 마약 중독 치료 미니게임 통해 게임의 재미를 제공합니다.
  <br/><img width="50%" src="https://github.com/user-attachments/assets/03938cdb-fa7c-41ce-984d-28878e01243c"/><img width="50%" src="https://github.com/user-attachments/assets/7704d661-ffbc-408d-b1c1-84f91c5d53db"/>
* 멀티 엔딩 연출
  * 마약의 작용, 부작용으로 인해 여러 갈림길에서 맞게 되는 다양한 배드 엔딩을 연출하여 사용자가 마약의 위험성을 체감하도록 합니다.
  <br/><img width="50%" src="https://github.com/user-attachments/assets/305703fd-4eda-4153-8269-6c77c384a4f9"/><img width="50%" src="https://github.com/user-attachments/assets/b7a51178-8a9b-44df-b7c8-911a7d0d3da0"/>
## 프로젝트 개요
🔗자세한 내용은 Notion에서 확인하실 수 있으십니다.    [<img src="https://img.shields.io/badge/Notion-000000?style=flat-round&logo=Notion&logoColor=white"/>](https://www.notion.so/BadTrip-178b66b96b77808eb6aec3e3a98111d4?pvs=4)
### 개발 기간
* 2024.03 - 2024.12 (약 9개월)
### 개발 환경
* Unity 2022.3.11f1
* Fungus
### 수행업무
프로젝트 팀원은 5명으로 그 중 개발에 참여하여 다음과 같은 부분을 담당하였습니다.<br/>

사운드 시스템 제작
* ScriptableObject를 활용한 오디오 데이터(오디오 번호, 오디오 클립, 루프 유무, 볼륨, 오디오 믹서 등) 관리
* 맵 Scene과 Initialization Scene의 독립성 유지를 위해 ScriptableObject를 이벤트 채널로 사용하여 오디오 재생

Fungus를 활용한 대사 출력 및 이벤트 호출 등 스토리 진행 관련 제작
* 대사 입력 및 컷씬 이동 제작
* 스토리 진행 관련 이벤트 Fungus command 커스텀 제작
* ScriptableObject를 활용한 스토리 진행 데이터 관리
* 스토리 진행 애니메이션 제작

Post Processing을 활용한 환각 효과 제작
* Coroutine을 활용한 점진적 환각 효과 제작

씬 이동 시스템 제작
* ScriptableObject를 활용한 씬 데이터 관리

세이브 시스템 제작
* Json을 활용한 세이브 파일 관리
* 불러오기 / 저장하기 제작
* ScrollView를 활용한 세이브 UI 제작

신경 세포 연결 퍼즐 미니게임 제작
* Handler 인터페이스를 활용한 노드 연결 게임 제작

Player 데이터 관리
* ScriptableObject를 활용한 Player 데이터 관리
## 프로젝트 성과
* 서울여자대학교 디지털미디어학과 제 7회 졸업전시회 참여
* 한국저작권위원회 등록
