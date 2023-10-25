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
        // 초기 스코어 설정
        UpdateScoreText();
    }

    // 스코어를 1 증가시키는 메소드
    public void IncreaseScore()
    {
        score++;
        UpdateScoreText();
    }

    // 스코어를 TextMeshPro에 업데이트
    void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}
