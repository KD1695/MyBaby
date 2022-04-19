using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLevelPass : MonoBehaviour
{
    bool passFlag = false;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Baby" && !passFlag)
        {
            GameManager.Instance.pass = true;
            passFlag = true;
        }
    }
}
