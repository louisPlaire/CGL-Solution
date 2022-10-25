using CGL.UI;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;


namespace CGL
{
    /// <summary>
    /// Allows you to create a two dimensional vector to place vertex in the screen.
    /// </summary>
    struct Vector2
    {
        public int x;
        public int y;
        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public static Vector2 Addition(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }
        public static Vector2 Substraction(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x - b.x, a.y - b.y);
        }
        public static Vector2 Mulitplication(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x * b.x, a.y * b.y);
        }
        public static Vector2 Division(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x / b.x, a.y / b.y);
        }
        public static bool Equal (Vector2 a, Vector2 b)
        {
            if(a.x == b.x && a.y == b.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool NotEqual(Vector2 a, Vector2 b)
        {
            if (a.x == b.x && a.y == b.y)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static Vector2 operator + (Vector2 a, Vector2 b)
        {
            return Vector2.Addition(a, b);
        }
        public static Vector2 operator - (Vector2 a, Vector2 b)
        {
            return Vector2.Substraction(a, b);
        }
        public static Vector2 operator * (Vector2 a, Vector2 b)
        {
            return Vector2.Mulitplication(a, b);
        }
        public static Vector2 operator / (Vector2 a, Vector2 b)
        {
            return Vector2.Division(a, b);
        }
        public static bool operator == (Vector2 a, Vector2 b)
        {
            return Vector2.Equal(a, b);
        }
        public static bool operator !=(Vector2 a, Vector2 b)
        {
            return Vector2.NotEqual(a, b);
        }
        public override string ToString()
        {
            return $"[{x}, {y}]";
        }
    }
    /// <summary>
    /// EXPERIMENTAL: A three dimentional vector.
    /// </summary>
    struct Vector3
    {
        public int x;
        public int y;
        public int z;
        public Vector3(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public static Vector3 Addition(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }
        public static Vector3 Substraction(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }
        public static Vector3 Mulitplication(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        }
        public static Vector3 Division(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);
        }
        public static bool Equal (Vector3 a, Vector3 b)
        {
            if(a.x == b.x && a.y == b.y && a.z == b.z)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool NotEqual(Vector3 a, Vector3 b)
        {
            if (a.x == b.x && a.y == b.y && a.z == b.z)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static Vector3 operator + (Vector3 a, Vector3 b)
        {
            return Vector3.Addition(a, b);
        }
        public static Vector3 operator - (Vector3 a, Vector3 b)
        {
            return Vector3.Substraction(a, b);
        }
        public static Vector3 operator * (Vector3 a, Vector3 b)
        {
            return Vector3.Mulitplication(a, b);
        }
        public static Vector3 operator / (Vector3 a, Vector3 b)
        {
            return Vector3.Division(a, b);
        }
        public static bool operator == (Vector3 a, Vector3 b)
        {
            return Vector3.Equal(a, b);
        }
        public static bool operator !=(Vector3 a, Vector3 b)
        {
            return Vector3.NotEqual(a, b);
        }
        public override string ToString()
        {
            return $"[{x}, {y}, {z}]";
        }
    }

    /// <summary>
    /// The basic unit of CGL.
    /// </summary>
    class Vertex
    {
        public Vector2 position;
        public int zIndex = 0;
        public Vector2 lastposition;
        public string body = "█";
        public ConsoleColor color = CgColor.White;
        public bool isActive = true;
        public string name = "unnamed";
        public readonly string id = " ";
        private Random random = new Random();
        public Vertex(int x, int y)
        {
            this.position.x = x;
            this.position.y = y;
            id = CreateId();
        }
        public Vertex(Vector2 position)
        {
            this.position = position;
            id = CreateId();
        }
        /// <summary>
        /// Bound vertices between each other <br></br> by creating vertices between them<br></br>  and instantiate those vertices in the pre-created pool.
        /// </summary>
        /// <param name="vertex"></param>
        public void Bound(Vertex vertex)
        {
            if (isActive)
            {
                int _x = position.x, _y = position.y;
                Vector2 newPos = vertex.position - position;
                //Console.ForegroundColor = ConsoleColor.Red;
                int newX = 0;
                int newY = 0;
                if(newPos.x > 0)
                {
                    for (int i = 1; i < newPos.x + 1; i++)
                    {
                        if (position.x < Console.BufferWidth && position.y < Console.BufferHeight && position.x > 0 && position.y > 0)
                        {
                            GraphicsFunc.Instantiate(new Vertex(_x + i, _y));
                            newX = _x + i;
                        }
                    }
                }
                if(newPos.y > 0)
                {
                    for (int i = 1; i < newPos.y; i++)
                    {
                        if (position.x < Console.BufferWidth && position.y < Console.BufferHeight && position.x > 0 && position.y > 0)
                        {
                            GraphicsFunc.Instantiate(new Vertex(newX, _y + i));
                        }
                    }
                }
                if (newPos.y < 0)
                {
                    for (int i = 0; i > newPos.y - 1; i--)
                    {
                        if (position.x < Console.BufferWidth && position.y < Console.BufferHeight && position.x > 0 && position.y > 0)
                        {
                            if (_y - i > 0 && _y - i < Console.BufferHeight)
                            {
                                GraphicsFunc.Instantiate(new Vertex(_x, _y + i));
                                newY = _y + i;
                            }
                        }
                    }
                }

                if (newPos.x < 0)
                {
                    for (int i = 0; i > newPos.x - 1; i--)
                    {
                        if (position.x < Console.BufferWidth && position.y < Console.BufferHeight && position.x > 0 && position.y > 0)
                        {
                            if (_x - i > 0 && _x - i < Console.BufferWidth) 
                            {
                                GraphicsFunc.Instantiate(new Vertex(_x + i, newY));
                            }
                        }
                    }
                }

                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        /// <summary>
        /// Bound vertices between each other <br></br> by creating vertices between them<br></br> and instantiate those vertices <br></br> in a user-created pool.
        /// </summary>
        /// <param name="vertex"></param>
        /// <param name="pool"></param>
        public void BoundToPool(Vertex vertex, GraphicsFunc.Pool pool)
        {
            if (isActive)
            {
                int _x = position.x, _y = position.y;
                Vector2 newPos = vertex.position - position;
                //Console.ForegroundColor = ConsoleColor.Red;
                int newX = 0;
                int newY = 0;
                if(newPos.x > 0)
                {
                    for (int i = 1; i < newPos.x + 1; i++)
                    {
                        if (position.x < Console.BufferWidth && position.y < Console.BufferHeight && position.x > 0 && position.y > 0)
                        {
                            GraphicsFunc.InstantiateInPool(new Vertex(_x + i, _y), pool);
                            newX = _x + i;
                        }
                    }
                }
                if(newPos.y > 0)
                {
                    for (int i = 1; i < newPos.y; i++)
                    {
                        if (position.x < Console.BufferWidth && position.y < Console.BufferHeight && position.x > 0 && position.y > 0)
                        {
                            GraphicsFunc.InstantiateInPool(new Vertex(newX, _y + i), pool);
                        }
                    }
                }
                if (newPos.y < 0)
                {
                    for (int i = 0; i > newPos.y - 1; i--)
                    {
                        if (position.x < Console.BufferWidth && position.y < Console.BufferHeight && position.x > 0 && position.y > 0)
                        {
                            if (_y - i > 0 && _y - i < Console.BufferHeight)
                            {
                                GraphicsFunc.InstantiateInPool(new Vertex(_x, _y + i), pool);
                                newY = _y + i;
                            }
                        }
                    }
                }

                if (newPos.x < 0)
                {
                    for (int i = 0; i > newPos.x - 1; i--)
                    {
                        if (position.x < Console.BufferWidth && position.y < Console.BufferHeight && position.x > 0 && position.y > 0)
                        {
                            if (_x - i > 0 && _x - i < Console.BufferWidth) 
                            {
                                GraphicsFunc.InstantiateInPool(new Vertex(_x + i, newY), pool);
                            }
                        }
                    }
                }

                Console.ForegroundColor = ConsoleColor.White;
            }
        } 
        void Draw()
        {
            lastposition = position;
            Console.SetCursorPosition(position.x, position.y);
            Console.WriteLine(body);
        }
        void UpdateSingle()
        {
            Console.SetCursorPosition(lastposition.x, lastposition.y);
            Console.WriteLine(' ');
            Console.SetCursorPosition(position.x, position.y);
            Console.WriteLine(body);
        }
        /// <summary>
        /// Update the vertex on the screen (position, color, appearance, etc...).
        /// </summary>
        public void Update()
        {
            if (position.x < Console.BufferWidth && position.y < Console.BufferHeight && position.x > 0 && position.y > 0 && isActive)
            {
                Console.ForegroundColor = color;
                UpdateSingle();
                Draw();
                Console.ResetColor();
            }
        }
        /// <summary>
        /// Get the position of the vertex.
        /// </summary>
        /// <returns></returns>
        public Vector2? GetPosition()
        {
            if (isActive)
            {
                return position;
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// Set the position of the vertex.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Vector2? SetPosition(int x, int y)
        {
            if (isActive)
            {
                position.x = x;
                position.y = y;
                return position;
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// Change the position of the vertex by adding x and y coordinates to its position.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Vector2? Translate(int x, int y)
        {
            if (isActive)
            {
                position.x += x;
                position.y += y;
                return new Vector2(x, y);
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// Set the state of the vertex.
        /// </summary>
        /// <param name="value"></param>
        public void SetActive(bool value)
        {
            isActive = value;
        }
        private string CreateId()
        {
            string id = "#";
            id += random.Next(0, 999999999).ToString();
            return id;
        }
        public override string ToString()
        {
            return $"CGL.Vertex({position.ToString()}, id:{id})";
        }
    }

    namespace Shapes
    {
        class Rectangle
        {
            public List<Vertex> vertices = new List<Vertex>();
            public Vector2 position, size;
            public Rectangle(int x, int y, int width, int height)
            {
                position = new Vector2(x, y);
                size = new Vector2(width, height);
            }
            public Rectangle(Vector2 position, Vector2 size)
            {
                this.position = position;
                this.size = size;
            }
            public void Update()
            {
                for (int i = 0; i < vertices.Count; i++)
                {
                    for (int h = 0; h < size.x; h++)
                    {
                        vertices[i].position.x = position.x + h;
                    }
                    vertices[i].Update();
                }
            }
        }
    }

    namespace UI
    {
        /// <summary>
        /// An integrated console.
        /// </summary>
        static class CgConsole
        {
            static bool isActive = false;
            static List<string> messages = new List<string>();
            /// <summary>
            /// Set the console active on screen.
            /// </summary>
            public static void Show()
            {
                isActive = true;
                if (isActive)
                {
                    Console.SetCursorPosition(Console.BufferWidth - 35, 1);
                    Console.WriteLine("Console ready\n");
                    Console.SetCursorPosition(Console.BufferWidth - 35, 2);
                    Console.WriteLine("------------Initialized------------");
                }

            }
            /// <summary>
            /// Set the console non-active on screen.
            /// </summary>
            public static void Hide()
            {
                isActive = false;
                Console.Clear();
            }
            /// <summary>
            /// Clear console messages.
            /// </summary>
            public static void Clear()
            {
                messages.Clear();
            }
            /// <summary>
            /// Update the console's display
            /// </summary>
            public static void Update()
            {
                if(messages.Count > 20)
                {
                    messages.Clear();
                }
                for (int i = 0; i < messages.Count; i++)
                {
                    Console.SetCursorPosition(Console.BufferWidth - 35, i + 3);
                    Console.WriteLine(messages[i]);
                }
            }
            #region print functions
            /// <summary>
            /// Display a message to the console. 
            /// </summary>
            /// <param name="message"></param>
            public static void Print(string message)
            {
                if (isActive)
                {
                    messages.Add(message);
                    Update();
                }
            }
            /// <summary>
            /// Display a message to the console. 
            /// </summary>
            /// <param name="message"></param>
            public static void Print(int message)
            {
                if (isActive)
                {
                    messages.Add(message.ToString());
                    Update();
                }
            }
            /// <summary>
            /// Display a message to the console. 
            /// </summary>
            /// <param name="message"></param>
            public static void Print(double message)
            {
                if (isActive)
                {
                    messages.Add(message.ToString());
                    Update();
                }
            }
            /// <summary>
            /// Display a message to the console. 
            /// </summary>
            /// <param name="message"></param>
            public static void Print(float message)
            {
                if (isActive)
                {
                    messages.Add(message.ToString());
                    Update();
                }
            }
            /// <summary>
            /// Display an error message to the console. 
            /// </summary>
            /// <param name="message"></param>
            public static void PrintError(string message)
            {
                if (isActive)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    messages.Add(message);
                    Update();
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            /// <summary>
            /// Display an error message to the console. 
            /// </summary>
            /// <param name="message"></param>
            public static void PrintError(int message)
            {
                if (isActive)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    messages.Add(message.ToString());
                    Update();
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            /// <summary>
            /// Display an error message to the console. 
            /// </summary>
            /// <param name="message"></param>
            public static void PrintError(double message)
            {
                if (isActive)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    messages.Add(message.ToString());
                    Update();
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            /// <summary>
            /// Display an error message to the console. 
            /// </summary>
            /// <param name="message"></param>
            public static void PrintError(float message)
            {
                if (isActive)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    messages.Add(message.ToString());
                    Update();
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            #endregion
        }
    }
    /// <summary>
    /// Colors avaible in CGL.
    /// </summary>
    public static class CgColor
    {
        #region colors
        public static ConsoleColor White = ConsoleColor.White,
                                   Green = ConsoleColor.Green,
                                   Blue = ConsoleColor.Blue,
                                   Yellow = ConsoleColor.Yellow,
                                   Cyan = ConsoleColor.Cyan,
                                   Black = ConsoleColor.Black,
                                   Gray = ConsoleColor.Gray,
                                   Grey = ConsoleColor.Gray,
                                   Red = ConsoleColor.Red,
                                   Magenta = ConsoleColor.Magenta,
                                   DarkBlue = ConsoleColor.DarkBlue,
                                   DarkCyan = ConsoleColor.DarkCyan,
                                   DarkGray = ConsoleColor.DarkGray,
                                   DarkGrey = ConsoleColor.DarkGray,
                                   DarkMagenta = ConsoleColor.DarkMagenta,
                                   DarkGreen = ConsoleColor.DarkGreen,
                                   DarkRed = ConsoleColor.DarkRed,
                                   DarkYellow = ConsoleColor.DarkYellow;
        #endregion
    }
    /// <summary>
    /// Keyboard input class.
    /// </summary>
    public static class Input
    {
        static ConsoleKey Key;


        /// <summary>
        /// Must be part of an "if (IsKeyAvaible())" statement.<br></br>
        /// Get the current key pressed and compare it with the parameter.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool GetKey(ConsoleKey key)
        {
            Key = Console.ReadKey(true).Key;
            if (Key == key)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// Determine if a key is pressed by the user.<br></br>
        /// Its use is HIGHLY recommended.
        /// </summary>
        /// <returns></returns>
        public static bool IsKeyAvaible()
        {
            return Console.KeyAvailable;
        }
    }

    /// <summary>
    /// Basic functions of CGL.
    /// </summary>
    internal static class GraphicsFunc
    {
        /// <summary>
        /// The local pool is where [by default] every vertex is Instantiated.
        /// </summary>
        public static List<Vertex> localPool = new List<Vertex>();
        static List<List<Vertex>> GlobalPool = new List<List<Vertex>>();
        private static int name = 0;
        /// <summary>
        /// Pool object : allows the user to create customizable pool objects <br></br> 
        /// where vertices can be instantiated <br></br> as in the local pool.
        /// </summary>
        public class Pool
        {
            /// <summary>
            /// A list that contains every vertices of the pool.
            /// </summary>
            public List<Vertex> storage = new List<Vertex>(); 

            /// <summary>
            /// Shorthand to update every vertices of the pool.
            /// </summary>
            public void Update()
            {
                foreach (Vertex vertex in storage)
                {
                    vertex.Update();
                }
            }
        }
        /// <summary>
        /// Return a vertex found by its name located in a pool object.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pool"></param>
        /// <returns></returns>
        public static Vertex? FindByNameInPool(string name, Pool pool)
        {
            foreach (Vertex vertex in pool.storage)
            {
                if (vertex.name == name)
                {
                    return vertex;
                }
            }
            return null;
        }
        /// <summary>
        /// Return a vertex found by its id located in a pool object.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pool"></param>
        /// <returns></returns>
        public static Vertex? FindByIdInPool(string id, Pool pool)
        {
            foreach (Vertex vertex in pool.storage)
            {
                if (vertex.id == id)
                {
                    return vertex;
                }
            }
            return null;
        }
        /// <summary>
        /// Instantiate a new vertex in a pool objects.
        /// </summary>
        /// <param name="vertex"></param>
        /// <param name="pool"></param>
        /// <returns></returns>
        public static Vertex? InstantiateInPool(Vertex vertex, Pool pool)
        {
            if (pool.storage.Count < 5000)
            {
                vertex.name = name.ToString();
                pool.storage.Add(vertex);
                return vertex;
            }
            else
            {
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = CgColor.Red;
                CgConsole.PrintError("Pool Size Reached");
                Console.ForegroundColor = CgColor.White;
                return null;
            }
        }
        /// <summary>
        /// Instantiate a new vertex in the local pool.
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public static Vertex? Instantiate(Vertex vertex)
        {
            if(localPool.Count < 5000)
            {
                vertex.name = name.ToString();
                localPool.Add(vertex);
                name += 1;
                return vertex;
            }
            else
            {
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = CgColor.Red;
                CgConsole.PrintError("Pool Size Reached");
                Console.ForegroundColor = CgColor.White;
                return null;
            }
        }
        /// <summary>
        /// Destroy an objetct found by its name in the local pool.
        /// </summary>
        /// <param name="name"></param>
        public static void DestroyInLocalPool(string name)
        {
            foreach(Vertex v in localPool.ToList())
            {
                if (v.name == name)
                {
                    localPool.Remove(v);
                }
            }
        }
        /// <summary>
        /// Simply destroy a vertex.
        /// </summary>
        /// <param name="vertex"></param>
        public static void Destroy(Vertex vertex)
        {
            foreach(Vertex v in localPool.ToList())
            {
                if (v == vertex)
                {
                    localPool.Remove(v);
                }
            }
        }
        /// <summary>
        /// Shorthand to update every vertices in the local pool.
        /// </summary>
        public static void UpdatePool()
        {
            
            foreach (Vertex vertex in localPool)
            {
                vertex.Update();
            }
            
        }
        /// <summary>
        /// Return a vertex found by name in the local pool.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Vertex? FindByName(string name)
        {
            foreach (Vertex vertex in localPool)
            {
                if(vertex.name == name)
                {
                    return vertex;
                }
            }
            return null;
        }
        /// <summary>
        /// Return a vertex found by id in the local pool.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Vertex? FindById(string id)
        {
            foreach (Vertex vertex in localPool)
            {
                if(vertex.id == id)
                {
                    return vertex;
                }
            }
            return null;
        }
    }
    /// <summary>
    /// All the keys avaible in CGL.
    /// </summary>
    public static class KeyCode
    {
        public static ConsoleKey A = ConsoleKey.A,
                                 B = ConsoleKey.B,
                                 C = ConsoleKey.C,
                                 D = ConsoleKey.D,
                                 E = ConsoleKey.E,
                                 F = ConsoleKey.F,
                                 G = ConsoleKey.G,
                                 H = ConsoleKey.H,
                                 I = ConsoleKey.I,
                                 J = ConsoleKey.J,
                                 K = ConsoleKey.K,
                                 L = ConsoleKey.L,
                                 M = ConsoleKey.M,
                                 N = ConsoleKey.N,
                                 O = ConsoleKey.O,
                                 P = ConsoleKey.P,
                                 Q = ConsoleKey.Q,
                                 R = ConsoleKey.R,
                                 S = ConsoleKey.S,
                                 T = ConsoleKey.T,
                                 U = ConsoleKey.U,
                                 V = ConsoleKey.V,
                                 W = ConsoleKey.W,
                                 X = ConsoleKey.X,
                                 Y = ConsoleKey.Y,
                                 Z = ConsoleKey.Z,
                                 SPACE = ConsoleKey.Spacebar;

    }

    /// <summary>
    /// Window class.
    /// </summary>
    public static class Window
    {
        /// <summary>
        /// Initialize the window.
        /// </summary>
        public static void Init()
        {
            Console.CursorVisible = false;
        }
    }
}