using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {
	[SerializeField] private GameObject enemyPrefab;
	private GameObject _enemy;
	private float basepeed = 6.0f;
	
	void Update() {
		if (_enemy == null) {
			_enemy = Instantiate(enemyPrefab) as GameObject;
			_enemy.transform.position = new Vector3(0, 1, 0);
			float angle = Random.Range(0, 360);
			_enemy.transform.Rotate(0, angle, 0);
			
		}
	}

	private void OnSpeedChanged(float value) {
		if(_enemy != null) {
			_enemy.GetComponent<WanderingAI>().speed = basepeed * value;
        }
	}

	private void Awake() {
		Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}

	private void OnDestroy() {
		Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}
}
