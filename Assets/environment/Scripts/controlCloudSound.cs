using System.Collections;
using DG.Tweening;
using UnityEngine;
public class controlCloudSound : MonoBehaviour
{

    [SerializeField] GameObject cloud;
    [SerializeField] GameObject lighting;
    AudioSource _audioSource;
    private void Start() => _audioSource = cloud.GetComponent<AudioSource>();
    private void OnTriggerEnter()
    {
        _audioSource.Play();
        lighting.SetActive(true);
        StartCoroutine(TestCoroutine());
    }
    IEnumerator TestCoroutine()
    {
        yield return new WaitForSeconds(5f);
        lighting.SetActive(false);
    }
}