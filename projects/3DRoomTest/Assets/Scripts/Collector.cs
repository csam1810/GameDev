using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Collector : MonoBehaviour {

	public KeyCode collectKey = KeyCode.E;
	public KeyCode showInventoryKey = KeyCode.I;

	public float raycastDistance = 100f;

	private bool isInventoryShown = false;
	private GameObject inventoryCanvas;
	private Inventory playerInventory;

	// Use this for initialization
	void Start () {
		playerInventory = GameObject.FindGameObjectWithTag ("PlayerInventory").GetComponent<Inventory>();
		inventoryCanvas = GameObject.FindGameObjectWithTag("InventoryCanvas");
		//deactivate inventory canvas upon start
		inventoryCanvas.SetActive(isInventoryShown);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (collectKey)) {
			Collectable collectable = getCollectable(getRaycastHitObject());
			if (collectable) {
				//try adding item to inventory
				if(playerInventory.addItem(collectable.getInventoryItem())) {
					Debug.Log("add item to inventory!");
					//collectable is only a component, get whole game object and destroy it
					Destroy(collectable.gameObject);
				}
			}
		} else if (Input.GetKeyDown (showInventoryKey)) {
			inventoryAction();
		}
	}

	private void inventoryAction() {
		//toggle boolean
		isInventoryShown = !isInventoryShown;
		inventoryCanvas.SetActive(isInventoryShown);

		if(isInventoryShown) {
			isInventoryShown = true;
			inventoryCanvas.SetActive(isInventoryShown);
			Button[] itemButtons = inventoryCanvas.GetComponentsInChildren<Button>();
			List<InventoryItem> items = playerInventory.getItems();
			//TODO: right now just assume we have less items than buttons, otherwise exception
			for(int i = 0; i < items.Count; i++) {
				Image[] itemImages = itemButtons[i].GetComponentsInChildren<Image>();
				foreach(Image itemImage in itemImages) {
					if(itemImage.tag.Equals("InventoryCanvasItemSprite")) {
						itemImage.sprite = items[i].icon;
					}
				}
				
			}
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
