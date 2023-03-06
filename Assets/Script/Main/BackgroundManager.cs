using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public Sprite[] background = new Sprite[7];

    // Start is called before the first frame update
    void Start()
    {
        int saveStage = PlayerPrefs.GetInt("saveStage");
        this.gameObject.GetComponent<SpriteRenderer>().sprite = background[saveStage];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
