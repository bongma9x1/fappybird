using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPipe : MonoBehaviour {
    [SerializeField]
    private GameObject pipeHoler;
	// Use this for initialization
	void Start () {
        StartCoroutine(Spawner());
	}
    void Update()
    {
        if (BirdController.instance != null)
        {
            if (BirdController.instance.flag == 1)
            {
                Destroy(GetComponent<SpawnerPipe>());
            }
        }
    }
	// Update is called once per frame
    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(1);
        Vector3 temp = pipeHoler.transform.position;
        temp.y = Random.Range(-2.5f, 2.5f);
        Instantiate(pipeHoler, temp, Quaternion.identity);
        StartCoroutine(Spawner());
    }
}
