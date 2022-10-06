using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;
using System.IO;
using System.Text;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    private StreamWriter sw;
   // Start is called before the first frame update
   private Text timerText;
   private float elapsedTimeOn;    //時間経過を格納する変数
   private float elapsedTimeOff;

   void Start()
   {
        sw=new StreamWriter("Assets/sample.csv",true,Encoding.GetEncoding("UTF-8"));
   }

   // Update is called once per frame
   void Update()
   {
        
   }
    
    void OnApplicationQuit(){
        sw.Close();
    }

   void OnEnable()
   {
       MidiMaster.noteOnDelegate += NoteOn;
       MidiMaster.noteOffDelegate += NoteOff;
   }

   void OnDisable()
   {
       MidiMaster.noteOnDelegate -= NoteOn;
       MidiMaster.noteOffDelegate -= NoteOff;
   }

   void NoteOn(MidiChannel channel, int note, float velocity)
   {
       elapsedTimeOn=Time.time;   //経過時間を格納
       Debug.Log("NoteOn: " + channel + "," + note + "," + velocity+","+elapsedTimeOn);
       SaveDataOn(note,velocity,elapsedTimeOn);         
    }

    void SaveDataOn(int note, float velocity,float elapsedTimeOn)
    {
        string[] s1={note.ToString(), velocity.ToString(),elapsedTimeOn.ToString()};
        string s2=string.Join(",",s1);
        sw.WriteLine(s2);
    }

   void NoteOff(MidiChannel channel, int note)
   {
       elapsedTimeOff=Time.time;
       Debug.Log("NoteOff: " + note+","+elapsedTimeOff);
       SaveDataOff(note,elapsedTimeOff);         
   }

    void SaveDataOff(int note, float elapsedTimeOff)
    {
        string[] s1={note.ToString(), elapsedTimeOff.ToString()};
        string s2=string.Join(",",s1);
        sw.WriteLine(s2);
    }


    // void SaveDataOff(float elapsedTime)
    // {
    //     string[] s1={elapsedTime.ToString()};
    //     string s2=string.Join(",",s1);
    //     sw.WriteLine(s2);
    // }

}