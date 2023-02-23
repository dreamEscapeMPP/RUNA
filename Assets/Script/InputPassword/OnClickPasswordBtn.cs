using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//비번 눌러지는 곳에 각각 넣기
public class OnClickPasswordBtn : MonoBehaviour
{
    //자신의 값 넣기
    public int myNumberPassword;

    //입력되는 거 넣기
    public GameObject LockerPasswordObj;

    void OnMouseDown()
    {
        LockerPasswordObj.GetComponent<password_locke>().Add_inputPassword(myNumberPassword);
    }
}
