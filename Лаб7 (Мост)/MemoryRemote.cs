﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб7__Мост_
{
   public  class MemoryRemote : Remote
    {
        private Dictionary<int, (int Power, int Mode)>  dictionary = new Dictionary<int, (int Power, int Mode)>();

        public MemoryRemote(IImplementor implementor) : base(implementor) { ArgumentNullException.ThrowIfNull(implementor); }

        public void Save(int index)
        {
            ArgumentNullException.ThrowIfNull(index);
            dictionary[index] = (power, mode);
            Console.WriteLine("Сохраненный режим {0}: Мощность {1}, Режим {2}", index,power,mode);
        }

        public void Load(int index)
        {
            ArgumentNullException.ThrowIfNull(index);
            if (dictionary.ContainsKey(index))
            {
                var d = dictionary[index];
                int savedPower = d.Power;
                int savedMode = d.Mode;

                power = savedPower;
                mode = savedMode;
                implementor.SetPower(power);
                implementor.SetMode(mode);
                Console.WriteLine("Загруженный режим {0}: Мощность {1}, Режим {2}", index, power,mode);
            }
            else
            {
                Console.WriteLine("Режим с индексом {0} не найден.", index);
            }
        }

    }

}
