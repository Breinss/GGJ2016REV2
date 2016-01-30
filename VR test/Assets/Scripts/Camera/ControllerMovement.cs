using UnityEngine;
using System.Collections;

public class ControllerMovement : MonoBehaviour {

    public float sens = 15f;

    void FixedUpdate()
    {
        if (Input.GetAxis("HorizontalRight") > 0)
        {
            transform.Rotate(0, Time.deltaTime * sens, 0);
        }
        if (Input.GetAxis("HorizontalRight") < 0)
        {
            transform.Rotate(0, Time.deltaTime * sens * -1, 0);
        }
    }
}
