using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 어느 지점에 도달했을 때 맵 어디에 와있는지 Map Bar에서 보여준다.(총 3개 지점)
public class MapBar : MonoBehaviour
{
    public static MapBar instance;
    private void Awake()
    {
        instance = this;
    }
    public float minMB = 0;
    public float maxMB = 1;
    public Scrollbar scrollbarProgress;
    float mb;
    public float MB
    {
        get { return mb; }
        set
        {
            if (value == 0 || mb < value)
            {
                mb = Mathf.Clamp(value, minMB, maxMB);
                scrollbarProgress.size = mb;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // 게임 시작할 때 size를 0으로 한다.
        // 첫번째 지점에 도착했을 때 0.25, 두번째 지점은 0.5, 세번째 지점은 0.75, 게임 종료될 때 1로 한다.
        // 이를 UI에도 표시하고 싶다.
        MB = minMB;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
