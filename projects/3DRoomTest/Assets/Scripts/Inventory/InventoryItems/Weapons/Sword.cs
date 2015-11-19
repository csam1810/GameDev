using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Sword : Weapon {

	public Sword(string name, string desc) : base (name, desc, 10f) {
		//per default every sword has damage 10.0 right now
	}
}
