namespace Shared.Models;

public class Bill
{
    public int id { get; set; }
    public int clientid { get; set; }
    public DateTime billingdate { get; set; }
    public DateTime duedate { get; set; }
    public double total { get; set; }
    public double priceperitem { get; set; }
    public double amount { get; set; }
    public string provider { get; set; }
    public bool payedstatus { get; set; }
    
    
    public Bill(int id, int userid, DateTime billingdate, DateTime duedate, double amount, double total, double priceperitem,
        string company, bool payedstatus)
    {
        this.id = id;
        clientid = userid;
        this.billingdate = billingdate;
        this.duedate = duedate;
        this.total = total;
        this.priceperitem = priceperitem;
        this.provider = company;
        this.payedstatus = payedstatus;
        this.amount = amount;
    }

    public override string ToString()
    {
        return id + ", " + clientid + ", " + billingdate + ", " + duedate + ", " + total + ", " + priceperitem + ", " +
               provider + ", " + payedstatus;
    }
}