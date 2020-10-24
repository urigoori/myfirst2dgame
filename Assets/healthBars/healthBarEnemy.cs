using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;


public class healthBarEnemy : MonoBehaviour
{
    public Slider sliderEnemy;
    public Transform enemy;
    public Vector3 offset;
    public Animator controlAnimetion;
    public GameObject enemyGameObject;
    public Canvas canvasEnemy;
    public void SetMaxHealthEnemy(int health)
    {
        sliderEnemy.maxValue = health;
        sliderEnemy.value = health;
    }

    public void SetHealthEnemy(int health)
    {
        sliderEnemy.value = health;
    }
    public void Update()
    {
        transform.position = enemy.position + offset;
        if(sliderEnemy.value == 0)
        {
            controlAnimetion.SetBool("isDie", true);
            Destroy(enemyGameObject);
            Destroy(canvasEnemy);
        }
    }
}
