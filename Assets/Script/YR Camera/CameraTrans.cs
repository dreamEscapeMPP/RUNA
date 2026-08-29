using System;
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
        public void ZoomIn_EachObject(string Obj_name)
        {
            SetCamera();

            GameObject MainCam = GameObject.Find("Main Camera");

            MainCam.GetComponent<Camera>().enabled = false;
            GameObject.Find(Obj_name + "_Cam").GetComponent<Camera>().enabled = true;
        }

        // ---------------------------------------------------------------
        // 페이드
        // 예전 구현은 0.01초마다 알파를 점점 큰 폭으로 빼는 방식이라 프레임 속도에 따라
        // 밝기가 툭툭 튀며 깜빡였다. 지금은 시간(Time.deltaTime) 기준으로 SmoothStep 보간한다.
        // ---------------------------------------------------------------

        public const float DefaultFadeDuration = 0.25f;

        /// <summary>from → to 로 알파를 duration 초 동안 부드럽게 보간</summary>
        public static IEnumerator FadeAlpha(Image Fade_Image, float from, float to, float duration)
        {
            if (Fade_Image == null) yield break;
            Color c = Fade_Image.color;
            if (duration <= 0f)
            {
                Fade_Image.color = new Color(c.r, c.g, c.b, to);
                yield break;
            }
            float t = 0f;
            Fade_Image.color = new Color(c.r, c.g, c.b, from);
            while (t < duration)
            {
                t += Time.deltaTime;
                float a = Mathf.Lerp(from, to, Mathf.SmoothStep(0f, 1f, Mathf.Clamp01(t / duration)));
                Fade_Image.color = new Color(c.r, c.g, c.b, a);
                yield return null;
            }
            Fade_Image.color = new Color(c.r, c.g, c.b, to);
        }

        /// <summary>
        /// 카메라 전환용: 검게 덮은 뒤(onBlack 실행) 다시 밝힌다.
        /// 카메라를 바꾸는 순간이 화면이 완전히 검을 때이므로 전환이 눈에 띄지 않는다.
        /// </summary>
        public static IEnumerator FadeTransition(Image Fade_Image, Action onBlack, float fadeOut = DefaultFadeDuration, float fadeIn = DefaultFadeDuration)
        {
            yield return FadeAlpha(Fade_Image, 0f, 1f, fadeOut);
            if (onBlack != null) onBlack();
            yield return FadeAlpha(Fade_Image, 1f, 0f, fadeIn);
        }

        // 검정(알파1) → 투명(알파0). 기존 호출부 호환용.
        public IEnumerator FadeCorutine(Image Fade_Image)
        {
            yield return FadeAlpha(Fade_Image, 1f, 0f, DefaultFadeDuration);
        }

        // 투명(알파0) → 검정(알파1). 씬 전환 전에 사용. 기존 호출부 호환용.
        public IEnumerator FadeOutCorutine(Image Fade_Image)
        {
            yield return FadeAlpha(Fade_Image, 0f, 1f, DefaultFadeDuration * 2f);
        }
    }
}

//사용시 자주 사용하면 using Cam_Object;
//자주 아니면, Cam_Object.camera_obj cam = new Cam_Object.camera_obj();
