using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Sword : Weapon {

	public string swordSpritePath;

	public Sword(string name, string desc) : base (name, desc) {

	}
}
