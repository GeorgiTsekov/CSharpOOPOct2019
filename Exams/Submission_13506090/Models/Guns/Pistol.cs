namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int BulletsPerBarrelConst = 10;
        private const int TotalBulletsConst = 100;
        private const int ShootedBulletsConst = 1;

        public Pistol(string name) 
            : base(name, BulletsPerBarrelConst, TotalBulletsConst)
        {
        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel <= 0 && this.TotalBullets > BulletsPerBarrelConst)
            {
                this.BulletsPerBarrel = BulletsPerBarrelConst;
                this.TotalBullets -= BulletsPerBarrelConst;
            }
            else if (this.BulletsPerBarrel <= 0 && this.TotalBullets <= BulletsPerBarrelConst && this.TotalBullets > 0)
            {
                if (this.TotalBullets - ShootedBulletsConst >= 0)
                {
                    this.TotalBullets -= ShootedBulletsConst;
                }

                return ShootedBulletsConst;
            }

            if (this.BulletsPerBarrel - ShootedBulletsConst >= 0)
            {
                this.BulletsPerBarrel -= ShootedBulletsConst;
            }

            return ShootedBulletsConst;
        }
    }
}
