using System.Collections;

namespace Shared.Models;

public class Bills
{
    private List<Bill> bills = new List<Bill>();


    public List<Bill> getBills()
    {
        return bills;
    }
}