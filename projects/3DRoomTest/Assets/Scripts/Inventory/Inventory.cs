using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	public static Inventory instance;

	public int maxInventorySize = 10;
	
	private List<InventoryItem> items;
	//we don't use items.Count here since we plan to have multiple lists in the future,
	//and want to be able to get the current number of items quickly
	private int numItems;

	void Start() {
		items = new List<InventoryItem>();
		numItems = 0;

		if (instance == null) {
			instance = this.gameObject.GetComponent<Inventory>();
		}
	}

	//TODO: do I really need method here?
	public List<InventoryItem> getItems() {
		return items;
	}

	public bool addItem(InventoryItem item) {
		if (isSpaceLeft()) {
			items.Add (item);
			numItems++;
			return true;
		}
		return false;
	}

	public bool isSpaceLeft() {
		return numItems < maxInventorySize;
	}

	//some methods that check instanceOf items and only return certain types?
	//e.g. getPotions(), getWeapons()
}
