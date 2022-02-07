using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGrabbed = false;
    public int force = 100;
    public bool isRotating = false;

    private void Awake()
    {
        Instance = this;
    }
}
