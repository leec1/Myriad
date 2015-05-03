using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Player : MonoBehaviour {

	private string name;
	private Role currentRole = null;
	private int currentHealth;
	private int maxHealth;
	private int money;
	private Weapon weapon;
	private Armor armor;

	// Use this for initialization
	void Start () {
		name = "BOB";
		currentRole = new Soldier ();
		maxHealth = 100;
		currentHealth = maxHealth;
		money = 0;
		weapon = new Weapon (name + "'S WEAPON");
		armor = new Armor (name + "'S ARMOR");
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
