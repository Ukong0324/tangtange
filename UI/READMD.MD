## UI
- 유저 인터페이스와 관련된 코드가 작성되어 있는 경로입니다.

### ButtonController
기능:
1. 기본적으로 게임을 시작할 때 패널이 닫히도록 하였습니다.
2. 버튼을 눌렸을 때 사용할 수 있는 메소드가 존재합니다.   
2.2 Open(패널 열고 시간: 0), close(패널 닫고 시간: 1), quit(게임 종료)

> **필요한 컴포넌트: 없음**

### CoinController
기능:
1. 코인을 플레이어가 먹었을 때 카운트를 올릴 수 있는 메소드가 존재합니다.

> **필요한 컴포넌트: CoinText (TextmeshproUGUI)**

### LevelController
기능:
1. 초기 레벨과 경험치를 조정할 수 있습니다.
2. 레벨이 오를 때마다 최대 경험치는 10씩 늘어나도록 설계 하였습니다.
3. 레벨 경험치 보유량에 따라 levelGauge가 늘어나도록 하였습니다.
```
level > Inspector

```

> **필요한 컴포넌트: levelGauge (UI > Image ), levelText (UI > TextMeshProUGUI)**

### ScoreController
기능:
1. Enemy가 죽었을 때 Score가 올라가게 하는 메소드가 존재합니다.
2. UpdateScoreText에서 킬 Text를 업데이트 합니다.

> **필요한 컴포넌트: KillScore (TextMeshProUGUI)**

### TimerController
기능:
1. 게임이 시작했을 때 시간이 증가하도록 하였습니다.

> **필요한 컴포넌트: Timer (TextMeshProUGUI)**