using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;


public class healthBarPlayer : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fillPlayer;
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        
        fillPlayer.color = gradient.Evaluate(1f);

    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fillPlayer.color = gradient.Evaluate(slider.normalizedValue);
    }
    public void Update()
    {
        if(slider.value == 0)
        {
            fillPlayer.color = gradient.Evaluate(slider.normalizedValue);
        }
        transform.position = new Vector3(5f, 4f, 0);
    }
}
