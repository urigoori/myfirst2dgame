using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;
public class takeBandages : MonoBehaviour
{
    public enemyHit enemyHit;
    public healthBarPlayer healthBarPlayer;
    public Animator animatorPlayer;
    public GameObject bandages;
    float timeToScreeDie = 0.5f;
    int heal = 3;

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.collider.tag == "health")
        {
            enemyHit.playerNowHealth += 3;
            healthBarPlayer.SetHealth(enemyHit.playerNowHealth);
            Destroy(bandages);

        }
    }
    void Update()
    {
        if(enemyHit.playerNowHealth > enemyHit.playerMaxHealth)
        {
            enemyHit.playerNowHealth -= enemyHit.playerNowHealth - enemyHit.playerMaxHealth;
            healthBarPlayer.SetHealth(enemyHit.playerNowHealth);
        }      
        if(enemyHit.playerNowHealth <= 0)
        {
            timeToScreeDie -= Time.deltaTime;
            animatorPlayer.SetBool("isInLife", false);
            if(timeToScreeDie <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
