using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Slider _hpBar;
    [SerializeField] private BaseController _base;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private GameObject _diePanel;
    [SerializeField] private GameController _gameController;
    [SerializeField] private Text _enemyCountText;
    [SerializeField] private Text _moneyText;

    private bool _isDie;

    private void Start()
    {
        _isDie = false;

        _hpBar.maxValue = _base.GetHealth();
        _hpBar.value = _hpBar.maxValue;
    }

    private void Update()
    {
        _diePanel.SetActive(_isDie);
        _enemyCountText.text = _enemySpawner.GetSpawnCount().ToString() + "/" + _enemySpawner.GetAllSpawnCount().ToString();
        _moneyText.text = _gameController.GetMoney().ToString();
        _hpBar.value = _base.GetHealth();

        if (_base.GetHealth() <= 0)
        {
            _isDie = true;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
