namespace ViceCity.Models.Players
{
    public class MainPlayer : Player
    {
        private const int LifePointsConst = 100;
        private const string NameConst = "Tommy Vercetti";       

        public MainPlayer() 
            : base(NameConst, LifePointsConst)
        {
        }
    }
}
