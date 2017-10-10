using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSimulator : MonoBehaviour {

    Character player_1, player_2;

    float timer_1, timer_2;


    float hitChance,cc,cc2,cv,cv2,damage2,dmg; //Cv used in damage2 and 3 but they re going to be 0 always

    int hitslanded = 0;
    int hitslanded2 = 0;

    private void Start()
    {
        timer_1 = 0;
        timer_2 = 0;
    }

    public void StartCombat(Character player_1, Character player_2)
    {
        this.player_1 = player_1;
        this.player_2 = player_2;
    }

    private void FixedUpdate()
    {
        if(player_1 != null && player_2!=null)
        {
            PrepareCombat();
            Simulate();
        }
    }

    private void PrepareCombat()
    {
        hitChance = 7.3f;   //HitChance = 100 * (1 - (25 / (pistol[2] + Character[1])))
        cc = 7.3f;           //cc = (pistol[4] + Character[4])
        cc2 = 7.3f;        //cc2 = (pistol[4] + Enemy[4])
    }

    private void Simulate()
    {
        if(player_1.hp > 0 && player_2.hp > 0)
        {
            AttackFromTo(ref player_1, ref player_2);
            AttackFromTo(ref player_2, ref player_1);
        }

    }

    private void AttackFromTo(ref Character from, ref Character to)
    {
        // Player1 Hitting Player2
        if (UnityEngine.Random.Range(0, 100) <= hitChance) //ranges of randoms
        {
            if (UnityEngine.Random.Range(0, 101) <= cc) //Critic
            {
                cv = 3.7f;            //cv = UnityEngine.Random.Range(1, (pistol[3] + Character[4]));
                Debug.Log("PLAYER CRIT FOR: " + cv);
            }
            else //No critic
                cv = 0;


            damage2 = 3.7f;//Damage2 = ((pistol[0] + cv) * (pistol[0] / (pistol[0] + Character[5] + Character[6])))
            dmg = damage2; //???

            hitslanded++;
            player_1.hp -= dmg;
        }
    }
}
