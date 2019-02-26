using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {

    public static AudioClip PlayerJumpSound, PlayerFireSound, PlayerHurtSound, GameOverSound;
    public static AudioSource audioSrc; 

	// Use this for initialization
	void Start () {
        PlayerJumpSound = Resources.Load<AudioClip>("PlayerJump");
        PlayerFireSound = Resources.Load<AudioClip>("PlayerFire");
        PlayerHurtSound = Resources.Load<AudioClip>("PlayerHit");
        GameOverSound = Resources.Load<AudioClip>("GameOver");

        audioSrc = GetComponent<AudioSource>(); 
	}
	
	// Update is called once per frame
	void Update () {

       
    }
    public static void PlaySound(string clip)
    {

        switch (clip) {
            case "PlayerJump": audioSrc.PlayOneShot(PlayerJumpSound);
                break;
            case "PlayerFire":
                audioSrc.PlayOneShot(PlayerFireSound);
                break;
            case "PlayerHit":
                audioSrc.PlayOneShot(PlayerHurtSound);
                break;
            case "GameOver":
                audioSrc.PlayOneShot(GameOverSound);
                break;
        }
         
    }
}

