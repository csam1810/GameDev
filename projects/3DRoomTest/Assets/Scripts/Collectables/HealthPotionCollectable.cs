using UnityEngine;
using System.Collections;

public class HealthPotionCollectable : Collectable {

	public HealthPotion potion;

	public override InventoryItem getInventoryItem() {
		return potion;
	}

}
