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
        private Text ChatText_Name_UI; // 대화창 UI
        private GameObject ChatText_bar; // 대화창 UI
        private Image Right_Image; // 오른쪽 캐릭터 이미지
        private GameObject panel;
        //private Image Left_Image; // 왼쪽 캐릭터 이미지

        public static Narration instance;

        private void Awake()
        {
            instance = this;
            panel = GameObject.Find("Panel");
            ChatText_Name_UI = GameObject.Find("Name_Text").GetComponent<Text>();
            ChatText_UI = GameObject.Find("Text").GetComponent<Text>();
            ChatText_bar = GameObject.Find("TextBarImg");
            Right_Image = GameObject.Find("right_img").GetComponent<Image>();
            //Left_Image = GameObject.Find("left_img").GetComponent<Image>();
            All_Off();
        }

        public void All_Off()
        {
            ChatText_bar.SetActive(false);
            Right_Image.enabled = false;
            //Left_Image.enabled = false;
        }

        public void UI_set(GameObject chattext_bar) // UI 대화창 설정
        {
            ChatText_bar = chattext_bar;
            ChatText_UI = ChatText_bar.transform.GetChild(0).GetComponent<Text>();
        }

        public void UI_On() // UI 대화창 Off
        {
            ChatText_bar.SetActive(true);
        }

        public void UI_Off() // UI 대화창 On
        {
            ChatText_bar.SetActive(false);
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
            //Left_Image = left_img;
        }

        public void Left_Image_On() // 왼쪽 캐릭터 이미지 On
        {
            //Left_Image.enabled = true;
        }

        public void Left_Image_Off() // 왼쪽 캐릭터 이미지 Off
        {
            //Left_Image.enabled = false;
        }

        public IEnumerator Chat(string narrator, float finish_stop_time) // 시스템 대사 출력해주는 기능
        {
            panel.SetActive(true);
            UI_On();
            ChatText_bar.GetComponent<AudioSource>().Play();
            int a = 0;
            ChatText_Name_UI.text = "System";
            writwer_Text = "";
            for (a = 0; a < narrator.Length; a++)
            {
                writwer_Text += narrator[a];
                ChatText_UI.text = writwer_Text;
                yield return new WaitForSeconds(0.05f);
            }
            //ChatText.text = narrator;
            yield return new WaitForSeconds(finish_stop_time);
            ChatText_bar.GetComponent<AudioSource>().Stop();
            UI_Off();
            panel.SetActive(false);
        }

        public IEnumerator EndingChat(string narrator, float finish_stop_time) // 엔딩 나레이션 설정
        {
            panel.SetActive(false);
            UI_On();
            ChatText_bar.GetComponent<AudioSource>().Play();
            int a = 0;
            ChatText_Name_UI.text = "Name";
            writwer_Text = "";
            for (a = 0; a < narrator.Length; a++)
            {
                writwer_Text += narrator[a];
                ChatText_UI.text = writwer_Text;
                yield return new WaitForSeconds(0.05f);
            }
            //ChatText.text = narrator;
            yield return new WaitForSeconds(finish_stop_time);
            ChatText_bar.GetComponent<AudioSource>().Stop();
            UI_Off();
        }

        public IEnumerator Charater_Chat(string narrator, float finish_stop_time) // 캐릭터 대사 출력해주는 기능
        {
            panel.SetActive(true);
            UI_On();
            Right_Image_On();
            ChatText_bar.GetComponent<AudioSource>().Play();
            int a = 0;
            writwer_Text = "";
            ChatText_Name_UI.text = "Name";
            for (a = 0; a < narrator.Length; a++)
            {
                writwer_Text += narrator[a];
                ChatText_UI.text = writwer_Text;
                yield return new WaitForSeconds(0.05f);
            }
            //ChatText.text = narrator;
            yield return new WaitForSeconds(finish_stop_time);
            ChatText_bar.GetComponent<AudioSource>().Stop();
            UI_Off();
            Right_Image_Off();
            panel.SetActive(false);
        }
    }
}
