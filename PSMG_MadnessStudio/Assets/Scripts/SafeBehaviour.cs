using UnityEngine;
using System.Collections;

public class SafeBehaviour : MonoBehaviour
{
    private int secretcombination;
    private GameObject gold; 
    private int money = 1337;
    private bool isOpen = false; 
	
    void Start () {

        gold = GameObject.Find("Gold");
        secretcombination = Random.Range(100, 200);
	}
	

    public int GetMoney()
    {
        if (isOpen)
            return money;
        else
            Debug.LogError("Open the Safe first");
            return 0;
    }

    public int GetCombination()
    {
        return secretcombination;
    }

    public bool OpenSafe(int combination)
    {
        if (combination == secretcombination&&!isOpen)
        {
            gold.GetComponent<Renderer>().enabled = false; 
            GetComponent<Animation>().Play();
            isOpen = true;
            return true;
        }

            return false;
    }

}
