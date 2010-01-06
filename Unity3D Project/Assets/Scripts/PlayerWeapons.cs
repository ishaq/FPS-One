using UnityEngine;
using System.Collections;

public class PlayerWeapons : MonoBehaviour {

	void Awake () {
		// Select the first weapon 
		SelectWeapon(0);
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Did the user press fire? 
		 if (Input.GetButton ("Fire1")) 
		  BroadcastMessage("Fire"); 
		 if (Input.GetKeyDown("1")) { 
		  SelectWeapon(0); 
		 }    
		 else if (Input.GetKeyDown("2")) { 
		  SelectWeapon(1); 
		}
	}
	
	void SelectWeapon(int index) { 
		for (int i=0; i<transform.childCount; i++) { 
	  		// Activate the selected weapon 
	  		if (i == index) 
	   	transform.GetChild(i).gameObject.SetActiveRecursively(true); 
		  // Deactivate all other weapons 
		  else 
		   transform.GetChild(i).gameObject.SetActiveRecursively(false); 
		}
	} 
	
}