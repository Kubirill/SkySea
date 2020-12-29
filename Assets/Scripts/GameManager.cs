using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class GameManager : MonoBehaviour
{

    [SerializeField] DragonMove DragonMove;
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject dragonButton;

    [SerializeField] SpriteRenderer logo;
    public void PressStart()
    {
        DragonMove.enabled = true;
        // disable kinematic
        // DragonMove.gameObject.GetComponent<Rigidbody>().useGravity = true;
        if (startButton == null)
        {
            startButton = GameObject.Find("Menu/StartButton");
        }
        startButton.transform.DOScale(new Vector3(0.001f, 0.001f, 0.001f), 1f);
        dragonButton.transform.DOScale(new Vector3(0.001f, 0.001f, 0.001f), 1f);
        StartCoroutine(ChangeColorOfLogo());
    }
    IEnumerator ChangeColorOfLogo()
    {
        yield return new WaitForSeconds(1f);
        logo.DOColor(new Color(logo.color.r, logo.color.g, logo.color.g, 0), 20);
    }
    IEnumerator DeleteStartButton()
    {
        yield return new WaitForSeconds(20f);
        // destroy our objects
        Destroy(startButton);
        Destroy(logo.gameObject);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}