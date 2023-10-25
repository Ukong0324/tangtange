using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelController : MonoBehaviour
{
    public Image levelGauge;
    public TextMeshProUGUI levelText;
    public int level = 1;
    private float exp = 0;
    private float maxExp = 10f;
    void Update()
    {
        if (exp > maxExp) // LevelUp!
        {
            level++;
            exp = 0;
            maxExp += 10f;
        } else
        {
            levelText.text = level.ToString();
            levelGauge.fillAmount = exp / maxExp;
        }

    }
    
    public void increaseExp()
    {
        exp++;
    }
}
