using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeItem : MonoBehaviour
{
    public Upgrade upgrade;
    // Start is called before the first frame update
    void Start() {
        GetComponentInChildren<Text>().text = upgrade.name;
        GetComponentsInChildren<Text>()[1].text = upgrade.cost.ToString() + "p";
        GetComponentsInChildren<Text>()[2].text = upgrade.description;
        GetComponentInChildren<Button>().onClick.AddListener(Purchse);
        if (upgrade.unlocked) {
            GetComponentInChildren<Button>().interactable = false;
        }
    }

    void Purchse() {
        if (GameManager.Upgrades.Purchase(upgrade)) {
            GetComponentInChildren<Button>().interactable = false;
        }
    }
}
