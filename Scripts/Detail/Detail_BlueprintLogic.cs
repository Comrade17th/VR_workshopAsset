using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detail_BlueprintLogic : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public List<Transform> nextStages = new List<Transform>();
    [SerializeField] public List<Transform> previousStages = new List<Transform>();

    public Material origin;
    public Material baseBlueprint;
    public Material activeBlueprint;
    public Material invisibleBlueprint;
    private Renderer renderer;

    private int condition;
    private bool needChangeMat = false;

    public Transform copyChild;
    public Transform originalParent;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.enabled = true;
        origin = renderer.material;
        ChangeCondition(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (needChangeMat)
        {
            switch (condition)
            {
                case 0: 
                    renderer.material = baseBlueprint;
                    needChangeMat = false;
                    break;
                case 1:
                    renderer.material = activeBlueprint;
                    needChangeMat = false;
                    break;
                case 2:
                    renderer.material = origin;
                    needChangeMat = false;
                    break;
                case 3:
                    renderer.material = invisibleBlueprint;
                    needChangeMat = false;
                    break;
            }
                
        }
    }

    public void CreateDetail(Vector3 position)
    {
        GameObject newCopy = Instantiate(gameObject, position ,this.transform.rotation);
        newCopy.GetComponent<Detail_BlueprintLogic>().SetParent(transform);
        copyChild = newCopy.GetComponent<Transform>();
    }

    public void SetParent(Transform parent)
    {
        originalParent = parent;
    }

    

    public void ChangeCondition(int condition)
    {
        needChangeMat = true;
        this.condition = condition;
    }

}
