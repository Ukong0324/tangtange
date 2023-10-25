## Enemy
- Enemy에 관한 코드가 작성되어 있는 경로입니다.
### EnemyController
기능:
1. Generator에 의해 생성된 Enemy는 Player Tag를 가진 요소에게 가게 하였습니다.
2. Enemy 기본 설정할 수 있습니다. (초기 체력, 최대 체력, 데미지 입히기)
3. Player가 Enemy를 죽이면 KillScore가 올라가면서 Exp를 떨굽니다.  

> **필요한 컴포넌트: Exp, Collider, Rigidbody**

### EnemyGenerator
기능: 
1. 사용자 화면 가장자리에 적이 소환되도록 하였습니다.
2. 소환 시간은 설정할 수 있습니다. (spawnInterval)

> **필요한 컴포넌트: Enemy.prefab**
