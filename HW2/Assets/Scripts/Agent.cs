using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Agent : MonoBehaviour
{
    public float speed = 5f; // Hızı ayarlamak için değişken
    public float rotationSpeed = 100f; // Dönme hızı

    private Rigidbody rb;
    private Camera mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //mainCamera = Camera.main; // Sahne içerisindeki ana kamerayı alır
        mainCamera = GameObject.Find("trial").GetComponent<Camera>();
        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }

    void Update()
    {
        // Yön tuşlarının girişini al
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Kameranın yatay yönünü al
        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;

        // Yatay yön vektörlerini yatay düzleme sıfırla
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Hareket vektörünü oluştur
        Vector3 moveDirection = cameraForward * verticalInput + cameraRight * horizontalInput;
        moveDirection.Normalize();

        // Hareketi uygula
        rb.velocity = moveDirection * speed;

        // Hedef dönme açısını hesapla
        if (moveDirection != Vector3.zero)
        {
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, 0.1f);

            // Dönme işlemini uygula
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
        
        if (transform.position.y > 2f)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.y = 2f;
            transform.position = currentPosition;
        }
            
    }
}
