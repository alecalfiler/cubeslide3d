using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    private Vector3 playerStartPoint;
    public Rigidbody player;
    public float restartDelay = 2f;

    public void RestartGame()
    {

        StartCoroutine("RespawnPlayer");
    }

    //respawn
    IEnumerator RespawnPlayer()
    {
        Destroy(this.gameObject);
        yield return new WaitForSeconds(restartDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
