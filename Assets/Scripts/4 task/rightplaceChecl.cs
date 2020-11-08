using UnityEngine;

public class rightplaceChecl : MonoBehaviour {
	[SerializeField] task task;

	private void OnTriggerEnter (Collider other) {
		print ($"7. rightplaceChecl -> other : {other}");
		if (other.gameObject.tag == "barrel")
			task.OnRightPlaceShootBarrel ();
	}
}