using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UpgradeMenuController : MonoBehaviour
{
    [SerializeField]
    public GameObject contentPanel;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var upgrade in GameManager.Upgrades.upgrades)
        {

            GameObject upgradeItem = Instantiate(prefab) as GameObject;
            upgradeItem.transform.SetParent(contentPanel.transform, false);
            upgradeItem.GetComponent<UpgradeItem>().upgrade = upgrade;
            upgradeItem.transform.localPosition = new Vector3(10+360*(upgrade.id%2), -20-90*((upgrade.id)/2), 0);
        }
    }
}
