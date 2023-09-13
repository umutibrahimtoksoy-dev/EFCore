// See https://aka.ms/new-console-template for more information
using Domain.Models;
using Persistence.Context;

Console.WriteLine("Hello, World!");


EfCoreDbContext efCoreDbContext = new();

#region Add 

//efCoreDbContext.Products.Add(
//    new Product()
//    {
//        Name = "FirstProduct",
//        Price = 400,
//        Quantity = 10
//    });

//efCoreDbContext.Products.Add(
//    new Product()
//    {
//        Name = "SecondProduct",
//        Price = 500,
//        Quantity = 15
//    });

//await efCoreDbContext.SaveChangesAsync();

#endregion

#region Update

//var product = await efCoreDbContext.Products.FindAsync(1);

//if (product != null)
//{
//    product.Price = 450;

//    efCoreDbContext.Products.Update(product);

//    await efCoreDbContext.SaveChangesAsync();
//}


#endregion

#region Delete

//var product = await efCoreDbContext.Products.FindAsync(2);

//if (product != null)
//{
//    efCoreDbContext.Products.Remove(product);

//    await efCoreDbContext.SaveChangesAsync();
//}

#endregion




Console.ReadLine();










