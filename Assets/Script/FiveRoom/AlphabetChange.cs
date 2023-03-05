using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetChange : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[6];
    public int alphabet_num = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeUpAlphabet()
    {
        alphabet_num++;
        if (alphabet_num == 6)
            alphabet_num = 0;
        Debug.Log(alphabet_num);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[alphabet_num];
    }

    public void ChangeDownAlphabet()
    {
        alphabet_num--;
        if (alphabet_num == -1)
            alphabet_num = 5;
        Debug.Log(alphabet_num);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[alphabet_num];
    }
}
