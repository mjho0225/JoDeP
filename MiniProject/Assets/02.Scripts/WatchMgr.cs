using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

//시계 클릭하면 방향찾기 UI 오픈
//화살표 가운데 방향에 맞출 시 정답
//시침의 방향 랜덤생성(12개)
//시계의 12시 방향엔 초록색 화살표 생성(고정)
//시침이 태양 방향과 일치 시 빨간색 화살표 생성
//초록, 빨간 화살표 생성 시 중간값 파란색 화살표 생성("이쪽이 남쪽")
//정답 완료 시 갈림길 인터페이스 씬으로

public class WatchMgr : MonoBehaviour
{
    public GameObject WatchUI;
    public Quaternion handPivot;
    int angle;
    // Start is called before the first frame update
    void Start()
    {
        WatchUI = GetComponentInChildren<Canvas>().gameObject;
        WatchUI.SetActive(false);

        //시침의 방향 랜덤생성(12개)
        //HandPivot의 Rotation의 Y값을 1~12까지의 12개 값에 30을 곱해 360도 단위로 만든다.
        handPivot.SetEulerRotation(0, 0, 0);
     }

    // Update is called once per frame
    void Update()
    {
          
    }
    //시계 트리거 엔터 되면 UI 오픈
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("RIGHTHAND")){
            WatchUI.SetActive(true);
            //시침의 방향 조정
            angle = Random.Range(0, 11); // 0도와 360도는 같으므로 각도를 0부터 11까지만 줌
            handPivot.SetEulerRotation(0, angle*30, 0);
        }
    }
}
