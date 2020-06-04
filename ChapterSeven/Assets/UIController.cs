using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreLabel;
    [SerializeField] private SettingsPopup settingsPopup;

    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreLabel.text = score.ToString();
        settingsPopup.close();

    }

    public void OnOpenSettings() {
        settingsPopup.open();
    }

    private void Awake() {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    private void OnDestroy() {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    private void OnEnemyHit() {
        score += 1;
        scoreLabel.text = score.ToString();
    }
}
