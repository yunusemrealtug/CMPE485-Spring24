using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Voice : MonoBehaviour
{
    // Ses nesnesine erişmek için bir referans oluşturun
    public AudioSource voiceObject;
    public static Voice instance;

    void Start()
    {
        // Başlangıçta sesi kapatın
        voiceObject.mute = false;
        voiceObject.loop = true;
    }

    void Awake()
    {
        if (instance == null)
        {
            // Eğer başka bir MusicManager yoksa, bu nesneyi koru.
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Eğer bu nesne zaten varsa, bu nesneyi yok et.
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Örneğin, klavye girişine göre sesi açıp kapatabilirsiniz
        if (Input.GetKeyDown(KeyCode.M))
        {
            voiceObject.mute = !voiceObject.mute; // Sesi aç veya kapat
        }
    }
}
