using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NextScene;
public class OpenLockerCheck : MonoBehaviour
{
    public GameObject door;  //문 콜라이더가 담긴 객체
    public Sprite ClearViewImage;  //ex금고, 열린 이미지
    //1.061431f ,-23.94382f
    public Vector3 ImagePosition_changed = new Vector3(0, 0, -0.01f);  //조정했으면 하는 위치로


    public void setViewClear()
    {
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<SpriteRenderer>().sprite = ClearViewImage;
        gameObject.transform.position = ImagePosition_changed;
        StartCoroutine(gameObject.transform.parent.GetComponent<lockerClear>().Set_Active_obj_locker_ver());
        door.GetComponent<ClearNNext>().Change_backgournd_Sprite();
    }
}
