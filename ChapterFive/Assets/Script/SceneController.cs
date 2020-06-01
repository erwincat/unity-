﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private MemoryCard originalCard;
    [SerializeField] private Sprite[] images;
    [SerializeField] private TextMesh scoreLabel;

    private const int gridRows = 2;
    private const int gridCols = 4;
    private const float offsetX = 2;
    private const float offsetY = 2.5f;

    private MemoryCard _firstRevealed;
    private MemoryCard _secondRevealed;

    private int score = 0;
    public bool canReveal {
        get { return _secondRevealed == null; }
    }

    public void CardRevealed(MemoryCard card) {
        if(_firstRevealed == null) {
            _firstRevealed = card;
        } else {
            _secondRevealed = card;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch() {
        if(_firstRevealed.id == _secondRevealed.id) {
            score++;
            scoreLabel.text = "Score: " + score;
        } else {
            yield return new WaitForSeconds(0.5f);
            _firstRevealed.unreveal();
            _secondRevealed.unreveal();
        }
        _firstRevealed = null;
        _secondRevealed = null;
    }

    public void Restart() {
        SceneManager.LoadScene("Scene");
    }
    // Start is called before the first frame update
    void Start()
    {

        Vector3 startPos = originalCard.transform.position;
        int[] number = { 0, 0, 1, 1, 2, 2, 3, 3 };
        number = ShuffleArray(number);
        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                MemoryCard card;
                if (i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as MemoryCard;
                }

                int index = j * gridCols + i;
                int id = number[index];
                card.SetCard(id, images[id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = -(offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private int[] ShuffleArray(int[] number)
    {
        int[] newArray = number.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

}
