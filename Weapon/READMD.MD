## Weapon
- 무기에 관한 코드가 작성되어 있는 경로입니다.
### WeaponController
기능: 
1. Generator에 의해 생성된 Weapon는 가장 가까이에 있는 Enemy를 찾아서 해당 방향으로 날아갑니다.
2. 물체가 닿으면 EnemyController에 있는 데미지 주는 메서드를 호출합니다.
3. Weapon이 날아간 시간이 특정 시간보다 더 오래 걸린다면 자동으로 사라집니다.
4. Weapon에 대한 속성을 설정할 수 있습니다. (이동 속도, 데미지, 수명, 생성 시간)

> **필요한 컴포넌트: Collider (isTrigger: true), Rigidbody**

### WeaponGenerator
기능: 
1. 특정 시간마다 플레이어로부터 무기가 소환되도록 하였습니다.

> **필요한 컴포넌트: Weapon.prefab**
