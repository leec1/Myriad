using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Player : MonoBehaviour {

	Role currentRole = null;


	// Use this for initialization
	void Start () {
		currentRole = new Soldier ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
