using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject _deathCanvas;
    [SerializeField] private AudioClip _deathExplosionSound;
    [SerializeField] private AudioSource _deathExplosionSource;
    void Awake(){
        instance = this;
    }
    public void ShipExplode(){

        _deathCanvas.SetActive(true);
        _deathExplosionSource.Play();
        StartCoroutine(ReloadScene());
    }
    private IEnumerator ReloadScene(){
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
