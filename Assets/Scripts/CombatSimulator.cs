using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatSimulator : MonoBehaviour {

    Character player_1, player_2;
    public Text textBox;

    float timer_1, timer_2;

    public CombatLog eventLog;


    float hitChance, cc, cc2, cv, cv2, damage2, dmg; //Cv used in da mage2 and 3 but th ey re going to be 0 always

    int hitslanded = 0;
    int hitslanded2 = 0;

    public int player_1_wins = 0;
    public int player_2_wins = 0;

    private void Start()
    {
        timer_1 = 0;
        timer_2 = 0;
       // eventLog = GetComponent<CombatLog>();

    }

    public void StartCombat(Character player_1, Character player_2)
    {
        this.player_1 = player_1;
        this.player_2 = player_2;
        //eventLog.visible = true;
		Battle();
    }

    private void Battle() //Modify this function to make it work 
    {
        if (player_1 != null && player_2 != null)
        {
            PrepareCombat();
            int result = Simulate();
				
			if (result == -1)
				Battle ();
			else if (result == 0) {
				player_1_wins++;
				player_2_wins++;
				player_1 = null;
				player_2 = null;
			} else if (result == 1) {
				player_1_wins++;
				player_1 = null;
				player_2 = null;
			} else if (result == 2) {
				player_2_wins++;
				player_1 = null;
				player_2 = null;
			}
        }
    }

    private void PrepareCombat()
    {
        hitChance = 7.3f;   //HitChance = 100 * (1 - (25 / (pistol[2] + Character[1])))
        cc = 7.3f;           //cc = (pistol[4] + Character[4])
        cc2 = 7.3f;        //cc2 = (pistol[4] + Enemy[4])
    }

    private int Simulate()
    {
        if (player_1.hp > 0 && player_2.hp > 0)
        {
            Debug.Log("--- New round --- ");
            //textBox.text += "---New round---\n";ç
            //eventLog.AddEvent("--- New round --- ");

           AttackFromTo(ref player_1, ref player_2);
           AttackFromTo(ref player_2, ref player_1);
        }



        if (player_1.hp <= 0 && player_2.hp <= 0)
        {
            return 0;
        }
        else if (player_1.hp <= 0)
        {
            return 1;
        }
        else if (player_2.hp <= 0)
        {
            return 2;
        }

        return -1;
    }

    private void AttackFromTo(ref Character from, ref Character to)
    {

        // from Hitting to
        if (UnityEngine.Random.Range(0, 100) <= hitChance)
        {
            if (UnityEngine.Random.Range(0, 101) <= cc) //Critic
            {
                cv = UnityEngine.Random.Range(1, (from.gun.criticalValue + from.criticalChance));  //cv = UnityEngine.Random.Range(1, (pistol[3] + Character[4]));
                //Debug.Log("PLAYER CRIT FOR: " + cv);
                //eventLog.AddEvent("PLAYER CRIT FOR: " + cv);
                //textBox.text += "PLAYER CRIT FOR: " + cv + "\n";
            }
            else //No critic
                cv = 0;

            dmg = (from.gun.damage + cv) * (from.gun.damage / (from.gun.damage + from.agility + from.shield));//Damage2 = ((pistol[0] + cv) * (pistol[0] / (pistol[0] + Character[5] + Character[6])))

            hitslanded++;
            to.hp -= dmg;
        }

        //Debug.Log(">>>Character with ID " + to.ID + " has " + to.hp + " HP now");
        //textBox.text += ">>> Character with ID " + to.ID + " has " + to.hp + " HP now" +  "\n";
        //eventLog.AddEvent(">>> Character with ID " + to.ID + " has " + to.hp + " HP now" +  "\n");

    }


}
