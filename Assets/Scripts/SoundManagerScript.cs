﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
	public static AudioClip correctCharSound, incorrectCharSound, sendTextSound, receiveTextSound;
	static AudioSource audioSrc;

	void Start()
	{
		correctCharSound = Resources.Load<AudioClip>("typewriter");
		incorrectCharSound = Resources.Load<AudioClip>("buzz");
		sendTextSound = Resources.Load<AudioClip>("bubble-pop-high");
		receiveTextSound = Resources.Load<AudioClip>("bubble-pop-low");

		audioSrc = GetComponent<AudioSource>();
	}

	public static void PlaySound(string sound) 
	{
		switch (sound) {
		case "correctChar":
			audioSrc.PlayOneShot(correctCharSound);
			break;
		case "incorrectChar":
			audioSrc.PlayOneShot(incorrectCharSound);
			break;
		case "sendText":
			audioSrc.PlayOneShot(sendTextSound);
			break;
		case "receiveText":
			audioSrc.PlayOneShot(receiveTextSound);
			break;
		}
	}

}