using System.ComponentModel;
namespace HW17
{
    internal class Program
    {
        static async Task Main(string[] args)
        {            
            var dapperProductsRepository = new DapperProductsRepository();

            #region Таблица products
            string commandText = "SELECT * FROM products";

            // Выборка 1
            var products = await dapperProductsRepository.GetAllProductsAsync(commandText);
            Console.WriteLine("Таблица products. Выборка 1");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.id} | {product.name} | {product.description} | {product.stockQuantity} | {product.price}");
            }
            Console.WriteLine("-----------------------------------------\n");

            // Выборка 2
            commandText =
                $"SELECT id, name, price " +
                $"FROM products " +
                $"WHERE price < @p";
            products = await dapperProductsRepository.GetProductsWhereAsync(commandText, 300);
            Console.WriteLine("Таблица products. Выборка 2");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.id} | {product.name} | {product.price}");
            }
            Console.WriteLine("-----------------------------------------\n\n\n");
            #endregion



            #region Таблица customers
            var dapperCustomersRepository = new DapperCustomersRepository();

            // Выборка 1
            commandText = $"SELECT * FROM customers";
            var customers = await dapperCustomersRepository.GetAllCustomersAsync(commandText);
            Console.WriteLine("Таблица customers. Выборка 1");
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.id} | {customer.firstName} | {customer.lastName} | {customer.age}");
            }
            Console.WriteLine("-----------------------------------------\n");

            // Выборка 2
            commandText =
                $"SELECT id, firstname, age " +
                $"FROM customers " +
                $"WHERE age >= @a AND age <= @b " +
                $"ORDER BY @age ASC";
            customers = await dapperCustomersRepository.GetCustomersWhereAsync(commandText, 35, 40);
            Console.WriteLine("Таблица customers. Выборка 2");
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.id} | {customer.firstName} | {customer.age}");
            }
            Console.WriteLine("-----------------------------------------\n\n\n");
            #endregion



            #region Таблица orders
            var dapperOrdersRepository = new DapperOrdersRepository();

            // Выборка 1
            commandText = $"SELECT * FROM orders";
            var orders = await dapperOrdersRepository.GetAllOrdersAsync(commandText);
            Console.WriteLine("Таблица orders. Выборка 1");
            foreach (var order in orders)
            {
                Console.WriteLine($"{order.id} | {order.customerId} | {order.productId} | {order.quantity}");
            }
            Console.WriteLine("-----------------------------------------\n");

            // Выборка 2
            commandText =
                $"SELECT * " +
                $"FROM orders " +
                $"WHERE customerid in (@c1, @c2, @c3) AND productid < @p1";
            orders = await dapperOrdersRepository.GetOrdersWhereAsync(commandText, 1, 3, 5, 2);
            Console.WriteLine("Таблица orders. Выборка 2");
            foreach (var order in orders)
            {
                Console.WriteLine($"{order.id} | {order.customerId} | {order.productId} | {order.quantity}");
            }
            Console.WriteLine("-----------------------------------------\n\n\n"); 
            #endregion
        }
    }
}
