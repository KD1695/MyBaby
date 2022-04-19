using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolidPass : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] bool isStartPassAllowed = true;

    private void Awake() 
    {
        image.enabled = !isStartPassAllowed;
        this.GetComponent<BoxCollider2D>().isTrigger = isStartPassAllowed;
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Baby")
        {
            this.GetComponent<BoxCollider2D>().isTrigger = false;
            image.enabled = true;
        }
    }
}
