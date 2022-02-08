using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject finishScreen;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        finishScreen.SetActive(true);
    }
}
