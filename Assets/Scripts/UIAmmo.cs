using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAmmo : MonoBehaviour
{
    private Text ammoText;

    private void Awake()
    {
        ammoText = GetComponent<Text>();
    }
    public void UpdateAmmoUI(Vector2 ammo) // X - current clip, Y - max xlip size
    {
        ammoText.text = $"{ammo.x}/{ammo.y}";
    }
    
}
