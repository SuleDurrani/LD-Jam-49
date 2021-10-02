using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{

    public int damage = 1;
    GameObject owner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setOwner(GameObject owner){
        this.owner = owner;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        try{
            col.gameObject.GetComponent<HealthController>().takeDamage(damage);
            if(col.gameObject.layer != 3 && col.gameObject != owner){
                Destroy(this.gameObject);
            }
        }catch{

        }
    }
}
