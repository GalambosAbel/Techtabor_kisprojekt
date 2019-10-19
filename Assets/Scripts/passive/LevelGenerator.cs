using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
	public NodeGrid nodeGrid;
	public int checkPointHeight = 2;
	public float sectionHeight;
	public GameObject[] sections = new GameObject[3];
	public GameObject background;
	public GameObject checkpoint;
	float highestSectionY;

	void Awake()
	{
		highestSectionY = sectionHeight / 2;
		nodeGrid.gridWorldSize.y = sectionHeight * (checkPointHeight + 1);
		background.transform.localScale = new Vector3(background.transform.localScale.x, sectionHeight * (checkPointHeight + 1) * 100, 1);
	}

	void Start()
	{
		OnCheckpointEnter();
	}

	void Update()
	{
		if (Camera.main.transform.position.y >= highestSectionY - 20) OnCheckpointEnter();
	}

	void OnCheckpointLoaded ()
	{
		nodeGrid.CreateGrid();
	}

	void OnCheckpointEnter ()
	{
		GetComponent<EnemySpawner>().StopSpawn();
		GetComponent<CameraMovment>().Stop();
		float y = transform.position.y - Camera.main.orthographicSize + background.transform.localScale.y / 200;
		background.transform.position = new Vector3(transform.position.x, y, transform.position.z);
		for (int i = 0; i < checkPointHeight - 1; i++)
		{
			SpawnSection();
		}
		SpawnCheckpoint();
		OnCheckpointLoaded();
	}

	void SpawnSection ()
	{
		if (sections.Length == 0) return;
		int sectionNumber = Random.Range(0, sections.Length);
		Instantiate(sections[sectionNumber], new Vector3(0, highestSectionY + sectionHeight, 0), Quaternion.identity);
		highestSectionY += sectionHeight;
	}

	void SpawnCheckpoint()
	{
		Instantiate(checkpoint, new Vector3(0, highestSectionY + sectionHeight, 0), Quaternion.identity);
		highestSectionY += sectionHeight;
	}
}
