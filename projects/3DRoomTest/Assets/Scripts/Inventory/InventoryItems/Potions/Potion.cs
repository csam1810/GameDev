using UnityEngine;
using System.Collections;
using System;

[Serializable]
public abstract class Potion : InventoryItem {

	//some potion specific code, maybe just some marker that this is drinkable
	//TODO for testing purposes just use the health potion sprite as default
	private string defaultPotionSpritePath = "Sprites/InventorySprites/healthPotion1.png";

	public Potion(string name, string desc) : base(name, desc) {
		//load default icon if no icon was specified
		if (this.icon == null) {
			this.icon = Resources.Load<Sprite>(defaultPotionSpritePath);
		}
	}
}
