using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinController : MonoBehaviour
{
    public TextMeshProUGUI coinCount;
    private int coin = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    // 스코어를 1 증가시키는 메소드
    public void IncreaseScore()
    {
        coin++;
        UpdateScoreText();
    }

    // 스코어를 TextMeshPro에 업데이트
    void UpdateScoreText()
    {
        coinCount.text = coin.ToString();
    }
}
