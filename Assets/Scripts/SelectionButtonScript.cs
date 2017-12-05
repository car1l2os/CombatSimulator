using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionButtonScript : MonoBehaviour, IPointerClickHandler
{

    MenuScript menuScript;

    private void Start()
    {
        menuScript = GameObject.Find("CombatSimulator").GetComponent<MenuScript>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            menuScript.deleteFromDataBase(Int32.Parse(this.name));
        }
    }
}

