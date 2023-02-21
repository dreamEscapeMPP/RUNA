using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//빈객체에 넣고, 검정 페이드인아웃될 UI추가
namespace Cam_Object
{
    public class camera_Movement : MonoBehaviour
    {
        public Image Black_Image; //검정 이미지
        CameraTrans camera;

        void Start()
        {
            camera = new CameraTrans();
            camera.SetCamera();  //메인카메라 셋팅(기본으로 돌아갈 카메라)
        }


        //Call FadeInOut
        public void Call_FadeInOut()
        {
            //Fadeinout실행
            StartCoroutine(camera.FadeCorutine(Black_Image));
        }
    }
}