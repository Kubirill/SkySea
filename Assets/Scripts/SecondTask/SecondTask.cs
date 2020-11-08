using System.Collections;
using DG.Tweening;
using PathCreation.Examples;
using UnityEngine;
public class SecondTask : MonoBehaviour {

	[SerializeField] Transform goalLeft;
	[SerializeField] Transform goalRight;
	[SerializeField] GameObject sign;
	[SerializeField] GameObject rope;
	[SerializeField] GameObject fallRock;
	[SerializeField] Transform catapult;
	GameObject dragon;

	AudioSource _audioSource;
	private void Start () {
		_audioSource = this.gameObject.GetComponent<AudioSource> ();
		dragon = GameObject.FindGameObjectWithTag("Dragon");
	}

	private void OnTriggerEnter () => cut ();

	private void Update () {
		if (Input.GetKeyDown (KeyCode.Q))
			cut ();
	}
	void cut () {
		_audioSource.Play ();
		dragon.GetComponent<Animator>().SetTrigger("CatsSave");
		rope.GetComponent<AudioSource> ().Play ();
		Destroy (rope);
		var rb = fallRock.GetComponent<Rigidbody> ();
		rb.isKinematic = false;
		rb.AddForce (new Vector3 (0, -1000, 0), ForceMode.Impulse);
		StartCoroutine (RockFly (0.3f));
	}
	IEnumerator RockFly (float time) {
		yield return new WaitForSeconds (time);
		sign.GetComponent<PathFollower> ().enabled = true;
		catapult.DORotate (new Vector3 (0, 0, -112), 0.2f);
		StartCoroutine (OpenDoors (1.3f));
	}
	IEnumerator OpenDoors (float time) {

		yield return new WaitForSeconds (time);
		dragon.GetComponent<Animator>().SetTrigger("CatsSave");
		goalLeft.DORotate (new Vector3 (0, 90, 0), 10);
		goalRight.DORotate (new Vector3 (0, -90, 0), 10);
	}

}