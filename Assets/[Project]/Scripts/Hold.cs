using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hold : MonoBehaviour
{
    [SerializeField] private Transform _door1, _door2;
    private Vector3 _door1Position, _door2Position;
    private GameObject[] _crates;
    void Start(){
        _door1Position = _door1.localPosition;
        _door2Position = _door2.localPosition;

        _crates = GameObject.FindGameObjectsWithTag("Crate");
    }
    public void OpenDoor(){
        _door1.DOLocalMoveZ(_door1Position.z + 3.5f, 1f);
        _door2.DOLocalMoveZ(_door2Position.z + -3.5f, 1f);

        foreach (GameObject item in _crates){
            float randomXRotation = Random.Range(-180f, 180f);
            float randomYRotation = Random.Range(-180f, 180f);
            float randomZRotation = Random.Range(-180f, 180f);
            Vector3 randomVector = new Vector3(randomXRotation,randomYRotation,randomZRotation);
            item.transform.rotation = Quaternion.Euler(randomVector);

            Rigidbody crateRigidbody = item.GetComponent<Rigidbody>();
            crateRigidbody.useGravity = false;
            crateRigidbody.AddForce(Vector3.right * 100);
        }
    }
    public void CloseDoor(){
        _door1.DOLocalMoveZ(_door1Position.z, 1f);
        _door2.DOLocalMoveZ(_door2Position.z, 1f);
        
        if(_crates.Length != 0){
            foreach (GameObject item in _crates){
            Rigidbody crateRigidbody = item.GetComponent<Rigidbody>();
            crateRigidbody.useGravity = true;
            }
        }
    }
}
