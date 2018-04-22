using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour {

    /* Attributes */
    // hp = hunger points: If 0, you ded. Reset position.
    // tp = thirst points: Special survival attribute#2. Affects hp and skills/behavior
    // fp = fatigue points: Natural implementation for boundary system
    // sp = stamina points: For running, swimming, etc.
    public static double hp, tp, fp, sp;
    public const double noHP=0, quarter=25, half=50, threefourth=75, full = 100;
    public static double rate;
    public static bool dead;

    private void Start()
    {
        hp = 20;
        tp = 80;
        fp = 100;
        sp = 5;
        dead = false;
    }

    private void Update()
    {
        // Death Case
        death();

        updateTP(); // Thirst Management
        updateRate(); // Rate of Hunger/Sec Management
        print(hp);  // Test Health
        updateHP(); // Hunger management
        updateStamina(); // Stamina management

    }

    private void updateRate()
    {
        // Lose .25 hp per second
        if (tp > threefourth && tp <= full)
            rate = .25 * Time.deltaTime;
        // Lose 1 hp per second
        else if (tp > half && tp <= threefourth)
            rate = 1 * Time.deltaTime;
        // Lose 2 hp per second
        else if (tp > quarter && tp <= half)
            rate = 2 * Time.deltaTime;
        // Lose 5 hp per second
        else
            rate = 5 * Time.deltaTime;
    }

    private void updateHP()
    {
        if (hp <= full && hp >= noHP) hp -= rate;
        else dead = true;
        // if (bool ate), increase hp
    }

    private void updateTP()
    {
        
        if (tp <= full) tp -= 1 * Time.deltaTime;
        // if (bool drink) some, increase hp
    }

    private void updateStamina()
    {
        if (Input.GetKey(KeyCode.LeftShift) && sp > 0)
            sp -= 1 * Time.deltaTime;
        else if (sp <= 5)
            sp += .5 * Time.deltaTime;
        if (sp <= 0)
            print("You need to relaaaaax. No more stamina. Rest a bit.");
    }
    private void death()
    {
        if (dead)
        {
            print("You ded");
            FindObjectOfType<GameManagerScript>().EndGame();
        }
    }

    /*Interaction with external objects*/
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
