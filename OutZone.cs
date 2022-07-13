using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutZone : MonoBehaviour
{
    public Transform startPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("player"))
        {
            other.gameObject.GetComponent<CharacterController>().enabled = false;
            other.transform.position = startPosition.position;
            other.transform.rotation = startPosition.rotation;
            other.gameObject.GetComponent<CharacterController>().enabled = true;
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
