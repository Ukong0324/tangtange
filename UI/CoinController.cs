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

    // ���ھ 1 ������Ű�� �޼ҵ�
    public void IncreaseScore()
    {
        coin++;
        UpdateScoreText();
    }

    // ���ھ TextMeshPro�� ������Ʈ
    void UpdateScoreText()
    {
        coinCount.text = coin.ToString();
    }
}
