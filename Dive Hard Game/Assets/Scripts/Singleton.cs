using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UberAudio;

public class Singleton : MonoBehaviour
{
    public static Singleton _instance;
    public static int blood = 0;
    public static int[] storeLevels = new int[11]; //se puede cambiar
    public static Vector3 localHighScores = Vector3.zero;
    public static bool subiendo = true;
    public static int tutorial=0;

    public static int slide;


    int highScoreUp, highScoreBlood;

    // Use this for initialization
    void Awake()
    {
        //serna help me here pls
        //path = Path.Combine(Application.persistentDataPath, "SaveStats.txt"); 

        if (_instance == null)
        {    
            Screen.orientation = ScreenOrientation.Portrait;
            Screen.SetResolution(720, 1280, true);

            _instance = this;
            DontDestroyOnLoad(transform.gameObject);

            SaveProtocole(TypeOfTranfer.Read);

            //AudioManager.Instance.Play("BGMusic");

        }
        else
        {
            subiendo = true;
            SaveProtocole(TypeOfTranfer.Update);
            Destroy(transform.gameObject);
        }
    }
    private void SaveProtocole(TypeOfTranfer _type)
    {
        switch (_type)
        {
            case TypeOfTranfer.Update:

                #region Update

                PlayerPrefs.SetInt("Blood", blood);

                PlayerPrefs.SetInt("Control",slide);

                PlayerPrefs.SetInt("Tuto", tutorial);


                string upd_StoreLevels = "";
                for (int i = 0; i < storeLevels.Length; i++)
                {
                    if (i != storeLevels.Length - 1)
                        upd_StoreLevels += (storeLevels[i].ToString() + ",");
                    else
                        upd_StoreLevels += storeLevels[i].ToString();
                }

                PlayerPrefs.SetString("Levels", upd_StoreLevels);


                PlayerPrefs.SetInt("ScoreBlood", (int)localHighScores.x);
                PlayerPrefs.SetInt("ScoreUp",(int)localHighScores.y);

                PlayerPrefs.Save();

                #endregion
                break;
            case TypeOfTranfer.Read:
                #region Read

                blood = PlayerPrefs.GetInt("Blood");
                slide = PlayerPrefs.GetInt("Slide");
                tutorial = PlayerPrefs.GetInt("Tuto");

                string[] txt_StoreLevels;
                

                txt_StoreLevels = PlayerPrefs.GetString("Levels").Split(',');
                for (int i = 0; i < storeLevels.Length; i++)
                {
                    storeLevels[i] = int.Parse(txt_StoreLevels[i]);
                }

                localHighScores.x = PlayerPrefs.GetInt("ScoreBlood");
                localHighScores.y = PlayerPrefs.GetInt("ScoreUp");



                #endregion
                break;
        }
    }

 
    enum TypeOfTranfer
    {
        Update,
        Read
    }
}
