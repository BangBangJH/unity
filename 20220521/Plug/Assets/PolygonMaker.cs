using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonMaker : MonoBehaviour
{
    [Range(3,50)]
    public int angleValue = 50;

    [Range(1, 30)]
    public int lenth = 10;

    [Range(0.1f, 10)]
    public float size = 0.5f;

    public GameObject obj0;
    public GameObject obj;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;

    public GameObject plug;
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public GameObject point4;
    public GameObject point5;

    public Shader shader;
    // Start is called before the first frame update
    void Start()
    {
        //MakePolygon(new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(1, 0, 1), new Vector3(0, 0, 1));

        //MakeOctagon(new Vector3(0, 0, 1), new Vector3(0, 0, 2), new Vector3(1, 0, 3), new Vector3(2, 0, 3), new Vector3(3, 0, 2), new Vector3(3, 0, 1), new Vector3(2, 0, 0), new Vector3(1, 0, 0));

        //MakeCylinder3(new Vector3(0, 0, 0), new Vector3(1, 0, 0), 4);
    }

    // Update is called once per frame
    void Update()
    {
        obj0 = MakePipe(obj0, plug.transform.position, point1.transform.position, angleValue, lenth, size);
        obj = MakePipe(obj,point1.transform.position, point2.transform.position, angleValue,lenth,size);
        obj2 = MakePipe(obj2,point2.transform.position, point3.transform.position, angleValue, lenth, size);
        obj3 = MakePipe(obj3,point3.transform.position, point4.transform.position, angleValue, lenth, size);
        obj4 = MakePipe(obj4, point4.transform.position, point5.transform.position, angleValue, lenth, size);
    }

    public GameObject MakePolygon(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4)
    {
        GameObject go = new GameObject("Quad");
        Mesh mesh = new Mesh();
        MeshFilter mf = go.AddComponent<MeshFilter>();
        MeshRenderer mr = go.AddComponent<MeshRenderer>();
        Material mt = new Material(Shader.Find("Standard"));

        Vector3[] vertices = { p1, p2, p3, p4 };
        Vector2[] uvs = { new Vector2(0, 0), new Vector2(1, 0),new Vector2(1,1), new Vector2(0, 1) };

        int[] tris = { 0, 2, 1, 0, 3, 1 };
        mt.mainTexture = (Texture)Resources.Load("Texture/images");
        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.triangles = tris;
        mf.mesh = mesh;
        mr.material = mt;

        return go;

    }

    public GameObject MakeOctagon(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, Vector3 p5, Vector3 p6, Vector3 p7, Vector3 p8)
    {
        GameObject go = new GameObject("Octagon");
        Mesh mesh = new Mesh();
        MeshFilter mf = go.AddComponent<MeshFilter>();
        MeshRenderer mr = go.AddComponent<MeshRenderer>();
        Material mt = new Material(Shader.Find("Standard"));

        Vector3[] vertices = { p1, p2, p3, p4, p5, p6, p7, p8 };
        Vector2[] uvs = { new Vector2(0, 1 / 3f), new Vector2(0, 2 / 3f), new Vector2(1 / 3f, 1), new Vector2(2 / 3f, 1), new Vector2(1, 2 / 3f), new Vector2(1, 1 / 3f), new Vector2(2 / 3f, 0), new Vector2(1 / 3f, 0) };

        int[] tris = { 0, 1, 2, 0,2,3, 0,3,4, 0,4,5, 0,5,6, 0,6,7 };
        mt.mainTexture = (Texture)Resources.Load("Texture/images");
        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.triangles = tris;
        mf.mesh = mesh;
        mr.material = mt;

        return go;

    }

    public GameObject MakeCircle(Vector3 p0,Vector3 p1, int angle)
    {
        GameObject go = new GameObject("Circle");
        Mesh mesh = new Mesh();
        MeshFilter mf = go.AddComponent<MeshFilter>();
        MeshRenderer mr = go.AddComponent<MeshRenderer>();
        Material mt = new Material(Shader.Find("Standard"));
        mt.shader = shader;
        float presentDegree = 0f;
        float degree = 360f / angle;
        float x;
        float z;
        float y = 10f;
        float r = 1f;
        Vector3[] p = new Vector3[angle];
        Vector3[] p2 = new Vector3[angle];
        Vector2[] uvs = new Vector2[angle];
        int trisValue = 3 * (angle - 2);
        int trisValue_3D = 3 * angle;
        int[] tris = new int[trisValue];

        int[] tris_3D = new int[trisValue_3D];
        int t1 = 1;
        int t2 = 2;

        int t22 = angle;

        // 2D  circle
        for (int i = 0; i < angle; i++)
        {
            x = Mathf.Cos(presentDegree * Mathf.Deg2Rad);
            z = Mathf.Sin(presentDegree * Mathf.Deg2Rad);
            p[i] = new Vector3(x, 0, z);
            //uvs[i] = new Vector2((x / 2) + 0.5f, (z / 2) + 0.5f);
            uvs[i] = new Vector2(x * 2, z * 2);
            presentDegree += degree;

        }
        for (int i = 0; i < trisValue; i += 3)
        {
            tris[i] = 0;
            tris[i + 1] = t2;
            tris[i + 2] = t1;
            t1++; t2++;
        }


        Vector3[] vertices = p;




        mt.mainTexture = (Texture)Resources.Load("Texture/images");
        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.triangles = tris;
        mf.mesh = mesh;
        mr.material = mt;

        return go;

    }

    public GameObject MakeCylinder(Vector3 p0, Vector3 p1, int angle)
    {
        GameObject go = new GameObject("Circle");
        Mesh mesh = new Mesh();
        MeshFilter mf = go.AddComponent<MeshFilter>();
        MeshRenderer mr = go.AddComponent<MeshRenderer>();
        Material mt = new Material(Shader.Find("Standard"));
        mt.shader = shader;
        float presentDegree = 0f;
        float degree = 360f / angle;
        float x;
        float z;
        float y = 10f;
        float r = 1f;
        Vector3[] p = new Vector3[angle];
        Vector3[] p2 = new Vector3[angle];
        Vector2[] uvs = new Vector2[angle*2];
        int trisValue = 3 * (angle - 2);
        int trisValue_3D = 3 * angle;
        int[] tris = new int[trisValue];

        int[] tris_3D = new int[trisValue_3D];
        int t1 = 1;
        int t2 = 2;
        int t0 = 0;
        int t22 = angle;

        //// 2D  circle
        //for (int i = 0; i < angle; i++)
        //{
        //    x = Mathf.Cos(presentDegree * Mathf.Deg2Rad);
        //    z = Mathf.Sin(presentDegree * Mathf.Deg2Rad);
        //    p[i] = new Vector3(x, 0, z);
        //    //uvs[i] = new Vector2((x / 2) + 0.5f, (z / 2) + 0.5f);
        //    uvs[i] = new Vector2(x*2 , z*2 );
        //    presentDegree += degree;

        //}
        //for (int i = 0; i < trisValue; i += 3)
        //{
        //    tris[i] = 0;
        //    tris[i + 1] = t2;
        //    tris[i + 2] = t1;
        //    t1++; t2++;
        //}


        //3D cylinder
        for (int i = 0; i < angle; i++)
        {
            x = Mathf.Cos(presentDegree * Mathf.Deg2Rad);
            z = Mathf.Sin(presentDegree * Mathf.Deg2Rad);
            p[i] = new Vector3(x, y, z);
            p2[i] = new Vector3(x, 0, z);
           
            presentDegree += degree;

        }
    

        for (int i = 0; i < trisValue_3D; i += 3)
        {
            if(i == 3*(angle-1))
            {
                tris_3D[i] = t0;
                tris_3D[i + 1] = 0;
                tris_3D[i + 2] = angle;

                break;
            }
            tris_3D[i] = t0;
            tris_3D[i + 1] = t1;
            tris_3D[i + 2] = t22;
            t0++; t1++; t22++;
        }


        //Vector3[] vertices = p;
        
        Vector3[] vertices = new Vector3[angle * 2];
        for (int i = 0; i < angle; i++)
        {
            vertices[i] = p[i];
            uvs[i] = new Vector2(i/angle, 1);
        }
        for (int i = 0; i < angle; i++)
        {
            vertices[i + angle] = p2[i];
            uvs[i+angle] = new Vector2(i/angle, 0);
        }



        mt.mainTexture = (Texture)Resources.Load("Texture/images");
        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.triangles = tris_3D;
        mf.mesh = mesh;
        mr.material = mt;

        return go;

    }

    public GameObject MakeCylinder2(Vector3 p0, Vector3 p1, int angle)
    {
        GameObject go = new GameObject("Cylinder");
        Mesh mesh = new Mesh();
        MeshFilter mf = go.AddComponent<MeshFilter>();
        MeshRenderer mr = go.AddComponent<MeshRenderer>();
        Material mt = new Material(Shader.Find("Standard"));
        mt.shader = shader;
        float presentDegree = 0f;
        float degree = 360f / angle;
        float x;
        float z;
        float y = 10f;
        float r = 1f;
        Vector3[] p_up = new Vector3[angle+1];
        Vector3[] p_down = new Vector3[angle+1];
        Vector2[] uvs = new Vector2[angle * 2];
        int trisValue = 3 * (angle - 2);
        int[] tris = new int[trisValue];
       

        for (int i = 0; i <= angle; i++)
        {
            x = Mathf.Cos(presentDegree * Mathf.Deg2Rad);
            z = Mathf.Sin(presentDegree * Mathf.Deg2Rad);
            p_up[i] = new Vector3(x, y, z);
            p_down[i] = new Vector3(x, 0, z);

            presentDegree += degree;
        }

        mt.mainTexture = (Texture)Resources.Load("Texture/images");
        //mesh.vertices;
        mesh.uv = uvs;
        mesh.triangles = tris;
        mf.mesh = mesh;
        mr.material = mt;

        return go;

    }

    public GameObject MakeCylinder3(Vector3 p1, Vector3 p2, int angle)
    {
        GameObject go = new GameObject("cylinder");
        Mesh mesh = new Mesh();
        MeshRenderer mr = go.AddComponent<MeshRenderer>();
        MeshFilter mf = go.AddComponent<MeshFilter>();
        Material mt = new Material(Shader.Find("Standard"));
        mt.shader = shader;

        int point_value = (angle + 1) * 2;
        int tris_value = 3 * angle;
        Vector3[] vertices = new Vector3[point_value];
        Vector2[] uvs = new Vector2[point_value];
        int[] tris = new int[tris_value];
        int[] tris2 = new int[tris_value*2];


        Vector3[] p= new Vector3[point_value];
        
        float presentDegree = 0f;
        float Dgree = 360f / angle;
        float x;
        float z;
        float y = 10f;
        int plusAG = angle + 1;

        int i2 = angle + 1;

        int t0 = 0;
        int t1 = 1;
        int t10 = angle + 1;
     

        for(int i = 0; i <=angle;i++)
        {
            x = Mathf.Cos(presentDegree * Mathf.Deg2Rad);
            z = Mathf.Sin(presentDegree * Mathf.Deg2Rad);
            p[i] = new Vector3(x, y, z);
            p[i2] = new Vector3(x, 0, z);
            presentDegree += Dgree;
            uvs[i] = new Vector2(i / (float)angle, 1);
            uvs[i2] = new Vector2(i / (float)angle, 0);
            //uvs[i] = new Vector2((x/5), 1);
            //uvs[i2] = new Vector2((x/5), 0);
            i2++;

        }

        for(int i=0;i<tris_value;i+=3)
        {
            tris2[i] = t0;
            tris2[i + 1] = t1;
            tris2[i + 2] = t10+1;

            tris2[i + tris_value] = t10;
            tris2[i +tris_value + 1] = t0;
            tris2[i +tris_value+ 2] = t10 + 1;

            t0++; t1++; t10++;
        }
        
        vertices = p;

        mt.mainTexture = (Texture)Resources.Load("");
        
        mesh.vertices = vertices;
        mesh.triangles = tris2;
        mesh.uv = uvs;
        mf.mesh = mesh;
        mr.material = mt;

        return go;
    }

    public GameObject MakeCylinder4(Vector3 p1, Vector3 p2, int angle, int lenth , int size)
    {
        GameObject go = obj;
        Mesh mesh = new Mesh();
        MeshRenderer mr = go.GetComponent<MeshRenderer>();
        MeshFilter mf = go.GetComponent<MeshFilter>();
        Material mt = new Material(Shader.Find("Standard"));
        //mt.shader = shader;

        int point_value = (angle + 1) * 2;
        int tris_value = 3 * angle;
        Vector3[] vertices = new Vector3[point_value];
        Vector2[] uvs = new Vector2[point_value];
        int[] tris = new int[tris_value];
        int[] tris2 = new int[tris_value * 2];


        Vector3[] p = new Vector3[point_value];

        float presentDegree = 0f;
        float Degree = 360f / angle;
        float x;
        float z;
        float y = lenth;
        int plusAG = angle + 1;

        int i2 = angle + 1;

        int t0 = 0;
        int t1 = 1;
        int t10 = angle + 1;


        for (int i = 0; i <= angle; i++)
        {
            x = Mathf.Cos(presentDegree * Mathf.Deg2Rad);
            z = Mathf.Sin(presentDegree * Mathf.Deg2Rad);
            x *= size;
            z *= size;
            p[i] = new Vector3(x, y, z);
            p[i2] = new Vector3(x, 0, z);
            presentDegree += Degree;
            uvs[i] = new Vector2(i / (float)angle, 1);
            uvs[i2] = new Vector2(i / (float)angle, 0);
            i2++;

        }

        for (int i = 0; i < tris_value; i += 3)
        {
            tris2[i] = t0;
            tris2[i + 1] = t1;
            tris2[i + 2] = t10 + 1;

            tris2[i + tris_value] = t10;
            tris2[i + tris_value + 1] = t0;
            tris2[i + tris_value + 2] = t10 + 1;

            t0++; t1++; t10++;
        }

        vertices = p;

        mt.mainTexture = (Texture)Resources.Load("");

        mesh.vertices = vertices;
        mesh.triangles = tris2;
        mesh.uv = uvs;
        mf.mesh = mesh;
        //mr.material = mt;

        return go;
    }

    public GameObject MakePipe(GameObject ob, Vector3 p1, Vector3 p2, int angle, int lenth, float size)
    {
        ob.transform.position = Vector3.zero;
        GameObject go = ob;
        Vector2 v = Turn(p1, p2);
        
        

        Mesh mesh = new Mesh();
        MeshRenderer mr = go.GetComponent<MeshRenderer>();
        MeshFilter mf = go.GetComponent<MeshFilter>();
        Material mt = new Material(Shader.Find("Standard"));
        //mt.shader = shader;

        int point_value = (angle + 1) * 2;
        int tris_value = 3 * angle;
        Vector3[] vertices = new Vector3[point_value];
        Vector2[] uvs = new Vector2[point_value];
        int[] tris = new int[tris_value];
        int[] tris2 = new int[tris_value * 2];


        Vector3[] p = new Vector3[point_value];

        float presentDegree = 0f;
        float Degree = 360f / angle;
        float x;
        float y;
        float z = lenth;
        int plusAG = angle + 1;

        int i2 = angle + 1;

        int t0 = 0;
        int t1 = 1;
        int t10 = angle + 1;

        // a.(32,11) 
        // (-15) 
        // (+15) 

        for (int i = 0; i <= angle; i++)
        {
            x = Mathf.Cos(presentDegree * Mathf.Deg2Rad)-0;
            y = Mathf.Sin(presentDegree * Mathf.Deg2Rad)+0;


            x *= size;
            y *= size;
            p[i] = new Vector3(x*v.x+p1.x, y+p1.y,p1.z-(x*v.y));
            p[i2] = new Vector3(x*v.x+p2.x, y+p2.y,p2.z-(x*v.y));
            presentDegree += Degree;
            uvs[i] = new Vector2(i / (float)angle, 1);
            uvs[i2] = new Vector2(i / (float)angle, 0);
            i2++;

        }

        for (int i = 0; i < tris_value; i += 3)
        {
            tris2[i] = t0;
            tris2[i + 1] = t1;
            tris2[i + 2] = t10 + 1;

            tris2[i + tris_value] = t10;
            tris2[i + tris_value + 1] = t0;
            tris2[i + tris_value + 2] = t10 + 1;

            t0++; t1++; t10++;
        }

        vertices = p;

        mt.mainTexture = (Texture)Resources.Load("");

        mesh.vertices = vertices;
        mesh.triangles = tris2;
        mesh.uv = uvs;
        mf.mesh = mesh;
        //mr.material = mt;

        
        return go;
    }

    private Vector2 Turn(Vector3 p1,Vector3 p2)
    {
        Vector2 v = new Vector2(0, 0);

        v = new Vector2(p1.x - p2.x, p1.z - p2.z);
        float deg = Mathf.Atan2(v.x, v.y) * Mathf.Rad2Deg;
        //Debug.LogErrorFormat("angle : {0}", deg);
        float z = Mathf.Sin(deg * Mathf.Deg2Rad);
        float x = Mathf.Cos(deg * Mathf.Deg2Rad);

        v = new Vector2(x, z);
        //Debug.LogError(v);

        
        return v;
    }
}
