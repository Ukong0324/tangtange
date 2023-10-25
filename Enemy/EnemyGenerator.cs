using UnityEngine;
using TMPro;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab; // ������ �� ������
    public float spawnInterval = 2f; // ���� ���� (��)

    private float nextSpawnTime;

    private void Update()
    {
        // ���� �ð��� ���� ���� �ð��� �Ѿ��
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            // ���� ���� �ð��� ����
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    private void SpawnEnemy()
    {
        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            // Main Camera�� �����ڸ� ��ġ ���
            float cameraHeight = mainCamera.orthographicSize;
            float cameraWidth = cameraHeight * mainCamera.aspect;

            float spawnX = Random.Range(-cameraWidth, cameraWidth);
            float spawnY = Random.Range(-cameraHeight, cameraHeight);

            Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);

            // ������ ���� �ν��Ͻ�ȭ�մϴ�.
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Main Camera�� �����ϴ�.");
        }
    }

}
