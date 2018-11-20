using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    [SerializeField]
    int waitForSeconds = 4;
    // Use this for initialization
    void Start() {
        StartCoroutine(LoadNextLevel());
    }

    private IEnumerator LoadNextLevel() {
        yield return new WaitForSeconds(waitForSeconds);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
