using UnityEngine;
using Mono.Data.Sqlite;
using System.IO;

public class ShowDatabase : MonoBehaviour {

	private SqliteConnection mSqliteConnection;  
    private SqliteCommand mSqliteCommand;  
    private SqliteDataReader mSqliteDataReader;
    public GameObject showText;
    float nexttime;

    string position = "null";
    string time = "null";
    string taskId;
    //DbAccess db;
    // Use this for initialization
	void Start () {
        loadSQL();
    }

    void loadSQL()
    {
		string appDBPath = Application.persistentDataPath + "/test1.db";

		if(!File.Exists(appDBPath))
 
 		{
            position = "no file";
            Debug.Log("null");
        }
 
		//在这里重新得到db对象。
		DbAccess db = new DbAccess("URI=file:" + appDBPath);

            using (SqliteDataReader sqReader = db.ReadFullTable("test2"))
            {

                if (sqReader == null) time = "no res";
                while (sqReader.Read())
                {
                    taskId = sqReader.GetString(sqReader.GetOrdinal("taskid"));
                    position = sqReader.GetString(sqReader.GetOrdinal("position"));
                    time = sqReader.GetString(sqReader.GetOrdinal("time"));
                }
              //  sqReader.Close();
            }

       // db.CloseSqlConnection();
    }

    void OnGUI()
    {
        GUILayout.Box("task id = " + taskId);
        GUILayout.Box("position =" + position);
        GUILayout.Box("time =" + time);
    } 
	
}
