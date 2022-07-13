using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZone : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("player"))
        {
            GameManager.instance.gameOverUI.SetActive(true);
            Timer.instance.StopTimer();
        }
    }
}
