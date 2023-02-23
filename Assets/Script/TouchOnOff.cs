using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchOnOff : MonoBehaviour
{
    private int Child_Count = 0;
    void Start()
    {
        Child_Count = gameObject.transform.childCount;
        OffEnableColider2D();
    }

    public void OnEnableColider2D()
    {
        for (int i = 0; i < Child_Count; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void OffEnableColider2D()
    {
        for (int i = 0; i < Child_Count; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
