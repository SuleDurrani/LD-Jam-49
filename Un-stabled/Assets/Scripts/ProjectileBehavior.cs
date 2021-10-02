using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{

    public float damage = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        try{
            // col.gameObject.GetComponent<Health>().takeDamage(damage);
            if(col.gameObject.layer != 3){
                Destroy(this.gameObject);
            }
        }catch{

        }
    }
}
