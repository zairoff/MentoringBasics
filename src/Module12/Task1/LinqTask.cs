using System;
using System.Collections.Generic;
using System.Linq;
using Task1.DoNotChange;

namespace Task1
{
    public static class LinqTask
    {
        public static IEnumerable<Customer> Linq1(IEnumerable<Customer> customers, decimal limit)
        {
            if (customers == null)
                throw new ArgumentNullException();

            return customers.Where(customer => customer.Orders.Sum(order => order.Total) > limit);
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            if (customers == null || suppliers == null)
                throw new ArgumentNullException();

            return customers.Select(customer =>
                                    (customer, suppliers.Where(supplier =>
                                                supplier.Country.Equals(customer.Country)
                                                && supplier.City.Equals(customer.City))));
            

        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2UsingGroup(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            if (customers == null || suppliers == null)
                throw new ArgumentNullException();

            //var result = customers.GroupBy(customer => new { customer.City, customer.Country })
            //                    .Select(group => group.Select(customer =>
            //                            (customer, suppliers.Where(supplier => 
            //                                    supplier.City.Equals(customer.City) &&
            //                                    supplier.Country.Equals(customer.Country)))));

            var result = customers.GroupBy(customer => new { customer.City, customer.Country })
                                    .Select(group => (group.Select(g => g),
                                    suppliers.Where(supplier => supplier.Country.Equals(group.Key.Country)
                                    && supplier.City.Equals(group.Key.City))));

            return null;                         
                                    
        }

        public static IEnumerable<Customer> Linq3(IEnumerable<Customer> customers, decimal limit)
        {
            if (customers == null)
                throw new ArgumentNullException();

            return customers.Where(customer => customer.Orders.Any(order => order.Total > limit));
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq4(
            IEnumerable<Customer> customers
        )
        {
            if (customers == null)
                throw new ArgumentNullException();

            return customers.Where(customer => customer.Orders.Count() > 0)
                            .Select(customer => (customer, customer.Orders
                            .Min(order => order.OrderDate)));
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq5(
            IEnumerable<Customer> customers
        )
        {
            if (customers == null)
                throw new ArgumentNullException();

            return customers.Where(customer => customer.Orders.Count() > 0)
                            .Select(customer => (customer, customer.Orders
                            .Min(order => order.OrderDate))).OrderBy(order => order.Item2);
        }

        public static IEnumerable<Customer> Linq6(IEnumerable<Customer> customers)
        {
            if (customers == null)
                throw new ArgumentNullException();

            var result = customers.Where(customer =>
                            !customer.Phone.Contains("(") ||
                            string.IsNullOrEmpty(customer.Region) ||
                            !customer.PostalCode.All(char.IsDigit));

            return result;
        }

        public static IEnumerable<Linq7CategoryGroup> Linq7(IEnumerable<Product> products)
        {
            /* example of Linq7result

             category - Beverages
	            UnitsInStock - 39
		            price - 18.0000
		            price - 19.0000
	            UnitsInStock - 17
		            price - 18.0000
		            price - 19.0000
             */

            //var result = products.GroupBy(product => product.Category)
            //                        .Select(group => (group.Key, group
            //                        .GroupBy(product => product.UnitsInStock)
            //                        .Select(unit => (unit.Key, unit
            //                        .Select(price => price.UnitPrice)))));

            var result = products.GroupBy(product => product.Category)
                                    .Select(group => new Linq7CategoryGroup
                                    {
                                        Category = group.Key,
                                        UnitsInStockGroup = group.GroupBy(product => product.UnitsInStock)
                                        .Select(group => new Linq7UnitsInStockGroup
                                        {
                                            UnitsInStock = group.Key,
                                            Prices = group.Select(product => product.UnitPrice)
                                        })
                                    });

            return result;
        }

        public static IEnumerable<(decimal category, IEnumerable<Product> products)> Linq8(
            IEnumerable<Product> products,
            decimal cheap,
            decimal middle,
            decimal expensive
        )
        {
            if (products == null)
                throw new ArgumentNullException();

            var result = products.GroupBy(b => b.UnitPrice <= cheap ? cheap :
                    (b.UnitPrice > cheap && b.UnitPrice <= middle ? middle : expensive)).Select(group => (group.Key, group.ToList().AsEnumerable()));

            return result;
        }

        public static IEnumerable<(string city, int averageIncome, int averageIntensity)> Linq9(
            IEnumerable<Customer> customers
        )
        {
            //var result = customers.GroupBy(customer => customer.City)
            //                        .Select(group => new
            //                        {
            //                            City = group.Key,
            //                            AverageIncome = group.Sum(g => g.Orders.Sum(o => o.Total)) / group.Count(),
            //                            AverageIntensity = group.Sum(o => o.Orders.Count()) / group.Count()
            //                        });

            var result = customers.GroupBy(customer => customer.City)
                                    .Select(group => (group.Key,
                                                    group.Sum(g => g.Orders.Sum(o => o.Total)) / group.Count(),
                                                    group.Sum(o => o.Orders.Count()) / group.Count()));

            return null;
        }

        public static string Linq10(IEnumerable<Supplier> suppliers)
        {
            throw new NotImplementedException();
        }
    }
}