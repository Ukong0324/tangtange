using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3.0f; // 이동 속도
    public float maxHealth = 100f; // 최대 체력
    public int damage = 10; // 적이 주는 데미지
    public GameObject exp;
    private float currentHealth; // 현재 체력
    private Transform target; // 따라다닐 대상 (플레이어)
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform; // Player 태그를 가진 오브젝트를 찾아서 대상으로 설정
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (target != null)
        {
            // 플레이어를 향해 이동합니다.
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

        // 체력이 0 이하로 떨어지면 오브젝트를 파괴하고 KilledMobs 값을 증가시킵니다.
        if (currentHealth <= 0)
        {
            // ScoreManager를 찾습니다.
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