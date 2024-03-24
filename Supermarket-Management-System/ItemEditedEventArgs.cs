using System;

public class ItemEditedEventArgs : EventArgs
{
    public string Barcode { get; }
    public string ItemName { get; }
    public int Quantity { get; }
    public decimal Price { get; }

    // Constructor to initialize the properties
    public ItemEditedEventArgs(string barcode, string itemName, int quantity, decimal price)
    {
        Barcode = barcode;
        ItemName = itemName;
        Quantity = quantity;
        Price = price;
    }
}
