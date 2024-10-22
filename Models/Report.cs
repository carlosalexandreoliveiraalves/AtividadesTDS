using System;

namespace Solucao.Models; 

public class ReportModel
{
    //Deve ser colocado a data
    public int ReportID { get; set; } 
    public int TotalRoom { get; set; }
    public int TotalReserve { get; set; }
    public decimal Profit { get; set; }

    public ReportModel(int reportID, int totalRoom, int totalReserve, decimal profit)
    {
        ReportID = reportID;
        TotalRoom = totalRoom;
        TotalReserve = totalReserve;
        Profit = profit;
    }

    //public ReportModel() {}
    public override string ToString() {
        return $"[{ReportID}, {TotalRoom}, {TotalReserve}, {Profit}]";
    }

  
    public override bool Equals(object? obj)
    {
        return obj is ReportModel model &&
               ReportID == model.ReportID &&
               TotalRoom == model.TotalRoom &&
               TotalReserve == model.TotalReserve &&
               Profit == model.Profit;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ReportID, TotalRoom, TotalReserve, Profit);
    }
}
