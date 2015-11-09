using UnityEngine;
using System.Collections;

public class ToggleView : MonoBehaviour {

	public float thirdPersonDistance = -0.8f;

	private bool firstPerson = false;


	// Use this for initialization
	void Start () {
		firstPerson = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			if(firstPerson) {
				transform.position += new Vector3(0,0,thirdPersonDistance);
			} else {
				transform.position -= new Vector3(0,0,thirdPersonDistance);
			}
			firstPerson = !firstPerson;
		}
	}
}
