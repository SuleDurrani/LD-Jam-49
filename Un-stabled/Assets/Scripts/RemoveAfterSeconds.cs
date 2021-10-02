using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAfterSeconds : MonoBehaviour
{

    float startTime;
    float elapsedTime;
    [SerializeField]
    float lifespanInSeconds = 2f;

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = Time.time;
        elapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > lifespanInSeconds){
            Destroy(this.gameObject);
        }
    }
}
