using UnityEngine;
using System.Collections;

sealed class Spawn : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private Timer _timer;
    public float _speedCube  {get;set;}
    public float _distance {get;set;}
    public float _startTimeBtwSpawns {get;set;}
    private float _timeBtwSpawn;

    void Start()
    {
        _timeBtwSpawn = _startTimeBtwSpawns;
    }
    private void Update()
    {
        
        if(_timer._isStart == true)
        {
            StartCreatCube();
        }
        
    }
    private void StartCreatCube()
    {
        if(_timeBtwSpawn <= 0)
        {
            CreateCube();
            _timeBtwSpawn = _startTimeBtwSpawns;
        } else 
        {
            _timeBtwSpawn -= Time.deltaTime;
        }
    }

    public void CreateCube()
    {
        Cube cube = Instantiate(_cube,gameObject.transform.position,Quaternion.identity);
        Vector3 endPosition = new Vector3(transform.position.x - _distance,transform.position.y + 1,transform.position.z);
        cube.Initialize(_speedCube,endPosition);
    }



    
}
