using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stroy;

public class Narration_Item : MonoBehaviour
{
    public string narration;
    public bool isCharaterNarration = false;

    void OnMouseDown()
    {
        if (isCharaterNarration)
            StartCoroutine(Narration.instance.Charater_Chat(narration, 2));
        else
            StartCoroutine(Narration.instance.Chat(narration, 2));
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
