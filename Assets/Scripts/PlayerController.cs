using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerController : NetworkBehaviour {

    [SerializeField]
    private float speed = 5f;

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


}
