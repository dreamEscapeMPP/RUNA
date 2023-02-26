using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stroy;

public class Narration_Item : MonoBehaviour
{
    public string narration;
    public bool isCharaterNarration = false;
    private Narration narration_item;

    void OnMouseDown()
    {
        if (isCharaterNarration)
            StartCoroutine(narration_item.Chat(narration, 2));
        else
            StartCoroutine(narration_item.Charater_Chat(narration, 2));
    }

    // Start is called before the first frame update
    void Start()
    {
        narration_item = GameObject.Find("Stroy").GetComponent<SecondRoomStory>().narration;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
