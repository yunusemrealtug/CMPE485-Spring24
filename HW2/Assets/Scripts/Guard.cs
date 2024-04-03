using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Guard : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 2f;

    private bool gameOver = false;
    public GameObject otherAgent;

    private void Start()
    {
        otherAgent = GameObject.FindWithTag("Player"); // "OtherAgentTag" yerine diğer agentın tag'ını kullanın
        StartCoroutine(MoveObject());
    }

    IEnumerator MoveObject()
    {
        while (!gameOver)
        {
            float journeyLength = Vector3.Distance(startPoint.position, endPoint.position);
            float journeyTime = journeyLength / speed;
            float elapsedTime = 0f;

            while (elapsedTime < journeyTime && !gameOver)
            {
                transform.position = Vector3.Lerp(startPoint.position, endPoint.position, elapsedTime / journeyTime);
                elapsedTime += Time.deltaTime;

                Vector3 horizontalDirection = endPoint.position - startPoint.position;
                horizontalDirection.y = 0f;

                Quaternion targetRotation = Quaternion.LookRotation(horizontalDirection);
                targetRotation.x = 0f;
                targetRotation.z = 0f;

                transform.rotation = targetRotation;

                if (transform.rotation.y == 0f &&
                otherAgent.transform.position.z >= transform.position.z &&
                otherAgent.transform.position.x >= 10f &&
                otherAgent.transform.position.x <= 20f &&
                otherAgent.transform.position.z < 40f
                ) {
                    Debug.Log("Game Overas1!");
                    GameOver();
                } 
            else if (transform.rotation.y != 0f &&
                otherAgent.transform.position.z <= transform.position.z &&
                otherAgent.transform.position.x >= 10f &&
                otherAgent.transform.position.x <= 20f &&
                otherAgent.transform.position.z > 10f
                ) {
                    Debug.Log("Game Overas2!");
                    GameOver();
                }

                yield return null;
            }

            yield return new WaitForSeconds(0.1f); // Optional: Wait for 0.1 second at the destination point
            Transform temp = startPoint;
            startPoint = endPoint;
            endPoint = temp;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Eğer çarpışan obje "Player" ise, game over olacak şekilde ayarlayın
        if (collision.gameObject.tag == "Player")
        {
            GameOver();
            // Burada başka bir şeyler yapabilirsiniz, örneğin oyunu durdurabilirsiniz.
        }
    }

    void GameOver()
    {
        gameOver = true;
        Debug.Log("Game Overas!"); // Oyun bittiğinde yapılacak işlemler burada olmalı
        SceneManager.LoadScene(3);
        // Örneğin oyunu durdurabilirsiniz: Time.timeScale = 0;
        // veya oyunu yeniden başlatabilirsiniz: SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
