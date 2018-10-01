using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdaptor : MonoBehaviour {

    private CameraPoints _cameraPoints;
    private GridCreator _gridCreator;
    private Camera _camera;
    private Spawner _spawner;

    private GameObject _leftBottomGrid;
    private GameObject _leftTopGrid;

    private bool _canIMoveDown;

    public bool IsAdapted { get; private set; }

    public GameObject userInput;
    private void Awake()
    {

        _cameraPoints = FindObjectOfType<CameraPoints>();
        _gridCreator = FindObjectOfType<GridCreator>();
        _camera = GetComponent<Camera>();
        _spawner = FindObjectOfType<Spawner>();
    }

    private IEnumerator Start()
    {
        while (_gridCreator.AllGrids == null)
        {
            yield return new WaitForEndOfFrame();
        }
        _leftBottomGrid = _gridCreator.AllGrids[0, 0];
        _leftTopGrid = _gridCreator.AllGrids[0, GridCreator.countOfRows - 1];
        SetCamerasFirsPosition();
    }
    private void Update()
    {
        if (IsAdapted)
        {
            return;
        }
        if (_leftBottomGrid == null || _leftTopGrid == null || _cameraPoints.CameraAngels == null)
        {
            return;
        }
        AdaptTheCamera();
    }

    private void SetCamerasFirsPosition()
    {
        if (GridCreator.countOfColumns % 2 != 0)
        {
            Camera.main.transform.position = _gridCreator.AllGrids[GridCreator.countOfColumns / 2, GridCreator.countOfRows / 2].transform.position
                - new Vector3(0, 0, 10);
        }
        else
        {
            Camera.main.transform.position = new Vector3(_gridCreator.AllGrids[GridCreator.countOfColumns / 2,
                GridCreator.countOfRows / 2].GetComponent<Renderer>().bounds.min.x,
                _gridCreator.AllGrids[GridCreator.countOfColumns / 2, GridCreator.countOfRows / 2].GetComponent<Renderer>().bounds.min.y,
                -10);
        }
    }

    private void AdaptTheCamera()
    {
        if (!_canIMoveDown)
        {
            if (_leftBottomGrid.GetComponent<Renderer>().bounds.min.x < _cameraPoints.CameraAngels[(int)Points.bottomLeftPoint].transform.position.x
               || _leftTopGrid.GetComponent<Renderer>().bounds.max.y > _cameraPoints.CameraAngels[(int)Points.topLeftPoint].transform.position.y
               || _leftBottomGrid.GetComponent<Renderer>().bounds.min.y < _cameraPoints.CameraAngels[(int)Points.bottomLeftPoint].transform.position.y)
            {
                _camera.orthographicSize += 0.5f;
            }
            else
            {
                _canIMoveDown = true;
            }
        }
        if (_canIMoveDown)
        {
            if (_leftBottomGrid.GetComponent<Renderer>().bounds.min.y > _cameraPoints.CameraAngels[(int)Points.bottomLeftPoint].transform.position.y)
            {
                _camera.gameObject.transform.position += new Vector3(0, 0.1f, 0);
            }
            else
            {
                EndingAdaptation();
            }
        }
    }

    private void EndingAdaptation()
    {
        IsAdapted = true;
        _spawner.SpawnRandomObject();
        userInput.SetActive(true);
    }
}
