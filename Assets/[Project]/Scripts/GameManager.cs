using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _deathCanvas;
    [SerializeField] private AudioClip _deathExplosionSound;
    [SerializeField] private AudioSource _deathExplosionSource;
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
