using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSimulator : MonoBehaviour {

    Character player_1, player_2;

    float timer_1, timer_2;

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
            Simulate();
        }
    }

    private void Simulate()
    {
        timer_1 += Time.fixedDeltaTime;
        timer_2 += Time.fixedDeltaTime;

        Debug.Log("In combat");
    }
}
