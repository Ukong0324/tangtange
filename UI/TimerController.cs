using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    private float gameTime = 0.0f; // 게임 시작 시간부터 경과한 시간
    public TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        // 게임이 시작될 때 현재 시간을 시작 시간으로 설정
        gameTime = 0.0f;

        // TextMeshPro Text 컴포넌트 참조
        textMesh = GetComponent <TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // 매 프레임마다 경과 시간을 증가시킴
        gameTime += Time.deltaTime;

        // 경과 시간을 MM:SS 형식으로 포맷
        string formattedTime = string.Format("{0:00}:{1:00}", Mathf.Floor(gameTime / 60), Mathf.Floor(gameTime % 60));

        // TextMeshPro Text에 시간 출력
        textMesh.text = formattedTime;
    }
}
