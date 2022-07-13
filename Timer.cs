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
        time += Time.deltaTime;     // �ð��� �帥��.
        msec = (int)((time - (int)time) * 100);
        sec = (int)(time % 60);
        min = (int)(time / 60 % 60);

        timer.text = string.Format("TIME  {0:00} : {1:00} : {2:00}", min, sec, msec);
    }

    public Text textGameOverTimerValue = null;
    public void StopTimer()
    {
        textGameOverTimerValue.text = timer.text; // = �� �������� ������ ���� ���ʿ� ����(����)�Ѵ�.
        this.enabled = false; // Timer ������Ʈ�� ����.
    }

}
