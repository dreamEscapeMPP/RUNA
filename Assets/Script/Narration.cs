using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Stroy
{
    public class Narration : MonoBehaviour
    {
        private string writwer_Text; // ������ְ� ���� ���
        private Text ChatText_UI; // ��ȭâ UI
        private Image Right_Image; // ������ ĳ���� �̹���
        private Image Left_Image; // ���� ĳ���� �̹���

        public void All_Off()
        {
            ChatText_UI.enabled = false;
            Right_Image.enabled = false;
            Left_Image.enabled = false;
        }

        public void UI_set(Text UI) // UI ��ȭâ ����
        {
            ChatText_UI = UI;
        }

        public void UI_On() // UI ��ȭâ Off
        {
            ChatText_UI.enabled = true;
        }

        public void UI_Off() // UI ��ȭâ On
        {
            ChatText_UI.enabled = false;
        }

        public void Right_Image_set(Image right_img) // ������ ĳ���� �̹��� ����
        {
            Right_Image = right_img;
        }

        public void Right_Image_On() // ������ ĳ���� �̹��� On
        {
            Right_Image.enabled = true;
        }

        public void Right_Image_Off() // ������ ĳ���� �̹��� Off
        {
            Right_Image.enabled = false;
        }

        public void Left_Image_set(Image left_img) // ���� ĳ���� �̹��� ����
        {
            Left_Image = left_img;
        }

        public void Left_Image_On() // ���� ĳ���� �̹��� On
        {
            Left_Image.enabled = true;
        }

        public void Left_Image_Off() // ���� ĳ���� �̹��� Off
        {
            Left_Image.enabled = false;
        }

        public IEnumerator Chat(string narrator, float finish_stop_time) // ��� ������ִ� ���
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
