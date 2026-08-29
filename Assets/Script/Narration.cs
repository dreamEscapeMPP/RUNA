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

        [Header("타이핑 설정")]
        [Tooltip("글자 하나가 출력되는 간격(초)")]
        public float typingInterval = 0.05f;
        [Tooltip("대사를 다 보여준 뒤 클릭이 없어도 자동으로 넘어가는 시간(초). 0 이하이면 클릭할 때까지 기다림")]
        public float autoAdvanceTime = 0f;

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

        public void UI_On() // UI 대화창 On
        {
            ChatText_bar.SetActive(true);
        }

        public void UI_Off() // UI 대화창 Off
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

        // 클릭(터치) 여부. Old Input Manager 기준이며 모바일 터치도 마우스 0번 버튼으로 들어온다.
        static bool Clicked()
        {
            return Input.GetMouseButtonDown(0);
        }

        /// <summary>
        /// 대사를 한 글자씩 출력한다.
        /// - 출력 중 클릭: 남은 글자를 즉시 전부 보여준다.
        /// - 전부 보여준 뒤 클릭: 다음으로 넘어간다. (autoAdvanceTime > 0 이면 그 시간 뒤 자동으로 넘어감)
        /// </summary>
        IEnumerator TypeAndWait(string narrator, float finish_stop_time)
        {
            // 대사를 시작시킨 클릭이 같은 프레임에 스킵으로 잡히지 않도록 한 프레임 넘긴다.
            yield return null;

            ChatText_UI.text = "";
            writwer_Text = "";
            AudioSource typingSound = ChatText_bar.GetComponent<AudioSource>();
            if (typingSound != null) typingSound.Play();

            float timer = 0f;
            int shown = 0;
            while (shown < narrator.Length)
            {
                if (Clicked())
                {
                    // 스킵: 전체 대사 즉시 표시
                    shown = narrator.Length;
                    ChatText_UI.text = narrator;
                    break;
                }

                timer += Time.deltaTime;
                while (timer >= typingInterval && shown < narrator.Length)
                {
                    timer -= typingInterval;
                    shown++;
                    ChatText_UI.text = narrator.Substring(0, shown);
                }
                yield return null;
            }
            writwer_Text = narrator;
            if (typingSound != null) typingSound.Stop();

            // 스킵에 사용된 클릭이 곧바로 다음 대사로 인식되지 않도록 한 프레임 넘긴다.
            yield return null;

            // 다음 대사로 넘어갈 때까지 대기 (클릭 또는 자동 진행 시간)
            bool useTimeout = autoAdvanceTime > 0f;
            float waited = 0f;
            while (true)
            {
                if (Clicked()) break;
                if (useTimeout)
                {
                    waited += Time.deltaTime;
                    if (waited >= autoAdvanceTime) break;
                }
                yield return null;
            }
        }

        public IEnumerator Chat(string narrator, float finish_stop_time) // 시스템 대사 보여주는 함수
        {
            panel.SetActive(true);
            UI_On();
            ChatText_Name_UI.text = "System";
            yield return TypeAndWait(narrator, finish_stop_time);
            UI_Off();
            panel.SetActive(false);
        }

        public IEnumerator EndingChat(string narrator, float finish_stop_time) // 엔딩 내레이션 전용
        {
            panel.SetActive(false);
            UI_On();
            ChatText_Name_UI.text = "Stella";
            yield return TypeAndWait(narrator, finish_stop_time);
            UI_Off();
        }

        public IEnumerator Charater_Chat(string narrator, float finish_stop_time) // 캐릭터 대사 보여주는 함수
        {
            panel.SetActive(true);
            UI_On();
            Right_Image_On();
            ChatText_Name_UI.text = "Stella";
            yield return TypeAndWait(narrator, finish_stop_time);
            UI_Off();
            Right_Image_Off();
            panel.SetActive(false);
        }
    }
}
