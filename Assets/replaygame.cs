using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using UnityEngine.UI;

public class replaygame : MonoBehaviour {

    DbAccess db;
    string path;
    List<int> operationid;
    List<Vector3> position;
    List<float> time;
    GameObject[] players;
    int count = 0;
    float startTime;
    
    public GameObject inputfield;
    public GameObject player;
    // Use this for initialization
    void Start ()
    {
        startTime = Time.time;
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject a in players)
        {
            Destroy(a);
        }
        //Application.LoadLevel(Application.loadedLevel);
        path = Application.persistentDataPath + "/recordtask.db";
        db = new DbAccess("URI=file:" + path);
        int value = int.Parse(inputfield.GetComponent<Text>().text);
        //operationid = new List<int>();
        position = new List<Vector3>();
        time = new List<float>();
        using (SqliteDataReader sqReader = db.SelectWhere("operation", new string[] { "time","operationId", "locationx", "locationy", "locationz" },
            new string[] { "taskid" }, new string[] { "=" }, new int[] { value }))
        {

            while (sqReader.Read())
            {
                Vector3 pos = new Vector3(sqReader.GetFloat(sqReader.GetOrdinal("locationx")),
                    sqReader.GetFloat(sqReader.GetOrdinal("locationy")), sqReader.GetFloat(sqReader.GetOrdinal("locationz")));
                //operationid.Add(sqReader.GetInt32(sqReader.GetOrdinal("operationId")));
                float tmptim = sqReader.GetFloat(sqReader.GetOrdinal("time"));
                position.Add(pos);
                Debug.Log(position[count]);
                time.Add(tmptim);
                Debug.Log(time[count]);
                count++;
                // time1 = sqReader.GetFloat(sqReader.GetOrdinal("time"));
             
            }
            sqReader.Close();
        }
        Debug.Log(count);
        //generate();
    }

    int i = 0;

    void FixedUpdate() {
        //Debug.Log(Time.time);
        Debug.Log(startTime);
        if (Time.time - startTime - time[i] > -0.01f && Time.time - startTime-time[i] < 0.01f)
            {
                Instantiate(player, position[i], Quaternion.identity);
                i++;
            }
        if (i == count) enabled = false;
    }


}
