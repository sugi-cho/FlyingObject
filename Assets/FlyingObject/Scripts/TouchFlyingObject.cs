using UnityEngine;
using System.Collections;

public class TouchFlyingObject : MonoBehaviour {
    public Camera viewCam;
    int copyCount = 0;
    // Use this for initialization
    void Start () {
        if (viewCam == null)
            viewCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (copyCount > 100)
            return;
		//カメラからマウスの位置へのRayを作る
        Ray ray = viewCam.ScreenPointToRay(Input.mousePosition);
		
        //  カメラから、任意のオブジェクトへのRayが欲しい時用
        //  Ray ray = new Ray(viewCam, TargetObject.transform.position);
        RaycastHit[] hit;
        //RayがHitするコライダがある時の、Hit情報をHitした分、全部取ってくる。
        hit = Physics.RaycastAll(ray, 100f);
		
        foreach (RaycastHit h in hit)
        {
            Flying f = h.collider.GetComponent<Flying>();
            if (f != null)
            {
                Flying newFly = (Flying)Instantiate(f, f.transform.position + Random.insideUnitSphere, Random.rotation);
                newFly.speed *= Random.Range(0.8f, 1.5f);
				newFly.maxDeltaRotate *= Random.Range(0.8f, 2f);
                copyCount++;
            }
        }
    }
}
