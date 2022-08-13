using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //This is Menu
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        Debug.Log("NewGame");
        SceneManager.LoadScene("Stage1");
    }
    public void LoadGame()
    {
        Debug.Log("LoadGame");
        
    }
    public void Setting()
    {
        Debug.Log("Setting");
        SceneManager.LoadScene("Setting",LoadSceneMode.Additive);
    }
    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
