using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endLevel : MonoBehaviour
{
    bool isFinishLevel = false;
    public Animator controlAnima;
    public BoxCollider2D cliding;
    public ParticleSystem Particale;
    void Start()
    {
        Particale.Stop();
    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.collider.tag == "finish")
        {
            if(isFinishLevel == false)
            {
                cliding.enabled = false;
                isFinishLevel = true;
                controlAnima.SetBool("isMidele", true);
                Particale.Play();                
            }
        }
    }
    void Update()
    {

        
    }
}
