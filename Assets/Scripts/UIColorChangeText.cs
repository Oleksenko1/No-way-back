using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIColorChangeText : MonoBehaviour
{
    private Text txt;

    Vector3 colorValues;
    public Vector3 ColorValues
    {
        get
        {
            return colorValues;
        }
        set
        {
            colorValues = value;
            changeText();
        }
    }
    private void Awake()
    {
        txt = GetComponent<Text>();
    }
    public void changeUIColorValues(Vector3 vec3) // Calculates color values for UI
    {
        int x = (int)Mathf.Lerp(0, 100, vec3.x);
        int y = (int)Mathf.Lerp(0, 100, vec3.y);
        int z = (int)Mathf.Lerp(0, 100, vec3.z);
        ColorValues = new Vector3(x, y, z);
    }
    void changeText()
    {
        txt.text = $"Red: {ColorValues.x}\nGreen: {ColorValues.y}\nBlue: {ColorValues.z}";
    }
}
