using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCB.NET.Domain.Model.Warehouse
{
    [Table("Board", Schema = "store")]
    public class Board
    {
        //public Board()
        //{
        //    Counts = new HashSet<Count>();
        //}
        public Board()
        {
            Hanging = new HashSet<Hanging>();
            SMD = new HashSet<SMD>();
        }


        [Key]
        public int BoardId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int CountBoard { get; set; }
        public string Description { get; set; }
        public DateTime? LastUpdate { get; set; }

        [Required]
        public virtual MapHanging MapHanging { get; set; }
        [Required]
        public virtual MapSMD MapSMD { get; set; }
        public virtual ICollection<Hanging> Hanging { get; set; }
        public virtual ICollection<SMD> SMD { get; set; }

        //public virtual MapBoardMap MapBoardMap { get; set; }
        //public virtual ICollection<Count> Counts { get; set; }

    }
}
