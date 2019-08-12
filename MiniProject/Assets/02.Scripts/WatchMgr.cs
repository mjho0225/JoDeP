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
    // Start is called before the first frame update
    void Start()
    {
        WatchUI = GetComponentInChildren<Canvas>().gameObject;
        WatchUI.SetActive(false);
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
        }
    }
}
