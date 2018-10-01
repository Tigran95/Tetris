
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Points
{
    bottomLeftPoint,
    bottomRightPoint,
    topRightPoint,
    topLeftPoint,
    CenterPoint,
    CenterRight
}

public class CameraPoints : MonoBehaviour
{

    public GameObject[] CameraAngels { get; private set; }
    
    private void Start()
    {
        
        CreateCameraPoints();
    }
    private void Update()
    {
        SetPointsPositions();
       
    }
    private void CreateCameraPoints()
    {
        CameraAngels = new GameObject[6];
        for (int i = 0; i < CameraAngels.Length; i++)
        {
            CameraAngels[i] = new GameObject();
            CameraAngels[i].transform.SetParent(Camera.main.transform, false);
        }
        CameraAngels[0].name = "bottomLeftPoint";
        CameraAngels[1].name = "bottomRightPoint";
        CameraAngels[2].name = "topRightPoint";
        CameraAngels[3].name = "topLeftPoint";
        CameraAngels[4].name = "CenterPoint";
        CameraAngels[5].name = "CenterRight";
    }

   
    private void SetPointsPositions()
    {
        float width = Camera.main.pixelWidth;
        float height = Camera.main.pixelHeight;
        CameraAngels[(int)Points.bottomLeftPoint].transform.position = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        CameraAngels[(int)Points.bottomRightPoint].transform.position = Camera.main.ScreenToWorldPoint(new Vector2(width, 0));
        CameraAngels[(int)Points.topRightPoint].transform.position = Camera.main.ScreenToWorldPoint(new Vector2(width, height));
        CameraAngels[(int)Points.topLeftPoint].transform.position = Camera.main.ScreenToWorldPoint(new Vector2(0, height));
        CameraAngels[(int)Points.CenterPoint].transform.position = Camera.main.ScreenToWorldPoint(new Vector2(width/2, height/2));
        CameraAngels[(int)Points.CenterRight].transform.position = Camera.main.ScreenToWorldPoint(new Vector2(width, height / 2));

    }
   

}

