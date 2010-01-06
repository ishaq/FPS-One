using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class PlayerCollisions : MonoBehaviour {

	private bool isDoorOpen = false;
	private float doorTimer = 0.0F;
	private GameObject currentDoor;

	public float doorOpenTime = 3.0F;
	public AudioClip doorOpenSound;
	public AudioClip doorCloseSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		RaycastHit hit;
		
		if(Physics.Raycast(transform.position, transform.forward, out hit, 5)) {
			if(hit.collider.gameObject.tag == "OutpostDoor" && isDoorOpen == false){ 
				currentDoor = hit.collider.gameObject;
				HandleDoor(currentDoor, doorOpenSound, "dooropen", true);
			}
		}
		
		if(isDoorOpen) {
			doorTimer += Time.deltaTime;
			if(doorTimer > doorOpenTime) {
				HandleDoor(currentDoor, doorCloseSound, "doorshut", false);
				doorTimer = 0.0F;
			}
			
		}	
	}
	
/*	void OnControllerColliderHit(ControllerColliderHit hit) {
		if(hit.gameObject.tag == "OutpostDoor" && isDoorOpen == false){ 
			currentDoor = hit.gameObject;
			HandleDoor(currentDoor, doorOpenSound, "dooropen", true);
		} 
	}
*/

	void HandleDoor(GameObject thisDoor, AudioClip doorSound, string animationName, bool doorStatus) {
		isDoorOpen = doorStatus;
		audio.PlayOneShot(doorSound);
		thisDoor.transform.parent.animation.Play(animationName);
	}
}
