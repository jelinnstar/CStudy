using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 태어날 때 체력을 10으로 하고 UI에도 표시하고 싶다.
// 1번 점프할 때 체력이 1 감소한다.
public class PlayerHP : MonoBehaviour
{
    public int maxHP = 10;
    int hp;
    public Slider sliderHP;
    public int HP
    {
        get { return hp; }
        set { hp = value;
            sliderHP.value = hp;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // 태어날 때 체력을 10으로 하고 UI에도 표시하고 싶다.
        sliderHP.maxValue = maxHP;
        HP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
