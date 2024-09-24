class Food
{
    private Random random = new Random();
    public Point Position { get; private set; }

    private int screenWidth;
    private int screenHeight;

    public Food(int screenWidth, int screenHeight)
    {
        this.screenWidth = screenWidth;
        this.screenHeight = screenHeight;
    }

    public void Spawn(List<Point> snakeBody)
    {
        do
        {
            Position = new Point(random.Next(0, screenWidth), random.Next(0, screenHeight));
        } while (snakeBody.Contains(Position));
    }
}