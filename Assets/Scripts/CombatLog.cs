using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatLog : MonoBehaviour
{
    // Private VARS
    private List<string> Eventlog = new List<string>();
    private string guiText = "";

    public bool visible = false;

    // Public VARS
    public int maxLines = 10;

    void OnGUI()
    {
        if(visible)
            GUI.Label(new Rect(0, 0, Screen.width, Screen.height), guiText, GUI.skin.textArea);
    }

    public void AddEvent(string eventString)
    {
        Eventlog.Add(eventString);

        if (Eventlog.Count >= maxLines)
            Eventlog.RemoveAt(0);

        guiText = "";

        foreach (string logEvent in Eventlog)
        {
            guiText += logEvent;
            guiText += "\n";
        }
    }
}

