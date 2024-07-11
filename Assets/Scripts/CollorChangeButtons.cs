using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollorChangeButtons : MonoBehaviour
{
    public enum ColorChoose { Red, Green, Blue};

    public ColorChoose neededColor;
    public int changeTo;


    private LaserColorChanger laserScript;

    private void Awake()
    {
        laserScript = GameObject.Find("LaserIndicator").GetComponent<LaserColorChanger>();
    }

    private void ChangeColor(bool doChange) // Calls changing colors functions, depending on type of the button
    {
        switch (neededColor)
        {
            case ColorChoose.Red:
                laserScript.changeRed(changeTo, doChange);
                break;
            case ColorChoose.Green:
                laserScript.changeGreen(changeTo, doChange);
                break;
            case ColorChoose.Blue:
                laserScript.changeBlue(changeTo, doChange);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) ChangeColor(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) ChangeColor(false);
    }
}
