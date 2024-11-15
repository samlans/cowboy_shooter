using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour {
    private Camera _camera;
    // Start is called before the first frame update
    void Start () {
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButton (0)) {
            Vector3 point = new Vector3 (
                _camera.pixelWidth / 2,
                _camera.pixelHeight / 2,
                0
            );
            
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast (ray, out hit)) {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null) {
                    target.ReactToHit ();
                }

            }
        }
    }
}