using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeItem : MonoBehaviour
{
    public int itemCost;
    public string itemName;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponentInChildren<Text>().text = itemName;
        this.gameObject.GetComponentsInChildren<Text>()[1].text = itemCost.ToString() + "p";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
