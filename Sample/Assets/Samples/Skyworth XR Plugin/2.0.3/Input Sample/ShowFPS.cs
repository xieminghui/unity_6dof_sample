using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShowFPS : MonoBehaviour
{
    /// <summary>
    /// 每次刷新计算的时间      帧/秒
    /// </summary>
    public float updateInterval = 0.5f;
    /// <summary>
    /// 最后间隔结束时间
    /// </summary>
    private double lastInterval;
    private int frames = 0;
    private float currFPS;
    public static long m_time;

    private Text label;
    // Use this for initialization
    void Start()
    {

        label = GetComponent<Text>();
        if (label == null)
        {
            label = gameObject.AddComponent<Text>();
        }
        lastInterval = Time.realtimeSinceStartup;
        frames = 0;
    }

    // Update is called once per frame
    void Update()
    {

        ++frames;
        float timeNow = Time.realtimeSinceStartup;
        if (timeNow > lastInterval + updateInterval)
        {
            currFPS = (float)(frames / (timeNow - lastInterval));
            frames = 0;
            lastInterval = timeNow;
        }

        float max = Application.targetFrameRate / 2;
        if (currFPS >= max)
        {
            label.color = Color.green;
        }
        else if (currFPS < max && currFPS >= 5)
        {
            label.color = Color.yellow;
        }
        else
        {
            label.color = Color.red;
        }
        //        GUILayout.Label("FPS:" + currFPS.ToString("f2"));
        //		GUI.Label(new Rect(Screen.width/4,Screen.height/2-500,100,50),"FPS:" + currFPS.ToString("f2"));
        //		GUI.Label(new Rect(Screen.width-Screen.width/4,Screen.height/2-500,100,50),"FPS:" + currFPS.ToString("f2"));
        string fps = "FPS:" + currFPS.ToString("f2");
        label.text = fps;
    }


}