using UnityEngine;
using System.Collections;

public class WinScript : MonoBehaviour {
    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200, 100), "You beat the game!");
    }
}
