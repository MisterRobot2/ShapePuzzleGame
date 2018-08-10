using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shapePreview : MonoBehaviour {


    public GameObject[] shapes = new GameObject[] { };
    public List<GameObject> includedShapes = new List<GameObject>();
    public List<GameObject> createdShapes = new List<GameObject>();

    private Camera previewCamera;
    [SerializeField]
    private GameObject nextShape;
    private GameObject objectToSpawn;
    [SerializeField]
    private GameObject newObject;
    private bool destroyBlock = false;
    [SerializeField]
    [Tooltip("Place where shapes spawn")]
    private GameObject parent;

    public MeshCreator MeshObjL;

    public GameObject waitButton;

    private void Awake()
    {
        addEnableShapes();
    }

    private void Start()
    {
        previewCamera = this.gameObject.transform.parent.gameObject.GetComponent<Camera>();
    }

    private void Update()
    {
        if (destroyBlock == true)
        {
            newObject.transform.position = nextShape.transform.position;
            destroyBlock = false;
        }

        if (GameData.blockIsFalling == true)
        {
            waitButton.SetActive(true);

        }
        else if (GameData.blockIsFalling == false)
        {
            waitButton.SetActive(false);
        }
    }

    void addEnableShapes()
    {
        //Check toggle in store to figure out which shapes to include
        if (CurrentData.gameData.iceBlockToggleIsOn == true)
        {
            shapes[2].gameObject.tag = "Block";
        }
        else
        {
            shapes[2].gameObject.tag = "Untagged";
        }

        if (CurrentData.gameData.phoneToggleIsOn == true)
        {
            shapes[5].gameObject.tag = "Block";
        }
        else
        {
            shapes[5].gameObject.tag = "Untagged";
        }

        if (CurrentData.gameData.waterGunToggleIsOn == true)
        {
            shapes[4].gameObject.tag = "Block";
        }
        else
        {
            shapes[4].gameObject.tag = "Untagged";
        }

        if (CurrentData.gameData.orbToggleIsOn == true)
        {
            shapes[6].gameObject.tag = "Block";
        }
        else
        {
            shapes[6].gameObject.tag = "Untagged";
        }

        if (CurrentData.gameData.tableToggleIsOn == true)
        {
            shapes[7].gameObject.tag = "Block";
        }
        else
        {
            shapes[7].gameObject.tag = "Untagged";
        }
        if (CurrentData.gameData.bookToggleIsOn == true)
        {
            shapes[8].gameObject.tag = "Block";
        }
        else
        {
            shapes[8].gameObject.tag = "Untagged";
        }
        if (CurrentData.gameData.bookShelfToggleIsOn == true)
        {
            shapes[9].gameObject.tag = "Block";
        }
        else
        {
            shapes[9].gameObject.tag = "Untagged";
        }

        foreach (GameObject shape in shapes)
        {
            if (shape.gameObject.tag == "Block")
            {
                includedShapes.Add(shape);
            }
        }
    }

    public void SpawnFirstShape()
    {

        //Creates Preview
        nextShape = GameObject.Instantiate(includedShapes[Random.Range(0, includedShapes.Count)], parent.transform);
        nextShape.transform.position = this.gameObject.transform.position;
        //Get Mesh Creator
        if (nextShape.GetComponent<MeshCreator>() == true)
        {
            nextShape.GetComponent<MeshCreator>().meshCreator();
        }
        else if (nextShape.GetComponent<MeshObjL>() == true)
        {
            nextShape.GetComponent<MeshObjL>().meshCreatorL();
        }
    }

    public void calculatePreview(bool doSkipShape)
    {
        //Takes preview and puts it to spawn spot
        newObject = nextShape;
        newObject.transform.position = GameObject.FindGameObjectWithTag("Spawner").transform.position;
        newObject.transform.parent = parent.transform;
        nextShape.GetComponent<ShapeMovement>().canBeControlled = true;


        if (newObject.GetComponent<SpriteRenderer>())
        {

            if (GameData.currentTeamNumber == 1)
            {
                newObject.GetComponent<SpriteRenderer>().color = GameData.team1Color;
            }
            else if (GameData.currentTeamNumber == 2)
            {
                newObject.GetComponent<SpriteRenderer>().color = GameData.team2Color;
            }
        }
        else if (newObject.GetComponent<MeshRenderer>())
        {
            if (GameData.currentTeamNumber == 1)
            {
                newObject.GetComponent<MeshRenderer>().material.SetColor("_Color", GameData.team1Color);
            }
            else if (GameData.currentTeamNumber == 2)
            {
                newObject.GetComponent<MeshRenderer>().material.SetColor("_Color", GameData.team2Color);
            }
        }

        //Scale Size
        //newObject.GetComponent<Transform>().localScale = new Vector3(0.9f, 0.9f, 0);




        //Add Colliders
        if (newObject.GetComponent<MeshCreator>() == true){
            newObject.AddComponent<BoxCollider2D>();
            newObject.GetComponent<BoxCollider2D>().isTrigger = true;
            newObject.GetComponent<ShapeMovement>().boxCollider2D = newObject.GetComponent<BoxCollider2D>();
        }
        else if (newObject.GetComponent<MeshObjL>() == true){
            newObject.AddComponent<PolygonCollider2D>();
            newObject.GetComponent<PolygonCollider2D>().isTrigger = true;
            newObject.GetComponent<ShapeMovement>().polycollider2D = newObject.GetComponent<PolygonCollider2D>();
            newObject.GetComponent<ShapeMovement>().RemoveColliders();
            Vector3[] temp = new Vector3[8];
            temp = newObject.GetComponent<MeshObjL>().vertices;
            Vector2[] vertices2 = new Vector2[temp.Length + 1];
            for (int i = 0; i < temp.Length; i++)
            {
                Vector3 tempV3 = temp[i];
                vertices2[i] = new Vector2(tempV3.x, tempV3.y);
            }
            vertices2 [temp.Length] = new Vector2(temp[0].x, temp[0].y);

            newObject.GetComponent<PolygonCollider2D>().SetPath(0, vertices2);
        }


        if (doSkipShape)
        {
            
        }


        //Make new Preview
        nextShape = GameObject.Instantiate(includedShapes[Random.Range(0, includedShapes.Count)], this.gameObject.transform);
        nextShape.transform.position = this.gameObject.transform.position;
        nextShape.GetComponent<ShapeMovement>().canBeControlled = false;
        //Get Mesh Creator
        if (nextShape.GetComponent<MeshCreator>() == true)
        {
            nextShape.GetComponent<MeshCreator>().meshCreator();
        }
        else if (nextShape.GetComponent<MeshObjL>() == true)
        {
            nextShape.GetComponent<MeshObjL>().meshCreatorL();
        }

        if(doSkipShape)
        {
            calculatePreview(false);
        }
    }

    public void ShapeSkip()
    {
        if(GameData.currentTeamNumber == 1){
            GameData.team1Skips--;
        } else if(GameData.currentTeamNumber == 2){
            GameData.team2Skips--;
        }


        GameObject.Destroy(newObject);

        newObject = nextShape;
        newObject.transform.position = GameObject.FindGameObjectWithTag("Spawner").transform.position;
        nextShape.GetComponent<ShapeMovement>().canBeControlled = true;

        if (newObject.GetComponent<SpriteRenderer>())
        {

            if (GameData.currentTeamNumber == 1)
            {
                newObject.GetComponent<SpriteRenderer>().color = GameData.team1Color;
            }
            else if (GameData.currentTeamNumber == 2)
            {
                newObject.GetComponent<SpriteRenderer>().color = GameData.team2Color;
            }
        }
        else if (newObject.GetComponent<MeshRenderer>())
        {
            if (GameData.currentTeamNumber == 1)
            {
                newObject.GetComponent<MeshRenderer>().material.SetColor("_Color", GameData.team1Color);
            }
            else if (GameData.currentTeamNumber == 2)
            {
                newObject.GetComponent<MeshRenderer>().material.SetColor("_Color", GameData.team1Color);
            }
        }

        //Add gravity
        //newObject.GetComponent<Rigidbody2D>().gravityScale = 1;

        //Add Colliders
        if (newObject.GetComponent<MeshCreator>() == true)
        {
            newObject.AddComponent<BoxCollider2D>();
            newObject.GetComponent<ShapeMovement>().boxCollider2D = newObject.GetComponent<BoxCollider2D>();
            newObject.GetComponent<ShapeMovement>().RemoveColliders();
        }
        else if (newObject.GetComponent<MeshObjL>() == true)
        {
            newObject.AddComponent<PolygonCollider2D>();
            Vector3[] temp = new Vector3[8];
            temp = newObject.GetComponent<MeshObjL>().vertices;
            Vector2[] vertices2 = new Vector2[temp.Length + 1];
            for (int i = 0; i < temp.Length; i++)
            {
                Vector3 tempV3 = temp[i];
                vertices2[i] = new Vector2(tempV3.x, tempV3.y);
            }
            vertices2[temp.Length] = new Vector2(temp[0].x, temp[0].y);

            newObject.GetComponent<PolygonCollider2D>().SetPath(0, vertices2);
        }


        //Make new Preview
        nextShape = GameObject.Instantiate(includedShapes[Random.Range(0, includedShapes.Count)], this.gameObject.transform);
        nextShape.transform.position = this.gameObject.transform.position;
        nextShape.GetComponent<ShapeMovement>().canBeControlled = false;
        //Get Mesh Creator
        if (nextShape.GetComponent<MeshCreator>() == true)
        {
            nextShape.GetComponent<MeshCreator>().meshCreator();
        }
        else if (nextShape.GetComponent<MeshObjL>() == true)
        {
            nextShape.GetComponent<MeshObjL>().meshCreatorL();
        }

        if (GameData.canSkip == true)
        {
            GameData.firstSkip = true;
        }
    }


    public void buySkips(){
        if (GameData.currentTeamNumber == 1)
        {
            GameData.team1coins -= 3;
            GameData.team1Skips++;
        }
        else if (GameData.currentTeamNumber == 2)
        {
            GameData.team2coins -= 3;
            GameData.team2Skips++;
        }
    }
}
