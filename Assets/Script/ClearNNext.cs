using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NextScene
{
    //문쪽 (나가는 곳)빈객체(콜라이더 생성 후 콜라이더 체크해제)에 넣기
    public class ClearNNext : MonoBehaviour
    {
        public string Next_Scene_Name; //다음 씬 이름 넣어주기
        public Sprite Clear_background_change;  //문 열린 이미지 넣어주기

        GameObject background;

        void Start()
        {
            background = GameObject.Find("background");
        }

        private void OnMouseDown()
        {
            Change_nextScene();
        }

        //이미지 바꾸기
        public void Change_backgournd_Sprite()
        {
            background.GetComponent<SpriteRenderer>().sprite = Clear_background_change;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }

        public void Change_nextScene()
        {
            SceneManager.LoadScene(Next_Scene_Name, LoadSceneMode.Single);
        }
    }

}