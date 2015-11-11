using UnityEngine;
using System.Collections;
using Mono.Data.Sqlite;
using UnityEngine.UI;

public class ControlText : MonoBehaviour {

    DbAccess db;
    string path;
    public int taskid;
    // Use this for initialization
	void Start () {
        path = Application.persistentDataPath + "/recordtask.db";
        db = new DbAccess("URI=file:" + path);
        using (SqliteDataReader sqReader = db.ReadFullTable("task"))
        {
            while (sqReader.Read())
            {
                taskid = sqReader.GetInt32(sqReader.GetOrdinal("taskid"));
            }
            sqReader.Close();
        }
        //string 
        this.GetComponent<Text>().text = "number 1 - " + taskid.ToString();
        db.CloseSqlConnection();
    }
	
	// Update is called once per frame

}
