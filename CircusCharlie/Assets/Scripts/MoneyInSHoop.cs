using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyInSHoop : MonoBehaviour
{
    public GameObject money;
    //private PlayerController playerController;

    private void OnEnable()
    {
        if(Random.Range(0,3) == 0) 
        {
            money.SetActive(true);
            Debug.Log("���� ������");
        }
        else 
        {
            money.SetActive(false);
            Debug.Log("���� ����");
        }
    }






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
