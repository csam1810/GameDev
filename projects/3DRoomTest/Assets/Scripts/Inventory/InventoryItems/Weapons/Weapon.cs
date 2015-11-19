using UnityEngine;
using System.Collections;
using System;

[Serializable]
public abstract class Weapon : InventoryItem {

	public float damage;

	public Weapon(string name, string desc, float dmg) : base(name, desc) {
		this.damage = dmg;
	}
}
