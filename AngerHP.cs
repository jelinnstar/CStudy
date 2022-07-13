using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ���Ͽ� �ε����� �� �г� �������� 1 ����Ѵ�.
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
        // �¾ �� �г�������� 0���� �ϰ� UI���� ǥ���ϰ� �ʹ�.
        sliderAngerHP.minValue = minANGERHP;
        ANGERHP = minANGERHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
