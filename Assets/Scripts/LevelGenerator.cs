using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] LevelPartGenerator partGenerator;

    private List<LevelPartGenerator> levelPartsList = new List<LevelPartGenerator>();

    void Start()
    {
        
    }

    void Update()
    {
        if(GameManager.Instance.pass)
        {
            var levelPart = GameObject.Instantiate<LevelPartGenerator>(partGenerator, new Vector3(0, GameManager.Instance.currentLevelMaxHeight, 0), Quaternion.identity);
            GameManager.Instance.currentLevelMaxHeight += 100;
            levelPart.CreateLevel();
            levelPartsList.Add(levelPart);
            
            if(levelPartsList.Count >= 3)
            {
                var removedLevel = levelPartsList[0];
                levelPartsList.RemoveAt(0);
                Destroy(removedLevel);
            }

            GameManager.Instance.pass = false;
        }
    }
}
