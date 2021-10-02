using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private int _current;
    private int current{
        get { return _current; }
        set {
            if (healthBar != null) healthBar.UpdateHealth(value);
            _current = value;
        }
    }
    private int _max;
    private int max{
        get { return _max; }
        set {
            if (healthBar != null) healthBar.UpdateMax(value);
            _max = value;
        }
    }

    public HealthBar healthBar;
    public int startHealth;
    public int startMax;

    // Start is called before the first frame update
    void Start()
    {
        current = startHealth;
        max = startMax;
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.RightArrow)) heal(1);
        // if(Input.GetKeyDown(KeyCode.LeftArrow)) takeDamage(1);
    }

    public void takeDamage(int damage) {
        if (current < damage) current = 0;
        else current -= damage;
    }

    public void heal(int healing) {
        if (current + healing > max) current = max;
        else current += healing;
    }

    public void setMax(int newMax) {
        max = newMax;
    }

}
