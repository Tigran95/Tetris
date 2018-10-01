using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreator : MonoBehaviour
 {

	public GameObject gridd;
	public static int countOfColumns;
	public static int countOfRows;
    
	public GameObject[,] AllGrids {get;set;}

    private CameraPoints _cameraPoints;

    private void Awake()
    {
        _cameraPoints = FindObjectOfType<CameraPoints>();
    }
	void Start ()
     {
		AllGrids = new GameObject[countOfColumns,countOfRows];
		GridFill();
	 }

    private void GridFill()
     {
      for (int i = 0; i < countOfColumns; i++)
        {
            for(int j =0; j < countOfRows; j++)
            {
              Vector2 tempPosition= new Vector2( _cameraPoints.CameraAngels[(int)Points.bottomLeftPoint].transform.position.x+ i
                  , _cameraPoints.CameraAngels[(int)Points.bottomLeftPoint].transform.position.y+j);
			  GameObject _grid=Instantiate(gridd,tempPosition,Quaternion.identity);
                _grid.transform.parent = this.transform;
                _grid.name = i + "" + j;
                AllGrids[i, j] = _grid;
			}
	    }
       
       
     }
    
    


}
