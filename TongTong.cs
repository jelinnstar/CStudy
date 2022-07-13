using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongTong : MonoBehaviour
{
    public AnimationCurve ac;
    Vector3 origin;
    float current;
    public float maxHeight = 2;
    public float jumpSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        origin = Vector3.zero;
        current = 1;
    }

    public void Jump()
    {
        if (current >= 1)
        {
            current = 0;
        }
    }

    public void CancelJump()
    {
        current = 1;
    }

    // Update is called once per frame
    void Update()
    {
        current += Time.deltaTime * jumpSpeed;
        if (current > 1)
        {
            current = 1;
        }

        float t = ac.Evaluate(current);

        transform.localPosition = origin + new Vector3(0, t * maxHeight, 0);
    }
}
