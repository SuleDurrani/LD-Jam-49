using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePoints : MonoBehaviour
{
    void Update()
    {
        this.gameObject.GetComponent<Text>().text = "Upgrade Points: " + GameManager.Upgrades.upgradePoints.ToString();
    }
}
