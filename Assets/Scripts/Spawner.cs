using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] tetrisObjects;
    private GridCreator _gridCreator;
    private void Awake()
    {
        _gridCreator = FindObjectOfType<GridCreator>();
    }
    public void SpawnRandomObject()
    {
        int _randomIndex = Random.Range(0, tetrisObjects.Length);
       GameObject _checkedObject= Instantiate(tetrisObjects[_randomIndex], transform.position,Quaternion.identity);
       _checkedObject.transform.position = new Vector2(_gridCreator.AllGrids[GridCreator.countOfColumns/2,0].transform.position.x, _gridCreator.AllGrids[0, GridCreator.countOfRows-1].transform.position.y+2);
      
    }

  
}
