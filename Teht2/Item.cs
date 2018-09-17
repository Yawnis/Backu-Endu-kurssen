using System;
using System.ComponentModel.DataAnnotations;

namespace Teht2
{
    
    public class Item
    {
        public Guid Id { get; set; }

        public string Name {get; set;}

        [Range(1, 99)]
        public int Level {get; set;}

        [ItemTypeLegless]
        public string Type {get; set;}

        [DateTypeLegless]
        public DateTime CreationTime {get; set;}
    }

}