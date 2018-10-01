using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixGrid:MonoBehaviour
{
    public  int Column{ get; private set; }
    public int Row { get; private set; }

    public Transform[,] Grid { get; set; }

    private void Start()
    {
       Row = GridCreator.countOfRows + 2;
       Column = GridCreator.countOfColumns;
       Grid =  new Transform[GridCreator.countOfColumns,GridCreator.countOfRows+2];

    }
    public  Vector2 RoundVector(Vector2 vector)
    {
        return new Vector2(Mathf.Round(vector.x), Mathf.Round(vector.y));
    }

    public  bool IsInside(Vector2 position)
    {
        return ((int)position.x >= 0 && (int)position.x < Column && (int)position.y >= 0);
    }

    public  void DeletaRow(int rowsIndex)
    {
        for (int i = 0; i < Column; i++)
        {
            GameObject.Destroy(Grid[i, rowsIndex].gameObject);
            Grid[i, rowsIndex] = null;
        }
        FindObjectOfType<GameScore>().ChangeScore();
    }

    public  void DecreaseRow(int rowsIndex)
    {
        for (int i = 0; i < Column; i++)
        {
            if (Grid[i, rowsIndex] != null)
            {
                Grid[i, rowsIndex - 1] = Grid[i, rowsIndex];
                Grid[i, rowsIndex] = null;
                Grid[i, rowsIndex - 1].position += new Vector3(0,-1,0);
            }
        }
    }
    public  void DecreaseRowsAbove(int rowsIndex)
    {
        for (int i = rowsIndex; i < Row; i++)
        {
            DecreaseRow(i);
        }
    }

    public  bool IsRowFull(int rowsIndex)
    {
        for (int i = 0; i < Column; i++)
        {
            if (Grid[i, rowsIndex] == null)
            {
                return false;
            }
        }
        return true;
    }

    public  void DeleteWholeRows()
    {
        for(int i = 0; i < Row; i++)
        {
            if (IsRowFull(i))
            {
                DeletaRow(i);
                DecreaseRowsAbove(i + 1);
                --i;
            }
        }
    }
}
