using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour
{
    public int StageNumber = 1;
    public void Go_HomeScene()
    {
        StartCoroutine(FadeOutHome());
        //SceneManager.LoadScene(0);
    }


    IEnumerator FadeOutHome()
    {
        Cam_Object.CameraTrans Fadeout = new Cam_Object.CameraTrans();
        yield return StartCoroutine(Fadeout.FadeOutCorutine(GameObject.Find("FadeInOutPanel").transform.GetComponent<Image>()));

        SceneManager.LoadScene(0);
    }
}
