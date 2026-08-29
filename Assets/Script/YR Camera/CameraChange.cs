using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//각각 객체에 넣어질 스크립트
namespace Cam_Object
{
    public class CameraChange : MonoBehaviour
    {

        private void OnMouseDown()
        {
            camera_Movement mover = GameObject.Find("GameManager_CamMove").GetComponent<camera_Movement>();

            // 페이드 도중 연타하면 깜빡임이 겹치므로 무시
            if (mover.IsFading) return;

            // 화면이 완전히 검어진 순간에 카메라를 바꾼다
            mover.Call_FadeInOut(SwitchCamera);
        }

        void SwitchCamera()
        {
            if (gameObject.CompareTag("backScene"))
                Change_Camera_backView();
            else if (gameObject.CompareTag("bookScene"))
                Change_Camera_BookView();
            else
                Change_Camera_objView();
        }

        public void Change_Camera_objView()
        {
            CameraTrans camera = new CameraTrans();
            camera.ZoomIn_Object(gameObject.name);
        }
        public void Change_Camera_backView()
        {
            CameraTrans camera = new CameraTrans();
            camera.SetCamera();
        }
        public void Change_Camera_BookView()
        {
            CameraTrans camera = new CameraTrans();
            camera.ZoomIn_EachObject("book");
        }
    }
}
