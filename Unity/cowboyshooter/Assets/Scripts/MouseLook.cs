using System.Collections;
using UnityEngine;

public class MouseLook : MonoBehaviour {
    public enum RotationAxes {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;

    public float minimumVert = -80.0f;
    public float maximumVert = 80.0f;

    private float _rotationX = 0;
    // Update is called once per frame
    void Update () {
        //horizontal rotation here
        if (axes == RotationAxes.MouseX) {
            transform.Rotate (0, Input.GetAxis ("Mouse X") * sensitivityHor, 0);
            //Debug.Log(_rotationX);

        }
        //vertical rotation here
        else if (axes == RotationAxes.MouseY) {
            _rotationX -= Input.GetAxis ("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp (_rotationX, minimumVert, maximumVert);

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3 (_rotationX, rotationY, 0);

            //Debug.Log(rotationY);
        }
        //both horizontal and vertical rotation here
        else {
            _rotationX -= Input.GetAxis ("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp (_rotationX, minimumVert, maximumVert);

            float delta = Input.GetAxis ("Mouse X") * sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3 (_rotationX, rotationY, 0);

            //Debug.Log(_rotationX);
            //Debug.Log(rotationY);
        }

    }
}