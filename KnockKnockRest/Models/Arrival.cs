﻿using System.Globalization;

namespace KnockKnockRest.Models
{
    public class Arrival
    {
        public int Id { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int? QrCode { get; set; }
        public string? Name { get; set; }

        public void ValidateArrivalTime()
        {
            if (ArrivalTime == null )
            {
                throw new InvalidOperationException("Arrival time must be provided");
            }

            var arrivalTimeThreshold = DateTime.Now.AddHours(-24);
            if (ArrivalTime < arrivalTimeThreshold)
            {
                throw new InvalidOperationException("Arrival time is too far in the past");
            }
        }

        public void ValidateQrCode()
        {
            if (QrCode == null)
            {
                throw new ArgumentException("QrCode can't be null");
            }

            if (QrCode > 99999999 || QrCode < 10000000)
            {
                throw new ArgumentException("QrCode must have exactly 8 digits");
            }
        }

        public void Validate()
        {
            ValidateArrivalTime();
            ValidateQrCode();
        }

        public override string ToString()
        {
            return $"Id: {Id}, ArrivalTime: {ArrivalTime}, QrCode: {QrCode}, Name: {Name}";
        }
    }
}