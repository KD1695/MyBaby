using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPartGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> artists;
    [SerializeField] Transform artistsParent;

    public void CreateLevel()
    {
        for(int levelHeight = GameManager.Instance.currentLevelMaxHeight - 95; levelHeight < GameManager.Instance.currentLevelMaxHeight; levelHeight+=7)
        {
            CreateArtists(levelHeight);
        }
    }

    void CreateArtists(float levelHeight)
    {
        float posX = Random.Range(-13, 13);
        float posY = Random.Range(levelHeight, levelHeight+7);
        var obj = GameObject.Instantiate(artists[Random.Range(0,2)], new Vector3(posX, posY, 0), Quaternion.identity, artistsParent);
        var rectTransform = obj.GetComponent<RectTransform>();
        rectTransform.anchorMax = new Vector2(0.5f, 0);
        rectTransform.anchorMin = new Vector2(0.5f, 0);
        rectTransform.position = new Vector3(posX, posY-90, 0);
    }
}
