using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class GameObjectPool : MonoBehaviour
{
    public static GameObjectPool instance;
    public int PoolSize = 20;

    [SerializeField] private GameObject Eye;
    [SerializeField] private GameObject Goblin;
    [SerializeField] private GameObject Mushroom;
    [SerializeField] private GameObject Skeleton;
    [SerializeField] private GameObject Coin;
    private List<GameObject> EnemyList = new List<GameObject>();
    private Queue<GameObject> EyePool = new Queue<GameObject>();
    private Queue<GameObject> GoblinPool = new Queue<GameObject>();
    private Queue<GameObject> MushroomPool = new Queue<GameObject>();
    private Queue<GameObject> SkeletonPool = new Queue<GameObject>();

    private Queue<GameObject> CoinPool;
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateEnemyPool(EyePool, Eye);
        CreateEnemyPool(GoblinPool, Goblin);
        CreateEnemyPool(MushroomPool, Mushroom);
        CreateEnemyPool(SkeletonPool, Skeleton);
        EnemyList.Add(Eye);
        EnemyList.Add(Goblin);
        EnemyList.Add(Mushroom);
        EnemyList.Add(Skeleton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateEnemyPool(Queue<GameObject> pool, GameObject enemy)
    {
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject Obj = Instantiate(enemy, gameObject.transform.position, Quaternion.identity, transform);
            Obj.SetActive(false);
            pool.Enqueue(Obj);
        }
    }

    public GameObject GetGameObject(Queue<GameObject> pool, GameObject enemy)
    {
        if (pool.Count <= 0)
        {
            CreateEnemyPool(pool, enemy);
        }
        GameObject EnemyObject = pool.Dequeue();
        EnemyObject.SetActive(true);
        EnemyObject.transform.parent = null;
        return EnemyObject;
    }

    public void ReturnToPool(Queue<GameObject> pool, GameObject enemy)
    {
        enemy.SetActive(false);
        enemy.transform.parent = transform;
        enemy.transform.localPosition = Vector3.zero;
        pool.Enqueue(enemy);
    }
    
    public Queue<GameObject> GetNeedPool(GameObject enemy)
    {
        switch (enemy.name)
        {
            case "Eyes(Clone)":
                return EyePool;
            case "Eyes":
                return EyePool;
            case "Goblin(Clone)":
                return GoblinPool;
            case "Goblin":
                return GoblinPool;
            case "Mushroom(Clone)":
                return MushroomPool;
            case "Mushroom":
                return MushroomPool;
            case "Skeleton(Clone)":
                return SkeletonPool;
            case "Skeleton":
                return SkeletonPool;
            case "Coin":
                return CoinPool;
            case "Coin(Clone)":
                return CoinPool;
            default:
                Debug.Log("未找到对象池");
                return null;
        }
    }
}
