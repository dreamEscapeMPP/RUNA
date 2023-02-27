using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    public static ChangeBackground instance;
    void Awake()
    {
        instance = this;
    }
    public static int CardCount = 0;
    static bool onceCall = true;

    public GameObject door_background;
    void Start()
    {
        door_background = GameObject.Find("background");
    }
    void OnMouseDown()
    {
        if (onceCall)
        {
            if (CardCount == 4)
            {
                StartCoroutine(door_background.GetComponent<FlickerBackImage>().FlickerImage());
                onceCall = false;
            }

        }
    }
}
