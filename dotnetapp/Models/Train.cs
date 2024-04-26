//Train.cs:
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models;
{
    public class Train
    {
        public int TrainID { get; set; }
        [Required]
        public string DepartureLocation { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public DateTime DepartureTime { get; set; }
    
        [System.ComponentModel.DataAnnotations.Range(1, 4, ErrorMessage = "Maximum capacity must be a positive integer.")]
        public int MaximumCapacity { get; set; }
        public List<Passenger> Passengers { get; set; }
    }
}
