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
    public int direction = 1;
    public bool pass = false;
    public int currentLevelMaxHeight = 100;

    //Prefabs references
    public GameObject KickerPrefab;
    public GameObject GrabberPrefab;
    public GameObject CircusParent;
    public GameObject Baby;

    public Camera MainCamera;

    public TMPro.TextMeshProUGUI text;
    int score = 0;

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

        if (Input.GetKey(KeyCode.A))
        {
            isRotating = true;
            direction = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            isRotating = true;
            direction = 1;
        }
        else
            isRotating = false;

        if(Baby.transform.position.y > score)
        {
            score = (int)Baby.transform.position.y;
            text.text = "Score : " + score;
        }
    }
}
