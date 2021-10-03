using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileHelper : MonoBehaviour
{
    public Vector3 trajectoryVectorToHitTarget(Transform from, Transform to, float projectileSpeed){
        float distance = to.position.x - from.position.x;
        Vector3 directionalVector = to.position - from.position;

        float v2 = projectileSpeed * projectileSpeed;
        float v4 = v2 * v2;

        float x = to.position.x;
        float x2 = x * x;
        float y = to.position.y;

        float theta = 0.5f*Mathf.Asin((Physics.gravity.y * distance) / (projectileSpeed * projectileSpeed));
        Vector3 releaseVector = (Quaternion.AngleAxis(theta * Mathf.Rad2Deg, -Vector3.forward) * directionalVector).normalized;
        Debug.DrawRay(transform.position, releaseVector*5, Color.cyan, 0.5f);
        return releaseVector * projectileSpeed;
    }
}
