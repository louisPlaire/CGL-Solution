using CGL;
using CGL.UI;
using static CGL.GraphicsFunc;

// JUST a main script to test the library

class main
{
    public static void Main(string[] args)
    {
        Window.Init();

        CgConsole.Show();

        Pool p = new Pool();        

        Vertex v = InstantiateInPool(new Vertex(6, 3), p);
        Vertex v1 = InstantiateInPool(new Vertex(12, 3), p);

        for (int i = 0; i < 5; i++)
        {
            v.BoundToPool(v1, p);
            v.Translate(1, 1);
            v1.Translate(-1, 1);
        }
        v.SetActive(false);
        v1.SetActive(false);

        void Update()
        {
            CgConsole.Clear();


            foreach (Vertex vertex in p.storage)
            {
                vertex.Translate(1, 0);
                CgConsole.Print(vertex.ToString());
            }

            p.Update();
            UpdatePool();
        }


        #region update
        while (true)
        {

            Update();
        }
        #endregion
    }
}