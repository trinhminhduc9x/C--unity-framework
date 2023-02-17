using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{

    public GameObject explosion;
    public GameObject playerExplosion;
    public int score;
    private GameController gameController;

    private void Start()
    {
        GameObject controller = GameObject.FindWithTag("GameController");

        if (controller != null)
        {
            gameController = controller.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("game loi");
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
            return;
        Instantiate(explosion,transform.position,transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        gameController.addScore(score);
        Destroy(other.gameObject);
        Destroy(gameObject);

    }
}
