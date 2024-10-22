using System;

namespace Solucao.Models; 

public class RoomModel
{


    public int RoomID { get; set; }
    public string? Desc { get; set; }
    public string? Price { get; set; }
    public bool Availability { get; set; }

    public RoomModel(int roomID, string? desc, string? price, bool availability)
    {
        RoomID = roomID;
        Desc = desc;
        Price = price;
        Availability = availability;
    }

    public RoomModel() {}

    public override string ToString()
    {
        return $"[{RoomID}, {Desc}, {Price}]";
    }

    public override bool Equals(object? obj)
    {
        return obj is RoomModel model &&
               RoomID == model.RoomID &&
               Desc == model.Desc &&
               Price == model.Price &&
               Availability == model.Availability;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(RoomID, Desc, Price, Availability);
    }
}
