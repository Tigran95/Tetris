using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UserInput : MonoBehaviour,  IPointerUpHandler,IPointerDownHandler
{
    private Vector2 _firstClickPosition;
    private Vector2 _finalClickPosition;
    private float _swipeResist ;
    private float _swipeAngle;


    private void Start()
    {
        _swipeResist = 1;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _firstClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _finalClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        CalculateAngle();
    }

    private void CalculateAngle()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        Vector2 vector = _finalClickPosition - _firstClickPosition;
       
        if (Mathf.Abs(vector.x) > _swipeResist || Mathf.Abs(vector.y) > _swipeResist)
        {
            _swipeAngle = Mathf.Atan2(vector.y, vector.x) * 180 / Mathf.PI;
            MoveTetrisObject();
        }
        else
        {
            FindObjectOfType<TetrisObjectBase>().DoRotate();
        }
       
    }

   
    private void MoveTetrisObject()
    {
        
        if (_swipeAngle > -45 && _swipeAngle <= 45)
        {
            FindObjectOfType<TetrisObjectBase>().MoveToRight();


        }
      
        else if ((_swipeAngle > 135 || _swipeAngle <= -135))
        {
            FindObjectOfType<TetrisObjectBase>().MoveToLeft();
        }

        else if (_swipeAngle < -45 && _swipeAngle >= -135)
        {

            FindObjectOfType<TetrisObjectBase>().MoveToBottom();
        }
    }

    
}
