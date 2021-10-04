using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    [SerializeField]
    float distance;
    Transform cm;

    // Start is called before the first frame update
    void Start()
    {
        cm = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = (cm.position / distance);
    }
}
