using UnityEngine;
using System.Collections;
using System;

[Serializable]
public abstract class Weapon : InventoryItem {

	public float damage;
	//TODO: for now, just take the health potion sprite 
	private string defaultWeaponSpritePath = "Sprites/InventorySprites/healthPotion1.png";

	public Weapon(string name, string desc) : base(name, desc) {
		//load default icon if no icon was specified
		if (this.icon == null) {
			this.icon = Resources.Load<Sprite>(defaultWeaponSpritePath);
		}
	}
}
