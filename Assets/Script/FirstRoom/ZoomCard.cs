using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCard : MonoBehaviour
{
    public GameObject zoom_obj;
    public bool zoominout_check = true;

    private void OnMouseDown()
    {
        if (zoominout_check)
            zoomIn_obj();
        else
            zoomOut_obj();
    }

    private void zoomIn_obj()
    {
        zoom_obj.SetActive(true);
    }

    private void zoomOut_obj()
    {
        gameObject.SetActive(false);
    }

}
