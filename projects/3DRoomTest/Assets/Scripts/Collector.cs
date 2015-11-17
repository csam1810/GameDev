using UnityEngine;
using System.Collections;

public class Collector : MonoBehaviour {

	public KeyCode collectKey = KeyCode.E;
	public KeyCode showInventoryKey = KeyCode.I;

	public int maxSize = 10;

	private ArrayList inventory;

	// Use this for initialization
	void Start () {
		inventory = new ArrayList ();
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Input.GetKeyDown (collectKey)) {
			if (Physics.Raycast (ray, out hit, 10)) {
				Debug.DrawLine (ray.origin, hit.point);
				GameObject hitObject = hit.collider.gameObject;
				if (hitObject && hitObject.tag.Equals ("Collectable")) {
					Debug.Log (hitObject);
					Collectable element = hitObject.GetComponent<Collectable> ();
					if (inventory.Count < maxSize) {
						inventory.Add (element);
						Destroy (hitObject);
					}
				}
			}

		} else if (Input.GetKeyDown (showInventoryKey)) {
			//"show" Collectables in inventory
			foreach (Collectable collectable in inventory) {
				Debug.Log ("item name:" + collectable.potion.name);
			}
		}

	}
}
