using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowEnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    float hideTime = 2;
    [SerializeField]
    float outTime = 2;
    [SerializeField]
    int shotCount = 3;

    float elapsedTime;

    bool hidden = true;

    float shootTime;

    [SerializeField]
    Sprite inSprite;
    [SerializeField]
    Sprite outSprite;
    [SerializeField]
    Sprite enemySprite;

    [SerializeField]
    Rigidbody2D weaponProjectile;
    [SerializeField]
    Transform target;


    CircleCollider2D col;
    GameObject windowChild;
    GameObject enemyChild;
    SpriteRenderer[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<CircleCollider2D>();
        elapsedTime = 0;
        shootTime = (float)(outTime-0.01f)/(float)shotCount;
        sprites = this.GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hidden){
            if (elapsedTime == 0)
            {
                sprites[0].sprite = inSprite;
                sprites[1].sprite = null;
                col.enabled = false;
            }
            if(elapsedTime > hideTime){
                elapsedTime = 0;
                hidden = !hidden;
                return;
            }
        }else
        {
            if (elapsedTime == 0)
            {
                sprites[0].sprite = outSprite;
                sprites[1].sprite = enemySprite;
                col.enabled = true;
            }
            if (elapsedTime > outTime)
            {
                elapsedTime = 0;
                hidden = !hidden;
                return;
            }

            if(elapsedTime%shootTime>.5 && (elapsedTime+Time.deltaTime)%shootTime<.5){
                if(weaponProjectile){
                    Rigidbody2D wp = Instantiate(weaponProjectile);
                    wp.transform.position = transform.position - (transform.position - target.position).normalized;
                    wp.AddForce(-(transform.position - (target.position + new Vector3(0,Random.Range(3f,7f),0)))*50f);
                    wp.gameObject.GetComponent<ProjectileBehavior>().setOwner(this.gameObject);
                }
            }
        }
        elapsedTime += Time.deltaTime;
    }
}