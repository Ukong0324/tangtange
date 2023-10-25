using UnityEngine;
using TMPro;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab; // 생성할 적 프리팹
    public float spawnInterval = 2f; // 생성 간격 (초)

    private float nextSpawnTime;

    private void Update()
    {
        // 현재 시간이 다음 생성 시간을 넘어가면
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            // 다음 생성 시간을 설정
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    private void SpawnEnemy()
    {
        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            // Main Camera의 가장자리 위치 계산
            float cameraHeight = mainCamera.orthographicSize;
            float cameraWidth = cameraHeight * mainCamera.aspect;

            float spawnX = Random.Range(-cameraWidth, cameraWidth);
            float spawnY = Random.Range(-cameraHeight, cameraHeight);

            Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);

            // 생성된 적을 인스턴스화합니다.
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Main Camera가 없습니다.");
        }
    }

}
