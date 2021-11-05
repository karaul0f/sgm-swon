using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource m_audioData;
    // Start is called before the first frame update
    void Start()
    {
        m_audioData = GetComponent<AudioSource>();
        m_audioData.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
