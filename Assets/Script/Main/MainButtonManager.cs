using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(2340, 1080, true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickExit()
    {
        Application.Quit();
        Debug.Log("OnClickExit");
    }

    public void StartNewGame()
    {
        Debug.Log("StartNewGame");
        SceneManager.LoadScene(1);
    }

    public void ReLoadGame()
    {
        Debug.Log("ReLoadGame");
        int saveStage = PlayerPrefs.GetInt("saveStage"); // �ҷ��ö�
        // PlayerPrefs.SetInt("saveStage", 1); �����Ҷ� 
        SceneManager.LoadScene(saveStage);
    }
    
}