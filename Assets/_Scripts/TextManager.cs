using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    float timer1;
    float timer2;
    [SerializeField] Text gameText = null;

    void Start()
    {
        timer1 = 0f;
    }

    void Update()
    {
        timer1 += Time.deltaTime;
        timer2 += Time.deltaTime;

        if (timer1 < 5f)
        {
            //Steuerung: WASD zum Bewegen, Leertaste zum springen, linke Maustaste zum Verkeinern und rechte Maustaste zum Vergrößern, E zum Aufheben, 1 und 2 zum einstellen der Entfernung beim Aufheben, R zum resetten der Boxen";
            gameText.text = "Willkommen in meiner Welt, Sterblicher.";
        }
        if (timer1 >= 5f && timer1 < 15f)
        {
            gameText.text = "Ich bin die Göttin dieses Dungeons und werde dir helfen, diesen zu verlassen, da ich sehe, dass du wieder in deine alte Welt zurück möchtest.";
        }
        if (timer1 >= 15f && timer1 < 22f)
        {
            gameText.text = "Ich habe dir ein Relikt gegeben mit dem du die molekulare Struktur dieser Holzkisten verändern kannst und sie somit vergrößerst oder verkleinerst.";
        }
        if (timer1 >= 22f && timer1 < 32f)
        {
            gameText.text = "Probiere es mal. Ziele mit der Maus auf eine Holzkiste und drücke rechte Maustaste um diese zu vergrößern und linke Muastaste um sie wieder zu verkleinern.";
        }
        if (timer1 >= 32f && timer1 < 42f)
        {
            gameText.text = "Mit WASD kannst du dich bewegen und mit Leertaste springen. Mit E hebst du die Kisten auf um sie neu zupositionieren.";
        }
        if (timer1 >= 42f && timer1 < 52f)
        {
            gameText.text = "Achja. Sollte mal eine Holzkiste verschwinden und du kommst nicht mehr weiter, kannst du mit R die Kisten wieder erscheinen lassen.";
        }
        if (timer1 >= 52f && timer1 < 60f)
        {
            gameText.text = "Versuche nun einige Rätsel in den nächsten Räumen zu lösen.";
        }

        if (timer2 >= 15f && timer1 >= 60f)
        {
            gameText.text = "";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "TextResetZone1")
        {
            timer2 = 0;
            gameText.text = "Nicht schlecht. Du kannst mit den Tasten 1 und 2 auch die Entfernung der Kisten bestimmen, wenn du sie hältst, um sie besser zu positionieren.";
        }
        if (other.gameObject.name == "TextResetZone3")
        {
            timer2 = 0;
            gameText.text = "Doch gar nicht so Dumm wie ich dachte, aber ein paar Rätsel warten noch auf dich. Und vergiss nich das du 1 und 2 für die Entfernung drücken kannst, das wird jetzt wichtig";
        }
        if (other.gameObject.name == "TextResetZone5")
        {
            timer2 = 0;
            gameText.text = "Das letzte Rätsel. Zeige mir was du mit den Kisten gelernt hast und ich werde dich mit einem Schatz belohnen und wieder in deine Welt schicken.";
        }
        if (other.gameObject.name == "TextResetZone6")
        {
            timer2 = 0;
            gameText.text = "Da ist der Schatz.";
        }
        if (other.gameObject.name == "TextResetZone7")
        {
            timer2 = 0;
            gameText.text = "Oder auch nicht. Der ist nur eine Illusion und du wirst in diesem Raum elendig verrecken. Viel vergnügen, kannst dich ja zu den anderen beiden in den Ecken setzen. DAS IST DEIN ENDE! und mit Escape kannst du das Spiel beenden.";
        }
    }
}
