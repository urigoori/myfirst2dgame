using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class enemyHit : MonoBehaviour
{
    public Transform player;
    public float dirction = 1f;
    public Animator controlAnim;
    public ParticleSystem blad;
    public int playerMaxHealth = 10;
    public int playerNowHealth = 3;
    int damageForPlayer = 2;
    bool isLive = true;
    public healthBarPlayer healthBar;
    bool isEnemyHit = false;
    bool isHealing = false;
    public float timeRamaning = 2f;
    void Start()
    {
        blad.Stop();
        playerNowHealth = playerMaxHealth;
        healthBar.SetMaxHealth(playerMaxHealth);

    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.collider.tag == "player")
        {
            //if he clied with player
            isEnemyHit = true;
        }
    }
    void OnCollisionExit2D(Collision2D collisionInfo)
    {
        isEnemyHit = false;
    }      
    void Update()
    {
        if(player.position.x < transform.position.x && dirction == -1)
        {
           transform.localScale = new Vector3(1f, 1f, 1f);
            dirction = 1f;
        }
        else if(player.position.x > transform.position.x && dirction == 1)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            dirction = -1f; 
        }
        timeRamaning -= Time.deltaTime;
        //Debug.Log(timeRamaning);
        if(timeRamaning <= 0 && isEnemyHit && isLive)
        {
            blad.Play();
            controlAnim.SetBool("isClider", true);
            playerNowHealth -= damageForPlayer;
            healthBar.SetHealth(playerNowHealth);
            timeRamaning = 2f;
        }
        else
        {
            controlAnim.SetBool("isClider", false);
        }
        if(controlAnim.GetBool("isDie") == false)
        {
            isLive = true;
        }
        else
        {
            isLive = false;
        }
        


    }
}
 