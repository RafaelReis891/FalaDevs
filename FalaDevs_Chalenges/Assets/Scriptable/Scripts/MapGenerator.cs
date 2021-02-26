using UnityEngine;
using UnityEngine.UI;

public class MapGenerator : MonoBehaviour
{
    public Texture2D texture;
    public ObjectInfo[] objectInfo;
    public Vector2 pos;


    [Header("Create Texture")]
    public int widht = 256;
    public int height = 256;
    public float scale = 20f;
    public int offsetX = 100;
    public int offsetY = 100;
    public float maxHeight = 20;

    public RawImage viewImg;

    void Start()
    {

        //offsetX = Random.Range(0,99999);
        //offsetY = Random.Range(0,99999);

        texture = GenerateTexture();

        viewImg.texture = texture;
        this.ReadTexture();
    }

    Texture2D GenerateTexture()
    {
        Texture2D text = new Texture2D(widht, height);

        //Generator perlin noise for the texture

        for(int x =0;x < widht; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = CalculateColor(x,y);
                text.SetPixel(x,y,color);
            }
        }

        text.Apply();
        return text;
    }

    private Color CalculateColor(int x, int y)
    {
        float xCoord = (float)x / widht * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;

        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }

    private void ReadTexture()
    {
        for (int w = 0; w < this.texture.width; w++)
        {
            for (int h = 0; h < this.texture.height; h++)
            {
                this.pos = new Vector2(w,h);
                this.GetColor(w,h);
            }
        }
    }

    private void GetColor(int w, int h)
    {
        Color c = this.texture.GetPixel(w,h);

        //if (c.a < 1)
        //    return;

        this.CreateObject(c);
    }

    private void CreateObject(Color c)
    {
        foreach(ObjectInfo info in objectInfo)
        {
            // if(c.r > 0.5f && c.g > 0.5f && c.b > 0.5f)
            // {
            float thisHeight = c.grayscale * 20;
            GameObject newBlock = Instantiate(info.prefab, new Vector3(Mathf.RoundToInt(this.pos.x), thisHeight, Mathf.RoundToInt(this.pos.y)) + info.offset, Quaternion.identity, this.transform);

            if (thisHeight > maxHeight * 0.8f)//Snow
            {
                newBlock.GetComponent<MeshRenderer>().material.color = Color.white;
            }
            else if (thisHeight > maxHeight * 0.6f && thisHeight <= maxHeight * 0.8f)//Grass
            {
                newBlock.GetComponent<MeshRenderer>().material.color = Color.green;
            }
            else if (thisHeight > maxHeight * 0.4f && thisHeight <= maxHeight * 0.6f)//Dirt
            {
                newBlock.GetComponent<MeshRenderer>().material.color = Color.yellow;
            }
            else if (thisHeight > maxHeight * 0.2f && thisHeight <= maxHeight * 0.4f)//Rock
            {
                newBlock.GetComponent<MeshRenderer>().material.color = Color.grey;
            }
            else if (thisHeight > maxHeight * 0.1f && thisHeight <= maxHeight * 0.2f)//another
            {
                newBlock.GetComponent<MeshRenderer>().material.color = Color.magenta;
            }
            else if (thisHeight <= maxHeight * 0.1f)//Water
            {
                newBlock.GetComponent<MeshRenderer>().material.color = Color.blue;
            }
            //}
        }
    }
}
