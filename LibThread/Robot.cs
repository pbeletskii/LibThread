namespace LibThread
{
    public class Robot
    {
        public Robot()
        {
            new Thread(Move).Start();
        }
        public Robot(int i)
        {
            Name+=i;
            Thread.Sleep(50);
            new Thread(Move).Start();
        }
        protected (int x, int y) position = (0, 0);
        protected string Name { get; set; } = "Робот";
        public void Move()
        {

            Random randomMove = new Random();
            string moveInfo;
            for (int i = 0; i < 3; i++)
            {
                switch (randomMove.Next(3))
                {
                    case 0:
                        position.y++;
                        moveInfo = "Вперед";
                        GetInfo(position, moveInfo);
                        break;
                    case 1:
                        position.y--;
                        moveInfo = "Назад";
                        GetInfo(position, moveInfo);
                        break;
                    case 2:
                        position.x++;
                        moveInfo = "Направо";
                        GetInfo(position, moveInfo);
                        break;
                    case 3:
                        position.x--;
                        moveInfo = "Налево";
                        GetInfo(position, moveInfo);
                        break;
                    default:
                        break;
                }
                Thread.Sleep(200);
            }
        }
        public void GetInfo((int, int) position, string moveInfo)
        {
            Console.WriteLine($"Имя: {Name} Движение: {moveInfo} Позиция: {position} ПотокID: {Thread.CurrentThread.ManagedThreadId}\n");
        }
    }
}