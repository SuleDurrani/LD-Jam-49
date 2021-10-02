using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public HealthController health;

    public RectTransform fullApples;
    public RectTransform halfApples;

    public RectTransform emptyApples;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void UpdateHealth(int current) {

        fullApples.sizeDelta = new Vector2(20*(((current)/2)), 20);
        halfApples.sizeDelta = new Vector2(20*(((current+1)/2)), 20);
    }

    public void UpdateMax(int max) {
        emptyApples.sizeDelta = new Vector2(20*(((max)/2)), 20);
    }
}
