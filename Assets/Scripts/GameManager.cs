using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class GameManager : MonoBehaviour
{

    [SerializeField] DragonMove move;
    [SerializeField] GameObject startButton;

    public void PressStart()
    {
        move.enabled = true;
        // disable kinematic
        move.gameObject.GetComponent<Rigidbody>().useGravity = true;
        startButton.transform.DOMoveY(20, 5);
    }
    IEnumerator DeleteStartButton()
    {
        yield return new WaitForSeconds(5f);
        Destroy(startButton);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}