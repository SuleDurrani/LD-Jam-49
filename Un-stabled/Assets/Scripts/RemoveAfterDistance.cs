using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAfterDistance : MonoBehaviour
{
    [SerializeField]
    Transform origin;
    [SerializeField]
    float maxDistance = 2f;
    Vector2 originPosition;

    // Start is called before the first frame update
    void Start()
    {
        if(origin){
            originPosition = origin.position;
        }else
        {
            originPosition = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position,originPosition)>=maxDistance){
            Destroy(this.gameObject);
        }
    }
}
