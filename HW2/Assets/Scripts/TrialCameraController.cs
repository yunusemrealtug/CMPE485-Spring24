using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrialCameraController : MonoBehaviour
{
    public Transform target; // Takip edilecek hedef (genellikle oyuncu)
    public float rotationSpeed = 5.0f; // Fareyle kameranın dönme hızı
    public Vector3 offset; // Kameranın hedefe olan konumunu ayarlamak için kullanılacak ofset değeri

    private float yaw = 180.0f;
    private float pitch = 0.0f;

    void LateUpdate()
    {
        if (target != null)
        {
            // Fare girişini al
            yaw += rotationSpeed * Input.GetAxis("Mouse X");
            pitch -= rotationSpeed * Input.GetAxis("Mouse Y");

            // Pitch sınırlarını belirle
            pitch = Mathf.Clamp(pitch, -90f, 90f);

            // Kameranın rotasyonunu güncelle
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

            // Hedefin pozisyonuna ofset ekleyerek arka pozisyonu al
            Vector3 desiredPosition = target.position + offset;
            transform.position = desiredPosition;
        }
    }
}
