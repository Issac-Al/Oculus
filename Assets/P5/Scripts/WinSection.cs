using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSection : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            panel.SetActive(true);
            other.gameObject.GetComponent<Player_Movement>().enabled = false;
        }
    }

    public void Replay()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
