using System;
using System.Collections.Generic;
using System.Security.Principal;

class Order
{
  private Customer _customer;
  private List<Product> _products;

  public Order(Customer customer)
  {
    _customer = customer;
    _products = new List<Product>();
  }

  public void AddProduct(Product product)
  {
    _products.Add(product);
  }

  public double CalculateTotalCost()
  {
    double total = 0;
    foreach (Product product in _products)
    {
      total += product.GetTotalCost();
    }
    double shippingCost = _customer.LivesInUSA() ? 5.0 : 35.0;
    return total + shippingCost;
  }

  public string GetPackingLabel()
  {
    string packingLabel = "Packing Label:\n";
    foreach (Product product in _products)
    {
      packingLabel += $"- {product.GetName()} (ID: {product.GetProductId()})\n";
    }
    return packingLabel;
  }

  public string GetShippingLabel()
  {
    string customerName = _customer.GetName();
    string customerAddress = _customer.GetAddress().GetFormattedAddress();
    return $"Shipping Label:\n{customerName}\n{customerAddress}";
  }
}