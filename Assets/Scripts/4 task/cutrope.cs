using UnityEngine;

public class cutrope : MonoBehaviour {
	[SerializeField] task task;
	[SerializeField] int id;

	private void OnTriggerEnter () => cut ();

	void cut () {
		task.Cut (id);
		Destroy (this.gameObject, 0.2f);
	}

}