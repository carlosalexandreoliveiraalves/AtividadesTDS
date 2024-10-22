using System;

namespace Solucao.Models; 

public class ReserveModel
{
    public int ReserveID { get; set; }
    public DateTime DateCheckIn { get; set; }
    public DateTime DateCheckOut { get; set; }


    public ReserveModel(int reserveID, DateTime dateCheckIn, DateTime dateCheckOut)
    {
        ReserveID = reserveID;
        DateCheckIn = dateCheckIn;
        DateCheckOut = dateCheckOut;
    }

    public ReserveModel() {}
    public override string ToString()
    {
        return $"[{ReserveID}, {DateCheckIn}, {DateCheckOut}]";
    }

    public override bool Equals(object? obj)
    {
        return obj is ReserveModel model &&
               ReserveID == model.ReserveID &&
               DateCheckIn == model.DateCheckIn &&
               DateCheckOut == model.DateCheckOut;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ReserveID, DateCheckIn, DateCheckOut);
    }

}
