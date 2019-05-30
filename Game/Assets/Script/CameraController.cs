using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera subCamera;

    // 「bool」は「true」か「false」の二択の情報を扱うことができます（ポイント）
    private bool mainCameraON = true;

    public GameObject aimImage;


    void Start()
    {
        mainCamera.enabled = true;
        subCamera.enabled = false;

        // 客観カメラの場合、照準器をオフにする。
        aimImage.SetActive(false);
    }

    void Update()
    {

        // （重要ポイント）「&&」は論理関係の「かつ」を意味する。
        // 「A && B」は「A かつ B」（条件AとBの両方が揃った時という意味）
        // 「==」は「左右が等しい」という意味

        // もしも「Cボタン」を押した時、「かつ」、「mainCameraON」のステータスが「true」の時（条件）
        if (Input.GetKeyDown(KeyCode.C) && mainCameraON == true)
        {
            mainCamera.enabled = false;
            subCamera.enabled = true;

            mainCameraON = false;
            // 主観カメラの場合、照準器をオンにする。
            aimImage.SetActive(true);

            // もしも「Cボタン」を押した時、「かつ」、「mainCameraON」のステータスが「false」の時（条件）
        }
        else if (Input.GetKeyDown(KeyCode.C) && mainCameraON == false)
        {
            mainCamera.enabled = true;
            subCamera.enabled = false;

            mainCameraON = true;

            // 客観カメラの場合、照準器をオフにする。
            aimImage.SetActive(false);
        }
    }
}
