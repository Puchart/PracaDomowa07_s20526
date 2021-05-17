using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public const int MAX_HEALTH = 10;
    public int health;

    void Start() {
        health = 5;
    }

    public void Heal(int i) {
        health += i;

        if(health > MAX_HEALTH) {
            health = MAX_HEALTH;
        }
    }
}
