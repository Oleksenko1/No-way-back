using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserColorChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public float changeSpeed;
    public Material material;
    public UIColorChangeText uiColorChangeText;

    public int red, green, blue;
    public bool isRed, isGreen, isBlue;

    private void Awake()
    {
        material.color = Color.white;
        uiColorChangeText.changeUIColorValues(new Vector3(material.color.r, material.color.g, material.color.b));
    }
    void Update() // Slowly changes colors
    {
        if(isRed)
        {
            material.color = new Color(Mathf.MoveTowards(material.color.r, red, changeSpeed * Time.deltaTime), material.color.g, material.color.b);
        }
        else if (isGreen)
        {
            material.color = new Color(material.color.r, Mathf.MoveTowards(material.color.g, green, changeSpeed * Time.deltaTime), material.color.b);
        }
        else if (isBlue)
        {
            material.color = new Color(material.color.r, material.color.g, Mathf.MoveTowards(material.color.b, blue, changeSpeed * Time.deltaTime));
        }

        if(isRed || isGreen || isBlue)
        {
            uiColorChangeText.changeUIColorValues(new Vector3(material.color.r, material.color.g, material.color.b));
        }
    }
    public void changeRed(int x, bool doChange)
    {
        red = x;
        isRed = doChange;
    }
    public void changeGreen(int x, bool doChange)
    {
        green = x;
        isGreen = doChange;
    }
    public void changeBlue(int x, bool doChange)
    {
        blue = x;
        isBlue = doChange;
    }
}
