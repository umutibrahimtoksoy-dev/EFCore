// See https://aka.ms/new-console-template for more information
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Persistence.Context;

Console.WriteLine("Hello, World!");

EfCoreDbContext efCoreDbContext = new();
Product product = new();

#region CRUD

#region Add 

if (false)
{
    efCoreDbContext.Products.Add(
    new Product()
    {
        Name = "FirstProduct",
        Price = 400,
        Quantity = 10
    });

    efCoreDbContext.Products.Add(
        new Product()
        {
            Name = "SecondProduct",
            Price = 500,
            Quantity = 15
        });

    await efCoreDbContext.SaveChangesAsync();
}

#endregion

#region Update

if (false)
{
    product = await efCoreDbContext.Products.FindAsync(6);

    if (product != null)
    {
        product.Price = 450;

        efCoreDbContext.Products.Update(product);

        await efCoreDbContext.SaveChangesAsync();
    }
}
#endregion

#region Delete

if (false)
{
    product = await efCoreDbContext.Products.FindAsync(2);

    if (product != null)
    {
        efCoreDbContext.Products.Remove(product);

        await efCoreDbContext.SaveChangesAsync();
    }
}
#endregion

#endregion

#region IQUERYABLE, IENUMERYABLE

if (false)
{
    // IQUERYABLE => Bir sorgunun execute edilmemiş, ön belleğe alınmamış halidir

    IQueryable<Product> query = efCoreDbContext.Products.Where(w => w.Price > 100 && w.Quantity > 0);

    // IENUMERYABLE => Bir sorgunun execute edilmiş, ön bellekte saklanan halidir

    List<Product> enumeryable = await query.ToListAsync();

    //Bir koleksiyonu,objeyi konsolda yazdırma

    string jsonSerializerForList = JsonConvert.SerializeObject(enumeryable);
    string jsonSerializerForObject = JsonConvert.SerializeObject(enumeryable.FirstOrDefault());

    Console.WriteLine(jsonSerializerForList);
    Console.WriteLine(jsonSerializerForObject);
}

#endregion

#region METHODS

#region First, FirstOrDefault, Last, LastOrDefault, Single, SingleOrDefault, Count, Max, Min, Any

if (true)
{
    //Product tablosunda şarta göre eşleşen kayıtlardan ilk kaydı getirir. Eğer kayıt yoksa exception fırlatır
    var usingFirstMethod = await efCoreDbContext.Products.FirstAsync(f => f.Price > 100);

    //Product tablosunda şarta göre eşleşen kayıtlardan ilk kaydı getirir. Eğer kayıt yoksa null döner
    var usingFirstOrDefaultMethod = await efCoreDbContext.Products.FirstOrDefaultAsync(f => f.Price > 100);

    //Product tablosunda şarta göre eşleşen kayıtlardan ilk kaydı getirir. Eğer kayıt yoksa exception fırlatır. Bu metod kullanılırken order by kullanılmalıdır.
    var usingLastMethod = await efCoreDbContext.Products.OrderBy(o => o.Id).LastAsync(f => f.Price > 100);

    //Product tablosunda şarta göre eşleşen kayıtlardan son kaydı getirir. Eğer kayıt yoksa null döner. Bu metod kullanılırken order by kullanılmalıdır.
    var usingLastOrDefaultMethod = await efCoreDbContext.Products.OrderBy(o => o.Id).LastOrDefaultAsync(f => f.Price > 100);

    //Product tablosunda şarta göre eşleşen kaydı getirir. Eğer birden fazla eşleşen kayıt varsa exception fırlatır.
    //var usingSingleMethod = await efCoreDbContext.Products.SingleAsync(f => f.Price > 100);

    //Product tablosunda şarta göre eşleşen kaydı getirir. Eğer birden fazla eşleşen kayıt varsa exception fırlatır. Ama eşleşen bir kayıt yoksa geriye null döner.
    var usingSingleOrDefaultMethodIsNull = await efCoreDbContext.Products.SingleOrDefaultAsync(f => f.Price < 100);
    //var usingSingleOrDefaultMethodException = await efCoreDbContext.Products.SingleOrDefaultAsync(f => f.Price > 100);

    //Count
    int countOfProduct = await efCoreDbContext.Products.CountAsync();

    //LongCount
    float longCountOfProduct = await efCoreDbContext.Products.LongCountAsync();

    //Max
    float max = await efCoreDbContext.Products.MaxAsync(m => m.Price);

    //Min
    float min = await efCoreDbContext.Products.MinAsync(m => m.Price);

    //Any
    bool any = await efCoreDbContext.Products.AnyAsync(a => a.Name.Contains("Product"));


}

#endregion

#endregion















Console.ReadLine();










