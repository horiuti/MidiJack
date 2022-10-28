using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;
using System.IO;
using System.Text;
using UnityEngine.UI;

public class Do : MonoBehaviour
{
   // Start is called before the first frame update
   public AudioSource audioSource_onkai;
//    public AudioSource audioSource_re;
//    public AudioSource audioSource_mi;
//    public AudioSource audioSource_fa;
//    public AudioSource audioSource_so;

   public AudioClip do;
   public AudioClip re;
   public AudioClip mi;
   public AudioClip fa;
   public AudioClip so;


   void Start()
   {
        Debug.Log("start");
        audioSource_onkai=GetComponent<AudioSource>();
        // audioSource_re=GetComponent<AudioSource>();
        // audioSource_mi=GetComponent<AudioSource>();
        // audioSource_fa=GetComponent<AudioSource>();
        // audioSource_so=GetComponent<AudioSource>();
   }

   // Update is called once per frame
   void Update()
   {
        
   }
    
   void OnEnable()
   {
       MidiMaster.noteOnDelegate += NoteOn;
       MidiMaster.noteOffDelegate += NoteOff;
       //Debug.Log("OnEnable");

   }

   void OnDisable()
   {
       MidiMaster.noteOnDelegate -= NoteOn;
       MidiMaster.noteOffDelegate -= NoteOff;
       //Debug.Log("OnDisable");

   }

   void NoteOn(MidiChannel channel, int note, float velocity)
   {
       Debug.Log("NoteOn: " + channel + "," + note + "," + velocity+",");
       if(note==52){
        audioSource_onkai.PlayOneShot(do);  
       }
   }


   void NoteOff(MidiChannel channel, int note)
   {
       Debug.Log("NoteOff: " + note+",");
   }



    // void SaveDataOff(float elapsedTime)
    // {
    //     string[] s1={elapsedTime.ToString()};
    //     string s2=string.Join(",",s1);
    //     sw.WriteLine(s2);
    // }

}