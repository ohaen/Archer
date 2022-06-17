using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum ColorType
    {
        RED,
        BLUE,
    }

    public ColorType colorType = ColorType.BLUE;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Å¬¸¯!");
        }
    }
}