using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 지니와 부딪혔을 때 분노 게이지가 1 상승한다.
public class AngerHP : MonoBehaviour
{
    public int minANGERHP = 0;
    public int maxANGERHP = 10;
    int ahp;
    public Slider sliderAngerHP;
    
    public int ANGERHP
    {
        get { return ahp; }
        set
        {
            ahp = value;
            sliderAngerHP.value = ahp;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // 태어날 때 분노게이지를 0으로 하고 UI에도 표시하고 싶다.
        sliderAngerHP.minValue = minANGERHP;
        ANGERHP = minANGERHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
