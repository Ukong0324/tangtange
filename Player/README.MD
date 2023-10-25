## Player
- 플레이어에 관한 코드가 작성되어 있는 경로입니다.
### PlayerController
기능:
1. 플레이어를 조이스틱(제작 또는 **[에셋 (Asset)](https://assetstore.unity.com/packages/tools/input-management/joystick-pack-107631)**)을 이용하여 컨트롤할 수 있습니다.
2. 플레이어 체력을 컨트롤 할 수 있습니다. (초기 체력, 최대 체력, 데미지 입히기)
3. 체력 게이지 UI와 연동이 가능합니다. (UI > Image)   
```
Inspector > Image   
Image Type: Filled   
Fill Method: Horizontal   
Fill Origin: Left   
```

> **필요한 컴포넌트: 조이스틱, 체력 게이지 (UI > Image), Collider (isTrigger: true), Rigidbody**
