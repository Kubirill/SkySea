using DG.Tweening;
using UnityEngine;
public class Rotate : MonoBehaviour {

	[SerializeField] Transform plot;
	[SerializeField] bool left;
	[SerializeField] float smooth = 0.3f;
	[SerializeField] float angle = 15;
	float rotAngle = 0;

	private void OnTriggerEnter () {
		rotAngle += left ? -angle : angle;
		plot.DORotate (new Vector3 (0, rotAngle, 0), smooth);
	}
}