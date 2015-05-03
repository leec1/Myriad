using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Player : MonoBehaviour {
	
	private Role currentRole = null;
	private int currentHealth;
	private int maxHealth;
	private int money;
	private Weapon weapon;
	private Armor armor;

	// Use this for initialization
	void Start () {
		name = "BOB";
		this.becomeSoldier();
		maxHealth = 100;
		currentHealth = maxHealth;
		money = 0;
		weapon = new Weapon (name + "'S WEAPON");
		armor = new Armor (name + "'S ARMOR");
	}
	
	// Update is called once per frame
	void Update () {

	}

	public bool becomeSoldier()
	{
		bool success = false;
		lock (this) {
			if ( null == currentRole ) {
				currentRole = new Soldier( this );
				success = true;
			} else {
				Soldier newRole = currentRole.becomeSoldier();
				if (null != newRole) {
					// Successfully Left the Commmand Base
					currentRole = newRole;
					success = true;
				}
			}
		}
		return success;
	}

	public bool becomeCommander()
	{
		bool success = false;
		lock ( this ) {
			if ( null == currentRole )
			{
				if ( CommandBase.Instance.enter( this ) ) {
					currentRole = new Commander( this );
					success = true;
				}
			} else {
				Commander newRole = currentRole.becomeCommander();
				if ( null != newRole ) {
					// Successfully Entered the Command Base
					currentRole = newRole;
					success = true;
				}
			}
		}
		return success;
	}

	public bool promptLeaveCommander()
	{
		// POP UP PROMPT
		// Assume (for now) that they always leave when prompted
		return this.becomeSoldier();
	}

	
	
}
