using System;
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
        [Tooltip("검게 덮는 시간(초)")]
        public float fadeOutDuration = 0.2f;
        [Tooltip("다시 밝아지는 시간(초)")]
        public float fadeInDuration = 0.3f;

        CameraTrans camera_;
        Coroutine running;

        void Start()
        {
            camera_ = new CameraTrans();
            camera_.SetCamera();  //메인카메라 셋팅(기본으로 돌아갈 카메라)
            if (Black_Image != null)
            {
                Black_Image.raycastTarget = false; // 페이드 이미지가 클릭을 가로채지 않도록
                Color c = Black_Image.color;
                Black_Image.color = new Color(c.r, c.g, c.b, 0f);
            }
        }

        // 전환 중인지 (전환 중 추가 클릭 무시용)
        public bool IsFading { get { return running != null; } }

        /// <summary>검게 덮은 상태에서 onBlack(카메라 전환)을 실행하고 다시 밝힌다.</summary>
        public void Call_FadeInOut(Action onBlack)
        {
            if (running != null) StopCoroutine(running);
            running = StartCoroutine(Run(onBlack));
        }

        // 기존 호환: 검게 → 밝아짐
        public void Call_FadeInOut()
        {
            Call_FadeInOut(null);
        }

        IEnumerator Run(Action onBlack)
        {
            yield return CameraTrans.FadeTransition(Black_Image, onBlack, fadeOutDuration, fadeInDuration);
            running = null;
        }
    }
}
