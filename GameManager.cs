using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

   public GameObject gameOverUI;
  
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.gameOverUI.SetActive(false);
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickQuit()
    {
        print("OnClickQuit");
        Application.Quit();
    }
    public void OnClickRestart()
    {
        print("OnClickRestart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
