using UnityEngine;

[System.Serializable]
public class MarkerData
{
    //Replace these example variable with your objects variables
    //that you wish to save
    public int health;
    public string name;
    public string playerName;
    public float[] position;

    public MarkerData(LocationPrefab marker)
    {
        name = marker.name;
        playerName = GameManager.instance.currentPlayername;
        Vector3 MarkerPos = marker.transform.position;

        position = new float[]
        {
            MarkerPos.x, MarkerPos.y, MarkerPos.z
        };
    }
}
