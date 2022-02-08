using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGrabbed = false;
    public int force = 100;
    public bool isRotating = false;

    //Prefabs references
    public GameObject KickerPrefab;
    public GameObject GrabberPrefab;
    public GameObject CircusParent;

    public Camera MainCamera;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
