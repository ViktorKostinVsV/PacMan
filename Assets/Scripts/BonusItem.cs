using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusItem : MonoBehaviour
{
    float randomLifeEcpectancy;
    float currentLifeTime;

    // Start is called before the first frame update
    void Start()
    {
        randomLifeEcpectancy = Random.Range(9, 10);

        this.name = "bonusItem";

        GameObject.Find("Game").GetComponent<GameBoard>().board[16, 15] = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLifeTime < randomLifeEcpectancy)
        {
            currentLifeTime += Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
