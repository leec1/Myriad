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
		bool success;
		lock (this) {
			switch ( currentRole ) {
				case Role.COMMANDER:
					if (CommandBase.Instance.leave (this)) {
						// Successfully Left the Commmand Base
						currentRole = Role.SOLDIER;
						viewStyle = ViewStyle.FIRST_PERSON;
						success = true;
					} else {
						success = false;
					}
					break;
				default:
					success = false;
					break;
			}
		}
		return success;
	}

	public bool becomeCommander()
	{
		bool success;
		lock ( this ) {
			switch ( currentRole ) {
				case Role.SOLDIER:
					if ( CommandBase.Instance.enter (this) ) {
						// Successfully Entered the Command Base
						currentRole = Role.COMMANDER;
						viewStyle = ViewStyle.TOP_DOWN;
						success = true;
					} else {
						success = false;
					}
					break;
				default:
					success = false;
					break;
			}
		}
		return success;
	}

	public bool promptLeaveCommander()
	{
		bool success;
		lock (this) {
			switch ( currentRole ) {
				case Role.COMMANDER:
					// POP UP PROMPT
					// Assume (for now) that they always leave when prompted
					success = CommandBase.Instance.leave (this);
					break;
				default:
					// Wasn't a COMMANDER to begin with
					success = true;
					break;
			}
		}
		return success;
	}

	
	
}
