using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour{
    [Header("General")]
    [SerializeField] private Transform container;
    [SerializeField] private int repeatCount;
    [SerializeField] private int distanceBetweenFullLine;
    [SerializeField] private int distanceBetweenRandomLine;
    [Header("Block")]
    [SerializeField] private Block blockTemplate;
    [SerializeField] private int blockSpawnChance;
    private BlockSpawnPoint[] blockSpawnPoints;
    [Header("Wall")]
    [SerializeField] private Wall wallTemplate;
    [SerializeField] private int wallSpawnChance;
    private WallSpawnPoint[] wallSpawnPoints;

	private void Start(){
        blockSpawnPoints = GetComponentsInChildren<BlockSpawnPoint>();
        wallSpawnPoints = GetComponentsInChildren<WallSpawnPoint>();
        for (int i = 0; i < repeatCount; i++) {
            MoveSpawner(distanceBetweenFullLine);

            GenerateRandomElements(wallSpawnPoints, wallTemplate.gameObject, wallSpawnChance, distanceBetweenFullLine, distanceBetweenFullLine / 2.6f);

            GenerateFullLine(blockSpawnPoints, blockTemplate.gameObject);
            MoveSpawner(distanceBetweenRandomLine);

            GenerateRandomElements(wallSpawnPoints, wallTemplate.gameObject, wallSpawnChance, distanceBetweenRandomLine, distanceBetweenRandomLine / 2.6f);

            GenerateRandomElements(blockSpawnPoints, blockTemplate.gameObject, blockSpawnChance);
        }
    }
    private void GenerateFullLine(SpawnPoint[] spawnPoints, GameObject generateElement) {
        for (int i = 0; i < spawnPoints.Length; i++) {
            GenerateElement(spawnPoints[i].transform.position, generateElement);

        }
    }
    private void GenerateRandomElements(SpawnPoint[] spawnPoints, GameObject generalElement, int spawnChance, int ScaleY = 1, float offsetY = 0) {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (Random.Range(0, 100) < spawnChance) {
                GameObject element = GenerateElement(spawnPoints[i].transform.position, generalElement, offsetY);
                element.transform.localScale = new Vector3(element.transform.localScale.x, ScaleY, element.transform.localScale.z);
            }
        }
    }
    private GameObject GenerateElement(Vector3 spawnPoint, GameObject generateElement, float offsetY = 0) {
        //Для Спавна Сцен
        spawnPoint.y -= offsetY;
        return Instantiate(generateElement, spawnPoint, Quaternion.identity, container);
    }
    private void MoveSpawner(int distanceY) {
        transform.position = new Vector3(transform.position.x, transform.position.y + distanceY, transform.position.z);
    }
}
