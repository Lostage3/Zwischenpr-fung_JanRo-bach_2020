using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] bool IsStart;
    [SerializeField] bool IsQuit;
    void OnMouseUp()
    {
        if (IsStart)
        {
            SceneManager.LoadScene("LevelScene", LoadSceneMode.Single);
        }

        if (IsQuit)
        {
            Application.Quit();
        }
    }
}
