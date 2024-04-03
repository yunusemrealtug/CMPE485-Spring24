using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour
{
    public float trapOpenDuration = 3f; // Tuzağın açık kalma süresi
    public float trapClosedDuration = 2f; // Tuzağın kapalı kalma süresi

    bool isOpen = false; // Tuzağın şu an açık olup olmadığını kontrol etmek için bir flag

    public Material openMaterial; // Açık renk malzemesi
    public Material closedMaterial; // Kapalı renk malzemesi

    private Renderer trapRenderer;

    void Start()
    {
        trapRenderer = GetComponent<Renderer>();
        StartCoroutine(ToggleTrap());
    }

    IEnumerator ToggleTrap()
    {
        while (true)
        {
            if (!isOpen) // Tuzağın kapalı olduğunda
            {
                yield return new WaitForSeconds(trapClosedDuration);
                isOpen = true; // Tuzağı aç
                OpenTrap();
                yield return new WaitForSeconds(trapOpenDuration);
                isOpen = false; // Tuzağı kapat
                CloseTrap();
            }
            else // Tuzağın açık olduğunda
            {
                yield return new WaitForSeconds(trapOpenDuration);
                isOpen = false; // Tuzağı kapat
                CloseTrap();
                yield return new WaitForSeconds(trapClosedDuration);
                isOpen = true; // Tuzağı aç
                OpenTrap();
            }
        }
    }

    void OpenTrap()
    {
        Debug.Log("Trap is open!");
        trapRenderer.material = openMaterial;
        // Tuzağın açık olduğunda yapılacak işlemler buraya yazılabilir
    }

    void CloseTrap()
    {
        Debug.Log("Trap is closed!");
        trapRenderer.material = closedMaterial;
        // Tuzağın kapalı olduğunda yapılacak işlemler buraya yazılabilir
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && isOpen) // Çarpışan objenin etiketini kontrol ediyoruz
        {
            // Eğer çarpışan obje istediğiniz objeyse, oyunu bitirme işlemini gerçekleştirin
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Overasa!"); // Oyun bittiğinde yapılacak işlemler burada olmalı
        SceneManager.LoadScene(3);
        // Örneğin oyunu durdurabilirsiniz: Time.timeScale = 0;
        // veya oyunu yeniden başlatabilirsiniz: SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
