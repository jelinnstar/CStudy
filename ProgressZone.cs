using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressZone : MonoBehaviour
{
    public float progressValue;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("player"))
        {
            MapBar.instance.MB = progressValue;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
