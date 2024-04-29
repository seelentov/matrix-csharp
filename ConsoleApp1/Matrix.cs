public class Matrix<T>
{
    public readonly T[,] map;
    public readonly int width;
    public readonly int height;

    public Matrix(int width, int height)
    {
        this.width = width;
        this.height = height;

        map = new T[height, width];
    }

    private bool IsRowExist(int row)
    {
        return row <= this.width && row > 0;
    }
    private bool IsColExist(int col)
    {
        return col <= this.height && col > 0;
    }

    private bool IsPointExist(Point point)
    {
        return this.IsRowExist(point.x) && this.IsColExist(point.y);
    }

    public void PrintMatrix()
    {
        for (int i = 0; i < this.height; i++)
        {
            for (int j = 0; j < this.width; j++)
            {
                Console.Write($"{this.map[i, j]} ");
            }
            Console.Write("\n");
        }
    }

    public void Fill(T data)
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                map[i, j] = data;
            }
        }
    }

    public void Set(Point point, T data)
    {
        if (this.IsPointExist(point))
        {
            this.map[point.y - 1, point.x - 1] = data;
        }

    }

    public T? Get(Point point)
    {
        if (!this.IsPointExist(point)) return default(T);

        return this.map[point.y - 1, point.x - 1];
    }

    public T[]? GetRow(int row)
    {
        T[] result = new T[this.width];

        for (int i = 0; i < this.width; i++)
        {
            result[i] = this.map[row - 1, i];
        }

        return result;
    }

    public T[]? GetCol(int col)
    {
        T[] result = new T[this.width];

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                result[i] = this.map[i, col - 1];    
            }
        }
        return result;
    }

    public T[]? GetDirection(Point point, Direction direction)
    {
        if (direction == Direction.up || direction == Direction.down)
        {
            T[] col = this.GetCol(point.y);

            if (direction == Direction.up)
            {
                return col[0..(int)(point.y - 1)].Reverse().ToArray();
            }
            else
            {
                return col[(int)(point.y)..col.Length];
            }
        }
        else
        {
            T[] row = this.GetRow(point.x);

            if (direction == Direction.left)
            {
                return row[0..(int)(point.x - 1)].Reverse().ToArray();
            }
            else
            {
                return row[(int)(point.x)..row.Length];
            }
        }
    }

}