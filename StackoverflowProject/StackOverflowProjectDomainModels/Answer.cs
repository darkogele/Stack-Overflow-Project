﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverFlowProjectDomainModels
{
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerID { get; set; }
        public string Answertext { get; set; }
        public DateTime AnswerDateAndTime { get; set; }
        public int UserID { get; set; }
        public int QuestionID { get; set; }
        public int VotesCount { get; set; }


        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        public virtual List<Vote> Vote { get; set; }

        [ForeignKey("QuestionID")]
        public virtual Question Question{ get; set; }
    }
}