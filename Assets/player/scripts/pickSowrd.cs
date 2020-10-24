using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class pickSowrd : MonoBehaviour
{
    private List<GameObject> colList = new List<GameObject>();

    public Text text;
    public Transform selectedtWeapon;
    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(3);
    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "sowrd")
        {
            GameObject leftHand = GameObject.Find("hand 2");
            if (leftHand.transform.childCount > 0)
            {
                Transform currentWeapon = leftHand.transform.GetChild(0);
                if (collisionInfo.gameObject != currentWeapon)
                {
                    colList.Add(collisionInfo.gameObject);
                }
            }
            else if (leftHand.transform.childCount == 0)
            {
                colList.Add(collisionInfo.gameObject);
            }
            text.enabled = true;
        }
        else
        {
            text.enabled = false;
        }
    }

    void OnCollisionExit2D(Collision2D collisionInfo)
    {
        if (colList.Contains(collisionInfo.gameObject))
        {
            colList.Remove(collisionInfo.gameObject);
        }
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            GameObject leftHand = GameObject.Find("hand 2");
            if (leftHand != null)
            {
                if (leftHand.transform.childCount > 0)
                {
                    Transform currentWeapon = leftHand.transform.GetChild(0);
                    if (currentWeapon != null)
                    {
                        currentWeapon.position = new Vector3(leftHand.transform.position.x - 10,
                            leftHand.transform.position.y + 5, leftHand.transform.position.z);
                        currentWeapon.parent = null;
                    }
                }
                if (colList.Count > 0)
                {
                    selectedtWeapon = colList[0].transform;
                    selectedtWeapon.position += new Vector3(transform.position.x - selectedtWeapon.position.x,
                    transform.position.y - selectedtWeapon.position.y + transform.lossyScale.y / 2, 0);
                    selectedtWeapon.Rotate(0, 0, -180);
                }

            }
            else
            {
            }
        }

    }
}
