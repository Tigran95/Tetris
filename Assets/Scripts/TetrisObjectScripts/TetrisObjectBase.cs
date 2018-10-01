using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TetrisObjectBase : MonoBehaviour {

    private float _lastFall;
    private float _speed;
    private MatrixGrid _matrixGrid;
    private UIManager _uIManager;
    private bool _isLost;

    public abstract void Rotate();
    public abstract void ReturnRotate();

    private void Start()
    {
        _matrixGrid = FindObjectOfType<MatrixGrid>();
        _uIManager = FindObjectOfType<UIManager>();
    }
    private void Update()
    {
        if (Time.timeScale != 0 && Time.time - _lastFall >= 1 - FindObjectOfType<UIManager>().speedSlider.value)
        {
            MoveToBottom();
        }
    }
    public void MoveToLeft()
    {
        transform.position += new Vector3(-1, 0, 0);
        if (IsValidGridPosition())
        {
            UpdateMatrixGrid();
        }
        else
        {
            transform.position += new Vector3(1, 0, 0);
        }
    }
    public void MoveToRight()
    {
        transform.position += new Vector3(1, 0, 0);
        if (IsValidGridPosition())
        {

            UpdateMatrixGrid();
        }
        else
        {
            transform.position += new Vector3(-1, 0, 0);
        }
    }
    public void MoveToBottom()
    {
        transform.position += new Vector3(0, -1, 0);
        _lastFall = Time.time;
        if (IsValidGridPosition())
        {
            FindObjectOfType<AudioSelecting>().ChooseAudio(AudioTypes.moveDown);
            _isLost = true;

            UpdateMatrixGrid();
        }
        else
        {
            if (!_isLost)
            {
                _uIManager.Lose();
                enabled = false;
                return;
            }
            transform.position += new Vector3(0, 1, 0);
            _matrixGrid.DeleteWholeRows();
            FindObjectOfType<Spawner>().SpawnRandomObject();
            enabled = false;
        }
    }
    public void DoRotate()
    {
       

        Rotate();
        if (IsValidGridPosition())
        {
            UpdateMatrixGrid();
        }
        else
        {
            ReturnRotate();
        }
    }

   

    private   bool IsValidGridPosition()
    {
        foreach(Transform child in transform)
        {
            Vector2 vector = _matrixGrid.RoundVector(child.position);
            if (!_matrixGrid.IsInside(vector))
            {
                return false;
            }
            if (_matrixGrid.Grid[(int)vector.x, (int)vector.y] != null &&_matrixGrid.Grid[(int)vector.x, (int)vector.y].parent != transform)

            {
                return false;
            }
        }
        return true;
    }
    private  void UpdateMatrixGrid()
    {
        for (int i = 0; i < FindObjectOfType<MatrixGrid>().Row; i++)
        {
            for (int j = 0; j < FindObjectOfType<MatrixGrid>().Column; j++)
            {
                if (_matrixGrid.Grid[j, i] != null)
                {
                    if (_matrixGrid.Grid[j, i].parent == transform)
                    {
                        _matrixGrid.Grid[j, i] = null;
                    }
                }
            }
        }

        foreach (Transform child in transform)
        {
            Vector2 vector = _matrixGrid.RoundVector(child.position);
            _matrixGrid.Grid[(int)vector.x, (int)vector.y] = child;
        }
    }
}
