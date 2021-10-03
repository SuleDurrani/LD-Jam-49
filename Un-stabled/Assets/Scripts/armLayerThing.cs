using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armLayerThing : MonoBehaviour
{
    CharacterController2D owner;
    SpriteRenderer texture;

    [SerializeField]
    bool isGunHand;

    // Start is called before the first frame update
    void Start()
    {
        try{
            owner = transform.parent.GetComponent<CharacterController2D>();
        }catch{

        }
        try{
            texture = GetComponent<SpriteRenderer>();
        }catch{

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(owner.m_FacingRight){
            texture.sortingOrder = isGunHand?1:-2;
        }else
        {
            texture.sortingOrder = isGunHand?-2:1;
        }
        
    }
}
