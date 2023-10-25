using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public FixedJoystick Joystick;
    public LineRenderer directionIndicator; // LineRenderer�� �����ؾ� �մϴ�.
    public Image healthBar; // ������ �̹����� ����
    public float moveSpeed;
    public float maxHealth = 100f; // �÷��̾��� �ִ� ü��
    public Image playerHP;

    private float currentHealth; // ���� ü��
    Rigidbody2D rb;
    Vector2 move;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth; // �÷��̾��� ü���� �ʱ�ȭ
    }

    private void Update()
    {
        move.x = Joystick.Horizontal;
        move.y = Joystick.Vertical;

        RectTransform playerHPRectTransform = playerHP.GetComponent<RectTransform>();
        Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        playerHPRectTransform.position = new Vector3(playerScreenPosition.x, playerScreenPosition.y + -65, playerScreenPosition.z);
        // ȸ��
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

        // ������ �ð������� ��Ÿ���� ���� LineRenderer ������Ʈ
        UpdateDirectionIndicator(move);
    }

    // �÷��̾��� ü���� ȸ���ϴ� �޼ҵ�
    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth); // �ִ� ü���� �ʰ����� �ʵ��� ����
    }

    // �÷��̾�� �������� ������ �޼ҵ�
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        float fillAmount = currentHealth / maxHealth;
        healthBar.fillAmount = fillAmount;
        Debug.Log(healthBar.fillAmount);
        if (currentHealth <= 0)
        {
            Time.timeScale = 0f;
            // Application.Quit(); => ���� ���� 
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
    }

    private void UpdateDirectionIndicator(Vector2 direction)
    {
        // LineRenderer�� ����Ͽ� ���� ǥ��
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
