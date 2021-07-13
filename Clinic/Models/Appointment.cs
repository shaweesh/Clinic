using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class Appointment
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required]
        [Display(Name = "Doctor")]
        public long DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
        [Required]
        [Display(Name = "Patient")]
        public long PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Reservation { get; set; }
        [Display(Name = "Appointment Type")]
        public long AppointmentId { get; set; }
        [ForeignKey("AppointmentId")]
        public AppointmentType AppointmentType { get; set; }
    }
}
