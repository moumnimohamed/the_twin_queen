﻿using UnityEngine.Audio;
using UnityEngine;
[System.Serializable]
public class sound  {


public string name;
  public AudioClip clip ;

[Range(0,1f)]
  public float volume;
  public bool loop;

[HideInInspector]
  public AudioSource source;
  

    
	
}
