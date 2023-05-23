using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameTrigger : MonoBehaviour
{
    public GameObject ScreamerImage;

    public float ScreamerDuration = 3f;

    public int GameLoseChance = 50;

    public AudioSource ScreamerSound;

    private void Awake()
    {
        ScreamerImage.SetActive(false);
    }

    void OnTriggerEnter(Collider collider)
    {
        var randomResult = Random.Range(0, 101);

        if (GameLoseChance < randomResult)
        {
            ScreamerImage.SetActive(true);
            ScreamerSound.Play();

            StartCoroutine(nameof(WaitForChangeScene));
        }
    }

    IEnumerator WaitForChangeScene()
    {
        yield return new WaitForSeconds(ScreamerDuration);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}