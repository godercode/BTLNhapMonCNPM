using BTLNhapMonCNPM.Models;

namespace BTLNhapMonCNPM.Repositories
{
    public class IBeverageRepositorys
    {
        public interface IBeverageRepository
        {
            IEnumerable<Beverage> GetAll();
            Beverage GetById(int id);
            void Add(Beverage beverage);
            void Update(Beverage beverage);
            void Delete(int id);
        }

        public class BeverageRepository : IBeverageRepository
        {
            private static List<Beverage> beverages = new List<Beverage>
    {
        new Beverage { Id = 1, Name = "Cà phê", Image = "https://hapotravel.com/wp-content/uploads/2023/03/chon-loc-25-hinh-nen-one-piece-tuyet-dep-cho-may-tinh-va-dien-thoai_1.jpg", Description = "Cà phê sữa đá", Price = 25000 },
        new Beverage { Id = 2, Name = "Cà phê", Image = "https://hapotravel.com/wp-content/uploads/2023/03/chon-loc-25-hinh-nen-one-piece-tuyet-dep-cho-may-tinh-va-dien-thoai_1.jpg", Description = "Cà phê đen đá", Price = 30000 },
        new Beverage { Id = 3, Name = "Cà phê", Image = "https://hapotravel.com/wp-content/uploads/2023/03/chon-loc-25-hinh-nen-one-piece-tuyet-dep-cho-may-tinh-va-dien-thoai_1.jpg", Description = "Bạc xỉu", Price = 25000 },
        new Beverage { Id = 4, Name = "Trà sữa", Image = "https://hapotravel.com/wp-content/uploads/2023/03/chon-loc-25-hinh-nen-one-piece-tuyet-dep-cho-may-tinh-va-dien-thoai_1.jpg", Description = "Trà sữa trân châu", Price = 30000 },
        new Beverage { Id = 5, Name = "Trà sữa", Image = "https://hapotravel.com/wp-content/uploads/2023/03/chon-loc-25-hinh-nen-one-piece-tuyet-dep-cho-may-tinh-va-dien-thoai_1.jpg", Description = "Trà sữa hoa nhài", Price = 25000 },
        new Beverage { Id = 6, Name = "Trà sữa", Image = "https://hapotravel.com/wp-content/uploads/2023/03/chon-loc-25-hinh-nen-one-piece-tuyet-dep-cho-may-tinh-va-dien-thoai_1.jpg", Description = "Trà sữa lúa mạch", Price = 30000 },
        new Beverage { Id = 7, Name = "Trà", Image = "https://hapotravel.com/wp-content/uploads/2023/03/chon-loc-25-hinh-nen-one-piece-tuyet-dep-cho-may-tinh-va-dien-thoai_1.jpg", Description = "Trà đào cam xả", Price = 25000 },
        new Beverage { Id = 8, Name = "Trà", Image = "https://hapotravel.com/wp-content/uploads/2023/03/chon-loc-25-hinh-nen-one-piece-tuyet-dep-cho-may-tinh-va-dien-thoai_1.jpg", Description = "Trà ô long", Price = 30000 },
        new Beverage { Id = 7, Name = "Trà", Image = "https://hapotravel.com/wp-content/uploads/2023/03/chon-loc-25-hinh-nen-one-piece-tuyet-dep-cho-may-tinh-va-dien-thoai_1.jpg", Description = "Trà nhiệt đới", Price = 25000 }
    };

            public IEnumerable<Beverage> GetAll()
            {
                return beverages;
            }

            public Beverage GetById(int id)
            {
                return beverages.FirstOrDefault(b => b.Id == id);
            }

            public void Add(Beverage beverage)
            {
                beverage.Id = beverages.Max(b => b.Id) + 1;
                beverages.Add(beverage);
            }

            public void Update(Beverage beverage)
            {
                var existingBeverage = GetById(beverage.Id);
                if (existingBeverage != null)
                {
                    existingBeverage.Name = beverage.Name;
                    existingBeverage.Image = beverage.Image;
                    existingBeverage.Description = beverage.Description;
                    existingBeverage.Price = beverage.Price;
                }
            }

            public void Delete(int id)
            {
                var beverage = GetById(id);
                if (beverage != null)
                {
                    beverages.Remove(beverage);
                }
            }
        }
    }
}
