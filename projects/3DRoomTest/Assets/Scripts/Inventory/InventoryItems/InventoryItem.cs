using UnityEngine;
using System;

[Serializable]
public abstract class InventoryItem {

	public string name;
	public string description;
	public Sprite icon;

	public InventoryItem(string name, string desc) {
		this.name = name;
		this.description = desc;
		//load icon as a sprite
		this.icon = null;
	}
}