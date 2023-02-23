using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cam_Object;

public class ExCameraTrans : MonoBehaviour
{
    public Image Black_Image; //검정 이미지
    CameraTrans camera_;

    //예시
    public Camera camera1;
    public Camera camera2;

    void Start()
    {
        camera_ = new CameraTrans();

        // Disable camera 2 by default
        camera2.enabled = false;
    }
    void Update()
    {
        //예시
        if (Input.GetKeyDown("f"))
        {
            camera1.enabled = !camera1.enabled;
            Call_FadeInOut();
            camera2.enabled = !camera2.enabled;
        }
    }

    //Call FadeInOut
    public void Call_FadeInOut()
    {
        //Fadeinout실행
        StartCoroutine(camera_.FadeCorutine(Black_Image));
    }
}
