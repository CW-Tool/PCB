//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace PCB.NET.Domain.Model.Warehouse
//{
//    [Table("Assembly", Schema = "store")]
//    public class AssemblyBoard
//    {
//        public AssemblyBoard()
//        {
//            Hanging = new HashSet<Hanging>();
//            SMD = new HashSet<SMD>();
//        }

//        [Key]
//        public int AssemblyId { get; set; }
//        [Required]
//        public Board Board { get; set; }

//        public virtual ICollection<Hanging> Hanging { get; set; }
//        public virtual ICollection<SMD> SMD { get; set; }

//    }
//}
