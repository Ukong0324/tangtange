using UnityEngine;

public class WeaponGenerator : MonoBehaviour
{
    public GameObject kunaiPrefab; // ������ Kunai ������
    public float spawnInterval = 2f; // ���� ���� (��)

    private float nextSpawnTime;
    private Transform playerTransform; // �÷��̾��� ��ġ�� ������ ����

    private void Start()
    {
        // �ʱ� ���� �ð� ����
        nextSpawnTime = Time.time + spawnInterval;

        // �÷��̾��� ��ġ�� ã�� playerTransform ������ ����
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player�� ã�� �� �����ϴ�.");
        }
    }

    private void Update()
    {
        // Enemy GameObject���� ã���ϴ�.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // ���� �ð��� ���� ���� �ð��� �Ѿ��
        if (Time.time >= nextSpawnTime && enemies.Length > 0)
        {
            SpawnKunai();
            // ���� ���� �ð��� ������Ʈ
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    private void SpawnKunai()
    {
        if (playerTransform != null)
        {
            // �÷��̾��� ��ġ���� Kunai�� ����
            Vector3 playerPosition = playerTransform.position;
            Instantiate(kunaiPrefab, playerPosition, Quaternion.identity);
        }
    }
}
