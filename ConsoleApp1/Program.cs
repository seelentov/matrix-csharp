internal class Program
{
    private static void Main(string[] args)
    {
        Matrix<string> matrix = new(5, 5);
        matrix.Set(new Point(3,1), "top2");
        matrix.Set(new Point(3,2), "top1");
        matrix.Set(new Point(3,4), "bot1");
        matrix.Set(new Point(3,5), "bot2");
        matrix.Set(new Point(1,3), "left2");
        matrix.Set(new Point(2, 3), "left1");
        matrix.Set(new Point(4, 3), "right1");
        matrix.Set(new Point(6, 6), "right2");
        matrix.PrintMatrix();
    }
}