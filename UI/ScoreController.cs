using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        // �ʱ� ���ھ� ����
        UpdateScoreText();
    }

    // ���ھ 1 ������Ű�� �޼ҵ�
    public void IncreaseScore()
    {
        score++;
        UpdateScoreText();
    }

    // ���ھ TextMeshPro�� ������Ʈ
    void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}
