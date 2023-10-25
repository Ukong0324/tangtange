using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    private float gameTime = 0.0f; // ���� ���� �ð����� ����� �ð�
    public TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        // ������ ���۵� �� ���� �ð��� ���� �ð����� ����
        gameTime = 0.0f;

        // TextMeshPro Text ������Ʈ ����
        textMesh = GetComponent <TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // �� �����Ӹ��� ��� �ð��� ������Ŵ
        gameTime += Time.deltaTime;

        // ��� �ð��� MM:SS �������� ����
        string formattedTime = string.Format("{0:00}:{1:00}", Mathf.Floor(gameTime / 60), Mathf.Floor(gameTime % 60));

        // TextMeshPro Text�� �ð� ���
        textMesh.text = formattedTime;
    }
}
