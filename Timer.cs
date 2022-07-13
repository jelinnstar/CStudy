using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    private void Awake()
    {
        instance = this;
    }
    public Text timer;
    public float time;
    float msec;
    float sec;
    float min;

    void Start()
    {
    }

    void Update()
    {
        time += Time.deltaTime;     // 시간이 흐른다.
        msec = (int)((time - (int)time) * 100);
        sec = (int)(time % 60);
        min = (int)(time / 60 % 60);

        timer.text = string.Format("TIME  {0:00} : {1:00} : {2:00}", min, sec, msec);
    }

    public Text textGameOverTimerValue = null;
    public void StopTimer()
    {
        textGameOverTimerValue.text = timer.text; // = 을 기준으로 오른쪽 값을 왼쪽에 대입(복사)한다.
        this.enabled = false; // Timer 컴포넌트를 끝다.
    }

}
