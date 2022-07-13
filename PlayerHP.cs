using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// �¾ �� ü���� 10���� �ϰ� UI���� ǥ���ϰ� �ʹ�.
// 1�� ������ �� ü���� 1 �����Ѵ�.
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
        // �¾ �� ü���� 10���� �ϰ� UI���� ǥ���ϰ� �ʹ�.
        sliderHP.maxValue = maxHP;
        HP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
