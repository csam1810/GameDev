using UnityEngine;
using System.Collections;
using System;

[Serializable]
public abstract class Potion : InventoryItem {

	//some potion specific code, maybe just some marker that this is drinkable

	//base == super in java
	public Potion(string name, string desc) : base(name, desc) {
		//do some potion specific actions here
	}
}
