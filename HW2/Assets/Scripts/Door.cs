using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish")) // Çarpışan objenin etiketini kontrol ediyoruz
        {
            // Eğer çarpışan obje istediğiniz objeyse, oyunu bitirme işlemini gerçekleştirin
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Overha!"); // Oyun bittiğinde yapılacak işlemler burada olmalı
        SceneManager.LoadScene(2);
        // Örneğin oyunu durdurabilirsiniz: Time.timeScale = 0;
        // veya oyunu yeniden başlatabilirsiniz: SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
