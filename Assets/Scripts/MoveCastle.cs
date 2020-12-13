using UnityEngine;

public class MoveCastle : MonoBehaviour {
    [SerializeField] Transform player;
    [SerializeField] int distance;

    private void FixedUpdate () =>
        this.transform.position = new Vector3 (
            this.transform.position.x,
            this.transform.position.y,
            player.position.z + distance);

    // void LateUpdate () {
    //     //block skinRotation
    //     this.transform.forward = player.transform.forward;
    // }
}