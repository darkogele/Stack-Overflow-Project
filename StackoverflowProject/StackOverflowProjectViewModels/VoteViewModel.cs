using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowProjectViewModels
{
    public class VoteViewModel
    {
        [Required]
        public int VoteID { get; set; }
        public int UserID { get; set; }
        public int AnswerID { get; set; }
        public int VoteValue { get; set; }
    }
}