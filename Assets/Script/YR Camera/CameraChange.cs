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
            GameObject.Find("GameManager_CamMove").GetComponent<camera_Movement>().Call_FadeInOut();
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
