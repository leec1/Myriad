using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Player : MonoBehaviour {
	
	private Role currentRole = Role.INVALID;
	private ViewStyle viewStyle = ViewStyle.INVALID;
	private int currentHealth;
	private int maxHealth;
	private int money;
	private Weapon weapon;
	private Armor armor;

	// Use this for initialization
	void Start () {
		name = "BOB";
		currentRole = Role.SOLDIER;
		viewStyle = ViewStyle.FIRST_PERSON;
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
			if (Role.COMMANDER == currentRole) {
				if (CommandBase.Instance.leave (this)) {
					// Successfully Left the Commmand Base
					currentRole = Role.SOLDIER;
					viewStyle = ViewStyle.FIRST_PERSON;
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
			if ( Role.SOLDIER == currentRole ) {
				if ( CommandBase.Instance.enter (this) ) {
					// Successfully Entered the Command Base
					currentRole = Role.COMMANDER;
					viewStyle = ViewStyle.TOP_DOWN;
					success = true;
				}
			}
		}
		return success;
	}

	public bool promptLeaveCommander()
	{
		bool success = false;
		lock (this) {
			if ( Role.COMMANDER == currentRole ) {
				// POP UP PROMPT
				// Assume (for now) that they always leave when prompted
				success = CommandBase.Instance.leave (this);
			}
		}
		return success;
	}

	
	
}
