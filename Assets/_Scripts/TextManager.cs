using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    float timer;
    [SerializeField] Text gameText = null;

    void Start()
    {
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer < 30f)
        {
            gameText.text = "Steuerung: WASD zum Bewegen, Umschalt zum Sprinten, Leertaste zum springen, linke Maustaste zum Verkeinern und rechte Maustaste zum Vergrößern, E zum Aufheben, 1 und 2 zum einstellen der Entfernung beim Aufheben";
        }
        if(timer >= 30f)
        {
            gameText.text = "";
        }
    }
}
