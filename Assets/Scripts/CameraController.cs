using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private float lookSpeed = 5f;

	// Update is called once per frame
	void Update () {
        DragCamera();
	}

    void RotateCamera() {
        var rot =  Input.GetAxis("Mouse X") * lookSpeed;

        if (transform.parent) {
            transform.Rotate(transform.parent.up, rot);
        }
    }


    private Vector3? mouseDownPosition;
    private Vector3? currentMousePosition;

    private enum MouseButtons { LEFT, RIGHT, CENTER, SIDE}

    [SerializeField]
    private MouseButtons dragButton = MouseButtons.LEFT;

    void DragCamera() {
        if(Input.GetMouseButtonDown((int)dragButton)) {
            mouseDownPosition = GetMouseWorldPosition();
        } else if(Input.GetMouseButton((int)dragButton)) {
            currentMousePosition = GetMouseWorldPosition();
        }
        if(Input.GetMouseButtonUp((int)dragButton)) {
            mouseDownPosition = null;
            currentMousePosition = null;
        }

        if(mouseDownPosition.HasValue && currentMousePosition.HasValue) {
            var diff = mouseDownPosition.Value - currentMousePosition.Value;
            diff.y = 0;
            transform.position += diff;
        }
    }

    Vector3? GetMouseWorldPosition() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, (1<<8))) {
            return hit.point;
        }

        return null;
    }


}
