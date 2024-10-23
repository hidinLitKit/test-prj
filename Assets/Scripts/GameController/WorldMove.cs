using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMove : MonoBehaviour
{
    #region Singleton
    public static WorldMove instance => _instance;
    private static WorldMove _instance;
    private void Awake()
    {
        if (instance == null) _instance = this;
        else Destroy(this.gameObject);
    }
    #endregion

    public bool CanMove => _canMove;

    [SerializeField] private List<GameObject> _objects = new List<GameObject>();
    [SerializeField] private GameObject _objPrefab;
    [SerializeField] private float _moveSpeed;
    private bool _canMove = true;

    private void OnEnable()
    {
        GameEvents.onCheckPoint += AddObject;
    }
    private void Update()
    {
        MoveWorld();
    }
    private void OnDisable()
    {
        GameEvents.onCheckPoint -= AddObject;
    }

    public void AddObject()
    {
        _objects.Add(SpawnObject());
    }
    public void DeleteObject()
    {
        _objects.RemoveAt(0);
    }
    public void SetMove(bool val)
    {
        _canMove = val;
    }

    
    
    private GameObject SpawnObject()
    {
        return Instantiate(_objPrefab, 
            _objects[-1].transform.position + new Vector3(1920f, 0f, 0f),
            _objPrefab.transform.rotation);
    }
    private void MoveWorld()
    {
        transform.position += new Vector3(_moveSpeed * 1f, 0f, 0f);
    }
    

}
