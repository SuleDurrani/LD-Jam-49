using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCircleRotate : MonoBehaviour
{
    Vector3 entityLocation; // This the "gun owner" position. e.g. The character holding the gun object
    Vector3 aimLocation;    // This is the aim location. 
    
    [SerializeField]
    private MouseFollower mouse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        entityLocation = transform.position;
        aimLocation = mouse.getMousePosition();

        float angle = angleFinder(entityLocation, aimLocation);
        Debug.Log(angle.ToString());
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private float angleFinder(Vector3 entity, Vector3 aim) 
    {
        float deltaX = aim.x - entity.x;
        float deltaY = aim.y - entity.y;
        float radians = Mathf.Atan2(deltaY, deltaX);
        float degrees = radians * Mathf.Rad2Deg;
        return degrees;
    }
}
