using UnityEngine;
using System.Collections;
using Mono.Data.Sqlite;

public class RecoedAction2 : MonoBehaviour {

    DbAccess recordTask;
    System.DateTime date;
    string[] tableInfo;
    string[] operationInfo;
    int actionCount = 0;
    CreatePlayer createPlayer;
    float startTime;

    int taskid_task;
    int taskid_op;
    int operationid;
    //int taskCount 
    
    // Use this for initialization
	void Start () {

        createPlayer = Camera.main.GetComponent<CreatePlayer>();

        string dbPath = Application.persistentDataPath + "/recordtask.db";
        //Debug.Log(dbPath);
        recordTask = new DbAccess("URI=file:" + dbPath);
        tableInfo = new string[] { "taskid", "userid", "time", "AttackResult", "reward1", "reward2", "reward3" };
        recordTask.CreateTable("task", tableInfo, new string[] { "INTEGER PRIMARY KEY", "text", "text", "BOOLEAN", "INTRGER", "INTRGER", "INTRGER" });
        date = System.DateTime.Now;
        //Debug.Log(date);
        recordTask.InsertInto("task", tableInfo, new ArrayList { "userid", date.ToString(), true, 10, 11, 12 },  1, 0);

        operationInfo = new string[] { "operationId", "taskid", "time", "locationx", "locationy", "locationz", "operationType", "operationObject", "FOREIGN KEY(taskid) REFERENCES " };
        recordTask.CreateTable("operation", operationInfo, new string[] { "INTEGER PRIMARY KEY", "INTRGER", "FLOAT", "FLOAT", "FLOAT", "FLOAT", "TEXT","TEXT", "task(taskid)" });
        using (SqliteDataReader sqReader = recordTask.ReadFullTable("task"))
        {

            while (sqReader.Read())
            {
                taskid_task = sqReader.GetInt32(sqReader.GetOrdinal("taskid"));
              //  Debug.Log(taskid_task);
            }
            sqReader.Close();
        }
    }

    // Update is called once per frame
    void FixedUpdate () {

       // string dbPath = Application.persistentDataPath + "/recordtask.db";
       // DbAccess recordTask1 = new DbAccess("URI=file:" + dbPath);

        if (actionCount == createPlayer.countplayer)
        {
            if (actionCount == 0)
            {
                startTime = Time.time;
            }

            ArrayList temp = new ArrayList();
            temp.Add(taskid_task);
            temp.Add(Time.time - startTime);
            temp.Add(createPlayer.generatePos.x);
            temp.Add(createPlayer.generatePos.y);
            temp.Add(createPlayer.generatePos.z);
            temp.Add("creat");
            temp.Add("player");

            
            recordTask.InsertInto("operation", operationInfo , temp, 1, 1);
            actionCount++;
        }
       // if()
    }

    float x;
   // float taskid_op;
    void OnGUI()
    {
       // string dbPath = Application.persistentDataPath + "/recordtask.db";

      //  DbAccess recordTask2 = new DbAccess("URI=file:" + dbPath);

        using (SqliteDataReader sqReader = recordTask.ReadFullTable("operation"))
        {
            while (sqReader.Read())
            {
                taskid_op = sqReader.GetInt32(sqReader.GetOrdinal("taskid"));
               // x = sqReader.GetFloat(sqReader.GetOrdinal("locationx"));
                operationid = sqReader.GetInt32(sqReader.GetOrdinal("operationId"));
            }
            sqReader.Close();
        }
        GUILayout.Box("taskid in task = " + taskid_task);
        GUILayout.Box("taskid in operation = " + taskid_op);
        GUILayout.Box("opid in operation = " + operationid);
        GUILayout.Box("x axis = " + x);
    }
}
