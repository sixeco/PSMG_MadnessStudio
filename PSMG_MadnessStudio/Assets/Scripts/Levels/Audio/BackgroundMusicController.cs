using UnityEngine;
using System.Collections;

public class BackgroundMusicController : MonoBehaviour {

    public AudioClip[] BGMusicClips;
    public AudioSource MusicSource;

    void Start()
    {
        int randomIndex = Random.Range(0, BGMusicClips.Length);
        MusicSource.GetComponent<AudioSource>().clip = BGMusicClips[randomIndex];
        MusicSource.Play();
    }

    void Update()
    {
        if (!MusicSource.isPlaying)
        {
            int randomIndex = Random.Range(0, BGMusicClips.Length);
            MusicSource.GetComponent<AudioSource>().clip = BGMusicClips[randomIndex];
            MusicSource.Play();
        }
    }
}
