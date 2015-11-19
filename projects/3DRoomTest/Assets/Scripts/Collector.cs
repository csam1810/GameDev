using UnityEngine;
using System.Collections;

/*
 * TODO: issues to discuss:
 * 
 */

public class Collector : MonoBehaviour {

	public KeyCode collectKey = KeyCode.E;
	public KeyCode showInventoryKey = KeyCode.I;

	public float raycastDistance = 100f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (collectKey)) {
			Collectable collectable = getCollectable(getRaycastHitObject());
			if (collectable) {
				//try adding item to inventory
				if(Inventory.instance.addItem(collectable.getInventoryItem())) {
					Debug.Log("add item to inventory!");
					//collectable is only a component, get whole game object and destroy it
					Destroy(collectable.gameObject);
				}
			}
		} else if (Input.GetKeyDown (showInventoryKey)) {
			showInventory();
		}
	}

	private GameObject getRaycastHitObject() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, raycastDistance)) {
			Debug.DrawLine (ray.origin, hit.point);
			return hit.collider.gameObject;
		}
		return null;
	}

	private void showInventory() {
		//"show" Collectables in inventory
		Debug.Log("inventory:");
		foreach (InventoryItem item in Inventory.instance.getItems()) {
			Debug.Log ("item name:" + item.name);
		}
	}

	private Collectable getCollectable(GameObject obj) {
		//check the object itself and it's parents for the tag "Collectable"
		if (obj) {
			//check if object itself is tagged
			if(obj.tag.Equals("Collectable")) {
				return obj.GetComponent<Collectable>();
			}
			//if not, check parents
			if(obj.transform.parent) {
				GameObject parent = obj.transform.parent.gameObject;
				if(parent) {
					return getCollectable(parent);
				} else {
					return null;
				}
			}
		}
		return null;
	}
}
