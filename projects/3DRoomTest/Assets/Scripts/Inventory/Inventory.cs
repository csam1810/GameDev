using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public string inventoryName = "General Inventory";
	public int maxInventorySize = 5;
	public GameObject inventoryCanvasPrefab;
	public GameObject inventoryCanvasItemPrefab;
	public int panelHeight = 500;
	public int panelWidth = 500;

	private GameObject inventoryCanvas;

	//change to map: Object -> numOccurences;
	//TODO: what exactly is key??
	private List<InventoryItem> items;
	//we don't use items.Count here since we plan to have multiple lists in the future,
	//and want to be able to get the current number of items quickly
	private int numItems;

	void Start() {
		items = new List<InventoryItem>();
		numItems = 0;
		createInventoryCanvas ();
	}

	private void createInventoryCanvas() {
		//create 
		inventoryCanvas = GameObject.Instantiate (inventoryCanvasPrefab);
		inventoryCanvas.name = inventoryName;
		initializeInventoryPanel ();
		initializeInventoryCanvas ();
	}

	private void initializeInventoryPanel() {
		Debug.Assert (inventoryCanvas.transform.childCount == 1);
		RectTransform panelRect = inventoryCanvas.transform.GetChild (0).GetComponent<RectTransform>();
		Debug.Log (panelRect);
		//TODO: why does this have no effect?
		panelRect.rect.Set (0, 0, panelWidth, panelHeight);
	}

	private void initializeInventoryCanvas() {
		Debug.Assert (inventoryCanvas.transform.childCount == 1);
		//get the panel in the inventory canvas
		RectTransform panelRect = inventoryCanvas.transform.GetChild (0).GetComponent<RectTransform>();
		//TODO: these values should be properties and dependent on the panel size
		//======= BEGIN =========
		int columnCount = 4;
		int tileWidth = 60;
		int tileHeight = 60;
		//======= END =========
		int j = 0;
		for (int i = 0; i < maxInventorySize; i++) {
			GameObject obj = Object.Instantiate (inventoryCanvasItemPrefab) as GameObject;
			obj.transform.SetParent(panelRect.transform);

			//note: taken from tutorial, not yet understood
			//======= BEGIN =========
			if (i % columnCount == 0)
				j++;
			//move and size the new item
			RectTransform rectTransform = obj.GetComponent<RectTransform>();
			
			float x = -panelRect.rect.width / 2 + tileWidth * (i % columnCount);
			float y = panelRect.rect.height / 2 - tileHeight * j;
			rectTransform.offsetMin = new Vector2(x, y);
			
			x = rectTransform.offsetMin.x + tileWidth;
			y = rectTransform.offsetMin.y + tileHeight;
			rectTransform.offsetMax = new Vector2(x, y);
			//======= END =========
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

	public void printInventory() {
		Debug.Log (numItems + " currently in inventory: ");
		foreach (InventoryItem item in items) {
			Debug.Log ("item name:" + item.name + ", item icon: " + item.icon);
		}
	}

	//some methods that check instanceOf items and only return certain types?
	//e.g. getPotions(), getWeapons()
}
