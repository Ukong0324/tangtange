using UnityEngine;

public class KunaiController : MonoBehaviour
{
    public float speed = 10f; // Kunai의 이동 속도
    public float damage = 10f; // Kunai의 데미지
    public float lifespan = 1f; // Kunai의 수명 (초)

    private Transform playerTransform; // 플레이어의 위치를 저장할 변수
    private Transform target; // 향할 대상 (가장 가까운 Enemy)
    private float startTime; // Kunai 생성 시간

    private void Start()
    {
        startTime = Time.time;

        // 플레이어의 위치를 찾아 playerTransform 변수에 저장
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;

            // 플레이어 주변에서 가장 가까운 Enemy를 찾습니다.
            FindClosestEnemy();
        }
        else
        {
            Debug.LogError("Player를 찾을 수 없습니다.");
        }

    }

    private void Update()
    {
        if (playerTransform != null && target != null)
        {
            // 플레이어 위치와 Enemy 위치를 기준으로 방향 벡터 계산
            Vector3 direction = (target.position - transform.position).normalized;

            // Kunai를 방향으로 이동시킵니다.
            transform.position += direction * speed * Time.deltaTime;

            // Kunai의 회전 각도를 설정하여 방향에 맞게 회전합니다.
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        } else
        {
            Destroy(gameObject);
        }

        // Kunai의 수명이 초과하면 제거합니다.
        if (Time.time - startTime >= lifespan)
        {
            Destroy(gameObject);
        }
    }



    private void FindClosestEnemy()
    {
        // 모든 Enemy를 찾습니다.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float closestDistance = float.MaxValue;
        Transform closestEnemy = null;

        // 모든 Enemy와의 거리를 계산하고, 가장 가까운 Enemy를 찾습니다.
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy.transform;
            }
        }

        target = closestEnemy;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 충돌한 오브젝트가 Enemy라면 데미지를 입힙니다.
        if (other.CompareTag("Enemy"))
        {
            EnemyController enemyController = other.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                enemyController.TakeDamage(damage);
            }

            // 충돌한 후에는 Kunai를 파괴합니다.
            Destroy(gameObject);
        }
    }
}
