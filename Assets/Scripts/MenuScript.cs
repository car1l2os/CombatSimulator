﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    public GameObject firstMenu;
    public GameObject secondMenu;
	public GameObject thirdMenu;

	public InputField ID;
	public InputField Hp;
	public InputField Acc;
	public InputField Strenght;
	public InputField Power;
	public InputField criticalchance;
	public InputField agility;
	public InputField shield;

    public Database database;

    private int loading = 0;
	private int creating = 0;

    private Character player_1;
    private Character player_2;

	//private Character CreatedPlayer;

    private CombatSimulator combatSimulator;

	// Use this for initialization
	void Start () {
        combatSimulator = GetComponent<CombatSimulator>();
        database = GetComponent<Database>();

        for(int i=0;i<secondMenu.transform.childCount;i++)
        {
            string id = "-";
            if(database.getCharacterById(i) != null)
            {
                id = database.getCharacterById(i).ID.ToString();
            }

            secondMenu.transform.GetChild(i).GetComponentInChildren<Text>().text = id;
        }
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(player_1);
        Debug.Log(player_2);
	}


    void changeMenu()
    {
        firstMenu.SetActive(!firstMenu.activeSelf);
        secondMenu.SetActive(!firstMenu.activeSelf);
    }

    public void loadButton_1()
    {
        changeMenu();
        loading = 1;
    }

	public void submitButton()
	{
		thirdMenu.SetActive(false);
        firstMenu.SetActive(true);
        secondMenu.SetActive(false);
        Character CreatedPlayer = new Character (float.Parse(ID.text),float.Parse(Hp.text),float.Parse(Acc.text),float.Parse(Strenght.text),float.Parse(Power.text),float.Parse(criticalchance.text),float.Parse(agility.text),float.Parse(shield.text));

		if(creating == 1)
		{
			player_1 = CreatedPlayer;
		}
		else if(creating == 2)
		{
			player_2 = CreatedPlayer;
		}
	}

    public void createButton_1()
    {
		thirdMenu.SetActive(true);
        firstMenu.SetActive(false);
        secondMenu.SetActive(false);
		creating = 1;
    }

    public void loadButton_2()
    {
        changeMenu();
        loading = 2;
    }

    public void createButton_2()
    {
		thirdMenu.SetActive(true);
        firstMenu.SetActive(false);
        secondMenu.SetActive(false);
		creating = 2;
    }

    void button_load(int button)
    {
        if(loading == 1)
        {
            player_1 = database.getCharacterById(button);
        }
        else if(loading == 2)
        {
            player_2 = database.getCharacterById(button);
        }

        changeMenu();
    }

    public void button_1()
    {
        button_load(0);
    }
    public void button_2()
    {
        button_load(1);

    }
    public void button_3()
    {
        button_load(2);
    }
    public void button_4()
    {
        button_load(3);
    }
    public void button_5()
    {
        button_load(4);
    }
    public void button_6()
    {
        button_load(5);

    }
    public void button_7()
    {
        button_load(6);

    }
    public void button_8()
    {
        button_load(7);

    }
    public void button_9()
    {
        button_load(8);
    }
    public void button_play()
    {
        if (player_1 != null && player_2 != null)
            StartCombat();
    }

    private void StartCombat()
    {
        combatSimulator.StartCombat(player_1, player_2);
    }
}
