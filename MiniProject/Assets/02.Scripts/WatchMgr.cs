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
    public Transform handPivot;
    int angle;

    int count;

    bool test;

    public Slider m_ArrowSlider;
    float currentTime;
    float maxSlider = 1;

    // Start is called before the first frame update
    void Start()
    {
        m_ArrowSlider = GetComponent<Slider>();
        WatchUI = GetComponentInChildren<Canvas>().gameObject;
        WatchUI.SetActive(false);

        //시침의 방향 랜덤생성(12개)
        //HandPivot의 Rotation의 Y값을 1~12까지의 12개 값에 30을 곱해 360도 단위로 만든다.
        
        angle = Random.Range(1, 12); //12 개의 시간 방향 중 랜덤하게 1개
     
        handPivot.localEulerAngles = new Vector3(0, 0, angle * 30);

        
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(test)
        {
            if (currentTime >= 1)
            {
                test = false;
                

            }
            else
                m_ArrowSlider.gameObject.SetActive(true);
            currentTime = 0;
            m_ArrowSlider.value = currentTime;
        }

    }
    //시계 트리거 엔터 되면 UI 오픈
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("RIGHTHAND") && count < 1)
        {
            //카운트를 센다
            //트리거를 한번만 실행한다.
            count++;

            Debug.Log("들어와썽!");
            WatchUI.SetActive(true);
            test = true;
            
            
            /*ArrowSlider();
            currentTime = 0;*/
        }
    }
    void ArrowSlider()
    {
        //슬라이더의 값은 시간에 따라 증가한다.
        //시간의 값 = 슬라이더값

       /* currentTime += currentTime * Time.deltaTime;
        if(currentTime < 1)
        {
            m_ArrowSlider.value += currentTime;
        }*/
        
        
    }
}
