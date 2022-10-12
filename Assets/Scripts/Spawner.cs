using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Spawner : MonoBehaviour
{
    [SerializeField]
    private CubeController prefabObect;
    [SerializeField]
    private InputField inputTimerSpawn;
    [SerializeField]
    private InputField inputSpeedObject;
    [SerializeField]
    private InputField inputDistanceMove;
    private float timerSpawn = 0.5f;
    private float speedObject = 2.0f;
    private float distanceMove = 2.0f;
    [HideInInspector]
    public List<CubeController> cubeControllers;

    void Start()
    {
        inputTimerSpawn.onValueChanged.AddListener(SetTimerSpawn);
        inputSpeedObject.onValueChanged.AddListener(SetSpeedObject);
        inputDistanceMove.onValueChanged.AddListener(SetDistance);

        CreaterObjects();
        StartCoroutine(TimerSpawn());
    }

    private void CreaterObjects()
    {
        for (int i = 0; i < 10; i++)
        {
            CreateObject(false);
        }

    }

    private void CreateObject(bool isActive)
    {
        CubeController cubeController = Instantiate(prefabObect);
        cubeControllers.Add(cubeController);
        cubeController.SetInit(speedObject, distanceMove);
        cubeController.gameObject.SetActive(isActive);
    }

    public void SetTimerSpawn(string value)
    {
        if (float.TryParse(inputTimerSpawn.text, out float timerSpawn))
        {
            this.timerSpawn = timerSpawn;
        }
    }

    public void SetSpeedObject(string value)
    {
        if (float.TryParse(inputSpeedObject.text, out float speedObject))
        {
            this.speedObject = speedObject;
        }
    }

    public void SetDistance(string value)
    {
        if (float.TryParse(inputDistanceMove.text, out float distanceMove))
        {
            this.distanceMove = distanceMove;
        }
    }

    private IEnumerator TimerSpawn()
    {
        while (true)
        {
            bool isAdd = true;
            for (int i = 0; i < cubeControllers.Count; i++)
            {
                if (!cubeControllers[i].isActiveAndEnabled)
                {
                    cubeControllers[i].gameObject.SetActive(true);
                    cubeControllers[i].SetInit(speedObject, distanceMove);
                    isAdd = false;
                    break;
                }
            }

            if (isAdd) CreateObject(true);

            yield return new WaitForSeconds(timerSpawn);
        }
    }

}
