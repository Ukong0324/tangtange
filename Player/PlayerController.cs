using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public FixedJoystick Joystick;
    public LineRenderer directionIndicator; // LineRenderer를 연결해야 합니다.
    public Image healthBar; // 게이지 이미지를 연결
    public float moveSpeed;
    public float maxHealth = 100f; // 플레이어의 최대 체력
    public Image playerHP;

    private float currentHealth; // 현재 체력
    Rigidbody2D rb;
    Vector2 move;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth; // 플레이어의 체력을 초기화
    }

    private void Update()
    {
        move.x = Joystick.Horizontal;
        move.y = Joystick.Vertical;

        RectTransform playerHPRectTransform = playerHP.GetComponent<RectTransform>();
        Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        playerHPRectTransform.position = new Vector3(playerScreenPosition.x, playerScreenPosition.y + -65, playerScreenPosition.z);
        // 회전
        float hAxis = move.x;
        float vAxis = move.y;
        float zAxis = Mathf.Atan2(hAxis, vAxis) * Mathf.Rad2Deg;

        if (hAxis > 0)
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 0);
        }

        // 방향을 시각적으로 나타내기 위해 LineRenderer 업데이트
        UpdateDirectionIndicator(move);
    }

    // 플레이어의 체력을 회복하는 메소드
    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth); // 최대 체력을 초과하지 않도록 조정
    }

    // 플레이어에게 데미지를 입히는 메소드
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        float fillAmount = currentHealth / maxHealth;
        healthBar.fillAmount = fillAmount;
        Debug.Log(healthBar.fillAmount);
        if (currentHealth <= 0)
        {
            Time.timeScale = 0f;
            // Application.Quit(); => 게임 종료 
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
    }

    private void UpdateDirectionIndicator(Vector2 direction)
    {
        // LineRenderer를 사용하여 방향 표시
        Vector3[] linePositions = { rb.position, rb.position + new Vector2(Joystick.Horizontal, Joystick.Vertical) * 1.0f };
        directionIndicator.positionCount = 2;
        directionIndicator.SetPositions(linePositions);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            TakeDamage(1);
        }

        if (collision.gameObject.tag == "Exp")
        {
            LevelController expCount = FindObjectOfType<LevelController>();
            expCount.increaseExp();
            Destroy(collision.gameObject);
        }
    }
}
