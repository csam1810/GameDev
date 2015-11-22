using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class HealthPotion : Potion {

	public int regeneratedHealthPoints = 5;

	public HealthPotion(string name, string desc) : base(name, desc) {
		//do some HealthPotion specific things here
		this.icon = Resources.Load<Sprite> ("/Sprites/InventorySprites/healthPotion1");
	}
}
