using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetButton : MonoBehaviour
{
    public GameObject myAlphabet;
    public bool IsUpButton;
    
    void OnMouseDown()
    {
        if (IsUpButton)
            myAlphabet.GetComponent<AlphabetChange>().ChangeUpAlphabet();
        else
            myAlphabet.GetComponent<AlphabetChange>().ChangeDownAlphabet();
        GameObject.Find("story").GetComponent<FiveRoomStory>().CheckFinish();
    }
}
