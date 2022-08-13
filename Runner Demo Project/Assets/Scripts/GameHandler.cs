using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ai1;
    [SerializeField] private GameObject ai2;
    [SerializeField] private GameObject ai3;
    [SerializeField] private GameObject ai4;
    [SerializeField] private GameObject ai5;
    [SerializeField] private GameObject ai6;
    [SerializeField] private GameObject ai7;
    [SerializeField] private GameObject ai8;
    [SerializeField] private GameObject ai9;
    [SerializeField] private GameObject ai10;

    [SerializeField] GameObject brush;

    [SerializeField] private TextMeshProUGUI placementText;
    [SerializeField] private TextMeshProUGUI timeText;

    GameObject[] _objects = new GameObject[11];
    public GameData data;
    bool setOnce=false;

    float time=0;
    // Start is called before the first frame update
    void Start()
    {
        data.gameStarted = false;
        _objects[0] = player;
        _objects[1] = ai1;
        _objects[2] = ai2;
        _objects[3] = ai3;
        _objects[4] = ai4;
        _objects[5] = ai5;
        _objects[6] = ai6;
        _objects[7] = ai7;
        _objects[8] = ai8;
        _objects[9] = ai9;
        _objects[10] = ai10;
    }

    void StartGame()
    {
        //Countdown
        time = Time.timeSinceLevelLoad;
        if(time >= 1)
        {
            timeText.text = "2";
            if (time >= 2)
            {
                timeText.text = "1";
                if (time >= 3)
                {
                    timeText.text = "GO!";
                }
                if (time >= 4)
                {
                    timeText.text="";
                    data.gameStarted = true;
                }
            }
        }
    }
    
    void LateUpdate()
    {
        StartGame();
        if (data.paintPhase == false)
        {
            //Ordering of array
            _objects = _objects.OrderByDescending(go => go.transform.position.z).ToArray();
            //Find which index player is
            placementText.text = ("#" + (System.Array.IndexOf(_objects, player) + 1));
            Debug.Log(System.Array.IndexOf(_objects, player));
        }
        
        if (data.paintPhase == true && setOnce == false)
        {
            if(System.Array.IndexOf(_objects, player) == 0)
            {
                placementText.text = ("3X Brush Size");
                brush.transform.localScale = brush.transform.localScale * 6;
                setOnce = true;
            }
            else if(System.Array.IndexOf(_objects, player) == 1)
            {
                placementText.text = ("2X Brush Size");
                brush.transform.localScale = brush.transform.localScale * 4;
                setOnce = true;
            }
            else if (System.Array.IndexOf(_objects, player) == 2)
            {
                placementText.text = ("1.5X Brush Size");
                brush.transform.localScale = brush.transform.localScale * 3f;
                setOnce = true;
            }
            else
            {
                placementText.text = ("Not In First 3 Normal Sized Brush");
                setOnce = true;
            }
        }
    }
    private void Update()
    {
        //restart scene
        if (Input.GetKeyDown(KeyCode.Return))
        {
            data.gameStarted = false;
            data.paintPhase = false;
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
