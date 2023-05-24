using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameTrigger : MonoBehaviour
{
    public GameObject ScreamerObject;

    public float ScreamerDuration = 5f;

    public int GameLoseChance = 50;

    public AudioSource ScreamerSound;

    private void Awake()
    {
        ScreamerObject.SetActive(false);
    }

    void OnTriggerEnter(Collider collider)
    {
        var videoPlayer = ScreamerObject.AddComponent<UnityEngine.Video.VideoPlayer>();

        var randomResult = Random.Range(0, 101);

        if (GameLoseChance < randomResult)
        {
            ScreamerObject.SetActive(true);
            videoPlayer.Play();
            ScreamerSound.Play();

            StartCoroutine(nameof(WaitForChangeScene));
        }
    }

    IEnumerator WaitForChangeScene()
    {
        yield return new WaitForSeconds(ScreamerDuration + 2);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}