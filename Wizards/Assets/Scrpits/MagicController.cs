using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicController : MonoBehaviour
{
    //魔法が入る配列を作る
    public GameObject[] magics;
    public int currentNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<magics.Length;i++){
            if(i == currentNum){
                //SetActiveでtrueになっているのが実際に使えるやつ
                magics[i].SetActive(true);
            }else{
                magics[i].SetActive(false);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            currentNum=(currentNum+1)%magics.Length;

            for(int i=0;i<magics.Length;i++){
                if(i == currentNum){
                    magics[i].SetActive(true);
                }else{
                    magics[i].SetActive(false);
                }
            }
        }
    }
}
