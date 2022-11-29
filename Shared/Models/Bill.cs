namespace Shared.Models;

public class Bill
{
    public int id { get; set; }
    public int userid { get; set; }
    public DateTime billingdate { get; set; }
    public DateTime duedate { get; set; }
    public double total { get; set; }
    public double priceperitem { get; set; }
    public string company { get; set; }
    public bool payedstatus { get; set; }
    
    
    public Bill(int id, int userid, DateTime billingdate, DateTime duedate, double total, double priceperitem,
        string company, bool payedstatus)
    {
        this.id = id;
        this.userid = userid;
        this.billingdate = billingdate;
        this.duedate = duedate;
        this.total = total;
        this.priceperitem = priceperitem;
        this.company = company;
        this.payedstatus = payedstatus;
    }

    public override string ToString()
    {
        return id + ", " + userid + ", " + billingdate + ", " + duedate + ", " + total + ", " + priceperitem + ", " +
               company + ", " + payedstatus;
    }
}