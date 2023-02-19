using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Stroy
{
    public class Narration : MonoBehaviour
    {
        private string writwer_Text; // 출력해주고 싶은 대사
        private Text ChatText_UI; // 대화창 UI
        private Image Right_Image; // 오른쪽 캐릭터 이미지
        private Image Left_Image; // 왼쪽 캐릭터 이미지

        public void All_Off()
        {
            ChatText_UI.enabled = false;
            Right_Image.enabled = false;
            Left_Image.enabled = false;
        }

        public void UI_set(Text UI) // UI 대화창 설정
        {
            ChatText_UI = UI;
        }

        public void UI_On() // UI 대화창 Off
        {
            ChatText_UI.enabled = true;
        }

        public void UI_Off() // UI 대화창 On
        {
            ChatText_UI.enabled = false;
        }

        public void Right_Image_set(Image right_img) // 오른쪽 캐릭터 이미지 설정
        {
            Right_Image = right_img;
        }

        public void Right_Image_On() // 오른쪽 캐릭터 이미지 On
        {
            Right_Image.enabled = true;
        }

        public void Right_Image_Off() // 오른쪽 캐릭터 이미지 Off
        {
            Right_Image.enabled = false;
        }

        public void Left_Image_set(Image left_img) // 왼쪽 캐릭터 이미지 설정
        {
            Left_Image = left_img;
        }

        public void Left_Image_On() // 왼쪽 캐릭터 이미지 On
        {
            Left_Image.enabled = true;
        }

        public void Left_Image_Off() // 왼쪽 캐릭터 이미지 Off
        {
            Left_Image.enabled = false;
        }

        public IEnumerator Chat(string narrator, float finish_stop_time) // 대사 출력해주는 기능
        {
            int a = 0;
            writwer_Text = "";
            for (a = 0; a < narrator.Length; a++)
            {
                writwer_Text += narrator[a];
                ChatText_UI.text = writwer_Text;
                yield return new WaitForSeconds(0.05f);
            }
            //ChatText.text = narrator;
            yield return new WaitForSeconds(finish_stop_time);
        }
    }
}
