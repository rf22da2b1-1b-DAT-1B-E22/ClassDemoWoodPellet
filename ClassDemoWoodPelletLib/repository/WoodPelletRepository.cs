using ClassDemoWoodPelletLib.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoWoodPelletLib.repository
{
    public class WoodPelletRepository
    {
        private readonly List<WoodPellet> _data = new List<WoodPellet>();
        private int nextId = 1;

        public WoodPelletRepository(bool mockData = false)
        {
            if (mockData)
            {
                Populate();
            }
        }

        public List<WoodPellet> GetAll()
        {
            return new List<WoodPellet>(_data);
        }

        public WoodPellet GetById(int id)
        {
            WoodPellet? woodPellet = _data.Find(wp => wp.Id == id);
            if (woodPellet is null)
            {
                throw new KeyNotFoundException();
            }

            return woodPellet;
        }

        public void Add(WoodPellet pellet)
        {
            pellet.Id = nextId++;
            if (!pellet.Validate())
            {
                throw new ArgumentException();
            }
            _data.Add(pellet);
        }

        public void Update(int id, WoodPellet pellet)
        {
            WoodPellet woodPellet = GetById(id);

            if (!pellet.Validate())
            {
                throw new ArgumentException();
            }
            int index = _data.IndexOf(woodPellet);
            _data[index] = pellet;
        }



        protected void Populate()
        {
            _data.Clear();
            _data.Add(new WoodPellet(1, "BigWood", 4995, 4));
            _data.Add(new WoodPellet(2, "BigWood", 5195, 4));
            _data.Add(new WoodPellet(3, "CheapPellets", 4125, 1));
            _data.Add(new WoodPellet(4, "GoldenWoodPellets", 5995, 5));
            _data.Add(new WoodPellet(5, "GoldenWoodPellets", 5795, 5));

            nextId = 6;
        }
        
    }
}
