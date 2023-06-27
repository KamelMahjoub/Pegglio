using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
   public static DataManager Instance;

   public string userName;
   public int highScore;
   public string highScorePlayer ;

   private void Awake()
   {
      if (Instance != null)
      {
         Destroy(gameObject);
         return;
      }
      Instance = this;
      DontDestroyOnLoad(gameObject);
      LoadData();
   }

   public void SetUserName(string name)
   {
      userName = name;
   }
   
   public void SetHighScorePlayer(string name)
   {
      highScorePlayer = name;
   }
   
   
   

   public void UpdateHighScore(int score)
   {
      highScore = score;
   }

   public int GetHighscore()
   {
      return highScore;
   }

   [Serializable]
   public class SaveData
   {
      public string playerName;
      public int highScore;
      public String highScorePlayer;
   }

   public void SavePlayerData()
   {
      SaveData data = new SaveData();

      data.playerName = userName;
      data.highScore = highScore;
      data.highScorePlayer = highScorePlayer;

      string json = JsonUtility.ToJson(data);
      
      File.WriteAllText(Application.persistentDataPath+"/savefile.json",json);
   }

   public void LoadData()
   {
      string path = Application.persistentDataPath+"/savefile.json";

      if (File.Exists(path))
      {
         string json = File.ReadAllText(path);
         SaveData data = JsonUtility.FromJson<SaveData>(json);
         userName = data.playerName;
         highScore = data.highScore;
         highScorePlayer = data.highScorePlayer;
         Debug.Log("vv : "+userName);
         Debug.Log("vv : "+highScorePlayer);
      }
   }



}
