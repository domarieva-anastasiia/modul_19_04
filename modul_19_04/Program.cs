internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }


//Task 1 Ваша програма повинна містити наступні елементи:
//Створення інтерфейсу IOrder, який містить методи для додавання товарів, видалення товарів та отримання загальної вартості замовлення.
//Створення класу Order, який реалізує інтерфейс IOrder та містить методи для роботи з замовленнями.
//Побудова ієрархії класів для товарів: базовий клас Product, який містить загальні властивості, та похідні класи, наприклад, FoodProduct, ElectronicProduct тощо.
//Використання конструкторів для ініціалізації об'єктів класів та деструкторів для звільнення ресурсів.
//Визначення події для сповіщення про зміну статусу замовлення та організація взаємодії об'єктів через цю подію.
//Реалізація узагальненого класу для зберігання списку товарів у замовленні.
//Створення класів винятків для обробки помилок під час роботи з замовленнями.


    interface IOrder
    {
        public void AddProduct();
        public void DeleteProduct();
        public void CountCost();
    }


    class Order : List<T> where T : Product, FoodProduct, ElectronicProduct, IOrder
    {
        public List<T> products;
        private string _status;

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public Order()
        {
            products = new List<T>();
            Status = "empty";
        }
        public Order(List<T> products, string status)
        {
            this.products = products;
            Status = status;
        }

        public void AddProduct(T new_product)
        {
            products.Add(new_product);
        }
        
        public void DeleteProduct(T new_product)
        {
            products.Remove(new_product);
        }
        
        public double CountCost()
        {
            double cost = 0;
            foreach(var product in products)
            {
                cost += product.Price();
            }
            return cost;
        }
    }

    class Product
    {
        private int _id;
        private string _name;
        private double _price;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public Product()
        {
            _id = 0;
            _name = "";
            _price = 0.0;
        }
        public Product(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
        public override string ToString()
        {
            return $"ID [{Id}], product name: {Name}, price: {Price};";
        }
    }

    class FoodProduct : Product
    {
        private string _type;
        private string _expiration_date;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string ExpirationDate
        {
            get { return _expiration_date; }
            set { _expiration_date = value; }
        }

        public FoodProduct() : base()
        {
            Type = "no type";
            ExpirationDate = "0.0.00";
        }
        public FoodProduct(int id, string name, double price, string type, string expiration_date) : base(id, name, price)
        {
            Type = type;
            ExpirationDate = expiration_date;

        }
        public override string ToString()
        {
            return $"ID [{Id}], product name: {Name}, price: {Price}, type - {Type}, expiration date: {ExpirationDate};";
        }

    }
     class ElectronicProduct : Product
    {
        private string _type;
        private int _power;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public int Power
        {
            get { return _power; }
            set { _power = value; }
        }
        public ElectronicProduct() : base()
        {
            Type = "no type";
            Power = 0;
        }
        public ElectronicProduct(int id, string name, double price, string type, int power) : base(id, name, price)
        {
            Type = type;
            Power = power;
        }
        public override string ToString()
        {
            return $"ID [{Id}], product name: {Name}, price: {Price}, type - {Type}, power: {Power}W;";
        }
    }

    
}