using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MiniTwitter.Models
{
    public class HashTagViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static Expression<Func<HashTag, HashTagViewModel>> FromHashTag
        {
            get 
            {
                return h => new HashTagViewModel()
                {
                    Id = h.Id,
                    Name = h.Name
                };
            }
        }
    }
}