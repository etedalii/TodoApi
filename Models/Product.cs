using System;

namespace TodoApi.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public DateTime ExpireDate { get; set; }

    public int Inventory { get; set; }
    
}
