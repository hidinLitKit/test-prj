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

    [SerializeField] private List<WordCollection> _objects = new List<WordCollection>();
    [SerializeField] private GameObject _objPrefab;
    [SerializeField] private float _moveSpeed;
    private bool _canMove = true;

    private void OnEnable()
    {
        GameEvents.onCheckPoint += AddObject;
        GameEvents.onDeath += () => SetMove(false);
    }
    private void Update()
    {
        MoveWorld();
    }
    private void OnDisable()
    {
        GameEvents.onCheckPoint -= AddObject;
        GameEvents.onDeath -= () => SetMove(false);
    }

    public void AddObject()
    {
        WordCollection _spawnObj = SpawnObject().GetComponent<WordCollection>();
        _objects.Add(_spawnObj);
        if (_objects.Count > 3) DeleteObject();
    }
    public void DeleteObject()
    {
        GameObject obj = _objects[0].gameObject;
        _objects.RemoveAt(0);
        Destroy(obj);
    }
    public void SetMove(bool val)
    {
        _canMove = val;
    }
    
    private GameObject SpawnObject()
    {
        GameObject obj = Instantiate(_objPrefab);

        obj.transform.parent = this.gameObject.transform;
        obj.transform.localPosition = _objects[_objects.Count - 1].transform.localPosition + new Vector3(36.21907f, 0f, 0f);

        return obj;

    }
    private void MoveWorld()
    {
        if (!_canMove) return;
        transform.position += new Vector3(-_moveSpeed * 1f*Time.deltaTime, 0f, 0f);
    }
    

}
