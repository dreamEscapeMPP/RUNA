using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockerClear : MonoBehaviour
{
    //보였으면 하는거 위로 쭉올리고, 안보였으면 하는거 쭉 아래에 둔담
    // 보였으면 하는 마지막객체의 순번넣어주기
    public int Start_Obj_index = 3;

    public IEnumerator Set_Active_obj_locker_ver()
    {
        int i = 0;

        while (i < gameObject.transform.childCount)
        {
            if (i < Start_Obj_index)
            {
                gameObject.transform.GetChild(i++).gameObject.SetActive(true);
            }
            else
                gameObject.transform.GetChild(i++).gameObject.SetActive(false);

        }

        yield return null;
    }
}
