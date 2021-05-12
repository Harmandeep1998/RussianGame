using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianGame
{
    public class Revolver
    {
        private bool[] bullets;
        public Revolver()
        {
            bullets = new bool[6];
        }

        public void LoadBullet()
        {
            bullets[0] = true;
        }

        public void Spin()
        {
            int times = new Random().Next() % 6;
            while( times > 0 )
            {
                bool bullet = bullets[bullets.Length - 1];
                for (int index = 0; index < bullets.Length - 1; index++)
                {
                    bullets[index+1] = bullets[index];
                }
                bullets[0] = bullet;
                times--;
            }
        }

        public bool Fire(int index)
        {
            return bullets[index];
        }
    }
}
