using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    public GameObject firstMenu;
    public GameObject secondMenu;
    public GameObject thirdMenu;
    public GameObject fourthMenu;

    [Header("Imputs")]
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

    private int num;

    private bool simulating_flag = false;

    private float last_id = 10;

    //private Character CreatedPlayer;

    private CombatSimulator combatSimulator;

    //Texts
    private Text p1;
    private Text p2;
    private Text p1Combat;
    private Text p2Combat;

    // Use this for initialization
    void Start()
    {
        combatSimulator = GetComponent<CombatSimulator>();
        database = GetComponent<Database>();

        fourthMenu.SetActive(true);
        p1 = GameObject.Find("Player1_Text").GetComponent<Text>();
        p2 = GameObject.Find("Player2_Text").GetComponent<Text>();
        p1Combat = GameObject.Find("Player_1_text_combat").GetComponent<Text>();
        p2Combat = GameObject.Find("Player_2_text_combat").GetComponent<Text>();
        fourthMenu.SetActive(false);


        for (int i = 0; i < secondMenu.transform.childCount; i++)
        {
            string id = "-";
            if (database.getCharacterById(i) != null)
            {
                id = database.getCharacterById(i).name;
            }

            secondMenu.transform.GetChild(i).GetComponentInChildren<Text>().text = id;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Combat();
        if (battles.text != "" && battles.text != "Number of battles needed" && battles.text != "Number no valid")
        {
            ColorBlock cb = battles.colors;
            cb.normalColor = Color.white;
            battles.colors = cb;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void loadButton_1()
    {
        firstMenu.SetActive(false);
        secondMenu.SetActive(true);
        thirdMenu.SetActive(false);
        fourthMenu.SetActive(false);
        loading = 1;
    }

    public void submitButton()
    {
        thirdMenu.SetActive(false);
        firstMenu.SetActive(true);
        secondMenu.SetActive(false);
        float n;

        if (float.TryParse(Hp.text, out n) &&
            float.TryParse(Acc.text, out n) &&
            float.TryParse(Strenght.text, out n) &&
            float.TryParse(Power.text, out n) &&
            float.TryParse(criticalchance.text, out n) &&
            float.TryParse(agility.text, out n) &&
            float.TryParse(shield.text, out n)
            )
        {
            Character CreatedPlayer = new Character(last_id, float.Parse(Hp.text), float.Parse(Acc.text), float.Parse(Strenght.text), float.Parse(Power.text), float.Parse(criticalchance.text), float.Parse(agility.text), float.Parse(shield.text), "CreatedCharacter");
            last_id++;
            CreatedPlayer.gun = database.itemDataBase[0];

            if (creating == 1)
            {
                player_1 = CreatedPlayer;
                p1.text = "Custom MOB";
                p1Combat.text = "Custom MOB";
            }
            else if (creating == 2)
            {
                player_2 = CreatedPlayer;
                p2.text = "Custom MOB";
                p2Combat.text = "Custom MOB";
            }
        }
        else
        {
            if(creating == 1)
            {
                p1.text = "Invalid creation values";
                player_1 = null;
            }
            else if(creating == 2)
            {
                p2.text = "Invalid creation values";
                player_2 = null;
            }
        }
    }

    public void createButton_1()
    {
        thirdMenu.SetActive(true);
        firstMenu.SetActive(false);
        secondMenu.SetActive(false);
        fourthMenu.SetActive(false);
        creating = 1;
    }

    public void loadButton_2()
    {
        firstMenu.SetActive(false);
        secondMenu.SetActive(true);
        thirdMenu.SetActive(false);
        fourthMenu.SetActive(false);
        loading = 2;
    }

    public void createButton_2()
    {
        thirdMenu.SetActive(true);
        firstMenu.SetActive(false);
        secondMenu.SetActive(false);
        fourthMenu.SetActive(false);
        creating = 2;
    }

    void button_load(int button)
    {
        if (loading == 1)
        {
            Character aux = database.getCharacterById(button);
            if (aux != null)
            {
                player_1 = new Character(aux.ID, aux.hp, aux.acc, aux.strenght, aux.power, aux.criticalChance, aux.agility, aux.shield, aux.name);
                player_1.gun = aux.gun;
                p1.text = aux.name;
                p1Combat.text = aux.name;
            }

        }
        else if (loading == 2)
        {
            Character aux = database.getCharacterById(button);
            if (aux != null)
            {
                player_2 = new Character(aux.ID, aux.hp, aux.acc, aux.strenght, aux.power, aux.criticalChance, aux.agility, aux.shield, aux.name);
                player_2.gun = aux.gun;
                p2.text = aux.name;
                p2Combat.text = aux.name;
            }

        }

        firstMenu.SetActive(true);
        secondMenu.SetActive(false);
        thirdMenu.SetActive(false);
        fourthMenu.SetActive(false);
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

    public void main_menu()
    {
        firstMenu.SetActive(true);
        thirdMenu.SetActive(false);
        secondMenu.SetActive(false);
        fourthMenu.SetActive(false);

        //To be sure that everything is like at the beggining...
        player_1 = null;
        player_2 = null;
        creating = 0;
        num = 0;
        simulating_flag = false;
    }

    public void button_play()
    {
        if (player_1 != null && player_2 != null && battles.text != "")
        {
            int n;
            if (int.TryParse(battles.text, out n))
            {
                player_1_health = player_1.hp;
                player_2_health = player_2.hp;

                StartCombat(int.Parse(battles.text));
                firstMenu.SetActive(false);
                secondMenu.SetActive(false);
                thirdMenu.SetActive(false);
                fourthMenu.SetActive(true);
                fourthMenu.transform.GetChild(5).gameObject.SetActive(false);
            }
            else
            {
                battles.text = "Number no valid";
                ColorBlock cb = battles.colors;
                cb.normalColor = Color.red;
                battles.colors = cb;
            }
        }
        else if (battles.text == "")
        {
            battles.text = "Number of battles needed";

            ColorBlock cb = battles.colors;
            cb.normalColor = Color.red;
            battles.colors = cb;
        }
    }

    private void StartCombat(int l_num)
    {
        num = l_num;
        simulating_flag = true;
    }

    void Combat()
    {
        if (num > 0)
        {
            Debug.Log("New battle:" + num);
            player_2.hp = player_2_health;
            player_1.hp = player_1_health;
            combatSimulator.StartCombat(player_1, player_2);

            fourthMenu.transform.GetChild(0).GetComponent<Text>().text = combatSimulator.player_1_wins.ToString();
            fourthMenu.transform.GetChild(1).GetComponent<Text>().text = combatSimulator.player_2_wins.ToString();

            num--;
        }

        else if (num == 0 && simulating_flag)
        {
            Debug.Log("player 1: " + combatSimulator.player_1_wins);
            Debug.Log("player 2: " + combatSimulator.player_2_wins);

            if (combatSimulator.player_1_wins > combatSimulator.player_2_wins)
            {
                fourthMenu.transform.GetChild(0).GetComponent<Text>().color = UnityEngine.Color.green;
                fourthMenu.transform.GetChild(1).GetComponent<Text>().color = UnityEngine.Color.red;

            }
            else if (combatSimulator.player_1_wins == combatSimulator.player_2_wins)
            {
                fourthMenu.transform.GetChild(0).GetComponent<Text>().color = UnityEngine.Color.yellow;
                fourthMenu.transform.GetChild(1).GetComponent<Text>().color = UnityEngine.Color.yellow;
            }
            else if (combatSimulator.player_1_wins < combatSimulator.player_2_wins)
            {
                fourthMenu.transform.GetChild(0).GetComponent<Text>().color = UnityEngine.Color.red;
                fourthMenu.transform.GetChild(1).GetComponent<Text>().color = UnityEngine.Color.green;
            }

            fourthMenu.transform.GetChild(2).GetComponent<Text>().text = "";
            fourthMenu.transform.GetChild(5).gameObject.SetActive(true);

            combatSimulator.player_1_wins = 0;
            combatSimulator.player_2_wins = 0;
            num = -1;

            simulating_flag = false;
        }

        if (combatSimulator.player_1_wins + combatSimulator.player_2_wins >= num)
        {
            //combatSimulator.eventLog.AddEvent("Player 1 has won: " + combatSimulator.player_1_wins.ToString());
            //combatSimulator.eventLog.AddEvent("Player 2 has won: " + combatSimulator.player_2_wins.ToString());
        }
    }
}
