using UnityEngine;
using UnityEngine.UI;

public class GUIScript : MonoBehaviour {

    BuildManager bm;
    Button cube, cylinder;
    bool buildopen = false;

    // Use this for initialization
    void Start () {
		bm = GameObject.Find("BuildManager").GetComponent<BuildManager>();
        Canvas cv = GameObject.Find("Canvas").GetComponent<Canvas>();
        cube = cv.transform.FindChild("CubeButton").gameObject.GetComponent<Button>();
        cylinder = cv.transform.FindChild("CylinderButton").gameObject.GetComponent<Button>();
    }

    public void ActiveteBuilding(Button pressedBtn)
    {
        if (pressedBtn.name == "BuildButton")
        {
            if (buildopen)
            {
                //bm.DeactivateBuildingmode();
                cube.gameObject.SetActive(false);
                cylinder.gameObject.SetActive(false);
                pressedBtn.image.color = Color.white;
                buildopen = false;
            }
            else
            {
                //bm.ActivateBuildingmode();
                cube.gameObject.SetActive(true);
                cylinder.gameObject.SetActive(true);
                pressedBtn.image.color = new Color(255, 0, 255);
                buildopen = true;

            }
        }
        else
        {
            switch (pressedBtn.name)
            {
                case "CubeButton":
                    bm.SelectBuilding(0);
                    break;
                case "CylinderButton":
                    bm.SelectBuilding(1);
                    break;
        
            }

            pressedBtn.image.color = new Color(155, 120, 255);
            bm.ActivateBuildingmode();
            
        }

    }

    void Update()
    {
        if (buildopen)
        {
            if (!bm.isBuildingEnabled)
            {
                if (cube.image.color != Color.white)
                    cube.image.color = Color.white;

                if (cylinder.image.color != Color.white)
                    cylinder.image.color = Color.white;
            }
        }
    }
}
