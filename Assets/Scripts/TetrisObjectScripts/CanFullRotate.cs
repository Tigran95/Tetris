using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanFullRotate : TetrisObjectBase {

    public override void Rotate()
    {
        FindObjectOfType<AudioSelecting>().ChooseAudio(AudioTypes.rotate);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z + 90));
       
    }

    public override void ReturnRotate()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z - 90));
    }



}
