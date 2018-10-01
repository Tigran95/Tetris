using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanHalfRotate : TetrisObjectBase {

    public override void Rotate()
    {
        FindObjectOfType<AudioSelecting>().ChooseAudio(AudioTypes.rotate);
        if (transform.rotation.eulerAngles.z == 90)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z - 90));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z + 90));
        }
     
    }

    public override void ReturnRotate()
    {
        Rotate();
    }
}
