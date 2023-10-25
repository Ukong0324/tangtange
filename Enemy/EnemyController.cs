using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3.0f; // �̵� �ӵ�
    public float maxHealth = 100f; // �ִ� ü��
    public int damage = 10; // ���� �ִ� ������
    public GameObject exp;
    private float currentHealth; // ���� ü��
    private Transform target; // ����ٴ� ��� (�÷��̾�)
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform; // Player �±׸� ���� ������Ʈ�� ã�Ƽ� ������� ����
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (target != null)
        {
            // �÷��̾ ���� �̵��մϴ�.
            Vector2 moveDirection = (target.position - transform.position).normalized;
            rb.velocity = moveDirection * moveSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        // ü���� 0 ���Ϸ� �������� ������Ʈ�� �ı��ϰ� KilledMobs ���� ������ŵ�ϴ�.
        if (currentHealth <= 0)
        {
            // ScoreManager�� ã���ϴ�.
            ScoreController scoreManager = FindObjectOfType<ScoreController>();

            if (scoreManager != null)
            {
                Instantiate(exp, transform.position, Quaternion.identity);
                scoreManager.IncreaseScore();
            }

            Destroy(gameObject);
        }
    }
}