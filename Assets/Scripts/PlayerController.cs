using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerController : NetworkBehaviour {

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private Vector3 initCameraPos = new Vector3(-5f, 5f, 0);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(isLocalPlayer) {
            InputMovement();
        }


	}

    void InputMovement() {
        var x = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        var z = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Translate(x, 0, z);
    }

    public override void OnStartLocalPlayer() {
        //Set the color to blue for the local player
        GetComponent<MeshRenderer>().material.color = Color.blue;
    
        
        //Attach the camera on spawn
        Camera cam = Camera.main;
        cam.transform.position = transform.position + initCameraPos;
        cam.transform.LookAt(transform);
        
    }

}
