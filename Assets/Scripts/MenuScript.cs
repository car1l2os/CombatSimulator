using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    public GameObject firstMenu;
    public GameObject secondMenu;
	public GameObject thirdMenu;
    public GameObject fourthMenu;

    [Header ("Imputs")]
    public InputField ID;
	public InputField Hp;
	public InputField Acc;
	public InputField Strenght;
	public InputField Power;
	public InputField criticalchance;
	public InputField agility;
	public InputField shield;
    public InputField battles;

    public Database database;

    private int loading = 0;
	private int creating = 0;

    private Character player_1;
    private Character player_2;

	private float player_1_health;
	private float player_2_health;

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
        //Debug.Log(player_1);
        //Debug.Log(player_2);
	}

    public void loadButton_1()
    {
        firstMenu.SetActive(false);
        secondMenu.SetActive(true);
        thirdMenu.SetActive(false);
        //fourthMenu.SetActive(false);
        loading = 1;
    }

	public void submitButton()
	{
		thirdMenu.SetActive(false);
        firstMenu.SetActive(true);
        secondMenu.SetActive(false);
        Character CreatedPlayer = new Character (float.Parse(ID.text),float.Parse(Hp.text),float.Parse(Acc.text),float.Parse(Strenght.text),float.Parse(Power.text),float.Parse(criticalchance.text),float.Parse(agility.text),float.Parse(shield.text));
        CreatedPlayer.gun = database.itemDataBase[0];

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
        //fourthMenu.SetActive(false);
        creating = 1;
    }

    public void loadButton_2()
    {
        firstMenu.SetActive(false);
        secondMenu.SetActive(true);
        thirdMenu.SetActive(false);
        //fourthMenu.SetActive(false);
        loading = 2;
    }

    public void createButton_2()
    {
		thirdMenu.SetActive(true);
        firstMenu.SetActive(false);
        secondMenu.SetActive(false);
        //fourthMenu.SetActive(false);
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

        firstMenu.SetActive(true);
        secondMenu.SetActive(false);
        thirdMenu.SetActive(false);
        //fourthMenu.SetActive(false);
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
			player_1_health = player_1.hp;
			player_2_health = player_2.hp;

            if (player_1 != null && player_2 != null && battles.text != "")
            {
                StartCombat(int.Parse(battles.text));
                firstMenu.SetActive(false);
                secondMenu.SetActive(false);
                thirdMenu.SetActive(false);
                //fourthMenu.SetActive(true);
            }

    }

    private void StartCombat(int num)
    {
        for(int i=0;i<num;i++)
        {
            Debug.Log("New battle:" + i);
			player_2.hp = player_2_health;
			player_1.hp = player_1_health;
            combatSimulator.StartCombat(player_1, player_2);
        }

		Debug.Log("player 1: " + combatSimulator.player_1_wins);
		Debug.Log("player 2: " + combatSimulator.player_2_wins);

        if(combatSimulator.player_1_wins + combatSimulator.player_2_wins >= num)
        {
            //combatSimulator.eventLog.AddEvent("Player 1 has won: " + combatSimulator.player_1_wins.ToString());
            //combatSimulator.eventLog.AddEvent("Player 2 has won: " + combatSimulator.player_2_wins.ToString());
        }

		combatSimulator.player_1_wins = 0;
		combatSimulator.player_2_wins = 0;
    }
}
