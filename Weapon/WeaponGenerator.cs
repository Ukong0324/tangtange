using UnityEngine;

public class WeaponGenerator : MonoBehaviour
{
    public GameObject kunaiPrefab; // 생성할 Kunai 프리팹
    public float spawnInterval = 2f; // 생성 간격 (초)

    private float nextSpawnTime;
    private Transform playerTransform; // 플레이어의 위치를 저장할 변수

    private void Start()
    {
        // 초기 생성 시간 설정
        nextSpawnTime = Time.time + spawnInterval;

        // 플레이어의 위치를 찾아 playerTransform 변수에 저장
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player를 찾을 수 없습니다.");
        }
    }

    private void Update()
    {
        // Enemy GameObject들을 찾습니다.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // 현재 시간이 다음 생성 시간을 넘어가면
        if (Time.time >= nextSpawnTime && enemies.Length > 0)
        {
            SpawnKunai();
            // 다음 생성 시간을 업데이트
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    private void SpawnKunai()
    {
        if (playerTransform != null)
        {
            // 플레이어의 위치에서 Kunai를 스폰
            Vector3 playerPosition = playerTransform.position;
            Instantiate(kunaiPrefab, playerPosition, Quaternion.identity);
        }
    }
}
