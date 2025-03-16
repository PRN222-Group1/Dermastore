using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Domain.Entities
{
    public class QuizResult
    {
        public int Id { get; set; }
        [Required]
        public string SkinType {  get; set; }
        public string Description {  get; set; }
        public string Characteristic { get; set; }
        public string CareTips {  get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
