using DG.Tweening;
using UnityEngine;
public class Rotate : MonoBehaviour {

	[SerializeField] Transform plot;
	[SerializeField] bool left;
	[SerializeField] float smooth = 0.3f;
	[SerializeField] float angle = 15;

	private void OnTriggerStay () =>
		plot.DORotate (new Vector3 (0, plot.rotation.eulerAngles.y +
			(angle * (left ? -1 : 1)), 0), smooth);

}