using System;

class Order
{
    private int orderNo;
    private int itemType;
    private int quantity;
    private double bill;

    public Order(int no, int item, int qty)
    {
        orderNo = no;
        itemType = item;
        quantity = qty;
    }

    public double pay_bill()
    {
        double price = 0;

        if (itemType == 1 || itemType == 2)
        {
            price = 6;
        }
        else if (itemType == 3 || itemType == 4)
        {
            price = 8;
        }

        bill = price * quantity;

        return bill;
    }

    public int getOrderNo()
    {
        return orderNo;
    }
}