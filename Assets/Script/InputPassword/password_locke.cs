using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//비밀번호 입력 나타나는 곳에 넣기 설정 ㄴㄴ
public class password_locke : MonoBehaviour
{

    public GameObject passwordObj;      //열릴 이미지를 바꿀 오브젝트 넣기
    public List<int> password = new List<int>() { 1, 2, 2, 7 };
    private bool password_ch = false;
    private int password_Count = 0;

    private List<int> inputPassword = new List<int>();


    public void Add_inputPassword(int Number)
    {
        inputPassword.Add(Number);
        gameObject.transform.GetChild(password_Count).gameObject.SetActive(true);
        password_Count++;
        if (password_Count == 4)
        {
            password_Count = 0;
            StartCoroutine(Compare_password());
        }

    }

    private void delete_inputPassword()
    {
        inputPassword.Clear();

        gameObject.transform.GetChild(3).gameObject.SetActive(false);
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);

    }

    IEnumerator Compare_password()
    {
        yield return new WaitForSeconds(0.2f);
        if (password[0] == inputPassword[0] && password[1] == inputPassword[1] && password[2] == inputPassword[2] && password[3] == inputPassword[3])
        {
            password_ch = true;
            passwordObj.GetComponent<OpenLockerCheck>().setViewClear();
        }
        else
        {
            delete_inputPassword();
        }

        yield return new WaitForSeconds(0.3f);
        inputPassword.Clear();
    }



}
