using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int current;
    public int max;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.UpdateHealth(current);
        healthBar.UpdateMax(max);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow)) takeDamage(-1);
        if(Input.GetKeyDown(KeyCode.LeftArrow)) takeDamage(1);
    }

    void takeDamage(int damage) {
        current -= damage;
        if (current < 0) {
            current = 0;
        }
        healthBar.UpdateHealth(current);
    }

}
