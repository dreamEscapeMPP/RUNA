using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Cam_Object
{
    public class CameraTrans : MonoBehaviour
    {

        GameObject[] View_Camera;

        //메인캠 넣기
        public void SetCamera()
        {
            GameObject[] View_Camera = GameObject.FindGameObjectsWithTag("MainCamera");
            GameObject MainCam = GameObject.Find("Main Camera");
            foreach (var cam in View_Camera)
            {
                cam.GetComponent<Camera>().enabled = false;
            }
            MainCam.GetComponent<Camera>().enabled = true;
        }

        ///클릭 시 해당 객체의 이름을 갖고와서 캠 찾기,
        public void ZoomIn_Object(string Obj_name)
        {
            GameObject MainCam = GameObject.Find("Main Camera");

            MainCam.GetComponent<Camera>().enabled = false;
            GameObject.Find(Obj_name + "_Cam").GetComponent<Camera>().enabled = true;
        }

        // 코루틴 이용해서 알파값 변경
        ///페이드인아웃 하는 법
        public IEnumerator FadeCorutine(Image Fade_Image)
        {
            float fadeCount = 1.0f; //처음 알파값
            int n = 1;
            while (fadeCount > 0) //알파 최대값 1.0, 최소 0까지 반복
            {
                fadeCount -= (0.001f * n++);
                yield return new WaitForSeconds(0.01f); //0.01초마다 실행
                Fade_Image.color = new Color(0, 0, 0, fadeCount); //해당 변수값으로 알파 값 지정
            }
        }

        public IEnumerator FadeOutCorutine(Image Fade_Image)
        {
            float fadeCount = 0.0f; //처음 알파값
            int n = 1;
            while (fadeCount < 1) //알파 최대값 1.0까지 반복
            {
                fadeCount += (0.001f * n++);
                yield return new WaitForSeconds(0.01f); //0.01초마다 실행
                Fade_Image.color = new Color(0, 0, 0, fadeCount); //해당 변수값으로 알파 값 지정
            }
        }
    }
}

//사용시 자주 사용하면 using Cam_Object;
//자주 아니면, Cam_Object.camera_obj cam = new Cam_Object.camera_obj(); 