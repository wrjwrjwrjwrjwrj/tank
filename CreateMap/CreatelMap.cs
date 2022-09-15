using 坦克大战升级版;

namespace CreateMap
{
    public static class CreatelMap
    {
        private static void CreateWall(int x,int y,int count)
        {
            int xPosition = x * 50;
            int yPosition = y * 50;
            for (int i = yPosition; i < yPosition+count*30; i+=15)
            {
                SingleObject.GetSingle().AddGameObject(new Wall(xPosition,yPosition));
            }
        }
        public static void InitialMap()
        {
            CreateWall(1, 1, 5);
        }
    }
}