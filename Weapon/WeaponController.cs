using UnityEngine;

public class KunaiController : MonoBehaviour
{
    public float speed = 10f; // Kunai�� �̵� �ӵ�
    public float damage = 10f; // Kunai�� ������
    public float lifespan = 1f; // Kunai�� ���� (��)

    private Transform playerTransform; // �÷��̾��� ��ġ�� ������ ����
    private Transform target; // ���� ��� (���� ����� Enemy)
    private float startTime; // Kunai ���� �ð�

    private void Start()
    {
        startTime = Time.time;

        // �÷��̾��� ��ġ�� ã�� playerTransform ������ ����
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;

            // �÷��̾� �ֺ����� ���� ����� Enemy�� ã���ϴ�.
            FindClosestEnemy();
        }
        else
        {
            Debug.LogError("Player�� ã�� �� �����ϴ�.");
        }

    }

    private void Update()
    {
        if (playerTransform != null && target != null)
        {
            // �÷��̾� ��ġ�� Enemy ��ġ�� �������� ���� ���� ���
            Vector3 direction = (target.position - transform.position).normalized;

            // Kunai�� �������� �̵���ŵ�ϴ�.
            transform.position += direction * speed * Time.deltaTime;

            // Kunai�� ȸ�� ������ �����Ͽ� ���⿡ �°� ȸ���մϴ�.
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        } else
        {
            Destroy(gameObject);
        }

        // Kunai�� ������ �ʰ��ϸ� �����մϴ�.
        if (Time.time - startTime >= lifespan)
        {
            Destroy(gameObject);
        }
    }



    private void FindClosestEnemy()
    {
        // ��� Enemy�� ã���ϴ�.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float closestDistance = float.MaxValue;
        Transform closestEnemy = null;

        // ��� Enemy���� �Ÿ��� ����ϰ�, ���� ����� Enemy�� ã���ϴ�.
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
        // �浹�� ������Ʈ�� Enemy��� �������� �����ϴ�.
        if (other.CompareTag("Enemy"))
        {
            EnemyController enemyController = other.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                enemyController.TakeDamage(damage);
            }

            // �浹�� �Ŀ��� Kunai�� �ı��մϴ�.
            Destroy(gameObject);
        }
    }
}
