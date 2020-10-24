using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class hit : MonoBehaviour
{
    public Animator animatorPlayer;
    public Animator animatorEnemy;
    public movementPlayer side;
    public Transform body;
    int enmeyMaxHealth = 3;
    int enemyNowHealth = 3;
    int damageForEnemy = 1;
    public healthBarEnemy healthBar;
    public enemyHit enehit;
    bool isClideEnemy = false;
    float timeToHit = 0.45f;
    void start()
    {
        //animatorPlayer = GetComponent<Animator>();
        enemyNowHealth = enmeyMaxHealth;
        healthBar.SetMaxHealthEnemy(enmeyMaxHealth);
    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.collider.tag == "enemy")
        {
            isClideEnemy = true;
        }
    }
    void OnCollisionExit2D(Collision2D collisionInfo)
    {
        timeToHit -= Time.deltaTime;
        if(timeToHit == 0)
        {
            isClideEnemy = false;
            timeToHit = 0.45f;
        }
    }    
        void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(isClideEnemy == true)
            {
                enemyNowHealth -= damageForEnemy;
                healthBar.SetHealthEnemy(enemyNowHealth); 
                enehit.timeRamaning += 1;
                animatorEnemy.SetBool("getHit", true);
            }
            else
            {
                animatorEnemy.SetBool("getHit", false);
            }
            animatorPlayer.SetBool("mouseClick", true);
            if (Mathf.Clamp((Input.mousePosition.x / Screen.width) * 2 - 1, -1.0F, 1.0F) < transform.position.x)
            {

                if (side.dirction == 1)
                {

                    //Debug.Log("i Flip from the right to the left");
                    body.Rotate (0, -180, 0);
                    side.dirction = -1;

                }
            } 
            else if (Mathf.Clamp((Input.mousePosition.x / Screen.width) * 2 - 1, -1.0F, 1.0F) > transform.position.x)
            {
                if (side.dirction == -1)
                {
                    //Debug.Log("i Flip from the left to the right");
                    body.Rotate (0, 180, 0);
                    side.dirction = 1;
                }
            }
        }
        else
        {
            animatorPlayer.SetBool("mouseClick", false);
            animatorEnemy.SetBool("getHit", false);
        }
    }
}

