using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerController : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartStage()
    {
        
    }
    public void NextStage(string s)
    {
        SceneManager.LoadScene(s);
    }
    public void ReStartStage()
    {
        Scene sceneName = SceneManager.GetActiveScene();
        SceneManager.LoadScene(sceneName.name);
    }
    public void Setting()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("Setting", LoadSceneMode.Additive);
    }
}
