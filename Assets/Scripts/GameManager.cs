using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class GameManager : MonoBehaviour
{

    [SerializeField] DragonMove DragonMove;
    [SerializeField] GameObject startButton;

    public void PressStart()
    {
        DragonMove.enabled = true;
        // disable kinematic
        DragonMove.gameObject.GetComponent<Rigidbody>().useGravity = true;
        if (startButton == null)
        {
            startButton = GameObject.Find("Menu/StartButton");
        }
        startButton.transform.DOMoveY(20, 5);
    }
    IEnumerator DeleteStartButton()
    {
        yield return new WaitForSeconds(5f);
        startButton.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}