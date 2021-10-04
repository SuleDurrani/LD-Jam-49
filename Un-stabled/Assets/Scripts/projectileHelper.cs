using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileHelper: MonoBehaviour
{
    public Vector3 trajectoryVectorToHitTarget(Vector3 from, Vector3 to, float projectileSpeed){
        float distance = to.x - from.x;
        Vector3 directionalVector = to - from;

        float v2 = projectileSpeed * projectileSpeed;
        float v4 = v2 * v2;

        float x = to.x;
        float x2 = x * x;
        float y = to.y;

        float theta = 0.5f*Mathf.Asin((Physics.gravity.y * distance) / (projectileSpeed * projectileSpeed));
        Vector3 releaseVector = (Quaternion.AngleAxis(theta * Mathf.Rad2Deg, -Vector3.forward) * directionalVector).normalized;
        return releaseVector * projectileSpeed;
    }
}
