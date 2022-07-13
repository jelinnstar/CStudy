using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ��� ������ �������� �� �� ��� ���ִ��� Map Bar���� �����ش�.(�� 3�� ����)
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
        // ���� ������ �� size�� 0���� �Ѵ�.
        // ù��° ������ �������� �� 0.25, �ι�° ������ 0.5, ����° ������ 0.75, ���� ����� �� 1�� �Ѵ�.
        // �̸� UI���� ǥ���ϰ� �ʹ�.
        MB = minMB;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
